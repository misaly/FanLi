using FanLi.IBLL;
using FanLi.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.BLL
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }
        public int Count(Expression<Func<T, bool>> whereLamdba) { return CurrentRepository.Count(whereLamdba); }
        public T Add(T entity) { return CurrentRepository.Add(entity); }

        public bool Update(T entity) { return CurrentRepository.Update(entity); }

        public bool Delete(T entity) { return CurrentRepository.Delete(entity); }

        public T Find(Expression<Func<T, bool>> whereLambda) { return CurrentRepository.Find(whereLambda); }
        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, string orderName, bool isAsc)
        {
            //return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, isAsc, order);
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, isAsc, orderName);
        }
        public IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLamdba, int pageIndex, int pageSize, out int totalRecord, string orderName, bool isAsc)
        {
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, whereLamdba, isAsc, orderName);
        }
        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, bool isAsc, string orderName)
        {
            return CurrentRepository.FindList(whereLamdba, isAsc, orderName);
        }

    }
}
