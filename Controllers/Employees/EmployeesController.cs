using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employees")]

public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly ReestrContext _context;
    private readonly MetaService _metaService;
    private readonly EmployeesService _employeesService;

    public EmployeesController(ILogger<EmployeesController> logger, ReestrContext context, MetaService metaService, EmployeesService employeesService)
    {
        _logger = logger;
        _context = context;
        _metaService = metaService;
        _employeesService = employeesService;
    }

    ///РАБОТНИКИ

    /// <summary>
    /// Получить список сотрудников с пагинацией
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Количество элементов на странице</param>
    /// <param name="field">Поле для сортировки</param>
    /// <param name="order">Направление сортировки (asc/desc)</param>
    /// <returns>Список сотрудников и метаданные пагинации</returns>
    [HttpGet("page/{page}")]
    public async Task<IActionResult> GetEmployeesPage(int page = 1, int pageSize = 20, string field = "Id", string order = "asc")
    {

        var meta = await _metaService.GenerateMetaAsync(_context.GovernmentEmployees, page, pageSize);
        var employees = await _employeesService.GetEmployeesAsync(page, pageSize, field, order);

        return Ok(new { data = employees, meta });
    }

    /// <summary>
    /// Получить сотрудника, его образование и путь с именами по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeesService.GetEmployeeByIdAsync(id);
        if (employee.Count == 0)
        {
            return NotFound(new { message = "Работник не найден" });
        }

        return Ok(new { data = employee });
    }

    /// <summary>
    /// Создание сотрудника
    /// </summary>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto newEmployee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdEmployee = await _employeesService.CreateEmployeeAsync(newEmployee);

        return Ok(new { message = "Работник успешно добавлен", id = createdEmployee.Id });
    }

    /// <summary>
    /// Изменение сотрудника по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    /// <param name="updateEmployee">DTO с данными для обновления сотрудника</param>

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployeeById(int id, [FromBody] EmployeeUpdateDto updateEmployee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _employeesService.UpdateEmployeeAsync(id, updateEmployee);

        if (!result)
        {
            return NotFound(new { message = "Работник не найден" });
        }

        return Ok(new {message = $"Работник {id} изменён"});
    }

    /// <summary>
    /// Удаление сотрудника по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeById(int id)
    {
        var result = await _employeesService.DeleteEmployeeAsync(id);
        
        if (!result)
        {
            return NotFound(new { message = "Работник не найден" });
        }
        return Ok(new {message = $"Работник {id} удалён"});
    }
}