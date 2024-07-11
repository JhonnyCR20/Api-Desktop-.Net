using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private readonly DbContextAPI dbContext;
        public FacturaController(DbContextAPI dbcontext)
        {
            this.dbContext = dbcontext;
        }
        // GET: api/<FacturasController>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            return this.dbContext.Factura.ToList();
        }

        // GET api/<FacturasController>/5
        [HttpGet("{numero}")]
        public Factura Get(int numero)
        {
            return this.dbContext.Factura.Find(numero);
        }

        // POST api/<FacturasController>
        [HttpPost]
        public Factura Post([FromBody] Factura value)
        {
            try
            {
                this.dbContext.Factura.Add(value);
                this.dbContext.SaveChanges();
                return this.dbContext.Factura.OrderBy(factura => factura.Numero).Last();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<FacturasController>/5
        [HttpPut]
        public void Put([FromBody] Factura value)
        {
            try
            {
                this.dbContext.Factura.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("{numero}")]
        public void Delete(int numero)
        {
            try
            {
                var temp = this.dbContext.Factura.Find(numero);
                this.dbContext.Factura.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//cierrre de la clase
}
