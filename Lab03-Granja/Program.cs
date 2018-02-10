using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {


        static void Main(string[] args)
        {

            DoIt();

        }

        public static void DoIt()
        {
            try
            {
                var mng = new AnimalManagemment();
                var animal = new Animal();

                Console.WriteLine("***   Granja Cenfotec   ***");
                Console.WriteLine("1.Categorias de Animales");
                Console.WriteLine("2.Animales de la Granja");
                Console.WriteLine("3.Registros de Produccion.");
                Console.WriteLine("4.Registro de Errores");

                Console.WriteLine("Elija una opcion: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        menuCategoria();
                        break;

                    case "2":
                        menuAnimales();
                        break;
                    case "3":
                        menuProducciones();
                        break;
                    case "4":
                        imprimirErrores();
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("***************************");
            }
            finally
            {
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }


        }

        private static void imprimirErrores()
        {
            throw new NotImplementedException();
        }

        private static void menuProducciones()
        {
            var pmng = new ProduccionManagemment();
            var produccion = new Produccion();
            var consulta = new Consulta();

            Console.WriteLine("***    Registros de Produccion    ***");
            Console.WriteLine("1.Ingresar la produccion de un animal");
            Console.WriteLine("2.Listar registros de produccion");
            Console.WriteLine("3.Buscar un registro de produccion por fecha");
            Console.WriteLine("4.Buscar un registro de produccion por fecha y categoria");
            Console.WriteLine("4.Eliminar un registro de produccion");

            Console.WriteLine("Elija una opcion:");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****     Crear     *******");
                    Console.WriteLine("***************************");
                    imprimirAnimales();
                    Console.WriteLine("Escriba el id del animal, cantidad, valor en cenfodolares y fecha del registro(yyyy/MM/dd), separados por coma:");
                    var info = Console.ReadLine();
                    var infoArray = info.Split(',');

                    produccion = new Produccion(infoArray);
                    pmng.Create(produccion);

                    Console.WriteLine("El registro fue ingresado");

                    break;

                case "2":

                    imprimirProducciones();
                    break;
                case "3":
                    Console.WriteLine("***************************");
                    Console.WriteLine("***** Buscar por fecha ****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba la fecha de inicio(yyyy/MM/dd) y fecha final(yyyy/MM/dd) de los registros que desea buscar, separados por coma:");
                    info = Console.ReadLine();
                    infoArray = info.Split(',');
                    consulta = new Consulta(infoArray);
                    var lstProducciones = pmng.RetrieveByDate(consulta);
                    var count = 0;

                    foreach (var p in lstProducciones)
                    {
                        count++;
                        Console.WriteLine(count + " ==> " + p.GetEntityInformation());
                    }
                    break;
                case "4":
                    imprimirCategorias();
                    Console.WriteLine("***************************************");
                    Console.WriteLine("***** Buscar por fecha y categoria ****");
                    Console.WriteLine("***************************************");
                    Console.WriteLine("Escriba la fecha de inicio(yyyy/MM/dd), fecha final(yyyy/MM/dd) y el id de la categoria de animal, de los registros de produccion que desea buscar , separados por coma:");
                    info = Console.ReadLine();
                    infoArray = info.Split(',');
                    consulta = new Consulta(infoArray);
                    lstProducciones = pmng.RetrieveByDateAndCategory(consulta);
                    count = 0;

                    foreach (var p in lstProducciones)
                    {
                        count++;
                        Console.WriteLine(count + " ==> " + p.GetEntityInformation());
                    }
                    break;

                case "5":
                    imprimirProducciones();
                    Console.WriteLine("***************************");
                    Console.WriteLine("******    Eliminar    *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id del registro de produccion que desea eliminar:");
                    produccion.Id = int.Parse(Console.ReadLine());
                    produccion = pmng.RetrieveById(produccion);

                    if (produccion != null)
                    {
                        Console.WriteLine(" ==> " + produccion.GetEntityInformation());

                        Console.WriteLine("Delete? Y/N");
                        var delete = Console.ReadLine();

                        if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            pmng.Delete(produccion);
                            Console.WriteLine("El registro fue eliminado ");
                        }
                    }
                    else
                    {
                        throw new Exception("El registro de produccion no se ha sido encontrado");
                    }

                    break;

            }
        }

        private static void menuAnimales()
        {
            var amng = new AnimalManagemment();
            var animal = new Animal();
            var categoria = new Categoria();

            Console.WriteLine("***    Animales    ***");
            Console.WriteLine("1.Ingresar un Animal");
            Console.WriteLine("2.Listar Animales");
            Console.WriteLine("3.Buscar un Animal");
            Console.WriteLine("4.Actualizar un Animal");
            Console.WriteLine("4.Eliminar un Animal");

            Console.WriteLine("Elija una opcion:");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    imprimirCategorias();
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****     Crear     *******");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id de la categoria, nombre, edad, fecha de nacimiento(yyyy/MM/dd) y alimento favorito del animal, separados por coma:");
                    var info = Console.ReadLine();
                    var infoArray = info.Split(',');

                    animal = new Animal(infoArray);
                    amng.Create(animal);

                    Console.WriteLine("El animal fue registrado");

                    break;

                case "2":

                    imprimirAnimales();
                    break;
                case "3":
                    imprimirAnimales();
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****     Buscar      *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id del animal que desea buscar:");
                    animal.Id = int.Parse(Console.ReadLine());
                    animal = amng.RetrieveById(animal);

                    if (animal != null)
                    {
                        Console.WriteLine(" ==> " + animal.GetEntityInformation());
                    }

                    break;
                case "4":
                    imprimirAnimales();
                    Console.WriteLine("***************************");
                    Console.WriteLine("******    Modificar   *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id del animal que desea modificar:");
                    animal.Id = int.Parse(Console.ReadLine());
                    animal = amng.RetrieveById(animal);

                    if (animal != null)
                    {
                        Console.WriteLine(" ==> " + animal.GetEntityInformation());
                        Console.WriteLine("Escriba un nuevo nombre para el animal, el nombre actual es: " + animal.Nombre);
                        animal.Nombre = Console.ReadLine();
                        Console.WriteLine("Escriba una nueva edad para el animal, la edad actual es: " + animal.Edad);
                        animal.Edad = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escriba una nueva fecha de nacimiento para el animal(yyyy/MM/dd), la fecha actual  es: " + animal.FechaNacimiento);
                        animal.FechaNacimiento = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Escriba un nuevo alimento favorito para el animal, el alimento actual es: " + animal.AlimentoFavorito);
                        animal.AlimentoFavorito = Console.ReadLine();

                        amng.Update(animal);
                        Console.WriteLine("El animal fue modificado");
                    }
                    else
                    {
                        throw new Exception("El animal no esta registrado");
                    }

                    break;

                case "5":
                    imprimirAnimales();
                    Console.WriteLine("***************************");
                    Console.WriteLine("******    Eliminar    *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id del animal que desea eliminar:");
                    animal.Id = int.Parse(Console.ReadLine());
                    animal = amng.RetrieveById(animal);

                    if (animal != null)
                    {
                        Console.WriteLine(" ==> " + animal.GetEntityInformation());

                        Console.WriteLine("Delete? Y/N");
                        var delete = Console.ReadLine();

                        if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            amng.Delete(animal);
                            Console.WriteLine("El animal fue eliminado ");
                        }
                    }
                    else
                    {
                        throw new Exception("El animal no se encuentra registrado");
                    }

                    break;

            }
        }

        private static void menuCategoria()
        {

            var cmng = new CategoriaManagemment();
            var categoria = new Categoria();

            Console.WriteLine("***    Categorias    ***");
            Console.WriteLine("1.Crear una Categoria");
            Console.WriteLine("2.Listar Categorias");
            Console.WriteLine("3.Buscar Categoria");
            Console.WriteLine("4.Actualizar Categorias");
            Console.WriteLine("4.Eliminar Categoria");

            Console.WriteLine("Elija una opcion: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****     Crear     *******");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el nombre y  tipo de unidad usado, separados por coma:");
                    var info = Console.ReadLine();
                    var infoArray = info.Split(',');

                    categoria = new Categoria(infoArray);
                    cmng.Create(categoria);

                    Console.WriteLine("La categoria fue creada");

                    break;

                case "2":

                    imprimirCategorias();
                    break;
                case "3":
                    imprimirCategorias();
                    Console.WriteLine("***************************");
                    Console.WriteLine("*****     Buscar      *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id de la categoria que desea buscar:");
                    categoria.Id = int.Parse(Console.ReadLine());
                    categoria = cmng.RetrieveById(categoria);

                    if (categoria != null)
                    {
                        Console.WriteLine(" ==> " + categoria.GetEntityInformation());
                    }

                    break;
                case "4":
                    imprimirCategorias();
                    Console.WriteLine("***************************");
                    Console.WriteLine("******    Modificar   *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id de la Categoria que desea modificar:");
                    categoria.Id = int.Parse(Console.ReadLine());
                    categoria = cmng.RetrieveById(categoria);

                    if (categoria != null)
                    {
                        Console.WriteLine(" ==> " + categoria.GetEntityInformation());
                        Console.WriteLine("Escriba un nuevo nombre para la categoria, el nombre actual es: " + categoria.Nombre);
                        categoria.Nombre = Console.ReadLine();
                        Console.WriteLine("Escriba un nuevo tipo de unidad para la categoria, el tipo de unidad actual es: " + categoria.Unidad);
                        categoria.Unidad = Console.ReadLine();

                        cmng.Update(categoria);
                        Console.WriteLine("La Categoria fue actualizada");
                    }
                    else
                    {
                        throw new Exception("La Categoria no esta Registrada");
                    }

                    break;

                case "5":
                    imprimirCategorias();
                    Console.WriteLine("***************************");
                    Console.WriteLine("******    Eliminar    *****");
                    Console.WriteLine("***************************");
                    Console.WriteLine("Escriba el id de la Categoria que desea eliminar:");
                    categoria.Id = int.Parse(Console.ReadLine());
                    categoria = cmng.RetrieveById(categoria);

                    if (categoria != null)
                    {
                        Console.WriteLine(" ==> " + categoria.GetEntityInformation());

                        Console.WriteLine("Delete? Y/N");
                        var delete = Console.ReadLine();

                        if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        {
                            cmng.Delete(categoria);
                            Console.WriteLine("La categoria fue eliminada");
                        }
                    }
                    else
                    {
                        throw new Exception("Categoria no registrada");
                    }

                    break;

            }
        }

        public static void imprimirCategorias()
        {
            var amng = new AnimalManagemment();
            Console.WriteLine("***************************");
            Console.WriteLine("*****    Categorias   *****");
            Console.WriteLine("***************************");

            var lstAnimales = amng.RetrieveAll();
            var count = 0;

            foreach (var a in lstAnimales)
            {
                count++;
                Console.WriteLine(count + " ==> " + a.GetEntityInformation());
            }

        }

        public static void imprimirAnimales()
        {
            var amng = new AnimalManagemment();
            Console.WriteLine("***************************");
            Console.WriteLine("*****    Animales     *****");
            Console.WriteLine("***************************");

            var lstAnimales = amng.RetrieveAll();
            var count = 0;

            foreach (var a in lstAnimales)
            {
                count++;
                Console.WriteLine(count + " ==> " + a.GetEntityInformation());
            }

        }

        private static void imprimirProducciones()
        {
            var pmng = new ProduccionManagemment();
            Console.WriteLine("***************************");
            Console.WriteLine("**Registros de Produccion**");
            Console.WriteLine("***************************");

            var lstProducciones = pmng.RetrieveAll();
            var count = 0;

            foreach (var p in lstProducciones)
            {
                count++;
                Console.WriteLine(count + " ==> " + p.GetEntityInformation());
            }
        }
    }
}
