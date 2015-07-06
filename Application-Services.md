A Kephas application uses internally all kinds of services, built-in and custom ones. Structurally, an **application service** has a *service contract* (an interface) declaring its API and one or more *service implementations* of this service contract. A good design keeps the services loosely coupled, ideally with no dependencies at the contract level; this approach has the big advantage of allowing the replacement of implementations due to new or changed requirements with no or minimum side-effects.

> Consuming an application service implies using its contract and never its implementation.

# Aims of application services design
* Support metadata.
* Declare the expected behavior at the service contract level, not at the implementation level.
* Possibility to override a service implementation in a declarative way.
* Possibility to prioritize the service implementations where a collection of them should be used.

# Steps for defining an application service

1. Define the application service contract and configure it using the `[AppServiceContract]` or `[SharedAppServiceContract]` attributes (Allow multiple: yes/no).

2. Implement one or more application services based on the contract defined in the step above. Note: for contracts not allowing multiple service implementations, it is a recommended practice to decorate the service implementation with the `[OverridePriority]` attribute.

3. Consume the service.

# Configure the application services
## Override priorities

An override priority is used for services not allowing multiple implementations at the same time, to ensure a deterministic identification of the desired service. The override priority attribute is applied on the service implementation.
Kephas exposes its default services either with a lowest override priority (for example for null services), or with a low priority (the rest of them), to allow an uncomplicated override, because when an override priority is not provided, the normal value is used in this case.

Example:

    /// <summary>
    /// Application service for processing requests.
    /// </summary>
    [SharedAppServiceContract]
    public interface IRequestProcessor : IAsyncRequestProcessor
    {
        /// <summary>
        /// Processes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The response.</returns>
        IResponse Process(IRequest request);
    }

    /// <summary>
    /// Provides the default implementation of the <see cref="IRequestProcessor"/> application service contract.
    /// </summary>
    [OverridePriority(Priority.Low)]
    public class DefaultRequestProcessor : IRequestProcessor
    {
        //...
    }
