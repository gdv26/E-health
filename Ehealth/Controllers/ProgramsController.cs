using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Ehealth.Models;
using Ehealth.ViewModels;

namespace Ehealth.Controllers
{
    public class ProgramsController : Controller
    {
        public ApplicationDbContext _context;

        public ProgramsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManagePrograms))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManagePrograms)]
        public ViewResult New()
        {
            var programTypes = _context.ProgramTypes.ToList();

            var viewModel = new ProgramFormViewModel
            {
                ProgramTypes = programTypes
            };

            return View("ProgramForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManagePrograms)]
        public ActionResult Edit(int id)
        {
            var program = _context.Programs.SingleOrDefault(c => c.Id == id);

            if (program == null)
                return HttpNotFound();

            var viewModel = new ProgramFormViewModel(program)
            {
                ProgramTypes = _context.ProgramTypes.ToList()
            };

            return View("ProgramForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var program = _context.Programs.Include(m => m.ProgramType).SingleOrDefault(m => m.Id == id);

            if (program == null)
                return HttpNotFound();

            return View(program);

        }
        // GET: Programs/Random
        public ActionResult Random()
        {
            var program = new Program() { Name = "ActivityProgram" };
            var users = new List<User>
            {
                new User {Name = "User 1" },
                new User {Name = "User 2" }
            };

            var viewModel = new RandomProgramViewModel()
            {
                Program = program,
                Users = users
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManagePrograms)]
        public ActionResult Save(Program program)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProgramFormViewModel(program)
                {
                    ProgramTypes = _context.ProgramTypes.ToList()
                };

                return View("ProgramForm", viewModel);
            }

            if (program.Id == 0)
            {
                program.DateAdded = DateTime.Now;
                _context.Programs.Add(program);
            }
            else
            {
                var programInDb = _context.Programs.Single(m => m.Id == program.Id);
                programInDb.Name = program.Name;
                programInDb.ProgramTypeId = program.ProgramTypeId;
                programInDb.NumberInStock = program.NumberInStock;
                programInDb.ReleaseDate = program.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Programs");
        }
    }
}