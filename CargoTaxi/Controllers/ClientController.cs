using AutoMapper;
using Business.Interfaces;
using Business.Models;
using CargoTaxi.CustomValidation;
using CargoTaxi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CargoTaxi.Controllers
{
    [Authorize(Roles = "Client,Admin")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IClientHelperService _helperService;
        private readonly IMapper _mapper;
       // private readonly NewOrderValidation _validator;

        public ClientController(IMapper mapper, IClientService clientService, IClientHelperService helper)
        {
            _helperService = helper;
            _clientService = clientService;
            _mapper = mapper;
           // _validator = new NewOrderValidation();
        }

        private bool ValidateOrder(CreateOrderPostModel newOrder)
        {
            var validator = new NewOrderFAValidation();
            var result = validator.Validate(newOrder);
            if (result.IsValid)
            {
                return true;
            }

            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }
   
    // GET: Client
    public ActionResult Index()
        {            
            return View();
        }

       // [Authorize(Roles = "Client")]
        public ActionResult EditClientProfile(string id)
        {
            if(id==null)
            {
                id = User.Identity.GetUserId();
            }
             
            var model = new ClientViewModel();// { Id = id }
            model.Id = id;
            var clientBl = _helperService.GetClientById(id);
            model.FirstName = clientBl.FirstName;
            model.LastName = clientBl.LastName;
            model.PhoneNumber = clientBl.PhoneNumber;
            if(User.IsInRole("Admin"))
            {
                return RedirectToAction("AllClients", "Client");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClientProfile(EditClientPostModel editClientPostModel)
        {
            var clientBl = _mapper.Map<UserModel>(editClientPostModel);
            var id = clientBl.Id;
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditClientProfile");
            }
            _clientService.EditClientProfile(clientBl);
            return RedirectToAction("Index");//, new { Id = id });
        }

        public ActionResult CreateOrder()//string id
        {
           // var id = User.Identity.GetUserId();
           // var client = _helperService.GetClientById(id);

            SelectList carCategories = new SelectList(_helperService.GetAllCategory(), "Id", "Name");
            ViewBag.Categories = carCategories;
            return View();
        }

        public ActionResult CarCatrgoriesPartial()
        {
            var carCategoriwsBL = _helperService.GetAllCategory();                
            var carCategoriesViewModel = _mapper.Map<List<CarCategoryViewModel>>(carCategoriwsBL);
            var viewResult = new ListCarCategories() { CarCategories = carCategoriesViewModel };
            return PartialView("CarCategoriesPartial", viewResult);

        }
        [HttpPost]
        public ActionResult CreateOrder([Bind(Include = "Id,Number, Date, StartTime, StartAdress,FinishAdress, CarCategoryId")]
        CreateOrderPostModel createOrderPostModel)//, string id
        {
            var id = User.Identity.GetUserId();
            createOrderPostModel.ClientId = id;

            if (!ModelState.IsValid)
            {
                SelectList carCategories = new SelectList(_helperService.GetAllCategory(), "Id", "Name");
                ViewBag.Categories = carCategories;
                return View(createOrderPostModel);//orderViewModel
            }
            //if (!ValidateOrder(createOrderPostModel))
            //{
            //    SelectList carCategories = new SelectList(_helperService.GetAllCategory(), "Id", "Name");
            //    ViewBag.Categories = carCategories;
            //    return View(createOrderPostModel);
            //}
            var orderBl = _mapper.Map<OrderModel>(createOrderPostModel);

            string orderNumber = _clientService.CreateOrder(orderBl, id);
            createOrderPostModel.Number = orderNumber;
            return RedirectToAction("CheckOrderMessage", "Client", createOrderPostModel);
        }


        public ActionResult CheckOrderMessage(MessageViewModel mesViewModel)
        {
            var clientBl = _helperService.GetClientById(mesViewModel.ClientId);
            var client = _mapper.Map<UserViewModel>(clientBl);

            var category = _helperService.GetCarCategoryById(mesViewModel.CarCategoryId);
            var categoryViewModel = _mapper.Map<CarCategoryViewModel>(category);

            mesViewModel.Client = client;
            mesViewModel.Category = categoryViewModel;

            return View(mesViewModel);
        }

        public ActionResult AllClientOrders(string id)
        {
            //string clientId = User.Identity.GetUserId();

            var allClientOrdersBL = _clientService.GetAllClientOrders(id);
           
            string carName = default;
            
            var orders = allClientOrdersBL.Select(x => new ClientOrderViewModel(carName="не назначена")
            {
                Number = x.Number,
                Date = x.Date,
                StartTime = x.StartTime,
                FinishTime = x.FinishTime,
                StartAdress = x.StartAdress,
                FinishAdress = x.FinishAdress,
                Category = x.Category.Name.ToString(),
                Car=x.Car==null? carName:x.Car.RegistrNumber                
            });;
            
            var allClientOrders = new AllClientOrdersViewModel { Orders = orders };
            
            return View(allClientOrders);
        }

        public ActionResult AllClients()
        {
            var clientsModel = _clientService.GetAllClients();
            var clientsVM = _mapper.Map<List<UserViewModel>>(clientsModel);
            return View(clientsVM);
        }

        public ActionResult DeleteClient(string id)
        {
            _clientService.DeleteClient(id);
            return RedirectToAction("AllClients");
        }

    }
}

