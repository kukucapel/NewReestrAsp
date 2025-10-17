using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Services;
using NewReestrAsp.Models;
using NewReestrAsp.Dtos;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employee/archive")]

public class EducationArchiveController : ControllerBase
{
    private readonly ILogger<EducationArchiveController> _logger;
    private readonly EmployeeEducationArchiveService _employeeEducationArchiveService;

    public EducationArchiveController(ILogger<EducationArchiveController> logger, EmployeeEducationArchiveService employeeEducationArchiveService)
    {
        _logger = logger;
        _employeeEducationArchiveService = employeeEducationArchiveService;
    }

    /// <summary>
    /// Добавление образование к сотруднику по id сотрудника
    /// </summary>
    /// <param name="idEmployee">Id сотрудника</param>
    /// <param name="employeeEducationArchiveCreateDto">Тело с данными образования</param>
    /// <returns></returns>
    [HttpPost("{idEmployee}/education/create")]
    public async Task<IActionResult> CreateEducationArchiveByEmployeeId(int idEmployee, [FromBody] EmployeeEducationCreateDto employeeEducationArchiveCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _employeeEducationArchiveService.CreateEducationArchiveAsync(idEmployee, employeeEducationArchiveCreateDto);

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
    public async Task<IActionResult> PutEducationArchiveById(int idEducation, [FromBody] EmployeeEducationUpdateDto employeeEducationUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _employeeEducationArchiveService.UpdateEducationArchiveAsync(idEducation, employeeEducationUpdateDto);

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
    public async Task<IActionResult> DeleteEducationArchiveById(int idEducation)
    {
        var result = await _employeeEducationArchiveService.DeleteEducationArchiveAsync(idEducation);

        if (!result)
        {
            return NotFound(new { message = "Образование не найдено" });
        }

        return Ok(new { message = "Образование успешно удалено" });
    }
}