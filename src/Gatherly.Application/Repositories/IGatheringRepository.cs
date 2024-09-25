using Gatherly.Domain.Entities;

namespace Gatherly.Application.Repositories;

public interface IGatheringRepository
{
    Task<Gathering?> GetByIdWithCreatorAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Gathering gathering);
}