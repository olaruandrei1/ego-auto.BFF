using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests.Vehicle;

namespace ego_auto.BFF.Application.Contracts.Persistence;

public interface IVehicleRepository
{
    Task UpsertVehicleAsync(VehicleUpsertRequest model);
    Task<PaginatedResult<Vehicle>> GetVehiclesAsync(GetVehiclesRequest request);
    Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);
    Task DeleteVehicleAsync(int id);
}
