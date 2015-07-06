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

In case a new service implementation with the same contract is defined and the override priority is set to a higher value, than this service implementation will be used and the previous one will be ignored.

    /// <summary>
    /// Provides a custom implementation of the <see cref="IRequestProcessor"/> application service contract.
    /// </summary>
    [OverridePriority(Priority.High)]
    public class CustomRequestProcessor : IRequestProcessor
    {
        //...
    }

> This is a very powerful feature that allows the replacement of service implementation in a declarative way. A simple case is the replacement of the "Null" services provided by Kephas with real implementations. The "Null" services have always the lowest override priority.

## Multiple services with the same contract
If the application service contract should allow multiple registered service implementations, set the AllowMultiple option to true in the contract declaration.

Example: 

    [AppServiceContract(AllowMultiple = true)]

Note: generic application service contracts allow multiple registrations by default, because it is expected that multiple services will be defined with different actual generic type parameters.

## Composition constructor
If an application service has only one constructor, this constructor is used for composition. If multiple constructors are defined, the constructor annotated with `[CompositionConstructor]` is used.

## Composition metadata
Application services may indicate metadata attributes that they use. The following conventions are applied:
* The attributes must implement `IMetadataValue<TValue>`. The `Value` property will provide the value of the metadata key.
* The attribute type without the “Attribute” suffix will be the metadata key.
* When declaring the contract, the supported metadata attributes must be declared.
* The attributes are applied to the service implementations.

Example:

    /// <summary>
    /// Application service for request processing interception.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    [AppServiceContract(AllowMultiple = true, MetadataAttributes = new[] { typeof(ProcessingPriorityAttribute) })]
    public interface IRequestFilter<TRequest> : IRequestFilter
    {
    }

## Generic application service contracts
When exposing generic application service contracts, Kephas will export the parts using the generic interface, unless a `ContractType` is specified in the metadata.

Example of generic export contract type:

    /// <summary>
    /// Application service for handling requests.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    [AppServiceContract]
    public interface IRequestHandler<TRequest> : IRequestHandler
    {
    }

In this example, the request handlers are exporting using the generic IRequestHandler contract type.
Example of the non-generic export contract type:

    /// <summary>
    /// Application service for request processing interception.
    /// </summary>
    public interface IRequestProcessingFilter
    {
    }

    /// <summary>
    /// Application service for request processing interception.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    [AppServiceContract(AllowMultiple = true, 
        MetadataAttributes = new[] { typeof(ProcessingPriorityAttribute) }, 
        ContractType = typeof(IRequestProcessingFilter))]
    public interface IRequestProcessingFilter<TRequest> : IRequestProcessingFilter
        where TRequest : IRequest
    {
    }

In this second example, the request processing filters are exported using the non-generic `IRequestProcessingFilter` contract type, so that all of them can be collected by the composition using the non-generic contract, and later decisions may be taken based on the generic type metadata.
Additional to the metadata collected by using the MetadataAttributes declaration, Kephas collects also from the service implementations the actual generic types and adds them to the existing composition metadata. The following rules are applies:
* The actual generic parameter is the metadata value.
* The adjusted name of the generic parameter is the metadata key. The adjusted name is obtained by stripping the leading “T”, if specified, and appending “Type”, if not already there.
