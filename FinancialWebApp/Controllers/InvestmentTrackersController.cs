using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financial;

namespace FinancialWebApp.Controllers
{
    public class InvestmentTrackersController : Controller
    {
        private readonly BankModel _context;

        public InvestmentTrackersController(BankModel context)
        {
            _context = context;
        }

        // GET: InvestmentTrackers
        public async Task<IActionResult> Index()
        {
            var bankModel = _context.InvestmentTracker.Include(i => i.Account);
            return View(await bankModel.ToListAsync());
        }

        // GET: InvestmentTrackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentTracker = await _context.InvestmentTracker
                .Include(i => i.Account)
                .FirstOrDefaultAsync(m => m.TrackerID == id);
            if (investmentTracker == null)
            {
                return NotFound();
            }

            return View(investmentTracker);
        }

        // GET: InvestmentTrackers/Create
        public IActionResult Create()
        {
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber");
            return View();
        }

        // POST: InvestmentTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrackerID,YearsInPeriod,Income,Interest,PercentOfSalarySaved,AccountNumber")] InvestmentTracker investmentTracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(investmentTracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", investmentTracker.AccountNumber);
            return View(investmentTracker);
        }

        // GET: InvestmentTrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentTracker = await _context.InvestmentTracker.FindAsync(id);
            if (investmentTracker == null)
            {
                return NotFound();
            }
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", investmentTracker.AccountNumber);
            return View(investmentTracker);
        }

        // POST: InvestmentTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackerID,YearsInPeriod,Income,Interest,PercentOfSalarySaved,AccountNumber")] InvestmentTracker investmentTracker)
        {
            if (id != investmentTracker.TrackerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(investmentTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvestmentTrackerExists(investmentTracker.TrackerID))
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
            ViewData["AccountNumber"] = new SelectList(_context.Accounts, "AccountNumber", "AccountNumber", investmentTracker.AccountNumber);
            return View(investmentTracker);
        }

        // GET: InvestmentTrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var investmentTracker = await _context.InvestmentTracker
                .Include(i => i.Account)
                .FirstOrDefaultAsync(m => m.TrackerID == id);
            if (investmentTracker == null)
            {
                return NotFound();
            }

            return View(investmentTracker);
        }

        // POST: InvestmentTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var investmentTracker = await _context.InvestmentTracker.FindAsync(id);
            _context.InvestmentTracker.Remove(investmentTracker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvestmentTrackerExists(int id)
        {
            return _context.InvestmentTracker.Any(e => e.TrackerID == id);
        }
    }
}
