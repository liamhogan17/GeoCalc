using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoCalc.Clients;
using GeoCalc.Interfaces;
using GeoCalc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using GeoCalc.Data.DBContext;
using System.Diagnostics;

namespace GeoCalc.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly ICache<WholeGrade> _classCache;
    private readonly IClassClient _classClient;
    private readonly GeoCalcContext _dbContext;

    public ClassController(GeoCalcContext dbContext, ICache<WholeGrade> gradeClient, IClassClient classClient, ILogger<ClassController> logger)
    {
        _logger = logger;
        _classCache = gradeClient;
        _classClient = classClient;
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("AddClass")]
    public async Task<IActionResult> AddClass([FromBody] Class model)
    {
        _logger.LogInformation($"AddClass request for: '{model.Name}'");
        await _dbContext.ClassSet.AddAsync(model);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteClass")]
    public async Task<IActionResult> RemoveClass([FromBody] Class model)
    {
        _logger.LogInformation($"RemoveClass request for: '{model.Name}'");
        var user = _dbContext.ClassSet.FirstOrDefault( _ => _.Id == model.Id);
        if (user != null)
        {
            _dbContext.ClassSet.Remove(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();    
    }

    [HttpGet]
    [Route("GetAllClasses/Grade/{grade}")]
    public async Task<IActionResult> GetClassesByGrade([FromRoute] string grade)
    {
        _logger.LogInformation($"GetAllClasses request for grade: '{grade}'");
        var classes = await _dbContext.ClassSet.ToListAsync();
        classes = classes.FindAll(x => x.Grade.Equals(grade));

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
    public async Task<IActionResult> GetClassesBySubject([FromRoute] string subject)
    {
        _logger.LogInformation($"GetAllClasses request for subject: '{subject}'");
        var classes = await _dbContext.ClassSet.ToListAsync();
        classes = classes.FindAll(x => x.Grade.Equals(subject));

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