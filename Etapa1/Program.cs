using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Bryan School", 2020,TiposEscuela.Primaria,
            ciudad:"Quito");
            escuela.Pais = "Ecuador";

            escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201", Jornada = TiposJornada.Mañana },
                new Curso   { Nombre = "301", Jornada = TiposJornada.Mañana }
            };

            escuela.Cursos.Add(new Curso(){Nombre="102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso(){Nombre="202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>(){
                new Curso() { Nombre = "401", Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "501", Jornada = TiposJornada.Mañana },
                new Curso   { Nombre = "502", Jornada = TiposJornada.Tarde }
            };
            /*
            escuela.Cursos.AddRange(otraColeccion);
            
            escuela.Cursos.RemoveAll(delegate(Curso cur){
                return cur.Nombre == "301";
            });
            escuela.Cursos.RemoveAll((cur)=>cur.Nombre == "501");
            */
            ImprimirCursosEscuela(escuela);

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        ///comentarios de los metodos
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("---------------------");
            WriteLine("Cursos de la Escuela");
            WriteLine("---------------------");


            //if (escuela == null && escuela.Cursos == null)
            if(escuela?.Cursos == null)
            {
                return;
            }
            else
            {
                foreach (var curso in escuela.Cursos)
                {
                    Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
            
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador ++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre {arregloCursos[contador].Nombre}, Id {arregloCursos[contador].UniqueId}");
                contador ++;
            }while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre {arregloCursos[i].Nombre}, Id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
            }
        }
    }
}
