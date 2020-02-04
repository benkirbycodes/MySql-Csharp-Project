using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using burgershack.Services;
using burgershack.Models;

namespace burgershack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BurgerController : ControllerBase
  {


    private readonly BurgerService _bs;

    public BurgerController(BurgerService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Burger>> Get(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newData)
    {
      try
      {
        return Ok(_bs.Create(newData));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Burger> Edit([FromBody] Burger update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_bs.Edit(update));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<Burger> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}
