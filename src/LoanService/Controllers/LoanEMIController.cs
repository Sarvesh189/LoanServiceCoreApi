using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanService.InfrastructureServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanService.Controllers
{
    [Route("api/loanemi")]
    public class LoanEMIController : Controller
    {
        // GET: /<controller>/{tenure}/{interestrate}

            [HttpGet("{amount}/{tenure}/{interestrate}")]
        public async Task<double> Index(int amount, int tenure, float interestrate)
            {
                var monthlyinterestrate1 = Math.Round((double)interestrate/1200,4);
                var monthlyinterestrate = 1 + monthlyinterestrate1;
                tenure = tenure*12;
                monthlyinterestrate = Math.Round(Math.Pow(monthlyinterestrate, tenure),4);

                var emi = Math.Round((amount * monthlyinterestrate1 * monthlyinterestrate) / (monthlyinterestrate - 1),2);

            //   EmailService.SendEmail(new Tuple<int, int, float, double>(amount,tenure,interestrate,emi));
             //   try
              //  {
                    var messagebocker = new MessageBrockerService();
                    await messagebocker.SendMessage(emi.ToString());
             //   }
             //   catch (Exception ex)
            //    {
             //       string exc = ex.Message;
             //   }

                return emi;
            }
    }
}
