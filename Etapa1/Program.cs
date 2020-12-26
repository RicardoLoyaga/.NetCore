using System;
using System.Collections.Generic;
using System.Linq;
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
            ImprimirCursosEscuela(engine.Escuela);
            var listaObjetos = engine.GetObjetosEscuela();

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"Juank");
            diccionario.Add(23,"Lorena Arevalo");

            foreach (var keyValPair in diccionario)
            {
                Console.WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }

            var dictmp = engine.GetDiccionarioObjetos();

            engine.imprimirDiccionario(dictmp);

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
