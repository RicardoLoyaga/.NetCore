using System;
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

            /*var arregloCursos = new Curso[3]{
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso   { Nombre = "301" }
            };*/

            escuela.Cursos = new Curso[] {
                new Curso() { Nombre = "101" },
                new Curso() { Nombre = "201" },
                new Curso   { Nombre = "301" }
            };

            ImprimirCursosEscuela(escuela);

            /*Console.WriteLine(escuela);
            System.Console.WriteLine("==============");
            /*Console.WriteLine(curso1.Nombre + " , "+curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}");
            Console.WriteLine(curso3);
            //imprimir array
            ImprimirCursosWhile(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosDoWhile(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosFor(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosForEach(arregloCursos);*/
        }

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
