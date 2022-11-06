using user.Data;
using user.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace user.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClienteController : ControllerBase
  {
    private readonly ApiDbContext _context;
    public ClienteController(ApiDbContext context)
    {
      _context = context;
    }
    //  listar cliente
    [HttpGet]
    public IEnumerable<Cliente> GetClientes()
    {
      return _context.Clientes;
    }

    // Listar cliente por id
    [HttpGet("{id}")]
    public IActionResult GetClientePorId(long id)
    {
      Cliente cliente = _context.Clientes.SingleOrDefault(modelo => modelo.Id == id);
      if (cliente == null)
      {
        return NotFound();
      }
      return new ObjectResult(cliente);
    }

    // add new cliente
    [HttpPost]
    public IActionResult CriarCliente(Cliente item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      _context.Clientes.Add(item);
      _context.SaveChanges();
      return new ObjectResult(item);
    }

    // Update cliente
    [HttpPut("{id}")]
    public IActionResult AtualizaCliente(long id, Cliente item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }
      _context.Entry(item).State = EntityState.Modified;
      _context.SaveChanges();
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCliente(long id)
    {
      var cliente = _context.Clientes.SingleOrDefault(m => m.Id == id);
      if (cliente == null)
      {
        return BadRequest();
      }
      _context.Clientes.Remove(cliente);
      _context.SaveChanges();
      return Ok(cliente);
    }
  }
}
