﻿using EgitimTakip.Data;
using EgitimTakip.Models;
using EgitimTakip.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakip.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _repo;

        public EmployeeController( IRepository<Employee> repo)
        {
            
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAll(int companyId)
        {
            //var result = _context.Employees.Where(e => e.CompanyId == companyId && !e.IsDeleted).ToList();
            //return Json(new { data = result });


        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            //_context.Employees.Add(employee);
            //_context.SaveChanges();
            //return Ok(employee);
            return Ok(_repo.Add(employee));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            //return Ok(employee);
            return Ok(_repo.Update(employee));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //SOFT DELETE
            //Employee employee = _context.Employees.Find(id);
            //employee.IsDeleted = true;
            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            //return Ok(employee);
            return Ok(_repo.Delete(id) is object);
        }

        //[HttpPost]
        //public IActionResult HardDelete(int id)
        //{
        //    Employee employee = _context.Employees.Find(id);
        //    _context.Employees.Remove(employee);
        //    _context.SaveChanges();
        //    return Ok(employee);
        //}

    }
}
