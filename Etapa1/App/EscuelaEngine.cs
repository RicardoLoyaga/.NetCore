using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;

namespace CoreEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Bryan School", 2020, TiposEscuela.Primaria,
                                ciudad: "Quito", pais: "Ecuador");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        public void imprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic
                                        ,bool impVal = false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());
                //Console.WriteLine(obj);

                foreach (var val in obj.Value)
                {
                    switch (obj.Key)
                    {
                        case LlaveDiccionario.Evaluacion:
                            if (impVal)
                            {
                                Console.WriteLine(val);
                            }
                        break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine("Escuela: " + val);
                        break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine("Alumno: " + val.Nombre);
                        break;
                        case LlaveDiccionario.Curso:
                            var curtmp = val as Curso;
                            if(curtmp!= null)
                            {
                                int count = curtmp.Alumnos.Count;
                                Console.WriteLine("Curso: " + val.Nombre + "Cantidad de Alumnos: " + count);
                            }
                        break;
                        default:
                            Console.WriteLine(val);
                        break;
                    }
                    
                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
  
            diccionario.Add(LlaveDiccionario.Escuela,new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            
            var listmp = new List<Evaluación>();
            var listmpAsig = new List<Asignatura>();
            var listmpAlum = new List<Alumno>();

            foreach (var cur in Escuela.Cursos)
            {
                listmpAsig.AddRange(cur.Asignaturas);
                listmpAlum.AddRange(cur.Alumnos);
                foreach (var alum in cur.Alumnos)
                {
                    listmp.AddRange(alum.Evaluaciones);
                }
            }

            diccionario.Add(LlaveDiccionario.Evaluacion, listmp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listmpAsig.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listmpAlum.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
                listaObj.Add(Escuela);
                listaObj.AddRange(Escuela.Cursos);
                foreach (var curso in Escuela.Cursos)
                {
                    listaObj.AddRange(curso.Asignaturas);
                    listaObj.AddRange(curso.Alumnos);

                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                    }
                    
                }
            return listaObj;
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoAlumnos = 0;
            var listaObj = new List<ObjetoEscuelaBase>();
                listaObj.Add(Escuela);

                if (traeCursos)
                    listaObj.AddRange(Escuela.Cursos);
                conteoCursos = Escuela.Cursos.Count;

                foreach (var curso in Escuela.Cursos)
                {
                    conteoAsignaturas += curso.Asignaturas.Count;
                    conteoAlumnos += curso.Alumnos.Count;

                    if (traeAsignaturas)
                        listaObj.AddRange(curso.Asignaturas);
                    
                    if (traeAlumnos)
                        listaObj.AddRange(curso.Alumnos);

                    if (traeEvaluaciones)
                    {
                        foreach (var alumno in curso.Alumnos)
                        {
                            listaObj.AddRange(alumno.Evaluaciones);
                        }
                    }
                    
                    
                }
            return listaObj;
        }

        #region Metodos de carga
        private void CargarEvaluaciones()
        {
            var rnd =  new Random();
            
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#(i+1)",
                                Nota = MathF.Round(5 * (float)rnd.NextDouble(),2),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var Curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura   { Nombre = "Matemáticas" },
                    new Asignatura   { Nombre = "Educación Física" },
                    new Asignatura   { Nombre = "Castellano" },
                    new Asignatura   { Nombre = "Ciencias" },
                    new Asignatura   { Nombre = "Inglés" },
                };
                Curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GeneralAlumnosAlAzar(int cantidad)
        {
            string[] primerNombre = { "Bryan", "Maurcio", "Juan", "Victor", "Fausto"};
            string[] apellidos = {"Armas", "Echeverria", "Jácome", "Vargas", "Suasnavas"};
            string[] segundoNombre = {"Ricardo", "Santiago", "Fernando", "Roberto", "Paúl"};

            //aplicacion de linq
            var listaAlumnos = from n1 in primerNombre
                                from n2 in segundoNombre
                                from a1 in apellidos
                                select new Alumno{ Nombre=$"{n1} {n2} {a1}"};
            
            return listaAlumnos.OrderBy((al) => al.UniqueId) .Take(cantidad).ToList();
                                
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso   { Nombre = "301", Jornada = TiposJornada.Mañana },
                new Curso   { Nombre = "401", Jornada = TiposJornada.Tarde },
                new Curso   { Nombre = "501", Jornada = TiposJornada.Tarde }
            };

            Random rnd = new Random();
            
            foreach (var Curso in Escuela.Cursos)
            {
                //genera un numero random Next dice que sea entero que vaya minimo 5 y maximo 20
                int cantRandom = rnd.Next(5,20);
                Curso.Alumnos = GeneralAlumnosAlAzar(cantRandom);
            }
        }
        #endregion
        
    }
}