using Microsoft.AspNetCore.Mvc;
using BarangaySystem.Data;
using BarangaySystem.Model;
using BarangaySystem.Model.Entities;
using BarangaySystem.Model.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BarangaySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;
        public ResidentController(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getResidents()
        {
            //var result = dbContext.Residents.ToList();
            //return Ok(result);

            var result = dbContext.Residents
                .Include(r => r.Education)
                .Select(s => new
                {
                    s.residentId,
                    s.residentName,
                    s.residentDOB,
                    s.residentAddress,
                    s.residentGender,
                    residentEducation = s.Education.educationName
                })
                .ToList();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult getResidentById(int id)
        {
            //FIND SiNGLE DATA BY ID
            var result = dbContext.Residents.Find(id);

            if (result is null)
            {
                return NotFound("Resident Not Found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult createResident(AddResidentDTO addResidentDTO)
        {
            var residentEntity = new Resident()
            {
                residentName = addResidentDTO.residentName,
                residentAddress = addResidentDTO.residentAddress,
                residentDOB = addResidentDTO.residentDOB,
                residentGender = addResidentDTO.residentGender,
                residentEducation = addResidentDTO.residentEducation
            };

            dbContext.Add(residentEntity);
            dbContext.SaveChanges();
            return Ok(residentEntity);
        }

        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult editResident(int id, [FromBody] EditResidentDTO editResidentDTO)
        {
            var resident = dbContext.Residents.Find(id);
            if (resident == null)
                return NotFound("Resident not found");

            _mapper.Map(editResidentDTO, resident);

            dbContext.SaveChanges();
            return Ok(resident);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteEmployee(int id)
        {
            var res = dbContext.Residents.Find(id);

            if (res is null) return NotFound("Resident Not Found");

            dbContext.Residents.Remove(res);
            dbContext.SaveChanges();
            return Ok(res);
        }
    }
}
