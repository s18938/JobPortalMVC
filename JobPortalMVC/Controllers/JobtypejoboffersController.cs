using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobPortalMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Grpc.Core;

namespace JobPortalMVC.Controllers
{
    public class JobtypejoboffersController : Controller
    {
        private readonly salesjobportalContext _context;

        public JobtypejoboffersController(salesjobportalContext context)
        {
            _context = context;
        }            

        // GET: Jobtypejoboffers/Create
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var x = _context.HasQuery
            ViewData["Id"] = id;  //new SelectList(_context.Filter<Joboffer>(Joboffer=>Joboffer.Id = id).Joboffers, "JobOfferId", "Content"); //Server.UrlEncode(id);
                                                  //  ViewBag.JobOffer = joboffer;
            ViewData["JobOfferJobOfferId"] = new SelectList(_context.Joboffers, "JobOfferId", "JobOfferId");
            ViewData["JobTypeJobTypeId"] = new SelectList(_context.Jobtypes, "JobTypeId", "JobTypeName");
            
            return View();
        }

        // POST: Jobtypejoboffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobTypeJobOfferId,JobTypeJobTypeId,JobOfferJobOfferId")] Jobtypejoboffer jobtypejoboffer, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                jobtypejoboffer.JobOfferJobOfferId = (int)id;
                _context.Add(jobtypejoboffer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Main", "Joboffers");
            }
            ViewData["JobOfferJobOfferId"] = jobtypejoboffer.JobOfferJobOfferId;
            ViewData["JobTypeJobTypeId"] = new SelectList(_context.Jobtypes, "JobTypeId", "JobTypeName", jobtypejoboffer.JobTypeJobTypeId);
            return View(jobtypejoboffer);
        }
    }
}