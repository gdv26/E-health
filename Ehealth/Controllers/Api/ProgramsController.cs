using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ehealth.Models;
using Ehealth.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Ehealth.Controllers.Api
{
    public class ProgramsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProgramsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ProgramDto> GetPrograms(string query = null)
        {
            var programsQuery = _context.Programs
                .Include(m => m.ProgramType)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                programsQuery = programsQuery.Where(m => m.Name.Contains(query));

            return programsQuery
                .ToList()
                .Select(Mapper.Map<Program, ProgramDto>);
        }


        public IHttpActionResult GetProgram(int id)
        {
            var program = _context.Programs.SingleOrDefault(c => c.Id == id);

            if (program == null)
                return NotFound();

            return Ok(Mapper.Map<Program, ProgramDto>(program));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManagePrograms)]
        public IHttpActionResult CreateProgram(ProgramDto programDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var program = Mapper.Map<ProgramDto, Program>(programDto);
            _context.Programs.Add(program);
            _context.SaveChanges();

            programDto.Id = program.Id;
            return Created(new Uri(Request.RequestUri + "/" + program.Id), programDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManagePrograms)]
        public IHttpActionResult UpdateProgram(int id, ProgramDto programDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var programInDb = _context.Programs.SingleOrDefault(c => c.Id == id);

            if (programInDb == null)
                return NotFound();

            Mapper.Map(programDto, programInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManagePrograms)]
        public IHttpActionResult DeleteProgram(int id)
        {
            var programInDb = _context.Programs.SingleOrDefault(c => c.Id == id);

            if (programInDb == null)
                return NotFound();

            _context.Programs.Remove(programInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
