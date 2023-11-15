using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
            
        }

        [Route("GetById/{IdProducto}")]
        [HttpGet]
        public IActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetById(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Route("Delete/{IdProducto}")]
        [HttpDelete]
        public IActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.Delete(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [Route("Update/{IdProducto}")]
        [HttpPut]
        public IActionResult Update(int IdProducto, [FromBody] ML.Producto producto)
        {
            producto.IdProducto = IdProducto;
            ML.Result result = BL.Producto.Update(producto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }


}
