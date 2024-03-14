using MediatR;

namespace NimblePros.MediatR.Contrib.Abstractions;

/// <summary>
/// Marker interface for Integration Event.
/// Integration Events span Bounded Contexts and/or Apps.
/// </summary>
public interface IIntegrationEvent : INotification
{
}
