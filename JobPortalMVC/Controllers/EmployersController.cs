﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalMVC.Models;
using System.IO;

namespace JobPortalMVC.Controllers
{
    public class EmployersController : Controller
    {
        private readonly salesjobportalContext _context;

        public EmployersController(salesjobportalContext context)
        {
            _context = context;
        }

        // GET: Employers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employers.ToListAsync());
        }

        // GET: Employers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers
                .FirstOrDefaultAsync(m => m.EmployerId == id);
            if (employer == null)
            {
                return NotFound();
            }

            return View(employer);
        }

        // GET: Employers/GetJobOffers/5
        public async Task<IActionResult> GetJobOffers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers
               .Include(j => j.Joboffers).ThenInclude(j => j.CityCity)
                .Include(j => j.Joboffers).ThenInclude(j => j.ClientDatabaseClientDatabase)
                .Include(j => j.Joboffers).ThenInclude(j => j.ClientTypeClientType)
                .Include(j => j.Joboffers).ThenInclude(j => j.EmployerEmployer)
                .Include(j => j.Joboffers).ThenInclude(j => j.IndustryIndustry)
                .Include(j => j.Joboffers).ThenInclude(j => j.PositionPosition)
                .Include(j => j.Joboffers).ThenInclude(j => j.SalesCycleLengthSalesCycleLength)
                .Include(j => j.Joboffers).ThenInclude(j => j.Jobtypejoboffers).ThenInclude(j=>j.JobTypeJobType)
                .FirstOrDefaultAsync(m => m.EmployerId == id);
            if (employer == null)
            {
                return NotFound();
            }

            return View(employer.Joboffers);
        }

     

        // GET: Employers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployerId,Name,Logo,Email,EmployeesNumber,Page")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employer);
        }

        // GET: Employers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }
            return View(employer);
        }

        // POST: Employers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployerId,Name,Logo,Email,EmployeesNumber,Page")] Employer employer)
        {
            if (id != employer.EmployerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                
                    _context.Update(employer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployerExists(employer.EmployerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Employers", new { id = employer.EmployerId });
               // return RedirectToAction(nameof(Index));
            }
            return View(employer);
        }

        // GET: Employers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employer = await _context.Employers
                .FirstOrDefaultAsync(m => m.EmployerId == id);
            if (employer == null)
            {
                return NotFound();
            }

            return View(employer);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployerExists(int id)
        {
            return _context.Employers.Any(e => e.EmployerId == id);
        }
    }
}
