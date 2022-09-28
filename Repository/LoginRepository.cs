using ControleDeEstoque.Context;
using ControleDeEstoque.Models;
using ControleDeEstoque.Repository.Interfaces;

namespace ControleDeEstoque.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly DatabaseContext _context;
        public LoginRepository(DatabaseContext context)
        {
            _context = context;
        }
        public UserModel verifyLogin(UserModel user)
        {
            var userLogin = _context.User.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            return userLogin;
        }
    }
}
