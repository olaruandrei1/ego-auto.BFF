using ego_auto.BFF.Domain.Dtos;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Contracts;

public interface IVehicleService
{
    Task<CustomResponse<PaginatedResult<Vehicle>>> GetVehiclesAsync(GetVehiclesRequest request);
    Task<CustomResponse<Vehicle>> GetVehicleAsync(int id);
    Task<CustomResponse> UpsertVehicleAsync(VehicleUpsertDto request);
}
