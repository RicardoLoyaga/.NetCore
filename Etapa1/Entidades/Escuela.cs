//creamos espacio de nombres
using System;
using System.Collections.Generic;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {
        public int AñoDeCreacion{get;set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public string Dirección { get; set; }

        public TiposEscuela TipoEscuela{get;set;}

        public List<Curso> Cursos { get; set; }

        //creamos los constructores
        /*public Escuela(string nombre, int año)
        {
            this.nombre = nombre;
            AñoDeCreacion = año;
        }*/

        //se llama igualacion por tuplas
        public Escuela(string nombre, int año) =>(Nombre, AñoDeCreacion) =
        (nombre,año);

        public Escuela(string nombre, int año, TiposEscuela tipos,
                        string pais="", string ciudad="")
        {
            //asignacion por tuplas
            (Nombre, AñoDeCreacion) = (nombre,año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela} \n Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Escuela...");
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.WriteTitle($"Escuela {Nombre} limpia");
        }
    }
}