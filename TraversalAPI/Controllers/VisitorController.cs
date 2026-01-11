using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalAPI.DAL.Context;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        VisitorContext context = new VisitorContext();
        [HttpGet]
        public IActionResult VisitorList()
        {
            var values = context.Visitors.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor v)
        {
            context.Add(v);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGetByID(int id)
        {
            var values = context.Visitors.Find(id);

            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            var values = context.Visitors.Find(id);

            if (values != null)
            {
                context.Visitors.Remove(values);
                context.SaveChanges();
                return Ok(values);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor v)
        {
            var values = context.Visitors.Find(v.VisitorId);
            if (values != null)
            {
                values.Name = v.Name;
                values.Surname = v.Surname;
                values.City = v.City;
                values.Country = v.Country;
                values.Mail = v.Mail;


                context.Visitors.Update(values);
                context.SaveChanges();
                return Ok(values);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
