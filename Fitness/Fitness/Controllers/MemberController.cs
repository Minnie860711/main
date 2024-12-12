using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Fitness_Service.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Entity.Member;

namespace Fitness.Controllers
{
    public class MemberController : Controller
    {
        #region == DI注入宣告 ==
        /// <summary>
        /// 【Aplus Service】拋轉Aplus ERP製造資訊相關
        /// </summary>
        public readonly MemberService _MemberService;

        #endregion
        #region == 全域宣告 ==
        private readonly ILogger<MemberController> _logger;

        #endregion
        #region == 建構 ==
        public MemberController(ILogger<MemberController> logger,
            MemberService MemberService)
        {
            _logger = logger;
            this._MemberService = MemberService;

        }
        #endregion

        public IActionResult Index(Member_DTO ao_memberDTO)
        {
            return View(ao_memberDTO);
        }

        [HttpGet]
        public IActionResult Edit(long ai_memberID)
        {
            Member_Filter lo_memberFilter = new Member_Filter()
            {
                memberID = ai_memberID
            };
            Member_DTO lo_result = this._MemberService.GetMember(lo_memberFilter);

            return View(lo_result);
        }

        [HttpPost]
        public IActionResult Edit(Member_DTO ao_memberDTO)
        {
            var lo_result = this._MemberService.InsertMember(ao_memberDTO);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Login(Member_Filter ao_memberFilter)
        {
            Member_DTO lo_result = this._MemberService.GetMember(ao_memberFilter);

            if (lo_result == null)
            {
                return View("Index");
            }
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
            return RedirectToAction("Index", "Member", lo_result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
