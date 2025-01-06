using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;

namespace ego_auto.BFF.Application.Contracts;

public interface IVehicleRepository
{
    Task UpsertVehicleAsync(VehicleUpsertRequest model);
    Task<PaginatedResult<Vehicle>> GetVehiclesAsync(GetVehiclesRequest request);
    Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);
    Task DeleteVehicleAsync(int id);
}
