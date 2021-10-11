using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data;
using Vehicles.API.Data.Entities;

namespace Vehicles.API.Controllers
{
    public class DocumentTypesController : Controller
    {
        private readonly DataContext _context;

        public DocumentTypesController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentTypes.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentTypes documentTypes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(documentTypes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbupdate)
                {
                    if (dbupdate.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbupdate.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(documentTypes);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentTypes documentTypes = await _context.DocumentTypes.FindAsync(id);
            if (documentTypes == null)
            {
                return NotFound();
            }
            return View(documentTypes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentTypes documentTypes)
        {
            if (id != documentTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentTypes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbupdate)
                {
                    if (dbupdate.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbupdate.InnerException.Message);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(documentTypes);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentTypes documentTypes = await _context.DocumentTypes
                    .FirstOrDefaultAsync(m => m.Id == id);
            if (documentTypes == null)
            {
                return NotFound();
            }

            _context.DocumentTypes.Remove(documentTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentTypesExists(int id)
        {
            return _context.DocumentTypes.Any(e => e.Id == id);
        }
    }
}

