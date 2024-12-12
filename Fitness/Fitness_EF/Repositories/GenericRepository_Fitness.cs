﻿using Fitness_EF.DbContextEF;
using Fitness_EF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fitness_EF.Repositories
{
    /// <summary>
    /// 【Erp】通用 Repository
    /// </summary>
    /// <typeparam name="TEntity">Table</typeparam>
    public abstract class GenericRepository_Fitness<TEntity> : IGenericRepository_Fitness<TEntity> where TEntity : class
    {
        #region == 【全域宣告】 ==
        /// <summary>
        /// Db Context
        /// </summary>
        protected readonly DbContext_Fitness _dbContext;
        #endregion

        #region == 建構 ==
        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="context">Db Context</param>
        protected GenericRepository_Fitness(DbContext_Fitness context)
        {
            _dbContext = context;
        }
        #endregion

        #region == 檢查相關 ==
        /// <summary>
        /// 檢查是否有任意資料達成條件
        /// </summary>
        /// <param name="predicate">處理式</param>
        /// <returns>「true，任意資料符合」</returns>
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).Any();
        }
        #endregion

        #region == 取資料相關 ==
        /// <summary>
        /// 依Table主key取Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetById(long id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// 取Table單筆Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// 取Table全部Data的Queryable
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// 取Table全部Data過濾後的Queryable
        /// </summary>
        /// <param name="predicate">處理式</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAlls(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }
        #endregion

        #region == 更新資料相關 ==
        /// <summary>
        /// 【單筆】添加Data至DbContext (尚未實際寫入DB)
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _dbContext.Set<TEntity>().Add(entity);
            }
        }

        /// <summary>
        /// 【多筆】添加Data至DbContext (尚未實際寫入DB)
        /// </summary>
        /// <param name="entitys"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Adds(List<TEntity> entitys)
        {
            if (entitys == null)
            {
                throw new ArgumentNullException("entitys");
            }
            else
            {
                _dbContext.Set<TEntity>().AddRange(entitys);
            }
        }

        /// <summary>
        /// 【單筆】修改DbContext的Data (尚未實際寫入DB)
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _dbContext.Set<TEntity>().Update(entity);
            }
        }

        /// <summary>
        /// 【多筆】修改DbContext的Data (尚未實際寫入DB)
        /// </summary>
        /// <param name="entitys"></param>
        public void Updates(List<TEntity> entitys)
        {
            if (entitys == null)
            {
                throw new ArgumentNullException("entitys");
            }
            else
            {
                _dbContext.Set<TEntity>().UpdateRange(entitys);
            }
        }

        /// <summary>
        /// 【單筆】移除DbContext的Data (尚未實際寫入DB)
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
        }

        /// <summary>
        /// 【多筆】移除DbContext的Data (尚未實際寫入DB)
        /// </summary>
        /// <param name="entitys"></param>
        public void Deletes(List<TEntity> entitys)
        {
            if (entitys == null)
            {
                throw new ArgumentNullException("entitys");
            }
            else
            {
                _dbContext.Set<TEntity>().RemoveRange(entitys);
            }
        }

        /// <summary>
        /// 【指令】移除DbContext的Data (尚未實際寫入DB)
        /// </summary>
        /// <param name="predicate">指令</param>
        public void Deletes(Expression<Func<TEntity, bool>> predicate)
        {
            var data = _dbContext.Set<TEntity>().Where(predicate);
            if (!data.Any())
            {
                throw new ArgumentNullException("predicate");
            }
            else
            {
                _dbContext.Set<TEntity>().RemoveRange(data);
            }
        }
        #endregion

        #region == 其他 ==
        // ...
        #endregion
    }
}