using API_RESTful_NetCore.Context;
using API_RESTful_NetCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTful_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _contex;
        public ProductoController(AppDbContext context)
        {
            _contex = context;
        }

        //Extrae todo los registros
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _contex.Producto.ToList();
        }

        //Extrae un solo registro
        [HttpGet("{id}")]
        public Producto Get(string id)
        {
            var producto = _contex.Producto.FirstOrDefault(p => p.pro_codigo == id);
            return producto;
        }

        //Agrega registro
        [HttpPost]
        public ActionResult Post([FromBody]Producto producto)
        {
            try
            {
                _contex.Producto.Add(producto);
                _contex.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        //Put: Actualiza el registro
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Producto producto)
        {
            if (producto.pro_codigo == id)
            {
                _contex.Entry(producto).State = EntityState.Modified;
                _contex.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //Delete: elimina el registro
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var producto = _contex.Producto.FirstOrDefault(p => p.pro_codigo == id);
            if(producto != null)
            {
                _contex.Producto.Remove(producto);
                _contex.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
