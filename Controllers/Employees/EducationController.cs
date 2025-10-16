using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employees")]

public class EducationController : ControllerBase
{
    private readonly ILogger<EducationController> _logger;
    private readonly EmployeeEducationService _employeeEducationService;

    public EducationController(ILogger<EducationController> logger, EmployeeEducationService employeeEducationService)
    {
        _logger = logger;
        _employeeEducationService = employeeEducationService;
    }


    /// <summary>
    /// Добавление образование к сотруднику по id сотрудника
    /// </summary>
    /// <param name="idEmployee">Id сотрудника</param>
    /// <param name="educationCreateDto">Тело с данными образования</param> 
    /// <returns></returns>
    [HttpPost("{idEmployee}/education/create")]
    public async Task<IActionResult> CreateEducationByEmployeeId(int idEmployee, [FromBody] EmployeeEducationCreateDto educationCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _employeeEducationService.CreateEducationAsync(idEmployee, educationCreateDto);

        if (!result)
        {
            return NotFound(new { message = "Работник не найден" });
        }

        return Ok(new { message = "Образование успешно добавлено" });
    }

    /// <summary>
    /// Изменение образования работника по id образования
    /// </summary>
    /// <param name="idEducation">Id образования</param>
     /// <param name="employeeEducationUpdateDto">Тело с данными образования</param> 
    /// <returns></returns>
    [HttpPut("education/{idEducation}")]
    public async Task<IActionResult> PutEducationById(int idEducation, [FromBody]EmployeeEducationUpdateDto employeeEducationUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _employeeEducationService.UpdateEducationAsync(idEducation, employeeEducationUpdateDto);

        if (!result)
        {
            return NotFound(new { message = "Образование не найдено" });
        }
        return Ok(new { message = "Образование успешно изменено" });
    }

    /// <summary>
    /// Удаление образования работника по id образования
    /// </summary>
    /// <param name="idEducation">Id образования</param>
    /// <returns></returns>
    [HttpDelete("education/{idEducation}")]
    public async Task<IActionResult> DeleteEducationById(int idEducation)
    {
        var result = await _employeeEducationService.DeleteEducationAsync(idEducation);

        if (!result)
        {
            return NotFound(new { message = "Образование не найдено" });
        }

        return Ok(new{message = "Образование успешно удалено"});
    }
}