using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using QuotingDojo.Models;
using Newtonsoft.Json;

namespace QuotingDojoAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        // GET api/quotes
        [HttpGet]
        public List<UserQuote> Get()
        {

            List<Dictionary<string, object>> results = DbConnector.Query("SELECT * FROM quotes");
            List<UserQuote> quotes = UserQuote.ConvertListOfDictionaries(results);
            return quotes;
        }

        // GET api/quotes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<Dictionary<string, object>> results = DbConnector.Query($"SELECT * FROM quotes WHERE id = {id}");
            if (results.Count < 1)
            {
                return NotFound();
            }
            Dictionary<string, object> item = results.FirstOrDefault();
            UserQuote quote = new UserQuote(item);
            return new ObjectResult(quote);
        }

        // POST api/quotes
        [HttpPost]
        public IActionResult Post([FromBody] UserQuote newQuote)
        {
            if (newQuote == null)
            {
                return BadRequest();
            }

            System.Console.WriteLine(JsonConvert.SerializeObject(newQuote));
            string sqlInsert = $@"INSERT INTO quotes (`name`, `quote`) VALUES('{newQuote.Name}', '{newQuote.Quote}')";
            System.Console.WriteLine(sqlInsert);
            DbConnector.Execute(sqlInsert);
            return Created("quotes", newQuote);
        }

        // // PUT api/quotes/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // DELETE api/quotes/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
