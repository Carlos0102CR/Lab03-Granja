using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }

        public Categoria()
        {

        }

        public Categoria(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 2){
                Nombre = infoArray[0];
                Unidad = infoArray[1];
            }
            else
            {
                throw new Exception("All values are require[id,nombre,unidad]");
            }

        }

    }
}
