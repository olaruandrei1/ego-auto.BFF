using ego_auto.BFF.Application.Contracts;
using ego_auto.BFF.Domain.Common;
using ego_auto.BFF.Domain.Entities;
using ego_auto.BFF.Domain.Requests;
using ego_auto.BFF.Domain.Responses;

namespace ego_auto.BFF.Application.Implementations;

public class VehicleService(IVehicleRepository _vehicleRepository) : IVehicleService
{
    public async Task<CustomResponse<PaginatedResult<Vehicle>>> GetVehiclesAsync(GetVehiclesRequest request)
    => CustomResponse<PaginatedResult<Vehicle>>.IsSuccess
        (
            await _vehicleRepository.GetVehiclesAsync(request)
        );

    public async Task<CustomResponse<Vehicle>> GetVehicleAsync(int id)
    => CustomResponse<Vehicle>.IsSuccess
        (
            await _vehicleRepository.GetVehicleByIdAsync(id)
        );

    public async Task<CustomResponse> UpsertVehicleAsync(VehicleUpsertRequest request)
    {
        await _vehicleRepository.UpsertVehicleAsync(request);

        return CustomResponse.IsSuccess
                (
                    customProp: request.VehicleId.HasValue ? 
                    string.Format("Vehicle with id {0} was updated successfully!", request.VehicleId) :
                    string.Format("{0} was added successfully", request.Model)
                );
    }

    public async Task<CustomResponse> DeleteVehicleAsync(int id)
    {
        await _vehicleRepository.DeleteVehicleAsync(id);

        return CustomResponse.IsSuccess();
    }
}
