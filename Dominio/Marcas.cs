using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marcas
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Marcas() { }//otro constructor

        public Marcas(string descripcion)//constructor 1
        {
            Descripcion = descripcion;
        }
        public Marcas(int id, string descripcion)//constructor 2
        {
            Id = id;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
