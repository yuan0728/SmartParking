using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XH.SmartParking.Base;
using XH.SmartParking.IService;

namespace XH.SmartParking.Service
{
    public class BaseService : IBaseService
    {

        protected readonly DbContext Context;
        public BaseService(DbContext context)
        {
            Context = context;
        }

        #region Query

        /// <summary>
        /// Context 就是数据库操作的EFcore的上下文Context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        /// <summary>
        ///  不应该暴露给上端使用者，尽量少用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        //[Obsolete("尽量避免使用，using 带表达式目录树的代替")]
        public IQueryable<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// 这才是合理的做法，上端给条件，这里查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return Context.Set<T>().Where(funcWhere);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize">每页条目数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public PageResult<T> QueryPage<T, S>(
            Expression<Func<T, bool>> funcWhere,
            int pageSize,
            int pageIndex,
            Expression<Func<T, S>> funcOrderby,
            bool isAsc = true) where T : class
        {

            var list = Set<T>();
            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = list.Count()
            };
            return result;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 即使保存  不需要再Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert<T>(T t) where T : class
        {
            Context.Set<T>().Add(t);
            Commit();//写在这里  就不需要单独commit  不写就需要
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            Context.Set<T>().AddRange(tList);
            Commit();//一个链接  多个sql
            return tList;
        }
        #endregion

        #region Update
        /// <summary>
        /// 是没有实现查询，直接更新的,需要Attach和State
        /// 
        /// 如果是已经在context，只能再封装一个(在具体的service)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t) where T : class
        {

            if (t == null) throw new Exception("t is null");

            Context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            Context.Entry(t).State = EntityState.Modified;
            Commit();//保存 然后重置为UnChanged
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {

            foreach (var t in tList)
            {
                Context.Set<T>().Attach(t);
                Context.Entry(t).State = EntityState.Modified;
            }
            Commit();
        }

        #endregion

        #region Delete
        /// <summary>
        /// 先附加 再删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(T t) where T : class
        {

            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Attach(t);
            Context.Set<T>().Remove(t);
            Commit();
        }

        /// <summary>
        /// 还可以增加非即时commit版本的，
        /// 做成protected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete<T>(int Id) where T : class
        {

            T t = Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Remove(t);
            Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {

            foreach (var t in tList)
            {
                Context.Set<T>().Attach(t);
            }
            Context.Set<T>().RemoveRange(tList);
            Commit();
        }
        #endregion

        #region Other

        /// <summary>
        /// 本省就是一个事务，前面可以多个操作，这里的SaveChange 就是把多个操作统一提交
        /// </summary>
        public void Commit()
        {
            Context.SaveChanges();
        }

        public IQueryable<T> ExcuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            return null;
        }

        public void Excute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            IDbContextTransaction trans = null;
            //DbContextTransaction trans = null;
            try
            {
                trans = Context.Database.BeginTransaction(); //这里是启动一个事务
                //this.Context.Database.ExecuteSqlRaw(sql, parameters);
                trans.Commit();
            }
            catch (Exception)
            {
                if (trans != null)
                    trans.Rollback();
                throw;
            }
        }

        public virtual void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
        #endregion
    }
}
