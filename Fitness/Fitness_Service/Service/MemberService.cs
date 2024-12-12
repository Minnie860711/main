using Entity.Member;
using Fitness_EF.Interface;
using Fitness_EF.Repositories.Tablerepository;
using Fitness_EF.Tables;
using Main_Common.Model.Result;
using System;


namespace Fitness_Service.Service
{
    public class MemberService
    {
        #region == DI注入宣告 ==
        /// <summary>
        /// Aplus資料庫工作單元
        /// </summary>
        public readonly IUnitOfWork_Fitness _unitOfWork_Fitness;

        #endregion
        #region == 全域宣告 ==
        #endregion
        #region == 建構 ==
        public MemberService(IUnitOfWork_Fitness unitOfWork_Fitness)
        {
            this._unitOfWork_Fitness = unitOfWork_Fitness;
        }

        #endregion

        //--【方法】=================================================================================

        #region == 檢查相關 ==
        public bool CheckMember(int memberID)
        {
            bool lb_result = false;
            return lb_result;
        }
        #endregion

        #region == 取資料相關 ==
        public Member_DTO GetMember(Member_Filter ao_member)
        {
            Member_DTO lo_member = new Member_DTO();
            Member_Filter lo_MemberFilter = new Member_Filter()
            {
                Account = ao_member.Account,
                Password = ao_member.Password,
            };

            lo_member = _unitOfWork_Fitness._IMember_Fitness.GetDTO(lo_MemberFilter);
            return lo_member;
        }

        #endregion

        #region == 存資料相關 ==
        public ResultSimpleData<List<string?>> InsertMember(Member_DTO ao_member)
        {
            ResultSimpleData<List<string?>> result = new ResultSimpleData<List<string?>>();
            //檢查是否存在
            var lb_result = this._unitOfWork_Fitness._IMember_Fitness.CheckExist(ao_member.Account);
            // 是否存在。 [T：存在，修改][F：不存在，跑下一筆]
            if (!lb_result)
            {
                Member lo_member = new Member()
                {
                    Name = ao_member.Name,
                    Photo = ao_member.Photo,
                    Account = ao_member.Account,
                    Password = ao_member.Password,
                    Birthday = ao_member.Birthday,
                    Height = ao_member.Height,
                    Gender = ao_member.Gender,
                    Target_Date = ao_member.Target_Date,
                    Target_Weight = ao_member.Target_Weight,
                    Block = "N",
                    Createtime = DateTime.Now,
                };
                try
                {
                    this._unitOfWork_Fitness._IMember_Fitness.Add(lo_member);
                    this._unitOfWork_Fitness.Save();
                }
                catch (Exception ex)
                {
                    // 添加Log訊息
                    result.IsSuccess = false;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "該筆帳號已存在";
            }

            return result;
        }

        #endregion
    }
}
