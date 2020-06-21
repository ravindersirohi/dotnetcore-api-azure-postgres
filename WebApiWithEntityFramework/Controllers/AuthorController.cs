using System;
using System.Collections.Generic;
using API.Domain;
using Microsoft.AspNetCore.Mvc;
using PostgresRepository.Database;

namespace WebApiWithEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            var result = new AuthorDataService().Read();
            return result;
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            var result = new AuthorDataService().Read(id);
            return result;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public Author Post([FromBody] Author dto)
        {
            var result = new AuthorDataService().Create(dto);
            return result;
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
