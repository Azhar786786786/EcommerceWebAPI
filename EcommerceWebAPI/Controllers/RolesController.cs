using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var roles = _context.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Role role)
        {
            if (role == null)
            {
                return NotFound();
            }

            Role roleToUpdate = new Role { RoleId = role.RoleId, RoleName = role.RoleName, UserRoles = role.UserRoles };

            _context.Roles.Add(roleToUpdate);
            _context.SaveChanges();


            return Ok("Yes Updated.");
        }
    }
}
