using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Dao;
using System;

namespace DataAcess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract void Create(BaseEntity entity);
        public abstract T Retrieve<T>(BaseEntity entity);
        public abstract List<T> RetrieveByDate<T>(DateTime inicio, DateTime final);
        public abstract List<T> RetrieveByDateAndCategory<T>(DateTime inicio, DateTime final, BaseEntity entity);
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseEntity entity);
        public abstract void Delete(BaseEntity entity);
        
    }
}
