using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Produccion : BaseEntity
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public DateTime Fecha { get; set; }

        public Produccion()
        {
            
        }

        public Produccion(string[] infoArray)
        {
            if(infoArray!=null && infoArray.Length >= 4){
                IdAnimal = int.Parse(infoArray[0]);
                Cantidad = int.Parse(infoArray[1]);
                Valor = float.Parse(infoArray[2]);
                Fecha = DateTime.Parse(infoArray[3]);
            }
            else
            {
                throw new Exception("All values are require[id,animal,cantidad,valor]");
            }

        }

    }
}
