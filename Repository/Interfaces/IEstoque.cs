using ControleDeEstoque.Models;

namespace ControleDeEstoque.Repository.Interfaces
{
    public interface IEstoque
    {
        EstoqueModel Create(EstoqueModel model);
        List<EstoqueModel> listAll();
        EstoqueModel GetById(int id);
        EstoqueModel EditEstoque(EstoqueModel model);
        bool DeleteEstoque(int id);
    }
}
