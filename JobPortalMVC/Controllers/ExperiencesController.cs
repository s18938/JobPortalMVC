using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalMVC.Models;

namespace JobPortalMVC.Controllers
{
    public class ExperiencesController : Controller
    {
        private readonly salesjobportalContext _context;

        public ExperiencesController(salesjobportalContext context)
        {
            _context = context;
        }

       
        // GET: Experiences/Create
        public IActionResult Create(int? id)
        {
            //ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email");
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName");
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName");
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName");
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName");
            
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienceId,CompanyName,StartDate,EndDate,ClientDatabaseClientDatabaseId,IndustryIndustryId,ClientTypeClientTypeId,PositionPositionId,SalesCycleLengthSalesCycleLengthId")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                experience.CandidateCandidateId = 2;
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetExperiences", "Candidates", new { id = experience.CandidateCandidateId });
            
            }
           
            //ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", experience.CandidateCandidateId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", experience.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", experience.ClientTypeClientTypeId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", experience.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", experience.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", experience.SalesCycleLengthSalesCycleLengthId);
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
           // ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", experience.CandidateCandidateId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", experience.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", experience.ClientTypeClientTypeId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", experience.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", experience.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", experience.SalesCycleLengthSalesCycleLengthId);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienceId,CompanyName,StartDate,EndDate,ClientDatabaseClientDatabaseId,IndustryIndustryId,ClientTypeClientTypeId,PositionPositionId,SalesCycleLengthSalesCycleLengthId")] Experience experience)
        {         
            if (id != experience.ExperienceId)
            {
                return NotFound();
            }
            experience.CandidateCandidateId = 2;
            if (ModelState.IsValid)
            {
                try
                {                    
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.ExperienceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("GetExperiences", "Candidates", new { id = experience.CandidateCandidateId });                
            }
           // ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", experience.CandidateCandidateId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", experience.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", experience.ClientTypeClientTypeId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", experience.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", experience.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", experience.SalesCycleLengthSalesCycleLengthId);
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var experience = await _context.Experiences
                .Include(e => e.CandidateCandidate)
                .Include(e => e.ClientDatabaseClientDatabase)
                .Include(e => e.ClientTypeClientType)
                .Include(e => e.IndustryIndustry)
                .Include(e => e.PositionPosition)
                .Include(e => e.SalesCycleLengthSalesCycleLength)
                .FirstOrDefaultAsync(m => m.ExperienceId == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetExperiences", "Candidates", new { id = experience.CandidateCandidateId });
           
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.ExperienceId == id);
        }
    }
}
