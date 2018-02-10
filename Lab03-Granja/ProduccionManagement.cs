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

        public List<Produccion> RetrieveByDate(DateTime inicio, DateTime final)
        {
            return crudProduccion.RetrieveByDate<Produccion>(inicio,final);
        }

        public List<Produccion> RetrieveByDateAndCategory(DateTime inicio, DateTime final, Produccion produccion)
        {
            return crudProduccion.RetrieveByDateAndCategory<Produccion>(inicio, final, produccion);
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
