using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Animal : BaseEntity
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string AlimentoFavorito { get; set; }

        public Animal()
        {
            
        }

        public Animal(int id)
        {
            Id = id;
        }

        public Animal(string[] infoArray, Categoria categoria)
        {
            if(infoArray!=null && infoArray.Length >= 5){
                Id = int.Parse(infoArray[0]);
                Categoria = categoria;
                Nombre = infoArray[1];
                var edad = 0;
                if (Int32.TryParse(infoArray[2], out edad))
                {
                    Edad = edad;
                }
                else
                {
                    throw new Exception("Age must be a number");
                }
                FechaNacimiento = DateTime.Parse(infoArray[3]);
                AlimentoFavorito = infoArray[4];

            }
            else
            {
                throw new Exception("All values are require[id,id de categoria,nombre,edad,fecha de nacimiento,alimento favorito]");
            }

        }

    }
}
