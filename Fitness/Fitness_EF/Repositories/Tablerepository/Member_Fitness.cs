using Entity.Member;
using Fitness_EF.DbContextEF;
using Fitness_EF.Interface.ITableRespository;
using Fitness_EF.Tables;
using System.Linq;

namespace Fitness_EF.Repositories.Tablerepository
{
    public class Member_Fitness : GenericRepository_Fitness<Member>, IMember_Fitness
    {
        public Member_Fitness(DbContext_Fitness dbContext) : base(dbContext)
        {

        }

        #region == 檢查相關 ==
        /// <summary>
        /// 檢查資料是否存在(ByNo)
        /// </summary>
        /// <param name="no">代號</param>        
        /// <returns>「true，有」「false，無」</returns>
        public bool CheckExist(string? as_account)
        {
            return this.Any(x => x.Account == as_account);
        }
        #endregion

        #region == 取資料相關 ==
        /// <summary>
        /// 【Queryable】【ref】過濾出製令單表頭的Queryable
        /// </summary>
        /// <param name="dbData">ref 製令單表頭的Queryable</param>
        /// <param name="input">查詢條件</param>
        /// <returns></returns>
        public void WhereQueryable(ref IQueryable<Member> dbData, Member_Filter input)
        {
            // 帳號
            if (!string.IsNullOrEmpty(input.Account))
            {
                dbData = dbData.Where(x => x.Account == input.Account);
            }

            // 帳號
            if (!string.IsNullOrEmpty(input.Password))
            {
                dbData = dbData.Where(x => x.Password == input.Password);
            }
        }

        /// <summary>
        /// 【資料】取製令單表頭DTO
        /// </summary>
        /// <param name="input">查詢條件</param>
        /// <returns></returns>
        public Member_DTO? GetDTO(Member_Filter input)
        {
            // 語法命令
            var dbData = this.GetAll();
            // 過濾命令(ref)
            this.WhereQueryable(ref dbData, input);
            // 取出資料
            var result = dbData.Select(x => new Member_DTO
            {
                Name = x.Name,
                Photo = x.Photo,
                Account = x.Account,
                Password = x.Password,
                Birthday = x.Birthday,
                Age = x.Age,
                Height = x.Height,
                Gender = x.Gender,
                Target_Weight = x.Target_Weight,
                Target_Date = x.Target_Date,
            }).FirstOrDefault();

            return result;
        }
        #endregion

        #region == 更新資料相關 ==
        // ...
        #endregion

        #region == 其他 ==
        // ...
        #endregion

    }
}
