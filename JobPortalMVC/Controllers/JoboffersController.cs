using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobPortalMVC.Models;
using System.Collections;
using System.Dynamic;

namespace JobPortalMVC.Controllers
{
    public class JoboffersController : Controller
    {
        private readonly salesjobportalContext _context;

        public JoboffersController(salesjobportalContext context)
        {
            _context = context;
        }

        // GET: Joboffers
        public async Task<IActionResult> Index()
        {
            var salesjobportalContext = _context.Joboffers.Include(j => j.CityCity).Include(j => j.ClientDatabaseClientDatabase).Include(j => j.ClientTypeClientType).Include(j => j.EmployerEmployer).Include(j => j.IndustryIndustry).Include(j => j.PositionPosition).Include(j => j.SalesCycleLengthSalesCycleLength);
            return View(await salesjobportalContext.ToListAsync());
        }

        // GET: View
        public async Task<IActionResult> Main()
        {
            var salesjobportalContext = _context.Joboffers.Include(j => j.CityCity).Include(j => j.ClientDatabaseClientDatabase).Include(j => j.ClientTypeClientType).Include(j => j.EmployerEmployer).Include(j => j.IndustryIndustry).Include(j => j.PositionPosition).Include(j => j.SalesCycleLengthSalesCycleLength).OrderBy(j=>j.StartDate);
            return View(await salesjobportalContext.ToListAsync());
        }

   
        // GET: Joboffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobofferContext = await _context.Joboffers
                .Include(j => j.CityCity)
                .Include(j => j.ClientDatabaseClientDatabase)
                .Include(j => j.ClientTypeClientType)
                .Include(j => j.EmployerEmployer)
                .Include(j => j.IndustryIndustry)
                .Include(j => j.PositionPosition)
                .Include(j => j.SalesCycleLengthSalesCycleLength)
                .Include(j => j.Jobtypejoboffers).ThenInclude(e=>e.JobTypeJobType)
                .FirstOrDefaultAsync(m => m.JobOfferId == id);
            if (jobofferContext == null)
            {
                return NotFound();
            }

            //dynamic mymodel = new ExpandoObject();
            //mymodel.joboffer = jobofferContext;
            //mymodel.candidate = await _context.Candidates.FirstOrDefaultAsync();
            //return View(mymodel);
        
            return View(jobofferContext);
        }



        // GET: Joboffers/GetCandidates/5
        public async Task<IActionResult> GetCandidates(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffers
                .Include(j => j.Joboffercandidates)
                .ThenInclude(j => j.CandidateCandidate).ThenInclude(c=>c.CityCity)
                .Include(j => j.Joboffercandidates)
                .ThenInclude(j => j.JobApliacationStateJobApliacationState)
                .Include(j => j.Joboffercandidates)
                .ThenInclude(j => j.CandidateCandidate).ThenInclude(c => c.Experiences)
                .Include(j => j.Joboffercandidates)
                .ThenInclude(j => j.CandidateCandidate).ThenInclude(c => c.Documents)

                .FirstOrDefaultAsync(m => m.JobOfferId == id);
            if (joboffer == null)
            {
                return NotFound();
            }

            return View(joboffer.Joboffercandidates);
        }

        // GET: Joboffers/Create
        public IActionResult Create()
        {
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName");
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName");
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName");
            ViewData["EmployerEmployerId"] = new SelectList(_context.Employers, "EmployerId", "Email");
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName");
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName");
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName");
           
            return View();
        }

        // POST: Joboffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobOfferId,Content,SalaryMax,SalaryMin,CommissonMin,CommissonMax,Title,CompanyCar,EmployerEmployerId,ClientDatabaseClientDatabaseId,IndustryIndustryId,ClientTypeClientTypeId,PositionPositionId,StartDate,EndDate,SalesCycleLengthSalesCycleLengthId,CityCityId")] Joboffer joboffer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(joboffer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Main", "Joboffers");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", joboffer.CityCityId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", joboffer.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", joboffer.ClientTypeClientTypeId);
            ViewData["EmployerEmployerId"] = new SelectList(_context.Employers, "EmployerId", "Email", joboffer.EmployerEmployerId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", joboffer.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", joboffer.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", joboffer.SalesCycleLengthSalesCycleLengthId);
            return View(joboffer);
        }


