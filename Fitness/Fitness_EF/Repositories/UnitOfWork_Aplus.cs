using Fitness_EF.DbContextEF;
using Fitness_EF.Interface;
using Fitness_EF.Interface.ITableRespository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Data.Common;

namespace Aplus_EF.Repositories
{
    /// <summary>
    /// 【Erp】資料庫工作單元
    /// </summary>
    public class UnitOfWork_Fitness : IUnitOfWork_Fitness
    {
        #region == 【全域宣告】 ==
        /// <summary>
        /// Db Context
        /// </summary>
        private readonly DbContext_Fitness _dbContext;

        /// <summary>
        /// ERP製造資訊 Repository
        /// </summary>
        public IMember_Fitness _IMember_Fitness { get; }        
        #endregion

        #region == 建構 ==
        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="dbContext">Db Context</param>
        /// <param name="edt01_0001_Aplus">ERP製造資訊 Repository</param>
        /// <param name="edt01_0002_Aplus">ERP批號庫存資訊 Repository</param>       
        public UnitOfWork_Fitness(DbContext_Fitness dbContext,
                            IMember_Fitness member_Fitness)
        {
            _dbContext = dbContext;
            _IMember_Fitness = member_Fitness;
        }
        #endregion

        #region == 處理 ==
        /// <summary>
        /// 存儲 (實際執行DB寫入)
        /// </summary>
        /// <returns></returns>
        /// <remarks>返回值表示已影響的資料庫項目數量</remarks>
        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 取DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext_Fitness Get_DbContext()
        {
            return _dbContext;
        }

        /// <summary>
        /// 取DbConnection
        /// </summary>
        /// <returns></returns>
        public DbConnection Get_DbConnection()
        {
            return _dbContext.Database.GetDbConnection();
        }
        #endregion

        #region == Dispose ==
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        #endregion
    }
}
