using Microsoft.AspNetCore.Mvc;
using tp_1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tp_1.Controllers;

[Route("api/[controller]")]
public class DevisesController : Controller
{
    private List<Devise> _devises { get; } = new()
    {
        new Devise(1, "Dollar", 1.08),
        new Devise(2, "Franc Suisse", 1.07),
        new Devise(3, "Yen", 120)
    };

    // GET: api/values
    [HttpGet]
    public IEnumerable<Devise> GetAll()
    {
        return _devises;
    }


    [HttpGet("{id}", Name = "GetDevise")]
    public ActionResult<Devise> GetById(int id)
    {
        var devise = _devises.FirstOrDefault(d => d.Id == id);
        if (devise == null) return NotFound();
        return devise;
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]   
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}