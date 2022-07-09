using Login_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_2.Controllers
{
    public class SignUpController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SignUpController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<SignUpModel> signUpModels = dbContext.SignUpModel.ToList();
            return View(signUpModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SignUpModel model)
        {
            dbContext.SignUpModel.Add(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = dbContext.SignUpModel.SingleOrDefault(e => e.Id == id);
            if (data != null)
            {
                dbContext.SignUpModel.Remove(data);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(data);
            }
        }
        public IActionResult Edit(int id)
        {
            var data = dbContext.SignUpModel.SingleOrDefault(e => e.Id == id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(SignUpModel model)
        {
            dbContext.SignUpModel.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.SignUpModel.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Password", "Invalid Credentials");
                    return View("Login");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
