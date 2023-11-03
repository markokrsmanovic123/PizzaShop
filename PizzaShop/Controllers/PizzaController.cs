﻿using Microsoft.AspNetCore.Mvc;
using PizzaShop.Models;
using System.Runtime.CompilerServices;

namespace PizzaShop.Controllers
{
    public class PizzaController : Controller
    {
        private IPieRepository _repository;

        public PizzaController (IPieRepository repository)
        {
            _repository = repository;
        }
        public ViewResult List()
        {
            return View(_repository.AllPies);
        }

        public IActionResult Index()
        {
            ViewBag.Uslov = false;
            ViewBag.Message = "Ovo je server-side poruka.";
            ViewBag.Message2 = "Ovo je druga poruka";
            return View();
        }
    }
}