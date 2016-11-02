using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FanLi.IBLL
{
    public interface IBaseService<T> where T:class
    {
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> whereLamdba);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

        /// <summary>
        /// 查询实体
        /// </summary> 
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="pageIndex">页码数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="order">排序</param>
        /// <param name="isAsc">true:升序，false:降序</param>
        /// <returns></returns>
        IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, string order, bool isAsc);
        IQueryable<T> FindPageList(Expression<Func<T, bool>> whereLamdba,int pageIndex, int pageSize, out int totalRecord, string order, bool isAsc);
        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, bool isAsc, string orderName);
    }
}
