using ControleDeEstoque.Context;
using ControleDeEstoque.Models;
using ControleDeEstoque.Repository.Interfaces;

namespace ControleDeEstoque.Repository
{
    public class EstoqueRepository : IEstoque
    {
        private readonly DatabaseContext _databaseContext;
        public EstoqueRepository(DatabaseContext context)
        {
           _databaseContext = context;
        }
        public EstoqueModel Create(EstoqueModel model)
        {
            _databaseContext.Invetory.Add(model);
            _databaseContext.SaveChanges();
            return model;
        }

        public bool DeleteEstoque(int id)
        {
            try
            {
                EstoqueModel estoque = GetById(id);
                _databaseContext.Invetory.Remove(estoque);
                _databaseContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public EstoqueModel EditEstoque(EstoqueModel model)
        {
            EstoqueModel estoque = GetById(model.id);
            if (estoque == null) throw new Exception("Erro!");
            estoque.name = model.name;
            estoque.price = model.price;
            estoque.description = model.description;
            _databaseContext.Invetory.Update(estoque);
            _databaseContext.SaveChanges();
            return estoque;

        }

        public EstoqueModel GetById(int id)
        {
            return _databaseContext.Invetory.FirstOrDefault(x => x.id == id) ?? throw new Exception("Error");
        }

        public List<EstoqueModel> listAll()
        {
            return _databaseContext.Invetory.ToList(); 
        }

    }
}
