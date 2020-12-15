using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadRight(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            DibujarLinea(titulo.Length);
            WriteLine(titulo);
            DibujarLinea(titulo.Length);
        }
    }
}