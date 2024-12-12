using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Fitness_Service.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Entity.Member;
using NPoco.fastJSON;
using Newtonsoft.Json;

namespace Fitness.Controllers
{
    public class HomeController : Controller
    {
        #region == DI注入宣告 ==
        /// <summary>
        /// 【Aplus Service】拋轉Aplus ERP製造資訊相關
        /// </summary>
        public readonly MemberService _MemberService;

        #endregion
        #region == 全域宣告 ==
        private readonly ILogger<HomeController> _logger;

        #endregion
        #region == 建構 ==
        public HomeController(ILogger<HomeController> logger,
            MemberService MemberService)
        {
            _logger = logger;
            this._MemberService = MemberService;

        }
        #endregion

        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 註冊登入頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult SingIn()
        {
            return View();
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="ao_memberDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(Member_DTO ao_memberDTO)
        {
            var lo_result = this._MemberService.InsertMember(ao_memberDTO);
            ViewBag.AlertMessage = lo_result.IsSuccess == true ? "註冊成功" : lo_result.Message;
            return View("SingIn");

        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="ao_memberFilter"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Login(Member_Filter ao_memberFilter)
        {
            //取得會員資料
            Member_DTO lo_result = this._MemberService.GetMember(ao_memberFilter);

            //查無資料 => 跳回首頁
            if (lo_result == null)
            {
                return View("Index");
            }
            //有資料=>登入成功
            else
            {
                #region == 生成登入驗證Cookie ==
                // 創建Claims聲明清單
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, lo_result.Name ?? "Null"), // 使用者名稱
                    };

                // 創建Identity身份 (聲明, 身份驗證方案)
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 創建容器，放入聲明身份
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                // 創建認證屬性
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // 表示身份驗證票據將在瀏覽器關閉後持續存在
                };

                // 寫入Cookie
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    claimPrincipal,
                    authProperties
                    );

                #endregion
            }

            //跳轉至會員資料
            return RedirectToAction("Index", "Member", lo_result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
