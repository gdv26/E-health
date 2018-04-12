using Ehealth.Dtos;
using Ehealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ehealth.Controllers.Api
{
    public class NewBuysController : ApiController
    {
        private ApplicationDbContext _context;

        public NewBuysController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewBuy(NewBuyDto newBuy)
        {
            var user = _context.Users.Single(
                c => c.Id == newBuy.UserId);

            var programs = _context.Programs.Where(
                m => newBuy.ProgramIds.Contains(m.Id)).ToList();

            foreach (var program in programs)
            {
                if (program.NumberAvailable == 0)
                    return BadRequest("Program is not available.");

                program.NumberAvailable--;

                var buy = new Buy
                {
                    User = user,
                    Program = program,
                    DateBought = DateTime.Now
                };

                _context.Buys.Add(buy);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
