using System.Linq.Dynamic.Core;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

namespace NewReestrAsp.Services;

public class AwardService
{
    private readonly ReestrContext _context;
    private readonly IMapper _mapper;

    public AwardService(ReestrContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //получение наград по страницам
    public async Task<List<AwardDto>> GetAwardsAsync(int page, int pageSize, string field, string order)
    {
        var sort = $"{field} {order}";
        var awards = await _context.Awards.Include(e => e.AwardsDocuments).OrderBy(sort).Skip((page - 1) * pageSize).Take(pageSize).ProjectTo<AwardDto>(_mapper.ConfigurationProvider).ToListAsync();

        return awards;
    }

    //получение награды по id
    public async Task<List<AwardDto>> GetAwardByIdAsync(int id)
    {
        var award = await _context.Awards.Include(e => e.AwardsDocuments).Where(e => e.Id == id).ProjectTo<AwardDto>(_mapper.ConfigurationProvider).ToListAsync();

        return award;
    }

    //создание награды
    public async Task<Award> CreateAwardAsync([FromBody] AwardCreateUpdateDto awardCreateUpdateDto)
    {
        var award = _mapper.Map<Award>(awardCreateUpdateDto);
        _context.Awards.Add(award);
        await _context.SaveChangesAsync();

        return award;
    }

    //изменение награды
    public async Task<bool> UpdateAwardByIdAsync(int id, [FromBody] AwardCreateUpdateDto awardCreateUpdateDto)
    {
        var award = _context.Awards.FirstOrDefault(e => e.Id == id);

        if (award == null)
        {
            return false;
        }
        _mapper.Map(awardCreateUpdateDto, award);

        await _context.SaveChangesAsync();

        return true;
    }

    //удаление награды
    public async Task<bool> DeleteAwardByIdAsync(int id)
    {
        var award = _context.Awards.FirstOrDefault(e => e.Id == id);

        if (award == null)
        {
            return false;
        }

        _context.Awards.Remove(award);

        await _context.SaveChangesAsync();

        return true;
    }
}