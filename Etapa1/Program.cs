using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Bryan School", 2020,TiposEscuela.Primaria,
            ciudad:"Quito");
            escuela.Pais = "Ecuador";

            var arregloCursos = new Curso[3];

            arregloCursos[0] = new Curso()
                                {
                                    Nombre = "101"
                                };  

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            arregloCursos[1] = curso2;

            arregloCursos[2] = new Curso
                                {
                                    Nombre = "301"
                                };

            Console.WriteLine(escuela);
            System.Console.WriteLine("==============");
            /*Console.WriteLine(curso1.Nombre + " , "+curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}");
            Console.WriteLine(curso3);*/
            //imprimir array
            ImprimirCursosWhile(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosDoWhile(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosFor(arregloCursos);
            System.Console.WriteLine("==============");
            ImprimirCursosForEach(arregloCursos);
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
