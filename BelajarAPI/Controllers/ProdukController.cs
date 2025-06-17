using BelajarAPI.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelajarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdukController(AppDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Produk>>> Get()
        {
            return await _context.Produk.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produk>> GetById(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if(produk == null) return NotFound();
            return Ok(produk);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produk produk)
        {
            _context.Produk.Add(produk);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = produk.Id }, produk);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Produk updatedProduk)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null) return NotFound();

            produk.Nama = updatedProduk.Nama;
            produk.Stok = updatedProduk.Stok;
            produk.Harga = updatedProduk.Harga;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null) return NotFound();

            _context.Produk.Remove(produk);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
