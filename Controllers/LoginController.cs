using ControleDeEstoque.Models;
using ControleDeEstoque.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _loginRepository;
        public LoginController(ILogin login)
        {
            _loginRepository = login;
        }
        public IActionResult Index()
        {
           if(HttpContext.Session.GetString("Teste") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Teste");
            }
            return View();
        }


        [HttpPost]
        public IActionResult LoginMethod(UserModel usermodel)
        {
            var result = _loginRepository.verifyLogin(usermodel);
            if(result == null)
            {
                TempData["messageError"] = "Erro";
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetString("Teste", "teste");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove("Teste");
            return RedirectToAction("Index");
        }
    }
}
