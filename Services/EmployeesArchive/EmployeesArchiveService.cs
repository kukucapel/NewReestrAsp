using System.Linq.Dynamic.Core;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

namespace NewReestrAsp.Services;

public class EmployeesArchiveService
{
    private readonly ReestrContext _context;
    private readonly IMapper _mapper;

    public EmployeesArchiveService(ReestrContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //Вывод сотрудников из архива по страницам 
    public async Task<List<EmployeeArchiveDto>> GetEmployeesArchiveAsync(int page, int pageSize, string field = "Id", string order = "asc")
    {
        var sort = $"{field} {order}";
        var employees = await _context.GovernmentEmployeesArchives.Include(e => e.GovernmentEmployeesEducationArchives).OrderBy(sort).Skip((page - 1) * pageSize).Take(pageSize).ProjectTo<EmployeeArchiveDto>(_mapper.ConfigurationProvider).ToListAsync();

        return employees;
    }

    //Вывод сотрудника из архива по id
    public async Task<List<EmployeeArchiveDto>> GetEmployeeArchiveByIdAsync(int id)
    {
        var employees = await _context.GovernmentEmployeesArchives.Include(e => e.GovernmentEmployeesEducationArchives).Where(e => e.Id == id).ProjectTo<EmployeeArchiveDto>(_mapper.ConfigurationProvider).ToListAsync();

        return employees;
    }

    //Обновление сотрудника из архива
    public async Task<bool> UpdateEmployeeArchiveAsync(int id, [FromBody] EmployeeArchiveUpdateDto employeeArchiveUpdateDto)
    {
        var employee = _context.GovernmentEmployeesArchives.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return false;
        }
        _mapper.Map(employeeArchiveUpdateDto, employee);

        await _context.SaveChangesAsync();

        return true;
    }
}