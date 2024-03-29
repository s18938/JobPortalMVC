﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly salesjobportalContext _context;

        public CandidatesController(salesjobportalContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var salesjobportalContext = _context.Candidates.Include(c => c.CityCity);
            return View(await salesjobportalContext.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.CityCity)
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,FirstName,LastName,Email,CityCityId,TelNum")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", candidate.CityCityId);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", candidate.CityCityId);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateId,FirstName,LastName,Email,CityCityId,TelNum")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.CandidateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = candidate.CandidateId.ToString() });
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", candidate.CityCityId);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.CityCity)
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.CandidateId == id);
        }

        // GET: Candidates/GetJobOffers/5
        public async Task<IActionResult> GetJobOffers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesjobportalContext = _context.Candidates.
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.CityCity).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.ClientDatabaseClientDatabase).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.ClientTypeClientType).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.EmployerEmployer).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.IndustryIndustry).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.PositionPosition).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.SalesCycleLengthSalesCycleLength).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobOfferJobOffer).ThenInclude(j => j.Jobtypejoboffers).ThenInclude(j => j.JobTypeJobType).
                Include(c => c.Joboffercandidates).ThenInclude(j => j.JobApliacationStateJobApliacationState)
                .FirstOrDefaultAsync(m => m.CandidateId == id);

            return View(await salesjobportalContext);
        }

        // GET: Candidates/GetExperiences/5
        public async Task<IActionResult> GetExperiences(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Candidates
                .Include(e => e.Experiences).ThenInclude(e => e.ClientDatabaseClientDatabase)
                .Include(e => e.Experiences).ThenInclude(e => e.ClientTypeClientType)
                .Include(e => e.Experiences).ThenInclude(e => e.IndustryIndustry)
                .Include(e => e.Experiences).ThenInclude(e => e.PositionPosition)
                .Include(e => e.Experiences).ThenInclude(e => e.SalesCycleLengthSalesCycleLength)
                .FirstOrDefaultAsync(m => m.CandidateId == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }
    }
}

