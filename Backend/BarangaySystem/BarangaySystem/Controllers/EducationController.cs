using Microsoft.AspNetCore.Mvc;
using BarangaySystem.Data;
using BarangaySystem.Model;
using BarangaySystem.Model.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BarangaySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;
        public EducationController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getEducation()
        {
            //var result = dbContext.Residents.ToList();
            //return Ok(result);

            var result = dbContext.Education.ToList();
            return Ok(result);
        }

    }
}
