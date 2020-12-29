using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la Escuela");
            
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();

            Printer.WriteTitle("Captura de una Evaluación por Consola");
            var nEval = new Evaluación();
            string nombre, notaString;
            float nota;

            WriteLine("Ingrese el nombre de la evaluación");
            Printer.PresioneEnter();
            nombre = Console.ReadLine();

            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El valor del nombre no puede ser vacio");
            }
            else
            {
                nEval.Nombre = nombre.ToLower();
                WriteLine("El nombre de la evaluación ha sido ingresado correctamente");
            }

            WriteLine("Ingrese la nota de la evaluación");
            Printer.PresioneEnter();
            notaString = Console.ReadLine();

            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException("El valor de la nota no puede ser vacio");
            }
            else
            {
                try
                {
                    nEval.Nota = float.Parse(notaString);
                    if (nEval.Nota < 0 || nEval.Nota > 5)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe ser entre 0 y 5");
                    }
                    WriteLine("La nota de la evaluación ha sido ingresado correctamente");
                }
                catch(ArgumentOutOfRangeException arge)
                {
                    Printer.WriteTitle(arge.Message);
                }
                catch (Exception)
                {
                    WriteLine("La nota de la evaluación no es un número válido");
                }
                finally
                {
                    //finally siempre se va a ejecutar
                    Printer.WriteTitle("Se ejecuto el finally");
                }
            }
        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        ///comentarios de los metodos
        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");


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
