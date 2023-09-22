using Microsoft.AspNetCore.Mvc;
using tp_1.Models;

namespace tp_1.Controllers;

[Route("api/[controller]")]
public class DevisesController : Controller
{
    private List<Devise> devises { get; } = new()
    {
        new Devise(1, "Dollar", 1.08),
        new Devise(2, "Franc Suisse", 1.07),
        new Devise(3, "Yen", 120)
    };

    /// <summary>
    ///     Retrieve all currencies.
    /// </summary>
    /// <returns>List of all currencies</returns>
    [HttpGet]
    public IEnumerable<Devise> GetAll()
    {
        return devises;
    }

    /// <summary>
    ///     Get a single currency.
    /// </summary>
    /// <returns>Details of a specific currency</returns>
    /// <param name="id">The id of the currency</param>
    /// <response code="200">When the currency id is found</response>
    /// <response code="404">When the currency id is not found</response>
    [HttpGet("{id}", Name = "GetDevise")]
    public ActionResult<Devise> GetById(int id)
    {
        var devise = devises.FirstOrDefault(d => d.Id == id);
        if (devise == null) return NotFound();
        return devise;
    }

    /// <summary>
    ///     Update a currency.
    /// </summary>
    /// <remarks>Updates a specific currency's details</remarks>
    /// <returns>Http response</returns>
    /// <param name="id">The id of the currency to be updated</param>
    /// <response code="204">Currency updated successfully</response>
    /// <response code="400">Invalid request</response>
    /// <response code="404">Currency not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public ActionResult Put(int id, [FromBody] Devise devise)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != devise.Id) return BadRequest();
        var index = devises.FindIndex(d => d.Id == id);
        if (index < 0) return NotFound();
        devises[index] = devise;
        return NoContent();
    }

    /// <summary>
    ///     Delete a currency.
    /// </summary>
    /// <returns>Details of the deleted currency</returns>
    /// <param name="id">The id of the currency to be deleted</param>
    /// <response code="200">Currency deleted successfully</response>
    /// <response code="404">Currency not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<Devise> Delete(int id)
    {
        var devise = devises.FirstOrDefault(d => d.Id == id);
        if (!ModelState.IsValid) return BadRequest();
        if (devise == null) return NotFound();
        devises.Remove(devise);
        return devise;
    }

    /// <summary>
    ///     Create a new currency.
    /// </summary>
    /// <returns>Details of the created currency</returns>
    /// <response code="201">Currency created successfully</response>
    /// <response code="400">Invalid request</response>
    /// <response code="204">No content</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public ActionResult<Devise> Post([FromBody] Devise devise)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        devises.Add(devise);
        return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
    }
}