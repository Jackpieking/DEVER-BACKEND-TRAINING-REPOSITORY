using FU_DEVER_BACKEND_TRAINING.DTOs.ClassroomDtos.Incomings;
using FU_DEVER_BACKEND_TRAINING.DTOs.ClassroomDtos.Outgoings;
using FU_DEVER_BACKEND_TRAINING.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace FU_DEVER_BACKEND_TRAINING.Controllers;

//[controller]: route parameter
//DTOs: data transfer object

[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
[ApiController]
public sealed class ClassroomController : ControllerBase
{
    private readonly SchoolContext _context;

    public ClassroomController(SchoolContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudentsAsync()
    {
        List<GetAllStudentsDto> dtos = new();

        await _context.ClassroomEntities
            .AsNoTracking()
            .Select(classRoom => new ClassroomEntity
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                NumberOfStudents = classRoom.NumberOfStudents,
            })
            .ForEachAsync(student =>
            {
                dtos.Add(new()
                {
                    Id = student.Id,
                    Name = student.Name,
                    NumberOfStudents = student.NumberOfStudents
                });
            });

        return Ok(dtos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateClassroomAsync([FromBody] CreateClassroomDto createClassroomDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Model is invalid");
        }

        try
        {
            await _context
                .ClassroomEntities
                .AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Name = createClassroomDto.Name,
                    NumberOfStudents = createClassroomDto.NumberOfStudent
                });

            await _context.SaveChangesAsync();

            return Ok("Create classroom successfully");
        }
        catch (DbUpdateConcurrencyException)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Database operations failed");
        }
        catch (DbUpdateException)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "Database operations failed");
        }
    }
}
