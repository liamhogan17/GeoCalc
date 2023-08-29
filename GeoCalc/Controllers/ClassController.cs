using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BrainDump.Clients;
using BrainDump.Interfaces;
using BrainDump.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainDump.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly ICache<WholeGrade> _classCache;
    private readonly IClassClient _classClient;

    public ClassController(DbContext dbContext, ICache<WholeGrade> gradeClient, IClassClient classClient, ILogger<ClassController> logger)
    {
        _logger = logger;
        _classCache = gradeClient;
        _classClient = classClient;
    }

    
    [HttpGet]
    [Route("GetAllClasses/Grade/{grade}")]
    public async Task<IActionResult> GetClassesByGrade([FromBody] WholeGrade model, [FromRoute] string grade)
    {
        _logger.LogInformation($"GetAllClasses request for grade: '{grade}'");
        var classes = await _classClient.GetAllClassesByGrade(grade);

        if (classes.Count == 0)
        {
            return NoContent();
        }
        if (classes != null)
        {
            return Ok(classes);
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("GetAllClasses/Subject/{subject}")]
    public async Task<IActionResult> GetClassesBySubject([FromBody] WholeGrade model, [FromRoute] string subject)
    {
        _logger.LogInformation($"GetAllClasses request for subject: '{subject}'");
        var classes = await _classClient.GetAllClassesBySubject(subject);

        if (classes.Count == 0)
        {
            return NoContent();
        }
        if (classes != null)
        {
            return Ok(classes);
        }
        return BadRequest();
    }

}