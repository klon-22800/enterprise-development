using Hospital.Core.Domain.Models;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Mappers;

public static class SpecializationMapepr
{
    public static Specialization ToDomain(this SpecializationDto dto) => new()
    {
        Name = dto.Name
    };

    public static SpecializationResponseDto ToResponse(this Specialization specialization) => new(
        specialization.Id,
        specialization.Name
    );
}