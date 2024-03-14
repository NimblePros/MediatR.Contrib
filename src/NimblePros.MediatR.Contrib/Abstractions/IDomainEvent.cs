using MediatR;

namespace NimblePros.MediatR.Contrib.Abstractions;

/// <summary>
/// Marker interface for events fired from domain model types, typically
/// consumed within the domain model or at least within the bounded context.
/// </summary>
public interface IDomainEvent : INotification
{
}
