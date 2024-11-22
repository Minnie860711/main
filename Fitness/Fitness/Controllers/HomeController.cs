using Fitness.Models;
using Fitness_EF.Interface;
using Fitness_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Fitness_Service.Service;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register()
        {
            var result = this._MemberService.InsertMember();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //4.3.6 加入Token驗證標籤
        public IActionResult Login()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
