#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicsApp.Models;
using ComicsApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ComicsApp.Controllers
{
    public class ComicsController : Controller
    {
      
        private readonly IComicService _comicService;
        public ComicsController(IComicService comicService)
        {
            _comicService = comicService;
        }

        // GET: Comics
        //public async Task<IActionResult> Index()
        //{
        //    var comicsContext = _context.Comics.Include(c => c.Author).Include(c => c.Publisher);
        //    return View(await comicsContext.ToListAsync());
        //}
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
           
            var authors = _comicService.GetAllQueryable().Include(c =>c.Author).Include(c => c.Publisher);

           
            return View(await authors.ToListAsync());

        }


        // GET: Comics/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _comicService.GetAllQueryable()
                  .FirstOrDefaultAsync(m => m.ComicId == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        // GET: Comics/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId");
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId");
            return View();
        }

        // POST: Comics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create([Bind("ComicId,ComicName,Genre,URL,Description,ComicCreated,AuthorID,PublisherID")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(comic);
                //await _context.SaveChangesAsync();
                // _comicService.AddComics(comic);
                _comicService.AddComic(comic);
               await _comicService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId", comic.AuthorID);
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId", comic.PublisherID);
            return View(comic);
        }

        // GET: Comics/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var comic = await _comicService.GetAllQueryable().FirstOrDefaultAsync(m => m.ComicId == id);
            if (comic == null)
            {
                return NotFound();
            }
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId", comic.AuthorID);
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId", comic.PublisherID);
            return View(comic);
        }

        // POST: Comics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Edit(int id, [Bind("ComicId,ComicName,Genre,URL,Description,ComicCreated,AuthorID,PublisherID")] Comic comic)
        {
            if (id != comic.ComicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _comicService.UpdateComic(comic);
              await  _comicService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
         
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId", comic.AuthorID);
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId", comic.PublisherID);
            return View(comic);
        }

        // GET: Comics/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _comicService.GetAllQueryable().FirstOrDefaultAsync(m => m.ComicId == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        // POST: Comics/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {


            var comic = await _comicService.GetAllQueryable().FirstOrDefaultAsync(m => m.ComicId == id);
            _comicService.DeleteComic(comic);
           await _comicService.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ComicExists(int id)
        {
            return _comicService.GetAllQueryable().Any(m => m.ComicId == id);
        }


        [HttpGet]
        public IActionResult SearchComics(string comicName, [Bind("ComicId,ComicName,Genre,URL,Description,ComicCreated,AuthorFirstName,PublisherID")] Comic comic)
        {
            var comics = _comicService.GetComicsByName(comicName).Include(c => c.Author).Include(c => c.Publisher); ;
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId");
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId");
            return View(comics);
        }


        [HttpGet]
        public IActionResult ComicsUser(int id, [Bind("ComicId,ComicName,Genre,URL,Description,ComicCreated,AuthorFirstName,PublisherID")] Comic comic)
        {
            var comics = _comicService.GetComicsById(id).Include(c => c.Author).Include(c => c.Publisher);
            ViewData["AuthorID"] = new SelectList(_comicService.GetAuthors(), "AuthorId", "AuthorId", "AuthorFirstname");
            ViewData["PublisherID"] = new SelectList(_comicService.GetPublishers(), "PublisherId", "PublisherId");
            return View(comics);
        }

    }
}
