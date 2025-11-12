namespace Hospital.Contracts.Dto;

/// <summary>
/// Data transfer object for a specialization.
/// </summary>
/// <param name="Name">The name of the specialization.</param>
public record SpecializationDto(string Name);

public record SpecializationResponseDto(
    Guid Id,
    string Name
    );