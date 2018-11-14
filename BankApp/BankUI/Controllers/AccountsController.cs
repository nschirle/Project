using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        

        // GET: Accounts
        public IActionResult Index()
        {
            return View(Bank.getAllAccounts(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.getAccountDetails(id.Value);
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
        public IActionResult Create([Bind("AccountNumber,EmailAddress,AccountType,Balance,CreatedDate")] Account account)
        {
            if(account.EmailAddress == null)
            {
                return View(account);
            }
            if (ModelState.IsValid)
            {
                 Bank.CreateAccount(account.EmailAddress, account.AccountType);
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

            var account = Bank.getAccountDetails(id.Value);
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
        public IActionResult Edit(int id, [Bind("AccountNumber,EmailAddress,AccountType,Balance,CreatedDate")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Bank.editAccount(account);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Bank.AccountExists(account.AccountNumber))
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
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.getAccountDetails(id.Value);
                
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
            
            Bank.DeleteAccount(id);
        }

        public IActionResult Deposit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var account = Bank.getAccountDetails(id.Value);
            return View(account);


        }
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Deposit(IFormCollection formData)
        {
            var accountNumber = Convert.ToInt32(formData["AccountNumber"]);
            var amount = Convert.ToInt64(formData["Amount"]);

            Bank.Deposit(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.getAccountDetails(id.Value);
            return View(account);


        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult withdraw(IFormCollection formData)
        {
            var accountNumber = Convert.ToInt32(formData["AccountNumber"]);
            var amount = Convert.ToInt32(formData["Amount"]);

            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Transactions(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

           var transactions = Bank.GetAllTransactions(id.Value);
            return View(transactions);

        }

    }
}
