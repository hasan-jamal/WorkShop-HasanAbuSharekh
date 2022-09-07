using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Web.Dto;
using WorkShop.Web.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private StoreHomeWorkContext _db;
        private readonly IMapper _mapper;
        public DataController(StoreHomeWorkContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;
        }

        // GET: api/<DataController>
        [HttpGet]
        public IActionResult Get()
        {
           var result = _db.Items
                .Select(c => new { Id = c.Id, Name = c.Name, SubCategory = c.SubCategory.Name,Category = c.SubCategory.Category.Name}).ToList();
           // var model = _mapper.Map<ItemsDto>(result);

            return Ok(result);
        }
 
        [HttpGet("[action]")]
        public IActionResult Csv()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id,Name,SubCategory,Category");
            var result = _db.Items.Include(x=> x.SubCategory.Category).ToList();

            foreach (var item in result)
            {
                builder.AppendLine($"{item.Id},{item.Name},{item.SubCategory.Name},{item.SubCategory.Category.Name}");
            }

            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", $"items.csv");
        }

        // POST api/<DataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
