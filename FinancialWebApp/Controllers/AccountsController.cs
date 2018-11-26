using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financial;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Create([Bind("AccountNumber,EmailAddress,FirstName,LastName,CreatedDate,YearsInPeriod,Income,Interest,PercentOfSalarySaved")] Account account)
        {
            if (account.EmailAddress == null)
            {
                return View(account);
            }
            if (ModelState.IsValid)
            {
                Constructor.CreateAccount(account.EmailAddress, account.FirstName, account.LastName);
                
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
        public IActionResult Edit(int id, [Bind("AccountNumber,EmailAddress,FirstName,LastName,CreatedDate,YearsInPeriod,Income,Interest,PercentOfSalarySaved")] Account account)
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
        public void DeleteConfirmed(int id)
        {
            Constructor.DeleteAccount(id);
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


            
            var runModel = Constructor.Getinvestment(id.Value);
            return View(runModel);
        }
            


        }
    }

