//creamos espacio de nombres
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        //lo encapsulamos en propiedades
        public string Nombre 
        { 
            //cuando alguien pregunte por el nombre (devuelvo la variable)
            get{return nombre;} 
            //cuando alguien quiera asignar valor, le asignamos
            set{nombre = value;}
        }

        public int AñoDeCreacion{get;set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
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

    }
}