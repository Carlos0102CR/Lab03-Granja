using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class CategoriaManagemment
    {
        private CategoriaCrudFactory crudCategoria;

        public CategoriaManagemment()
        {
            crudCategoria = new CategoriaCrudFactory();
        }

        public void Create(Categoria categoria)
        {

            crudCategoria.Create(categoria);

        }

        public List<Categoria> RetrieveAll()
        {
            return crudCategoria.RetrieveAll<Categoria>();
        }

        public Categoria RetrieveById(Categoria categoria)
        {
            return crudCategoria.Retrieve<Categoria>(categoria);
        }

        internal void Update(Categoria categoria)
        {
            crudCategoria.Update(categoria);
        }

        internal void Delete(Categoria categoria)
        {
            crudCategoria.Delete(categoria);
        }
    }
}
