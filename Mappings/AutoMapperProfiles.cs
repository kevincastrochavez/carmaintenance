using AutoMapper;
using CarMaintenance.Models.Domain;

namespace CarMaintenance.Repositories;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<MaintenanceRecord, MaintenanceRecordDto>().ReverseMap();
        CreateMap<AddMaintenanceRecordDto, MaintenanceRecord>().ReverseMap();
        CreateMap<UpdateMaintenanceRecordDto, MaintenanceRecord>().ReverseMap();

        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<AddCarDto, Car>().ReverseMap();
        CreateMap<UpdateCarDto, Car>().ReverseMap();
    }
}