using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DbContextAPI dbContext;
        public UsuarioController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this.dbContext.Usuario.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{login}")]
        public Usuario Get(string login)
        {
            return this.dbContext.Usuario.Find(login);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] Usuario value)
        {
            try
            {
                this.dbContext.Usuario.Add(value);

                this.dbContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public void Put([FromBody] Usuario value)
        {
            try
            {
                this.dbContext.Usuario.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{login}")]
        public void Delete(string login)
        {
            try
            {
                var temp = this.dbContext.Usuario.Find(login);
                this.dbContext.Usuario.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
