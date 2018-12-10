using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Financial;
using FinancialWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FinancialWebApp.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {

        // GET: Accounts
        public IActionResult Index()
        {
            return View(Constructor.getAllAccounts(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountNumber,EmailAddress,FirstName,LastName,CreatedDate,YearsInPeriod,Income,Interest,PercentOfSalarySaved,ExpectedInflation")] Account account)
        {
            if (account.EmailAddress == null)
            {
                return View(account);
            }
            if (ModelState.IsValid)
            {
                Constructor.CreateAccount(account);
                
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);
            var Invest = Constructor.investmentTracker(account);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AccountNumber,EmailAddress,FirstName,LastName,CreatedDate,YearsInPeriod,Income,Interest,PercentOfSalarySaved,ExpectedInflation")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Constructor.editAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Constructor.AccountExists(account.AccountNumber))
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
            return View(account);
        }

        // GET: Accounts/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Constructor.DeleteAccount(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return Constructor.AccountExists(id);
        }
        public IActionResult RunModel(int? id)
        {
           if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);
            var Invest = Constructor.investmentTracker(account);
            Constructor.UpdateTrackers(id);
            var runModel = Constructor.Getinvestment(id.Value);

            

            return View(runModel);
        }

        public IActionResult yearsList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = Constructor.getAccountDetails(id.Value);
            var Invest = Constructor.investmentTracker(account);
            var yearsList = Constructor.GetAllYears(Invest);

            foreach (var year in yearsList)
            {
                var temp =System.DateTime.Today.Year;
                year.Year += temp +1;
                
            }
            return View(yearsList);
        }


        public IActionResult GraphofYears(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);
            var Invest = Constructor.investmentTracker(account);
            var yearsList = Constructor.GetAllYears(Invest);
            List<string> yearValue = new List<string>();
            double inflatiion = ((account.ExpectedInflation /100)+1);
            List<DataPoint> dataPointsInflation = new List<DataPoint>();
            foreach (var year in yearsList)
            {
                dataPointsInflation.Add(new DataPoint((Convert.ToInt64(year.Year) + Convert.ToInt64(System.DateTime.Today.Year)), Convert.ToInt64(year.Value * inflatiion)));
                inflatiion += (account.ExpectedInflation / 100);
            }
            ViewBag.DataPointsInflation = JsonConvert.SerializeObject(dataPointsInflation);

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var year in yearsList)
            {
                dataPoints.Add(new DataPoint((Convert.ToInt32(year.Year) + Convert.ToInt32(System.DateTime.Today.Year)), Convert.ToInt32(year.Value)));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }

        public IActionResult GraphofYearsBar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Constructor.getAccountDetails(id.Value);
            var Invest = Constructor.investmentTracker(account);
            var yearsList = Constructor.GetAllYears(Invest);
            List<string> yearValue = new List<string>();
            double inflatiion = ((account.ExpectedInflation / 100) + 1);
            List<DataPoint> dataPointsInflation = new List<DataPoint>();
            foreach (var year in yearsList)
            {
                dataPointsInflation.Add(new DataPoint((Convert.ToInt64(year.Year) + Convert.ToInt64(System.DateTime.Today.Year)), Convert.ToInt64(year.Value * inflatiion)));
                inflatiion += (account.ExpectedInflation / 100);
            }
            ViewBag.DataPointsInflation = JsonConvert.SerializeObject(dataPointsInflation);

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var year in yearsList)
            {
                dataPoints.Add(new DataPoint((Convert.ToInt32(year.Year) + Convert.ToInt32(System.DateTime.Today.Year)), Convert.ToInt32(year.Value)));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }

    }

    }

