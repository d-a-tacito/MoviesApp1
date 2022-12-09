
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MoviesContext _context;
        private readonly ILogger<HomeController> _logger;

        public ActorsController(MoviesContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET Actors
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Actors.Select(a => new ActorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate
            }).ToList());
        }

        // Get Actors/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _context.Actors.Where(a => a.Id == id).Select(a => new ActorViewModel
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate
            }).FirstOrDefault();
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        //Get Actors/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post Actors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,BirthDate")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Actor
                {
                    FirstName = inputModel.FirstName,
                    LastName = inputModel.LastName,
                    BirthDate = inputModel.BirthDate
                });
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }

        [HttpGet]
        // Get: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _context.Actors.Where(a => a.Id == id).Select(a => new EditActorViewModel()
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthDate
                }).FirstOrDefault();
            if (editModel == null)
            {
                return NotFound();
            }

            return View(editModel);
        }

        // Post Actors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,LastName,Birthdate")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var actor = new Actor
                    {
                        Id = id,
                        FirstName = editModel.FirstName,
                        LastName = editModel.LastName,
                        BirthDate = editModel.BirthDate
                    };
                    _context.Update(actor);
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (!ActorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(editModel);
        }

        [HttpGet]

        // Get Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteActor = _context.Actors.Where(a => a.Id == id).Select(a => new DeleteActorViewModel
            {
                FirstName = a.FirstName,
                LastName = a.LastName,
                BirthDate = a.BirthDate
            }).FirstOrDefault();
            if (deleteActor == null)
            {
                return NotFound();
            }

            return View(deleteActor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _context.Actors.Find(id);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            _logger.LogError($"Actor with id {actor.Id} has been deleted!");
            return RedirectToAction(nameof(Index));
        }
        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}