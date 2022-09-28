using ControleDeEstoque.Models;
using ControleDeEstoque.Repository;
using ControleDeEstoque.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    //Para passar mais de uma model para uma view, é dever criar uma model para juntar todas as models necessárias
    public class InventoryController : Controller
    {
        private readonly IEstoque _estoqueRepository;
        public InventoryController(IEstoque estoque)
        {
            _estoqueRepository = estoque;
        }
        //Criamos uma instancia da viewmodel e colocamos o resultado da busca dentro do estoqueList 
        public IActionResult Index()
        {
            EstoqueViewModel estoqueViewModel = new EstoqueViewModel();
            List<EstoqueModel> estoqueList = _estoqueRepository.listAll();
            estoqueViewModel.estoqueList = estoqueList;
            return View(estoqueViewModel);
        }
        public IActionResult Edit(int id)
        {
            EstoqueModel estoque = _estoqueRepository.GetById(id);
            return View(estoque);
        }

        [HttpPost]
        public IActionResult CreateNewProduct(EstoqueModel estoque)
        {
            _estoqueRepository.Create(estoque);
            return RedirectToAction("Index", "Inventory");
        }

        [HttpPost]
        public IActionResult EditarEstoque(EstoqueModel estoque)
        {
            _estoqueRepository.EditEstoque(estoque);
            return RedirectToAction("Index");
        }

        public IActionResult ComeBack()
        {
            return RedirectToAction("Index");
        }

        public IActionResult RemoveEstoque(int id)
        {
            _estoqueRepository.DeleteEstoque(id);
            return RedirectToAction("Index");
        }
        
    }
}
