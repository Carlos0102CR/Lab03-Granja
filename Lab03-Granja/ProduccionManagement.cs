using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class ProduccionManagemment
    {
        private ProduccionCrudFactory crudProduccion;

        public ProduccionManagemment()
        {
            crudProduccion = new ProduccionCrudFactory();
        }

        public void Create(Produccion produccion)
        {

            crudProduccion.Create(produccion);

        }

        public List<Produccion> RetrieveAll()
        {
            return crudProduccion.RetrieveAll<Produccion>();
        }

        public Produccion RetrieveById(Produccion produccion)
        {
            return crudProduccion.Retrieve<Produccion>(produccion);
        }

        public List<Produccion> RetrieveByDate(Consulta consulta)
        {
            return crudProduccion.RetrieveByDate<Produccion>(consulta);
        }

        public List<Produccion> RetrieveByDateAndCategory(Consulta consulta)
        {
            return crudProduccion.RetrieveByDateAndCategory<Produccion>(consulta);
        }

        internal void Update(Produccion produccion)
        {
            crudProduccion.Update(produccion);
        }

        internal void Delete(Produccion produccion)
        {
            crudProduccion.Delete(produccion);
        }
    }
}
