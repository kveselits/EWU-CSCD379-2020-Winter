﻿using BlogEngine.Business;
using BlogEngine.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogEngine.Api.Controllers
{
    //https://localhost/api/Author
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService AuthorService { get; }

        public AuthorController(IAuthorService authorService)
        {
            AuthorService = authorService ?? throw new System.ArgumentNullException(nameof(authorService));
        }

        // GET: https://localhost/api/Author
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            List<Author> authors = await AuthorService.FetchAllAsync();
            return authors;
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Author>> Get(int id)
        {
            if (await AuthorService.FetchByIdAsync(id) is Author author)
            {
                return Ok(author);
            }
            return NotFound();
        }

        // POST: api/Author
        [HttpPost]
        public void Post([FromBody] Author value)
        {

        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
