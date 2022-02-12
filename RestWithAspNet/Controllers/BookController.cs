using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNet.Business;
using RestWithAspNet.Hypermedia.Filters;
using RestWithAspNet.Model;
using System;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/")]
    public class BookController : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [AllowAnonymous]
        [HttpGet("status")]
        public IActionResult Get() => Ok("Books it's working");

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetAllBooks()
        {
            try
            {
                return Ok(_bookBusiness.FindAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetById(long id)
        {
            try
            {
                return Ok(_bookBusiness.FindById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post(BookVO book)
        {
            try
            {
                return Ok(_bookBusiness.Create(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(BookVO book)
        {
            try
            {
                return Ok(_bookBusiness.Update(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]        
        public IActionResult Delete(long id)
        {
            try
            {
                _bookBusiness.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
