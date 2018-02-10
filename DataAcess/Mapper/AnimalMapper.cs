using DataAcess.Dao;
using DataAcess.Crud;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class AnimalMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID_ANIMAL";
        private const string DB_COL_ID_CATEGORIA = "ID_CATEGORIA_ANIMAL";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_EDAD= "EDAD";
        private const string DB_COL_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_COL_ALIMENTO_FAVORITO = "ALIMENTO_FAVORITO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_ANIMAL_PR"};

            var a = (Animal) entity;
            operation.AddIntParam(DB_COL_ID_CATEGORIA, a.IdCategoria);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddIntParam(DB_COL_EDAD, a.Edad);
            operation.AddDateTimeParam(DB_COL_FECHA_NACIMIENTO, a.FechaNacimiento);
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, a.AlimentoFavorito);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_ANIMAL_PR"};

            var a = (Animal)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
         
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ANIMAL_PR" };            
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_ANIMAL_PR" };

            var a = (Animal)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
            operation.AddIntParam(DB_COL_ID_CATEGORIA, a.IdCategoria);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddIntParam(DB_COL_EDAD, a.Edad);
            operation.AddDateTimeParam(DB_COL_FECHA_NACIMIENTO, a.FechaNacimiento);
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, a.AlimentoFavorito);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_ANIMAL_PR" };

            var a = (Animal)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var animal = BuildObject(row);
                lstResults.Add(animal);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var animal = new Animal
            {
                Id = GetIntValue(row, DB_COL_ID),
                IdCategoria = GetIntValue(row, DB_COL_ID_CATEGORIA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Edad = GetIntValue(row, DB_COL_EDAD),
                FechaNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                AlimentoFavorito = GetStringValue(row, DB_COL_ALIMENTO_FAVORITO)
            };

            return animal;
        }       

    }
}
