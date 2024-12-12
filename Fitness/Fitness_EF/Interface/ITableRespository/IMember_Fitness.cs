using Entity.Member;
using Fitness_EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_EF.Interface.ITableRespository
{
    public interface IMember_Fitness : IGenericRepository_Fitness<Member>
    {
        #region == 檢查相關 ==
        /// <summary>
        /// 檢查資料是否存在(ByNo)
        /// </summary>
        /// <param name="no">代號</param>        
        /// <returns>「true，有」「false，無」</returns>
        public bool CheckExist(string? as_account);
        #endregion

        #region == 取資料相關 ==
        /// <summary>
        /// 【Queryable】【ref】過濾出製令單表頭的Queryable
        /// </summary>
        /// <param name="dbData">ref 製令單表頭的Queryable</param>
        /// <param name="input">查詢條件</param>
        /// <returns></returns>
        public void WhereQueryable(ref IQueryable<Member> dbData, Member_Filter input);

        /// <summary>
        /// 【資料】取製令單表頭DTO
        /// </summary>
        /// <param name="input">查詢條件</param>
        /// <returns></returns>
        public Member_DTO GetDTO(Member_Filter input);

        #endregion

        #region == 更新資料相關 ==
        // ...
        #endregion

        #region == 其他 ==
        // ...
        #endregion

    }

}
