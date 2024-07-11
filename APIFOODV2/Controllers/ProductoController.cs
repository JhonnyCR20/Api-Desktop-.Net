using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly DbContextAPI dbContext;
        public ProductoController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<Productoontroller>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return this.dbContext.Producto.ToList();
        }

        // GET api/<Productoontroller>/5
        [HttpGet("{CodigoInterno}")]
        public Producto Get(string CodigoInterno)
        {
            return this.dbContext.Producto.Find(CodigoInterno);
        }

        // POST api/<Productoontroller>
        [HttpPost]
        public void Post([FromBody] Producto value)
        {
            try
            {
                this.dbContext.Producto.Add(value);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<Productoontroller>/5
        // PUT api/<Productoontroller>/5
        [HttpPut("{CodigoInterno}")]
        public void Put(string CodigoInterno, [FromBody] Producto value)
        {
            try
            {
                var existingProducto = this.dbContext.Producto.Find(CodigoInterno);
                if (existingProducto == null)
                {
                    // Manejar el caso donde el producto no existe
                    return;
                }
                // Actualizar propiedades del producto existente
                existingProducto.CodigoBarra = value.CodigoBarra;
                existingProducto.Descripcion = value.Descripcion;
                existingProducto.PrecioVenta = value.PrecioVenta;
                existingProducto.Descuento = value.Descuento;
                existingProducto.Impuesto = value.Impuesto;
                existingProducto.UnidadMedida = value.UnidadMedida;
                existingProducto.PrecioCompra = value.PrecioCompra;
                existingProducto.Usuario = value.Usuario;
                existingProducto.Existencia = value.Existencia;

                this.dbContext.Producto.Update(existingProducto);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<Productoontroller>/5
        [HttpDelete("{CodigoInterno}")]
        public void Delete(string CodigoInterno)
        {
            try
            {
                var temp = this.dbContext.Producto.Find(CodigoInterno);
                this.dbContext.Producto.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }//cierre de clase
}
