using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestUserBusiness.Handlers;
using TestUserCrud.Models;
using TestUserDataConnection.Models;
using TestUserDataConnection.Repositories;

namespace TestUserCrud.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserHandler _userHandler;
        private readonly IUserTypes _userTypesRepository;

        public UserController(IUserHandler userHandler, IUserTypes userTypesRepository)
        {
            _userHandler = userHandler;
            _userTypesRepository = userTypesRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<UserModel> users = _userHandler.GetAll().Select(user => new UserModel
            {
                UserName = user.Username,
                UserType = user.IdNavigation.Typename
            });

            return View(users);
        }

        public IActionResult Insert()
        {
            ViewBag.usertypes = _userTypesRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(UserModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User userBase = new User
                    {
                        Username = user.UserName,
                        Typeuser = user.IdUserType
                    };
                    _userHandler.InsertOne(userBase);

                    TempData[UserConst.Message] = UserConst.MessageInsert;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToPage("Error", null, e.Message);
                }
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            UserModel userBase = null;
            if ((id ?? 0) == 0)
            {
                User user = _userHandler.GetById(id);
                userBase = new UserModel
                {
                    UserName = user.Username,
                    UserType = user.IdNavigation.Typename,
                    IdUserType = user.IdNavigation.Id
                };
            }
            if (userBase == null)
                return RedirectToPage("Error");
            return View(userBase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserModel user)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    User userBase = new User
                    {
                        Username = user.UserName,
                        Typeuser = user.IdUserType
                    };
                    _userHandler.UpdateOne(userBase);

                    TempData[UserConst.Message] = UserConst.MessageUpdate;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToPage("Error", null, e.Message);
                }
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            UserModel userBase = null;
            if ((id ?? 0) == 0)
            {
                User user = _userHandler.GetById(id);
                userBase = new UserModel
                {
                    UserName = user.Username,
                    UserType = user.IdNavigation.Typename,
                    IdUserType = user.IdNavigation.Id
                };
            }
            if (userBase == null)
                return RedirectToPage("Error");
            return View(userBase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteUser(int? id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _userHandler.DeleteOne(id);

                    TempData[UserConst.Message] = UserConst.MessageUpdate;

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToPage("Error", null, e.Message);
                }
            }
            return View();
        }
    }
}
