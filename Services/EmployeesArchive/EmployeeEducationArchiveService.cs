using Microsoft.AspNetCore.Mvc;
using NewReestrAsp.Dtos;
using NewReestrAsp.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace NewReestrAsp.Services;

public class EmployeeEducationArchiveService
{
    private readonly ReestrContext _contex;
    private readonly IMapper _mapper;

    public EmployeeEducationArchiveService(ReestrContext contex, IMapper mapper)
    {
        _contex = contex;
        _mapper = mapper;
    }

    //Создание образования    
    public async Task<bool> CreateEducationArchiveAsync(int idEmployee, EmployeeEducationCreateDto educationCreateDto)
    {
        educationCreateDto.id_employee = idEmployee;
        var employee = _contex.GovernmentEmployeesArchives.FirstOrDefault(e => e.Id == idEmployee);

        if (employee == null)
        {
            return false;
        }
        var education = _mapper.Map<GovernmentEmployeesEducationArchive>(educationCreateDto);
        _contex.GovernmentEmployeesEducationArchives.Add(education);
        await _contex.SaveChangesAsync();

        return true;
    }

    //обновление образования
    public async Task<bool> UpdateEducationArchiveAsync(int idEducation, EmployeeEducationUpdateDto employeeEducationUpdateDto)
    {
        var education = _contex.GovernmentEmployeesEducationArchives.FirstOrDefault(e => e.Id == idEducation);
        if (education == null)
        {
            return false;
        }
        _mapper.Map(employeeEducationUpdateDto, education);

        await _contex.SaveChangesAsync();

        return true;
    }

    //Удаление образования
    public async Task<bool> DeleteEducationArchiveAsync(int idEducation)
    {
        var education = _contex.GovernmentEmployeesEducationArchives.FirstOrDefault(e => e.Id == idEducation);

        if (education == null)
        {
            return false;
        }
        _contex.GovernmentEmployeesEducationArchives.Remove(education);
        await _contex.SaveChangesAsync();

        return true;
    }
}