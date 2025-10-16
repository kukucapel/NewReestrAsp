using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employees/archive")]

public class EmployeesArchiveController : ControllerBase
{
    private readonly ILogger<EmployeesArchiveController> _logger;
    private readonly MetaService _metaService;
    private readonly ReestrContext _context;
    private readonly EmployeesArchiveService _employeesArchiveService;

    public EmployeesArchiveController(ILogger<EmployeesArchiveController> logger, MetaService metaService, ReestrContext context, EmployeesArchiveService employeesArchiveService)
    {
        _logger = logger;
        _metaService = metaService;
        _context = context;
        _employeesArchiveService = employeesArchiveService;
    }

    /// <summary>
    /// Получить список сотрудников из архива с пагинацией
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Количество элементов на странице</param>
    /// <param name="field">Поле для сортировки</param>
    /// <param name="order">Направление сортировки (asc/desc)</param>
    /// <returns>Список сотрудников и метаданные пагинации</returns>
    [HttpGet("page/{page}")]
    public async Task<IActionResult> GetEmployeesArchivePage(int page = 1, int pageSize = 20, string field = "Id", string order = "asc")
    {
        var meta = await _metaService.GenerateMetaAsync(_context.GovernmentEmployeesArchives, page, pageSize);
        var employees = await _employeesArchiveService.GetEmployeesArchiveAsync(page, pageSize, field, order);

        return Ok(new { data = employees, meta });
    }

    /// <summary>
    /// Получить сотрудника из архива, его образование и путь с именами по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeesArchiveById(int id)
    {
        var employee = await _employeesArchiveService.GetEmployeeArchiveByIdAsync(id);
        if (employee.Count == 0)
        {
            return NotFound(new { message = "Работник не найден" });
        }
        return Ok(new { data = employee });
    }


    /// <summary>
    /// Изменение сотрудника из архива по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <param name="updateEmployeeArchive">DTO с данными для обнвления сотрудника</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployeesArchiveById(int id, [FromBody] EmployeeArchiveUpdateDto updateEmployeeArchive)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _employeesArchiveService.UpdateEmployeeArchiveAsync(id, updateEmployeeArchive);

        if (!result)
        {
            return NotFound(new { message = "Работник не найден" });
        }

        return Ok(new { message = $"Работник {id} изменён" });
    }
}