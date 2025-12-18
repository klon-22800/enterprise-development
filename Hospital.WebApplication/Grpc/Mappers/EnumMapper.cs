using Hospital.Core.Domain.Shared.Enums;
using Hospital.Grpc.Contracts;

public static class EnumMappers
{
    public static Gender ToDomain(this GenderGrpc grpcGender) => grpcGender switch
    {
        GenderGrpc.Male => Gender.Male,
        GenderGrpc.Female => Gender.Female
    };

    public static BloodType? ToDomain(this BloodTypeGrpc grpcBloodType) => grpcBloodType switch
    {
        BloodTypeGrpc.A => BloodType.A,
        BloodTypeGrpc.B => BloodType.B,
        BloodTypeGrpc.Ab => BloodType.AB,
        BloodTypeGrpc.O => BloodType.O,
        _ => null
    };

    public static RhesusFactor? ToDomain(this RhesusFactorGrpc grpcRhesus) => grpcRhesus switch
    {
        RhesusFactorGrpc.Positive => RhesusFactor.Positive,
        RhesusFactorGrpc.Negative => RhesusFactor.Negative,
        _ => null
    };
}
