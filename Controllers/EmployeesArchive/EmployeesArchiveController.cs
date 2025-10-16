using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("employees/archive")]

public class EmployeesArchiveController : ControllerBase
{
    private readonly ILogger<EmployeesArchiveController> _logger;

    public EmployeesArchiveController(ILogger<EmployeesArchiveController> logger)
    {
        _logger = logger;
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
    public IActionResult GetEmployeesArchivePage(int page = 1, int pageSize = 20, string field = "Id", string order = "asc")
    {
        return Ok();
    }

    /// <summary>
    /// Получить сотрудника из архива, его образование и путь с именами по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    [HttpGet("{id}")]
    public IActionResult GetEmployeesArchiveById(int id)
    {
        return Ok();
    }


    /// <summary>
    /// Изменение сотрудника из архива по id
    /// </summary>
    /// <param name="id">Id сотрудника</param>
    [HttpPut("{id}")]
    public IActionResult PutEmployeesArchiveById(int id)
    {
        return Ok();
    }
}