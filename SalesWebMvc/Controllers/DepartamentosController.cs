using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> departamentos = new List<Departamento>();

            departamentos.Add(new Departamento() { Id = 1, Nome = "Eletronics" });
            departamentos.Add(new Departamento() { Id = 2, Nome = "Sports" });
            departamentos.Add(new Departamento() { Id = 3, Nome = "Clothes" });

            return View(departamentos);
        }
    }
}
