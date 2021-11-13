using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bookstore.Repositories;
using bookstore.Entity;
using System.Net;



namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookControllers : ControllerBase
    {
        private IBookRepository _bookRepository;
        public BookControllers(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public IActionResult GetBook()
        {
            var result = new ObjectResult(_bookRepository.GetAll())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count", _bookRepository.CountBook().ToString());
            return result;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] int id)
        {

            if (await BookExists(id))
            {
                var book = await _bookRepository.Find(id);//in
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }
      
        private async Task<bool> BookExists(int id)
        {
            return await _bookRepository.IsExists(id);
        }
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] BookEntity book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bookRepository.Add(book);
            return CreatedAtAction("GetBook", new { Id = book.Id }, book);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] BookEntity book)
        {
            await _bookRepository.Update(book);
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.Remove(id);
            return Ok();
        }


    }
}

