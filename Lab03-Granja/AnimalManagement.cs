using DataAcess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class AnimalManagemment
    {
        private AnimalCrudFactory crudAnimal;

        public AnimalManagemment()
        {
            crudAnimal = new AnimalCrudFactory();
        }

        public void Create(Animal animal)
        {

            crudAnimal.Create(animal);

        }


        public List<Animal> RetrieveAll()
        {
            return crudAnimal.RetrieveAll<Animal>();
        }

        public Animal RetrieveById(Animal animal)
        {
            return crudAnimal.Retrieve<Animal>(animal);
        }

        internal void Update(Animal animal)
        {
            crudAnimal.Update(animal);
        }

        internal void Delete(Animal animal)
        {
            crudAnimal.Delete(animal);
        }
    }
}
