using Fitness_EF.Interface;
using Main_Common.Model.Result;


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
        #endregion

        #region == 取資料相關 ==
        #endregion

        #region == 存資料相關 ==
        public ResultSimpleData<List<string?>> InsertMember()
        {
            ResultSimpleData<List<string?>> result = new ResultSimpleData<List<string?>>();

            return result;
        }

        #endregion
    }
}
