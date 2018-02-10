using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class CategoriaCrudFactory : CrudFactory
    {
        CategoriaMapper mapper;

        public CategoriaCrudFactory() : base()
        {
            mapper = new CategoriaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var categoria=(Categoria) entity;
            var sqlOperation = mapper.GetCreateStatement(categoria);
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

        public override List<T> RetrieveAll<T>()
        {
            var lstCategorias = new List<T>();
            
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCategorias.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
           
            return lstCategorias;
        }

        public override void Update(BaseEntity entity)
        {
            var categoria = (Categoria)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(categoria));
        }

        public override void Delete(BaseEntity entity)
        {
            var categoria = (Categoria)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(categoria));
        }

        public override List<T> RetrieveByDate<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveByDateAndCategory<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
