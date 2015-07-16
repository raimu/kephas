While it is true that the composition (see also Inversion of Control or Dependency Injection) provides an abstraction level which, in the beginning, may be hard to understand with respect to the way it works, in the end it makes the application easier to keep under control, more extensible, more maintainable, and, very important, easier to unit test.

## Aims for composition
* Be implementation agnostic. This means that any DI/IoC/Composition framework could be used, provided that specific adapters are implemented.
* Write as little wire-up code as possible, ideally make the composition discover the parts "magically".
* Use conventions and fluent configuration for defining them.
* Support by default application services.

## The infrastructure
The infrastructure for composition includes:
* The interface *IConventionsRegistrar*, which is the contract for registering composition conventions.
* The interface *IConventionsBuilder*, which is the contract for defining conventions using a fluent API.
* The interface *ICompositionContainer*, which is the contract for components providing composition hosting.
* The class *CompositionContainerBuilderBase*, which provides a base implementation for builders of composition containers.

How the composition infrastructure works:

1. All the convention registrars are collected (simply all the classes implementing *IConventionRegistrar*) and then they are invoked to register the conventions.

1. The composition container builder registers the log manager, the configuration manager, and the platform manager with factory export providers.

1. The composition container builder registers all application services [link] according to their metadata provided by the [AppServiceContract] attribute.

1. The composition container is built using the provided conventions.

1. And last, the composition container registers itself as the service exporting *ICompositionContainer*.

### Recommendations:
* There is no restriction about the number of convention registrars per assembly nor what those registrars should register. However, to keep the things under control, a registrar should not register conventions for components outside the scope of the assembly where it is defined and, also, it is recommended to have one registrar per assembly.
* For components participating in composition, if possible, import the required services in the constructor. By using this approach it is clearly defined what is required for the component to function properly and also specific checks may be performed at the constructor level regarding imported services. However, if there are a lot of dependencies, the constructor may not be very appropriate due to an ugly signature, therefore in this case it is acceptable to use either property import or a combination of them.
* Prefer conventions over attributes. The code becomes clearer and more concise, and the dependencies on specific IoC containers will diminish.

## Part configuration
### Composition constructor
If an application service has only one constructor, this constructor is used for composition. If multiple constructors are defined, the constructor annotated with `[CompositionConstructor]` is used.

## Concrete implementations
Kephas provides by default only composition contracts and base functionality around this contracts. A concrete implementation should take care of the following:
* The composition container should export itself as a shared service for the ICompositionContainer contact, so that services requiring the composition container get this service injected. Accessing ambient services (like AmbientServices.Instance.CompositionContainer [link]) makes unit testing very hard.
* Use a composition container builder derived from the one provided as base, to have access to all the features it provides, including the registration of application services.

### Managed Extensibility Framework (MEF, Microsoft.Composition)
Kephas provides a composition implementation based on the Managed Extensibility Framework for Windows Store.
