using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class ProduccionCrudFactory : CrudFactory
    {
        ProduccionMapper mapper;

        public ProduccionCrudFactory() : base()
        {
            mapper = new ProduccionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var produccion=(Produccion) entity;
            var sqlOperation = mapper.GetCreateStatement(produccion);
            dao.ExecuteProcedure(sqlOperation);
        }

      

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveByDate<T>(BaseEntity entity)
        {
            var lstProducciones = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveDateStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProducciones;
        }

        public override List<T> RetrieveByDateAndCategory<T>(BaseEntity entity)
        {
            var lstProducciones = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveDateCategoryStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProducciones;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstProducciones = new List<T>();
            
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducciones.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
           
            return lstProducciones;
        }

        public override void Update(BaseEntity entity)
        {
            var produccion = (Produccion)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(produccion));
        }

        public override void Delete(BaseEntity entity)
        {
            var produccion = (Produccion)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(produccion));
        }
    }
}
