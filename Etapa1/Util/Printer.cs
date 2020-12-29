using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DrawLine(int tam = 10)
        {
            WriteLine("".PadRight(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            DrawLine(titulo.Length);
            WriteLine(titulo);
            DrawLine(titulo.Length);
        }

        public static void PresioneEnter()
        {
            WriteLine("Presione ENTER para continuar");
        }
    }
}