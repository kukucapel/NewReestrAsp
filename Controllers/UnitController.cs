using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("")]
public class UnitController : ControllerBase
{
    private readonly ILogger<UnitController> _logger;
    private readonly UnitService _unitService;
    public UnitController(ILogger<UnitController> logger, UnitService unitService)
    {
        _logger = logger;
        _unitService = unitService;
    }

    /// <summary>
    /// Получить всех соотрудников со структурой
    /// </summary>
    [HttpGet("units")]
    public async Task<IActionResult> GetUnitAll()
    {
        var units = await _unitService.GetUnitWithEmployee();
        return Ok(units);
    }

    /// <summary>
    /// Получить голую структуру
    /// </summary>
    /// <param name="id">Id активного юнита (если есть)</param>
    [HttpGet("units_modal/{id}")]
    public async Task<IActionResult> GetUnitModal(int id = 0)
    {
        var tree = await _unitService.GetUnitModal(id);
        return Ok(tree);
    }
}