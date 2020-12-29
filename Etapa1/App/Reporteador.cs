using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEscu)
        {
            if (dicObsEscu == null)
            {
                throw new ArgumentNullException(nameof(dicObsEscu));
            }
            _diccionario = dicObsEscu;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            //_diccionario[LlaveDiccionario.Evaluacion]
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, 
                out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>(); 
            }
            {
                return new List<Evaluación>();
            }
            
        }

        public IEnumerable<string> GetListaAsignaturas(
            )
        {
            return GetListaAsignaturas(
                out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(
            out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluación>> GetDiccionarioEvaluacionesPorAsignatura()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluación>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                                where eval.Asignatura.Nombre == asig
                                select eval;
                dicRta.Add(asig, evalsAsig);
            }
            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnosPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalXAsig = GetDiccionarioEvaluacionesPorAsignatura();

            foreach (var asigConEval in dicEvalXAsig)
            {
                var promAlum = from eval in asigConEval.Value
                            group eval by new {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupoEvalasAlumno
                            select new AlumnoPromedio{
                                alumnoId = grupoEvalasAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalasAlumno.Key.Nombre,
                                promedio = grupoEvalasAlumno.Average(evaluacion => evaluacion.Nota)
                            };

                rta.Add(asigConEval.Key, promAlum);
            }

            return rta;
        }
    }
}