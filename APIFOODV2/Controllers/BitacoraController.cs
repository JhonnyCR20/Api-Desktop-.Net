using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private readonly DbContextAPI dbContext;
        public BitacoraController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<BitacoraController>
        [HttpGet]
        public IEnumerable<Bitacora> Get()
        {
            return this.dbContext.Bitacora.ToList();
        }

        [HttpGet("/BuscarBitacora/{usuario}")]
        public List<Bitacora> GetBitacora(string usuario)
        {
            return this.dbContext.Bitacora.Where(b => b.Usuario.Contains(usuario)).ToList(); ;
        }


        // POST api/<BitacoraController>
        [HttpPost]
        public void Post([FromBody] Bitacora value)
        {
            try
            {
                this.dbContext.Bitacora.Add(value);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<BitacoraController>/5
        [HttpPut]
        public void Put([FromBody] Bitacora value)
        {
            try
            {
                this.dbContext.Bitacora.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/<BitacoraController>/5
        [HttpDelete("{Usuario}")]
        public void Delete(string Usuario)
        {
            try
            {
                var temp = this.dbContext.Bitacora.Find(Usuario);
                this.dbContext.Bitacora.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
