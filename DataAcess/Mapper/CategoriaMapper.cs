using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CategoriaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID_CATEGORIA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_UNIDAD = "UNIDAD";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_CATEGORIA_PR"};

            var c = (Categoria) entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_UNIDAD, c.Unidad);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "RET_CATEGORIA_PR" };

            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORIA_PR" };            
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORIA_PR" };

            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_UNIDAD, c.Unidad);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORIA_PR" };

            var c = (Categoria)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var categoria = BuildObject(row);
                lstResults.Add(categoria);
            }

            return lstResults;            
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var categoria = new Categoria
            {
                Id = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Unidad = GetStringValue(row, DB_COL_NOMBRE)
            };

            return categoria;
        }       

    }
}
