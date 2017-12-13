using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contoso.API.Models;

namespace Contoso.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly TestContext _testContext;
        public TestController(TestContext context)
        {
            _testContext = context;
            if (_testContext.TestItems.Count() == 0)
            {
                _testContext.TestItems.Add(new Models.Test { Nombre = "Test" });
                _testContext.SaveChanges();
            }

        }
        
        [HttpGet]
        public IEnumerable<Test> GetAll()
        {   
            return _testContext.TestItems.ToList();
        }


        [HttpGet("{id}")]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var item = _testContext.TestItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] Test item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _testContext.TestItems.Add(item);
            _testContext.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

    }
}