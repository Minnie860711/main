namespace Main_Common.Model.Result
{
    /// <summary>
    /// 簡易結果回傳 (含資料)
    /// </summary>
    /// <typeparam name="TData">回傳資料</typeparam>
    public class ResultSimpleData<TData>
    {
        #region == 主要屬性 ===============================================================================
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 標題
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// 回傳資料
        /// </summary>
        public TData Data { get; set; }
        #endregion

        #region == 建構 ===============================================================================
        /// <summary>
        /// 建構-初始值
        /// </summary>
        public ResultSimpleData()
        {
            this.IsSuccess = true;
        }

        /// <summary>
        /// 建構-初始值
        /// </summary>
        /// <param name="defaultSuccess">是否預設成功</param>
        /// <param name="data">回傳資料</param>
        public ResultSimpleData(bool defaultSuccess, TData data)
        {
            if (defaultSuccess)
            {
                this.IsSuccess = true;
                this.Title = "【成功】";
            }
            else
            {
                this.IsSuccess = false;
                this.Title = "【失敗】";
            }

            this.Data = data;
        }

        /// <summary>
        /// 建構-初始值
        /// </summary>
        /// <param name="defaultSuccess">是否預設成功</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料</param>
        public ResultSimpleData(bool defaultSuccess, string message, TData data)
        {
            if (defaultSuccess)
            {
                this.IsSuccess = true;
                this.Title = "【成功】";
            }
            else
            {
                this.IsSuccess = false;
                this.Title = "【失敗】";
            }

            this.Data = data;
            this.Message = message;
        }
        #endregion
    }
}
