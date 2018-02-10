using DataAcess.Dao;
using DataAcess.Crud;
using Entities_POJO;
using System.Collections.Generic;
using System;

namespace DataAcess.Mapper
{
    public class ProduccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID_PRODUCCION";
        private const string DB_COL_ID_ANIMAL = "ID_ANIMAL";
        private const string DB_COL_CANTIDAD = "CANTIDAD";
        private const string DB_COL_VALOR = "VALOR";
        private const string DB_COL_FECHA = "FECHA";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_PRODUCCION_PR"};

            var p = (Produccion) entity;
            operation.AddIntParam(DB_COL_ID_ANIMAL, (int)p.Animal.Id);
            operation.AddIntParam(DB_COL_CANTIDAD, p.Cantidad);
            operation.AddDoubleParam(DB_COL_VALOR, p.Valor);
            operation.AddDateTimeParam(DB_COL_FECHA, p.Fecha);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_PRODUCCION_PR" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID, p.Id);
         
            return operation;
        }

        public SqlOperation GetRetriveDateStatement(DateTime inicio, DateTime final)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCCION_DATE_PR" };
            
            operation.AddDateTimeParam("FECHA_INICIO", inicio);
            operation.AddDateTimeParam("FECHA_INICIO", final);

            return operation;
        }

        public SqlOperation GetRetriveDateCategoryStatement(DateTime inicio, DateTime final, BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCCION_DATE_CATEGORY_PR" };

            var p = (Produccion)entity;
            operation.AddDateTimeParam("FECHA_INICIO", inicio);
            operation.AddDateTimeParam("FECHA_INICIO", final);
            operation.AddIntParam("ID_CATEGORIA", p.Animal.Categoria.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCCION_PR" };            
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRODUCCION_PR" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID, p.Id);
            operation.AddIntParam(DB_COL_ID_ANIMAL, (int)p.Animal.Id);
            operation.AddIntParam(DB_COL_CANTIDAD, p.Cantidad);
            operation.AddDoubleParam(DB_COL_VALOR, p.Valor);
            operation.AddDateTimeParam(DB_COL_FECHA, p.Fecha);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PRODUCCION_PR" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID, p.Id);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var produccion = BuildObject(row);
                lstResults.Add(produccion);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var animalCrud = new ProduccionCrudFactory();
            var animal = new Animal(GetIntValue(row, DB_COL_ID_ANIMAL));
            animal = animalCrud.Retrieve<Animal>(animal);
            var produccion = new Produccion
            {
                Id = GetIntValue(row, DB_COL_ID),
                Animal = animal,
                Cantidad = GetIntValue(row, DB_COL_CANTIDAD),
                Valor = GetDoubleValue(row, DB_COL_VALOR),
                Fecha = GetDateValue(row, DB_COL_FECHA)
            };

            return animal;
        }       

    }
}
