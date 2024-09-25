using Gatherly.Domain.Entities;

namespace Gatherly.Application.Repositories;

public interface IInvitationRepository
{
    void Add(Invitation invitation);
}