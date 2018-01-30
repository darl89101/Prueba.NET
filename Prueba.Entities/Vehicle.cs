using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Entities
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Transmission { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }


        
        public string Editar { get { return "Editar"; } set { } }
        public string Eliminar { get { return "Eliminar"; } set { } }
        public Bitmap Image { get; set; }
    }
}
