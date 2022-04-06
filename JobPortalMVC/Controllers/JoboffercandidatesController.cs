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
    public class JoboffercandidatesController : Controller
    {
        private readonly salesjobportalContext _context;

        public JoboffercandidatesController(salesjobportalContext context)
        {
            _context = context;
        }

        // GET: Joboffercandidates
        public async Task<IActionResult> Index()
        {
            var salesjobportalContext = _context.Joboffercandidates.Include(j => j.CandidateCandidate).Include(j => j.JobApliacationStateJobApliacationState).Include(j => j.JobOfferJobOffer);
            return View(await salesjobportalContext.ToListAsync());
        }

        // GET: Joboffercandidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffercandidate = await _context.Joboffercandidates
                .Include(j => j.CandidateCandidate)
                .Include(j => j.JobApliacationStateJobApliacationState)
                .Include(j => j.JobOfferJobOffer)
                .FirstOrDefaultAsync(m => m.JobOfferCandidateId == id);
            if (joboffercandidate == null)
            {
                return NotFound();
            }

            return View(joboffercandidate);
        }

        // GET: Joboffercandidates/Create/
        public IActionResult Create()
        {
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email");
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name");
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content");
            
            return View();
        }

        // POST: Joboffercandidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobOfferCandidateId,JobOfferJobOfferId,CandidateCandidateId,AddDate,JobApliacationStateJobApliacationStateId")] Joboffercandidate joboffercandidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joboffercandidate);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
               // return RedirectToAction("../Joboffers/Main");
                return RedirectToAction("Main", "Joboffers");
            }
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", joboffercandidate.CandidateCandidateId);
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name", joboffercandidate.JobApliacationStateJobApliacationStateId);
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content", joboffercandidate.JobOfferJobOfferId);
            return View(joboffercandidate);
        }

        

        // GET: Joboffercandidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffercandidate = await _context.Joboffercandidates.FindAsync(id);
            if (joboffercandidate == null)
            {
                return NotFound();
            }
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", joboffercandidate.CandidateCandidateId);
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name", joboffercandidate.JobApliacationStateJobApliacationStateId);
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content", joboffercandidate.JobOfferJobOfferId);
            return View(joboffercandidate);
        }

        // POST: Joboffercandidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobOfferCandidateId,JobOfferJobOfferId,CandidateCandidateId,AddDate,JobApliacationStateJobApliacationStateId")] Joboffercandidate joboffercandidate)
        {
            if (id != joboffercandidate.JobOfferCandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joboffercandidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoboffercandidateExists(joboffercandidate.JobOfferCandidateId))
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
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", joboffercandidate.CandidateCandidateId);
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name", joboffercandidate.JobApliacationStateJobApliacationStateId);
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content", joboffercandidate.JobOfferJobOfferId);
            return View(joboffercandidate);
        }


        // GET: Joboffercandidates/EditState/5
        public async Task<IActionResult> EditState(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffercandidate = await _context.Joboffercandidates.FindAsync(id);
            if (joboffercandidate == null)
            {
                return NotFound();
            }
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", joboffercandidate.CandidateCandidateId);
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name", joboffercandidate.JobApliacationStateJobApliacationStateId);
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content", joboffercandidate.JobOfferJobOfferId);
            return View(joboffercandidate);
        }

        // POST: Joboffercandidates/EditState/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditState(int id, [Bind("JobOfferCandidateId,JobOfferJobOfferId,CandidateCandidateId,AddDate,JobApliacationStateJobApliacationStateId")] Joboffercandidate joboffercandidate)
        {
            if (id != joboffercandidate.JobOfferCandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joboffercandidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JoboffercandidateExists(joboffercandidate.JobOfferCandidateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("MyCandidates", "JobOffers", new { id = joboffercandidate.JobOfferJobOfferId });
               // return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateCandidateId"] = new SelectList(_context.Candidates, "CandidateId", "Email", joboffercandidate.CandidateCandidateId);
            ViewData["JobApliacationStateJobApliacationStateId"] = new SelectList(_context.Jobapliacationstates, "JobApliacationStateId", "Name", joboffercandidate.JobApliacationStateJobApliacationStateId);
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "Content", joboffercandidate.JobOfferJobOfferId);
            return View(joboffercandidate);
        }

        // GET: Joboffercandidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffercandidate = await _context.Joboffercandidates
                .Include(j => j.CandidateCandidate)
                .Include(j => j.JobApliacationStateJobApliacationState)
                .Include(j => j.JobOfferJobOffer)
                .FirstOrDefaultAsync(m => m.JobOfferCandidateId == id);
            if (joboffercandidate == null)
            {
                return NotFound();
            }

            return View(joboffercandidate);
        }

        // POST: Joboffercandidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joboffercandidate = await _context.Joboffercandidates.FindAsync(id);
            _context.Joboffercandidates.Remove(joboffercandidate);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool JoboffercandidateExists(int id)
        {
            return _context.Joboffercandidates.Any(e => e.JobOfferCandidateId == id);
        }

        // POST: Joboffercandidates/AddAplication
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAplication([Bind("JobOfferId")] int jobofferId)
        {
            if (ModelState.IsValid)
            {
                Joboffercandidate joboffercandidate1 = new Joboffercandidate()
                {
                    AddDate = DateTime.Now,
                    JobOfferJobOfferId = jobofferId,
                    JobApliacationStateJobApliacationStateId = 1,
                    CandidateCandidateId = 1
                };
                _context.Add(joboffercandidate1);
                await _context.SaveChangesAsync();

                return RedirectToAction("Main", "Joboffers");
            }
            return RedirectToAction("Main", "Joboffers");
        }
    }
}
