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
    public class AuthorsController : Controller
    {
        
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Authors

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Authors.ToListAsync());
        //}


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index(string searchString)
        {
            //var authors = from a in _context.Authors
            //              select a;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    authors = authors.Where(s => (s.AuthorFirstname + " " + s.AuthorLastname)!.Contains(searchString));
            //}


            //return View(await authors.ToListAsync());

            var authors = _authorService.GetAllQueryable();

            if (searchString is not null)
            {
                authors = _authorService.GetByCondition(s => (s.AuthorFirstname + " " + s.AuthorLastname)!.Contains(searchString));
            }
            return View(await authors.ToListAsync());

        }

        // GET: Authors/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var author = await _authorService.GetAllQueryable()
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }



        // GET: Authors/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorFirstname,AuthorLastname")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                await _authorService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetAllQueryable().FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorFirstname,AuthorLastname")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _authorService.UpdateAuthor(author);
                await _authorService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorService.GetAllQueryable().FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetAllQueryable().FirstOrDefaultAsync(m => m.AuthorId == id);
            _authorService.DeleteAuthor(author);
            await _authorService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _authorService.GetAllQueryable().Any(m => m.AuthorId == id);
        }
    
    }
}
