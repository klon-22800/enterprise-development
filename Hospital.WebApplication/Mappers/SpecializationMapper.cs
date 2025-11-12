using Hospital.Core.Domain.Models;
using Hospital.Contracts.Dto;

namespace Hospital.WebApplication.Mappers;

/// <summary>
/// Provides mapping methods for Specializations.
/// </summary>
public static class SpecializationMapper
{
    /// <summary>
    /// Converts an SpecializationDto to an Specialization domain model.
    /// </summary>
    public static Specialization ToDomain(this SpecializationDto dto) => new()
    {
        Name = dto.Name
    };

    /// <summary>
    /// Converts an Specialization to an SpecializationResponseDto.
    /// </summary>
    public static SpecializationResponseDto ToResponse(this Specialization specialization) => new(
        specialization.Id,
        specialization.Name
    );
}