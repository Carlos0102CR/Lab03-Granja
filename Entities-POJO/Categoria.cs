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

        public Categoria(int id)
        {
            Id = id;
        }

        public Categoria(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 3){
                Id = int.Parse(infoArray[0]);
                Nombre = infoArray[1];
                Unidad = infoArray[2];
            }
            else
            {
                throw new Exception("All values are require[id,nombre,unidad]");
            }

        }

    }
}
