using Hospital.Core.Domain.Shared.Enums;
using Hospital.Grpc.Contracts;

/// <summary>
/// Класс для преобразования gRPC enum типов в доменные enum типы приложения.
/// </summary>
public static class EnumMappers
{
    /// <summary>
    /// Метод для перевода GenderGrpc в Gender
    /// </summary>
    public static Gender ToDomain(this GenderGrpc grpcGender) => grpcGender switch
    {
        GenderGrpc.Male => Gender.Male,
        GenderGrpc.Female => Gender.Female,
        _ => throw new ArgumentOutOfRangeException(nameof(grpcGender), grpcGender.ToString())
    };

    /// <summary>
    /// Метод для перевода BloodTypeGrpc в BloodType
    /// </summary>
    public static BloodType? ToDomain(this BloodTypeGrpc grpcBloodType) => grpcBloodType switch
    {
        BloodTypeGrpc.A => BloodType.A,
        BloodTypeGrpc.B => BloodType.B,
        BloodTypeGrpc.Ab => BloodType.AB,
        BloodTypeGrpc.O => BloodType.O,
        _ => null
    };

    /// <summary>
    /// Метод для перевода RhesusFactorGrpc в RhesusFactor
    /// </summary>
    public static RhesusFactor? ToDomain(this RhesusFactorGrpc grpcRhesus) => grpcRhesus switch
    {
        RhesusFactorGrpc.Positive => RhesusFactor.Positive,
        RhesusFactorGrpc.Negative => RhesusFactor.Negative,
        _ => null
    };
}
