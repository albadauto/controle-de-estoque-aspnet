using ControleDeEstoque.Models;

namespace ControleDeEstoque.Repository.Interfaces
{
    public interface ILogin
    {
        UserModel verifyLogin(UserModel user);
    }
}
