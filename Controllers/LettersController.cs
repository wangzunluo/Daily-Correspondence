using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daily_Correspondence.Data;
using Daily_Correspondence.Models;

namespace Daily_Correspondence.Controllers
{
    public class LettersController : Controller
    {
        private readonly Daily_CorrespondenceContext _context;

        public LettersController(Daily_CorrespondenceContext context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Letter.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,Body,Subject")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                letter.PublishDate = DateTime.Now;
                _context.Add(letter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(letter);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,PublishDate,Body,Subject")] Letter letter)
        {
            if (id != letter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterExists(letter.Id))
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
            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letter = await _context.Letter.FindAsync(id);
            if (letter != null)
            {
                _context.Letter.Remove(letter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
            return _context.Letter.Any(e => e.Id == id);
        }
    }
}
