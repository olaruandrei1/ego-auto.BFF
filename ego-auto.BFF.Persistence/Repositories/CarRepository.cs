using ego_auto.BFF.Application.Contracts;

namespace ego_auto.BFF.Persistence.Repositories;

public sealed class CarRepository(IConnectionFactory _connectionFactory) : ICarRepository
{
}
