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
            return RedirectToAction("Index", "Home");
        }
    }
}
