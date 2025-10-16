using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace NewReestrAsp.Services;

public class EmployeeEducationService
{
    private readonly ReestrContext _contex;
    private readonly IMapper _mapper;

    public EmployeeEducationService(ReestrContext contex, IMapper mapper)
    {
        _contex = contex;
        _mapper = mapper;
    }

    //Создание образования    
    public async Task<bool> CreateEducationAsync(int idEmployee, EmployeeEducationCreateDto educationCreateDto)
    {
        var employee = _contex.GovernmentEmployees.FirstOrDefault(e => e.Id == idEmployee);

        if (employee == null)
        {
            return false;
        }
        var education = _mapper.Map<GovernmentEmployeesEducation>(educationCreateDto);
        _contex.GovernmentEmployeesEducations.Add(education);
        await _contex.SaveChangesAsync();

        return true;
    }

    //обновление образования
    public async Task<bool> UpdateEducationAsync(int idEducation, EmployeeEducationUpdateDto employeeEducationUpdateDto)
    {
        var education = _contex.GovernmentEmployeesEducations.FirstOrDefault(e => e.Id == idEducation);
        if (education == null)
        {
            return false;
        }
        _mapper.Map(employeeEducationUpdateDto, education);

        await _contex.SaveChangesAsync();

        return true;
    }

    //Удаление образования
    public async Task<bool> DeleteEducationAsync(int idEducation)
    {
        var education = _contex.GovernmentEmployeesEducations.FirstOrDefault(e => e.Id == idEducation);

        if (education == null)
        {
            return false;
        }
        _contex.GovernmentEmployeesEducations.Remove(education);
        await _contex.SaveChangesAsync();

        return true;
    }
}