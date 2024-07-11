using APIFOODV2.Data;
using APIFOODV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIFOODV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly DbContextAPI dbContext;
        public ClienteController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return this.dbContext.Cliente.ToList();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{cedulaLegal}")]
        public Cliente Get(string cedulaLegal)
        {
            return this.dbContext.Cliente.Find(cedulaLegal);
        }

        [HttpGet("/BuscarNombre/{nombre}")]
        public List<Cliente> GetEmail(string nombre)
        {
            return this.dbContext.Cliente.Where(b => b.nombreCompleto.Contains(nombre)).ToList(); ;
        }


        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            try
            {
                this.dbContext.Cliente.Add(value);
                this.dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public void Put([FromBody] Cliente value)
        {
            try
            {
                this.dbContext.Cliente.Update(value);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{cedulaLegal}")]
        public void Delete(string cedulaLegal)
        {
            try
            {
                var temp = this.dbContext.Cliente.Find(cedulaLegal);
                this.dbContext.Cliente.Remove(temp);
                this.dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }//cierre de la clase
}
