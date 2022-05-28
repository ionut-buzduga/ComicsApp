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
    public class PublishersController : Controller
    {
        
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            
            _publisherService = publisherService;
        }

        // GET: Publishers
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var publishers = _publisherService.GetAllQueryable();

            
            return View(await publishers.ToListAsync());
        }

        // GET: Publishers/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetAllQueryable()
                 .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,PublisherCountry")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _publisherService.AddPublisher(publisher);
               await  _publisherService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetAllQueryable().FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublisherId,PublisherName,PublisherCountry")] Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _publisherService.UpdatePublisher(publisher);
               await _publisherService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _publisherService.GetAllQueryable().FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {


            var publisher = await _publisherService.GetAllQueryable().FirstOrDefaultAsync(m => m.PublisherId == id);
            _publisherService.DeletePublisher(publisher);
            await _publisherService.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _publisherService.GetAllQueryable().Any(m => m.PublisherId == id);
        }
    }
}
