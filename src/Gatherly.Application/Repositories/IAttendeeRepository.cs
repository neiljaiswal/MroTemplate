using Gatherly.Domain.Entities;

namespace Gatherly.Application.Repositories;

public interface IAttendeeRepository
{
    void Add(Attendee attendee);
}