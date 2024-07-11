using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasPorCobrarController : ControllerBase
    {
        private readonly DbContextAPI dbContext;
        public CuentasPorCobrarController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CuentasPorCobrarController>
        [HttpGet]
        public IEnumerable<CuentasPorCobrar> Get()
        {
            return dbContext.CuentasPorCobrar.ToList(); ;
        }

        // GET api/<CuentasPorCobrarController>/5
        [HttpGet("{numFactura}/{codCliente}")]
        public CuentasPorCobrar Get(int numFactura, string codCliente)
        {
            return this.dbContext.CuentasPorCobrar.Find(numFactura, codCliente);
        }

        // POST api/<CuentasPorCobrarController>
        [HttpPost]
        public void Post([FromBody] CuentasPorCobrar value)
        {
            try
            {
                this.dbContext.CuentasPorCobrar.Add(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<CuentasPorCobrarController>/5
        [HttpPut]
        public void Put([FromBody] CuentasPorCobrar value)
        {
            try
            {
                this.dbContext.CuentasPorCobrar.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/<FacturasController>/5
        [HttpDelete("{numFactura}/{codCliente}")]
        public void Delete(int numFactura, string codCliente)
        {
            try
            {
                var temp = this.dbContext.CuentasPorCobrar.Find(numFactura, codCliente);
                this.dbContext.CuentasPorCobrar.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//cierre de la clase
}
