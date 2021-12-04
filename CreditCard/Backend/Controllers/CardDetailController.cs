
using CreditCard.Backend.Data;
using CreditCard.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCard.Backend.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    public class CardDetailController : Controller
    {

        private readonly CardDetailContext _context;

        public CardDetailController(CardDetailContext context)
        {
            _context = context;
        }
        // GET: api/CardDetailController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDetail>>> GetCardDetails()
        {
            return await _context.CardDetails.ToListAsync();
        }

        // GET: api/CardDetailController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDetail>> GetCardDetail(string id)
        {
            var cardDetail = await _context.CardDetails.FindAsync(id);
            if (cardDetail == null)
            {
                return NotFound();
            }
            return cardDetail;
        }


        // POST: CardDetailController/Create/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<CardDetail>> CreateCardDetail(CardDetail cardDetail) 
        {

            cardDetail.PaymentId = Guid.NewGuid().ToString();
            _context.CardDetails.Add(cardDetail);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardDetail", new { id = cardDetail.PaymentId }, cardDetail);
        }

        // PUT: api/CardDetailController/Edit
        [HttpPost("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCardDetail(string id, CardDetail cardDetail) 
        {

            if (id != cardDetail.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(cardDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!PaymentIdCheck(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // POST: CardDetailController/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCardDetail(string id)
        {
            var cardDetail = await _context.CardDetails.FindAsync(id);
            if (cardDetail == null)
            {
                return NotFound();
            }
            _context.CardDetails.Remove(cardDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentIdCheck(string id)
        {
            return _context.CardDetails.Any(e => e.PaymentId == id);
        }
    }
}
