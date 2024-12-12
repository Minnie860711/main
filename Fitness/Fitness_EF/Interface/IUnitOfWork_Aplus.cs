using Fitness_EF.DbContextEF;
using Fitness_EF.Interface.ITableRespository;
using System;
using System.Data.Common;

namespace Fitness_EF.Interface
{
    /// <summary>
    /// 【Erp】【interface】資料庫工作單元
    /// </summary>
    public interface IUnitOfWork_Fitness : IDisposable
    {
        #region == Table Repository ==        
        IMember_Fitness _IMember_Fitness { get; }
        #endregion

        #region == 方法 ==
        /// <summary>
        /// 存儲 (實際執行DB寫入)
        /// </summary>
        /// <returns></returns>
        /// <remarks>返回值表示已影響的資料庫項目數量</remarks>
        int Save();

        /// <summary>
        /// 取DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext_Fitness Get_DbContext();

        /// <summary>
        /// 取DbConnection
        /// </summary>
        /// <returns></returns>
        public DbConnection Get_DbConnection();
        #endregion
    }
}
