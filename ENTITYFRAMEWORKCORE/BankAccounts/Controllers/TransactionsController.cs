using System;
using System.Linq;
using System.Diagnostics;
using BankAccounts.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// Other usings

namespace BankAccounts.Controllers
{
    public class TransactionsController : Controller
    {
        private AccountContext _context;

        public TransactionsController(AccountContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("account/{AccountId}")]
        public IActionResult Account(int AccountId)
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");             
            if (AccountId != CurrentUserId)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Users");
            }
            List<Transactions> NewTransaction = _context.Transactions.Where(i => i.UserId == AccountId)
                                                                        .OrderByDescending(i => i.TransactionDate)
                                                                        .ToList();
            ViewBag.TransactionInfo = NewTransaction;
            ViewBag.Client = _context.Users.SingleOrDefault(i => i.UserId == AccountId).FirstName;
            ViewBag.Balance = _context.Users.SingleOrDefault(i => i.UserId == AccountId).Balance;
            return View();
            // Other code
        }

        [HttpPost]
        [Route("newtransaction")]
        public IActionResult CreateTransaction(int Amount)
        {
            int? AccountId = HttpContext.Session.GetInt32("CurrentUser");
            Users Client = _context.Users.SingleOrDefault(u => u.UserId == AccountId);
            if(Amount < 0 && ((Amount * -1) > Client.Balance) || Amount == 0)
            {
                List<Transactions> NewTransaction = _context.Transactions.Where(i => i.UserId == AccountId)
                                                                        .OrderByDescending(i => i.TransactionDate)
                                                                        .ToList();
                ViewBag.TransactionInfo = NewTransaction;                
                ViewBag.Client = _context.Users.SingleOrDefault(i => i.UserId == AccountId).FirstName;                
                ViewBag.Message = "Insufficient funds in your account/You must deposit some money first.";
                return View("Account");
            }
            else
            {
                Transactions NewTrans = new Transactions{
                    Amount = Amount,
                    UserId = Client.UserId,
                    TransactionDate = DateTime.Now,
                };
                Client.Balance += Amount;
                _context.Transactions.Add(NewTrans);
                _context.SaveChanges();
                return RedirectToAction("Account", new { AccountId});                
            }            
        } 
    }
}