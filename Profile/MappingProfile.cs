using AutoMapper;
using NewReestrAsp.Models;
using NewReestrAsp.Dtos;

namespace NewReestrAsp.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GovernmentEmployeesEducation, EmployeeEducationDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.id_employee, opt => opt.MapFrom(src => src.IdEmployee))
            .ForMember(dest => dest.education, opt => opt.MapFrom(src => src.Education))
            .ForMember(dest => dest.type_education, opt => opt.MapFrom(src => src.TypeEducation))
            .ForMember(dest => dest.educational_institution, opt => opt.MapFrom(src => src.EducationalInstitution))
            .ForMember(dest => dest.profession, opt => opt.MapFrom(src => src.Profession))
            .ForMember(dest => dest.type_profession, opt => opt.MapFrom(src => src.TypeProfession));

        CreateMap<EmployeeEducationCreateDto, GovernmentEmployeesEducation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // id ставит база
            .ForMember(dest => dest.IdEmployee, opt => opt.MapFrom(src => src.id_employee))
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.education))
            .ForMember(dest => dest.TypeEducation, opt => opt.MapFrom(src => src.type_education))
            .ForMember(dest => dest.EducationalInstitution, opt => opt.MapFrom(src => src.educational_institution))
            .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.profession))
            .ForMember(dest => dest.TypeProfession, opt => opt.MapFrom(src => src.type_profession));

        CreateMap<EmployeeEducationUpdateDto, GovernmentEmployeesEducation>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // id ставит база
            .ForMember(dest => dest.IdEmployee, opt => opt.Ignore())
            .ForMember(dest => dest.Education, opt => opt.MapFrom(src => src.education))
            .ForMember(dest => dest.TypeEducation, opt => opt.MapFrom(src => src.type_education))
            .ForMember(dest => dest.EducationalInstitution, opt => opt.MapFrom(src => src.educational_institution))
            .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.profession))
            .ForMember(dest => dest.TypeProfession, opt => opt.MapFrom(src => src.type_profession)).ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


        CreateMap<GovernmentEmployee, EmployeeDto>()
               .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.surname, opt => opt.MapFrom(src => src.Surname))
               .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.patronymic, opt => opt.MapFrom(src => src.Patronymic))
               .ForMember(dest => dest.birth_date, opt => opt.MapFrom(src => src.BirthDate))
               .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.post, opt => opt.MapFrom(src => src.Post))
               .ForMember(dest => dest.start_work_date, opt => opt.MapFrom(src => src.StartWorkDate))
               .ForMember(dest => dest.temp, opt => opt.MapFrom(src => src.Temp))
               .ForMember(dest => dest.number_phone_division, opt => opt.MapFrom(src => src.NumberPhoneDivision))
               .ForMember(dest => dest.addres, opt => opt.MapFrom(src => src.Addres))
               .ForMember(dest => dest.mobile_number, opt => opt.MapFrom(src => src.MobileNumber))
               .ForMember(dest => dest.id_unit, opt => opt.MapFrom(src => src.IdUnit))
               .ForMember(dest => dest.educations,
                          opt => opt.MapFrom(src => src.GovernmentEmployeesEducations));


        CreateMap<Unit, UnitDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.unit_name, opt => opt.MapFrom(src => src.UnitName))
                .ForMember(dest => dest.path, opt => opt.MapFrom(src => src.Path));

        CreateMap<Unit, UnitModalDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.unit_name, opt => opt.MapFrom(src => src.UnitName))
                .ForMember(dest => dest.path, opt => opt.MapFrom(src => src.Path));


        CreateMap<EmployeeCreateDto, GovernmentEmployee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // id ставит база
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.surname))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.patronymic))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.birth_date))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.gender))
            .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.StartWorkDate, opt => opt.MapFrom(src => src.start_work_date))
            .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
            .ForMember(dest => dest.NumberPhoneDivision, opt => opt.MapFrom(src => src.number_phone_division))
            .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.addres))
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.mobile_number))
            .ForMember(dest => dest.IdUnit, opt => opt.MapFrom(src => src.id_unit)).ReverseMap();

        CreateMap<EmployeeUpdateDto, GovernmentEmployee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // id ставит база
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.surname))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.patronymic))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.birth_date))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.gender))
            .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src.post))
            .ForMember(dest => dest.StartWorkDate, opt => opt.MapFrom(src => src.start_work_date))
            .ForMember(dest => dest.Temp, opt => opt.MapFrom(src => src.temp))
            .ForMember(dest => dest.NumberPhoneDivision, opt => opt.MapFrom(src => src.number_phone_division))
            .ForMember(dest => dest.Addres, opt => opt.MapFrom(src => src.addres))
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.mobile_number))
            .ForMember(dest => dest.IdUnit, opt => opt.MapFrom(src => src.id_unit))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}