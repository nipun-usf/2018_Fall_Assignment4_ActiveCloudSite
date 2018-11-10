using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEXTrading.DataAccess;
using Microsoft.AspNetCore.Mvc;
using IEXTrading.Infrastructure.IEXTradingHandler;
using IEXTrading.Models;
using IEXTrading.Models.ViewModel;
using Newtonsoft.Json;

namespace IEXTrading.Controllers
{
    public class TopStocksController : Controller
    {
        public ApplicationDbContext dbContext;

        public TopStocksController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            IEXHandler webHandler = new IEXHandler();
            Dictionary<string, float> quoteDict = new Dictionary<string, float>();
            float priceMomentum;
            Quote quoteSym;
            ViewBag.dbSuccessChart = 0;

            List<Quote> quotes = webHandler.GetQuotes();

            //52-Week Price Range Strategy
            foreach (Quote q in quotes)
            {
                priceMomentum = (q.latestPrice - q.week52Low) / (q.week52High - q.week52Low);
                if (priceMomentum >= 0.82)
                {
                    quoteDict.Add(q.symbol, priceMomentum);
                }
            }

            List<string> topStockSymbols = quoteDict.OrderByDescending(d => d.Value).ToDictionary(t => t.Key, v => v.Value).Keys.ToList().GetRange(0, 5);

            List<Quote> filteredQuotes = new List<Quote>();

            foreach (string symbol in topStockSymbols)
            {
                quoteSym = quotes.Where(q => q.symbol == symbol).FirstOrDefault();
                filteredQuotes.Add(quoteSym);
            }

            //Save top stocks in TempData
            TempData["TopStocks"] = JsonConvert.SerializeObject(filteredQuotes);

            return View(filteredQuotes);
        }

        /****
         * Saves the Stocks in database.
        ****/
        public IActionResult SaveTopStocks()
        {
            List<Quote> quote = JsonConvert.DeserializeObject<List<Quote>>(TempData["TopStocks"].ToString());
            foreach (Quote q in quote)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Quotes.Where(c => c.symbol.Equals(q.symbol)).Count() == 0)
                {
                    dbContext.Quotes.Add(q);
                }
            }
            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Index", quote);
        }
    }
}