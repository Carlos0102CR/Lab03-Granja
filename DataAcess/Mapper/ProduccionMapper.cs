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
            operation.AddIntParam(DB_COL_ID_ANIMAL,p.IdAnimal);
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

        public SqlOperation GetRetriveDateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCCION_DATE_PR" };

            var c = (Consulta)entity;
            operation.AddDateTimeParam("FECHA_INICIO", c.FechaInicio);
            operation.AddDateTimeParam("FECHA_FINAL", c.FechaFinal);

            return operation;
        }

        public SqlOperation GetRetriveDateCategoryStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCCION_DATE_CATEGORY_PR" };

            var c = (Consulta)entity;
            operation.AddDateTimeParam("FECHA_INICIO", c.FechaInicio);
            operation.AddDateTimeParam("FECHA_FINAL", c.FechaFinal);
            operation.AddIntParam("ID_CATEGORIA", c.IdCategoria);

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
            operation.AddIntParam(DB_COL_ID_ANIMAL, p.IdAnimal);
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
            var produccion = new Produccion
            {
                Id = GetIntValue(row, DB_COL_ID),
                IdAnimal = GetIntValue(row, DB_COL_ID_ANIMAL),
                Cantidad = GetIntValue(row, DB_COL_CANTIDAD),
                Valor = GetDoubleValue(row, DB_COL_VALOR),
                Fecha = GetDateValue(row, DB_COL_FECHA)
            };

            return produccion;
        }       

    }
}
