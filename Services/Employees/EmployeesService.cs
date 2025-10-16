using System.Linq.Dynamic.Core;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

namespace NewReestrAsp.Services;

public class EmployeesService
{
    private readonly ReestrContext _context;
    private readonly IMapper _mapper;

    public EmployeesService(ReestrContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    //Метод добавления массива пути
    protected List<EmployeeDto> GetEmployeeWhithUnitsName(List<EmployeeDto> employees)
    {
        var units = _context.Units
            .Select(u => new { u.Id, u.UnitName, u.Path })
            .ToList();

        var mapUnitsById = units.ToDictionary(u => u.Id, u => u.Path);
        var mapUnitsByPath = units.ToDictionary(u => u.Path ?? string.Empty, u => u.UnitName ?? string.Empty);

        foreach (var emp in employees)
        {
            if (emp.id_unit == null) continue;
            if (!mapUnitsById.TryGetValue(emp.id_unit.Value, out var path) || string.IsNullOrEmpty(path))
                continue;

            var names = new List<string>();
            var parts = path.Split('.');
            for (int i = 0; i < parts.Length; i++)
            {
                var subPath = string.Join('.', parts.Take(i + 1));
                if (mapUnitsByPath.TryGetValue(subPath, out var unitName))
                    names.Add(unitName);
            }

            emp.unit_names = names;
        }
        return employees;
    }


    //Вывод сотрудников по страницам
    public async Task<List<EmployeeDto>> GetEmployeesAsync(int page, int pageSize, string field = "Id", string order = "asc")
    {
        var sort = $"{field} {order}";
        var employees = await _context.GovernmentEmployees.Include(e => e.GovernmentEmployeesEducations).OrderBy(sort).Skip((page - 1) * pageSize).Take(pageSize).ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToListAsync();

        return GetEmployeeWhithUnitsName(employees);
    }

    //Получение сотрудника по id
    public async Task<List<EmployeeDto>> GetEmployeeByIdAsync(int id)
    {
        var employees = await _context.GovernmentEmployees.Include(e => e.GovernmentEmployeesEducations).Where(e => e.Id == id).ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider).ToListAsync();

        return GetEmployeeWhithUnitsName(employees);
    }

    //Создание сотрудника
    public async Task<GovernmentEmployee> CreateEmployeeAsync([FromBody] EmployeeCreateDto newEmployeeDto)
    {
        var employee = _mapper.Map<GovernmentEmployee>(newEmployeeDto);
        _context.GovernmentEmployees.Add(employee);
        await _context.SaveChangesAsync();


        return employee;
    }

    public async Task<bool> UpdateEmployeeAsync(int id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
    {
        var employee = _context.GovernmentEmployees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return false;
        }
        _mapper.Map(employeeUpdateDto, employee);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = _context.GovernmentEmployees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return false;
        }

        _context.GovernmentEmployees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }
}