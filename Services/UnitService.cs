using System.Linq.Dynamic.Core;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using NewReestrAsp.Dtos;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace NewReestrAsp.Services;

public class UnitService
{
    private readonly ReestrContext _context;
    private readonly IMapper _mapper;
    public UnitService(ReestrContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<UnitDto>> GetUnitWithEmployee()
    {
        // 1. Получаем все юниты
        var units = await _context.Units
            .Select(u => new
            {
                u.Id,
                u.UnitName,
                u.Path
            })
            .ToListAsync();

        // 2. Получаем всех сотрудников + их образования
        var employees = await _context.GovernmentEmployees
            .Include(e => e.GovernmentEmployeesEducations)
            .ToListAsync();

        // 3. Строим словари юнитов
        var mapUnitsByPath = new Dictionary<string, UnitDto>();
        var mapUnitsById = new Dictionary<int, string?>();

        foreach (var u in units)
        {
            var path = u.Path ?? string.Empty;
            var dto = new UnitDto
            {
                id = u.Id,
                unit_name = u.UnitName,
                path = path,
                self_employees = 0,
                total_employees = 0,
                employees = new List<EmployeeDto>(),
                children = new List<UnitDto>()
            };

            mapUnitsByPath[path] = dto;
            mapUnitsById[u.Id] = path;
        }

        // 4. Раскладываем сотрудников по юнитам
        foreach (var emp in employees)
        {
            if (!emp.IdUnit.HasValue)
                continue;

            var unitId = emp.IdUnit.Value;
            if (!mapUnitsById.TryGetValue(unitId, out var empPath) || string.IsNullOrEmpty(empPath))
                continue;

            // 👇 добавляем сбор имён подразделений
            var unitNames = new List<string>();
            if (!string.IsNullOrEmpty(empPath))
            {
                var parts = empPath.Split('.');
                for (int i = 0; i < parts.Length; i++)
                {
                    var subPath = string.Join('.', parts.Take(i + 1));
                    if (mapUnitsByPath.TryGetValue(subPath, out var u))
                        unitNames.Add(u.unit_name ?? "");
                }
            }

            var empDto = new EmployeeDto
            {
                id = emp.Id,
                surname = emp.Surname,
                name = emp.Name,
                patronymic = emp.Patronymic ?? string.Empty,
                birth_date = emp.BirthDate,
                gender = emp.Gender,
                post = emp.Post ?? string.Empty,
                start_work_date = emp.StartWorkDate,
                temp = emp.Temp,
                number_phone_division = emp.NumberPhoneDivision ?? string.Empty,
                addres = emp.Addres ?? string.Empty,
                mobile_number = emp.MobileNumber ?? string.Empty,
                unit_names = unitNames,
                educations = emp.GovernmentEmployeesEducations?
                    .Select(ed => new EmployeeEducationDto
                    {
                        id = ed.Id,
                        id_employee = ed.IdEmployee,
                        education = ed.Education ?? string.Empty,
                        type_education = ed.TypeEducation ?? string.Empty,
                        educational_institution = ed.EducationalInstitution ?? string.Empty,
                        profession = ed.Profession ?? string.Empty,
                        type_profession = ed.TypeProfession ?? string.Empty
                    })
                    .ToList() ?? new List<EmployeeEducationDto>()
            };

            // Добавляем сотрудника в свой юнит
            if (mapUnitsByPath.TryGetValue(empPath, out var targetUnit))
                targetUnit.employees.Add(empDto);
        }

        // 5. Строим дерево юнитов
        var tree = new List<UnitDto>();

        foreach (var u in units)
        {
            var path = u.Path ?? string.Empty;
            if (!mapUnitsByPath.TryGetValue(path, out var node))
                continue;

            var parentPath = path.Contains('.')
                ? path.Substring(0, path.LastIndexOf('.'))
                : null;

            if (!string.IsNullOrEmpty(parentPath) && mapUnitsByPath.TryGetValue(parentPath, out var parent))
            {
                parent.children.Add(node);
            }
            else
            {
                tree.Add(node);
            }
        }

        // 6. Подсчитываем сотрудников рекурсивно
        int CountEmployees(UnitDto node)
        {
            node.self_employees = node.employees?.Count ?? 0;
            int total = node.self_employees ?? 0;

            foreach (var child in node.children)
            {
                total += CountEmployees(child);
            }

            node.total_employees = total;
            return total;
        }

        foreach (var root in tree)
        {
            CountEmployees(root);
        }

        return tree;
    }
    public async Task<List<UnitModalDto>> GetUnitModal(int id)
    {
        var units = await _context.Units
            .Select(u => new
            {
                u.Id,
                u.UnitName,
                u.Path
            })
            .ToListAsync();

        var mapUnitsByPath = new Dictionary<string, UnitModalDto>();
        var mapUnitsById = new Dictionary<int, string?>();

        foreach (var u in units)
        {
            var path = u.Path ?? string.Empty;
            var dto = new UnitModalDto
            {
                id = u.Id,
                unit_name = u.UnitName,
                path = path,
                is_active = u.Id == id ? 1 : 0,
                children = new List<UnitModalDto>()
            };

            mapUnitsByPath[path] = dto;
            mapUnitsById[u.Id] = path;
        }

        var tree = new List<UnitModalDto>();

        foreach (var u in units)
        {
            var path = u.Path ?? string.Empty;
            if (!mapUnitsByPath.TryGetValue(path, out var node))
                continue;

            var parentPath = path.Contains('.')
                ? path.Substring(0, path.LastIndexOf('.'))
                : null;

            if (!string.IsNullOrEmpty(parentPath) && mapUnitsByPath.TryGetValue(parentPath, out var parent))
            {
                parent.children.Add(node);
            }
            else
            {
                tree.Add(node);
            }
        }

        return tree;
    }
}