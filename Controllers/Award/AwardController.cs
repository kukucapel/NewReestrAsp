using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using NewReestrAsp.Services;

namespace NewReestrAsp.Controllers;

[ApiController]
[Route("awards")]

public class AwardController : ControllerBase
{
     private readonly ILogger<AwardController> _logger;
    private readonly ReestrContext _context;
    private readonly MetaService _metaService;
    private readonly AwardService _awardService;

    public AwardController(ILogger<AwardController> logger, ReestrContext context, MetaService metaService, AwardService awardService)
    {
        _logger = logger;
        _context = context;
        _metaService = metaService;
        _awardService = awardService;
    }

    ///НАГРАДЫ

    /// <summary>
    /// Получить список наград с пагинацией
    /// </summary>
    /// <param name="page">Номер страницы</param>
    /// <param name="pageSize">Количество элементов на странице</param>
    /// <param name="field">Поле для сортировки</param>
    /// <param name="order">Направление сортировки (asc/desc)</param>
    /// <returns>Список сотрудников и метаданные пагинации</returns>
    [HttpGet("page/{page}")]
    public async Task<IActionResult> GetAwardsPage(int page = 1, int pageSize = 20, string field = "Id", string order = "asc")
    {
        var meta = await _metaService.GenerateMetaAsync(_context.Awards, page, pageSize);

        var result = await _awardService.GetAwardsAsync(page, pageSize, field, order);

        return Ok(new { data = result, meta });
    }

    /// <summary>
    /// Получить награду и список файлов по id 
    /// </summary>
    /// <param name="id">Id награды</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAwardById(int id)
    {
        var result = await _awardService.GetAwardByIdAsync(id);
        if (result.Count == 0)
        {
            return NotFound(new { message = "Награда не найдена" });
        }

        return Ok(new { data = result });
    }

    /// <summary>
    /// Создание награды
    /// </summary>
    /// <param name="awardCreateUpdateDto">Тело с данными награды</param>
    [HttpPost("create")]
    public async Task<IActionResult> CreateAward([FromBody] AwardCreateUpdateDto awardCreateUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdAward = await _awardService.CreateAwardAsync(awardCreateUpdateDto);

        return Ok(new { message = "Награда успешно добавлена", id = createdAward.Id });
    }

    /// <summary>
    /// Изменение награды по id 
    /// </summary>
    /// <param name="id">Id награды</param>
    /// <param name="awardCreateUpdateDto">Тело с данными награды</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAwardById(int id, [FromBody] AwardCreateUpdateDto awardCreateUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _awardService.UpdateAwardByIdAsync(id, awardCreateUpdateDto);

        if (!result)
        {
            return NotFound(new { message = "Награда не найдена" });
        }

        return Ok(new { message = "Награда успешно изменена" });
    }

    /// <summary>
    /// Удаление награды по id
    /// </summary>
    /// <param name="id">Id награды</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAwardById(int id)
    {
        var result = await _awardService.DeleteAwardByIdAsync(id);

        if (!result)
        {
            return NotFound(new { message = "Награда не найдена" });
        }

        return Ok(new { message = "Награда успешно удалена" });
    }
}