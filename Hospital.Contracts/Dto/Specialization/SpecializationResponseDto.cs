namespace Hospital.Contracts.Dto.Specialization;

/// <summary>
/// Data transfer object for a specialization.
/// </summary>
/// <param name="Name">The name of the specialization.</param>

public record SpecializationResponseDto(
    Guid Id,
    string Name
    );