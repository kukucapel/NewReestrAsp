using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Services;
using NewReestrAsp.Models;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employee/archive")]

public class EducationArchiveController : ControllerBase
{
    private readonly ILogger<EducationArchiveController> _logger;

    public EducationArchiveController(ILogger<EducationArchiveController> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// Добавление образование к сотруднику по id сотрудника
    /// </summary>
    /// <param name="idEmployee">Id сотрудника</param>
    /// <returns></returns>
    [HttpPost("{idEmployee}/education/create")]
    public IActionResult CreateEducationByEmployeeId(int idEmployee)
    {
        return Ok();
    }

    /// <summary>
    /// Изменение образования работника по id образования
    /// </summary>
    /// <param name="idEducation">Id образования</param>
    /// <returns></returns>
    [HttpPut("education/{idEducation}")]
    public IActionResult PutEducationById(int idEducation)
    {
        return Ok();
    }

    /// <summary>
    /// Удаление образования работника по id образования
    /// </summary>
    /// <param name="idEducation">Id образования</param>
    /// <returns></returns>
    [HttpDelete("education/{idEducation}")]
    public IActionResult DeleteEducationById(int idEducation)
    {
        return Ok();
    }
}