        // POST: Joboffers/Test
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Test([Bind("JobOfferId,Content,SalaryMax,SalaryMin,CommissonMin,CommissonMax,Title,CompanyCar,EmployerEmployerId,ClientDatabaseClientDatabaseId,IndustryIndustryId,ClientTypeClientTypeId,PositionPositionId,StartDate,EndDate,SalesCycleLengthSalesCycleLengthId,CityCityId")] Joboffer joboffer, [Bind("JobTypeJobOfferId,JobTypeId,JobOfferId")] Jobtypejoboffer jobtypejoboffer)
        {
            if (ModelState.IsValid)
            {
                
                joboffer.Jobtypejoboffers.Add(jobtypejoboffer);
                _context.Add(joboffer);
               // _context.Add(jobtypejoboffer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Main", "Joboffers");
               // return RedirectToAction(nameof(Main));
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", joboffer.CityCityId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", joboffer.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", joboffer.ClientTypeClientTypeId);
            ViewData["EmployerEmployerId"] = new SelectList(_context.Employers, "EmployerId", "Email", joboffer.EmployerEmployerId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", joboffer.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", joboffer.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", joboffer.SalesCycleLengthSalesCycleLengthId);
            ViewData["JobTypeId"] = new SelectList(_context.Jobtypes, "JobTypeId", "JobTypeName");
            return View(joboffer);
        }

        // GET: Joboffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffers.FindAsync(id);
            if (joboffer == null)
            {
                return NotFound();
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", joboffer.CityCityId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", joboffer.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", joboffer.ClientTypeClientTypeId);
            ViewData["EmployerEmployerId"] = new SelectList(_context.Employers, "EmployerId", "Email", joboffer.EmployerEmployerId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", joboffer.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", joboffer.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", joboffer.SalesCycleLengthSalesCycleLengthId);
            return View(joboffer);
        }

        // POST: Joboffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobOfferId,Content,SalaryMax,SalaryMin,CommissonMin,CommissonMax,Title,CompanyCar,EmployerEmployerId,ClientDatabaseClientDatabaseId,IndustryIndustryId,ClientTypeClientTypeId,PositionPositionId,StartDate,EndDate,SalesCycleLengthSalesCycleLengthId,CityCityId")] Joboffer joboffer)
        {
            if (id != joboffer.JobOfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(joboffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobofferExists(joboffer.JobOfferId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("GetJobOffers", "Employers", new { id = joboffer.EmployerEmployerId });
               // return RedirectToAction(nameof(Index));
            }
            ViewData["CityCityId"] = new SelectList(_context.Cities, "CityId", "CityName", joboffer.CityCityId);
            ViewData["ClientDatabaseClientDatabaseId"] = new SelectList(_context.Clientdatabases, "ClientDatabaseId", "ClientDatabaseName", joboffer.ClientDatabaseClientDatabaseId);
            ViewData["ClientTypeClientTypeId"] = new SelectList(_context.Clienttypes, "ClientTypeId", "ClientTypeName", joboffer.ClientTypeClientTypeId);
            ViewData["EmployerEmployerId"] = new SelectList(_context.Employers, "EmployerId", "Email", joboffer.EmployerEmployerId);
            ViewData["IndustryIndustryId"] = new SelectList(_context.Industries, "IndustryId", "IndustryName", joboffer.IndustryIndustryId);
            ViewData["PositionPositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", joboffer.PositionPositionId);
            ViewData["SalesCycleLengthSalesCycleLengthId"] = new SelectList(_context.Salescyclelengths, "SalesCycleLengthId", "SalesCycleLengthName", joboffer.SalesCycleLengthSalesCycleLengthId);
            return View(joboffer);
        }

        // GET: Joboffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var joboffer = await _context.Joboffers
                .Include(j => j.CityCity)
                .Include(j => j.ClientDatabaseClientDatabase)
                .Include(j => j.ClientTypeClientType)
                .Include(j => j.EmployerEmployer)
                .Include(j => j.IndustryIndustry)
                .Include(j => j.PositionPosition)
                .Include(j => j.SalesCycleLengthSalesCycleLength)
               
                .FirstOrDefaultAsync(m => m.JobOfferId == id);
            if (joboffer == null)
            {
                return NotFound();
            }

            return View(joboffer);
        }

        // POST: Joboffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {      
            var joboffer = await _context.Joboffers
                .Include(j => j.Joboffercandidates)
                .Include(j => j.Jobtypejoboffers)                
                .FirstOrDefaultAsync(m => m.JobOfferId == id);

            _context.Joboffercandidates.RemoveRange(joboffer.Joboffercandidates.ToList());
            _context.Jobtypejoboffers.RemoveRange(joboffer.Jobtypejoboffers.ToList());
            _context.Joboffers.Remove(joboffer);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetJobOffers", "Employers", new { id = joboffer.EmployerEmployerId });         
        }

        private bool JobofferExists(int id)
        {
            return _context.Joboffers.Any(e => e.JobOfferId == id);
        }
    }
}
