using System;

namespace escuela
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public int anioFundacion;
        public string ceo; // = "Bryan Armas";

        public void Timbrar(){
            //todo
            Console.Beep(10000,3000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Escuela miEscuela = new Escuela();
            miEscuela.nombre = "Bryan School";
            miEscuela.direccion = "Quito-Ecuador";
            miEscuela.anioFundacion = 2020;
            Console.WriteLine("Timbrando mi escuela");
            miEscuela.Timbrar();
            //Console.WriteLine("Hello World!");
        }
    }
}
