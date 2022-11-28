using DesignPattern.CQRS.PresentationLayer.CQRS.Handlers;
using DesignPattern.CQRS.PresentationLayer.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductProducerQueryHandler _getProductProducerQueryHandler;
        private readonly GetProductPlannerQueryHandler _getProductPlannerQueryHandler;

        public ProductController(GetProductProducerQueryHandler getProductProducerQueryHandler, GetProductPlannerQueryHandler getProductPlannerQueryHandler)
        {
            _getProductProducerQueryHandler = getProductProducerQueryHandler;
            _getProductPlannerQueryHandler = getProductPlannerQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductProducerQueryHandler.Handle(new GetProductProducerQuery());
            return View(values); 
        }

        public IActionResult PlannerProductList()
        {
            var values = _getProductPlannerQueryHandler.Handle(new GetProductPlannerQuery());
            return View(values);
        }
    }
}
