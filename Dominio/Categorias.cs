using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    public Categorias () { }

    public Categorias(string descripcion)//constructor 1 para el datagrid
        {
            Descripcion = descripcion;
        }

    

    public Categorias(int id, string descripcion)// constructor 2 para comboBox
        {
            Descripcion = descripcion;
            Id = id;
        }

        public override string ToString() //para meter una cadena que representa mi clase (Objeto) en la Lista<Articulos>
        {
            return Descripcion;
        }
        
    }
}
