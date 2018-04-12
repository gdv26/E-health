using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ehealth.Models;
using System.Data.Entity;
using Ehealth.ViewModels;

namespace Ehealth.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new UserFormViewModel
            {
                User = new User(),
                MembershipTypes = membershipTypes
            };

            return View("UserForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UserFormViewModel
                {
                    User = user,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("UserForm", viewModel);
            }

            if(user.Id == 0)
                _context.Users.Add(user);

            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);

                userInDb.Name = user.Name;
                userInDb.BirthDate = user.BirthDate;
                userInDb.MembershipTypeId = user.MembershipTypeId;
                userInDb.IsSubscribedToNewsletter = user.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult Details(int id)
        {
            var user = _context.Users.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();

            var viewModel = new UserFormViewModel
            {
                User = user,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("UserForm", viewModel);
        }
    }
}