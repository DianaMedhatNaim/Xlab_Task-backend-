using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Context;
using Models;
using Services;

namespace Xlab_Task_backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IOperations<Items> _context;

        public ItemsController(IOperations<Items> context)
        {
            _context = context;
        }
        

        // GET: api/Items
        [HttpGet]
        public  ActionResult<IEnumerable<Items>> GetItems()
        {
            return  _context.GetALL();
        }

        //// GET: api/Items/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Items>> GetItems(string id)
        //{
        //    var items = await _context.Items.FindAsync(id);

        //    if (items == null)
        //    {
        //        return NotFound();
        //    }

        //    return items;
        //}

        //// PUT: api/Items/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutItems(string id, Items items)
        //{
        //    if (id != items.Item_Name)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(items).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Items
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Items>> PostItems(Items items)
        //{
        //    _context.Items.Add(items);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ItemsExists(items.Item_Name))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetItems", new { id = items.Item_Name }, items);
        //}

        //// DELETE: api/Items/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteItems(string id)
        //{
        //    var items = await _context.Items.FindAsync(id);
        //    if (items == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Items.Remove(items);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ItemsExists(string id)
        //{
        //    return _context.Items.Any(e => e.Item_Name == id);
        //}
    }
}
