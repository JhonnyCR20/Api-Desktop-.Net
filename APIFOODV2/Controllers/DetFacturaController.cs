using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetFacturaController : ControllerBase
    {

        private readonly DbContextAPI dbContext;
        public DetFacturaController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<DetFacturaController>
        [HttpGet]
        public IEnumerable<DetFactura> Get()
        {
            return this.dbContext.DetFactura.ToList();
        }

        // GET api/<DetFacturaController>/5
        [HttpGet("{numFactura}/{codInterno}")]
        public DetFactura Get(int numFactura, string codInterno)
        {
            return this.dbContext.DetFactura.Find(numFactura, codInterno);
        }

        // POST api/<DetFacturaController>
        [HttpPost]
        public void Post([FromBody] DetFactura value)
        {
            try
            {
                this.dbContext.DetFactura.Add(value);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<DetFacturaController>/5
        [HttpPut]
        public void Put([FromBody] DetFactura value)
        {
            try
            {
                this.dbContext.DetFactura.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("{numFactura}/{codInterno}")]
        public void Delete(int numFactura, string codInterno)
        {
            try
            {
                var temp = this.dbContext.DetFactura.Find(numFactura, codInterno);
                this.dbContext.DetFactura.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//cierre de clase
}
