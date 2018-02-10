using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Consulta : BaseEntity
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdCategoria { get; set; }

        public Consulta()
        {
        }

        public Consulta(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                FechaInicio = DateTime.Parse(infoArray[0]);
                FechaFinal = DateTime.Parse(infoArray[1]);
            }
            else if (infoArray != null && infoArray.Length >= 3)
            {

                FechaInicio = DateTime.Parse(infoArray[0]);
                FechaFinal = DateTime.Parse(infoArray[1]);
                IdCategoria = int.Parse(infoArray[2]);
            }
            else
            {
                throw new Exception("All values are require[fecha inicio, fecha final y id de animal]");
            }
        }
    }
}
