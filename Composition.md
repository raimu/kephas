# Foreword
While it is true that the composition (see also Inversion of Control or Dependency Injection) provides an abstraction level which, in the beginning, may be hard to understand with respect to the way it works, in the end it makes the application easier to keep under control, more extensible, more maintainable, and, very important, easier to unit test.

# Aims for composition
* Be implementation agnostic. This means that any DI/IoC/Composition framework could be used, provided that specific adapters are implemented.
* Write as little wire-up code as possible, ideally make the composition discover the parts "magically".
* Use conventions and fluent configuration for defining them.
* Support by default application services.

# MEF integration
Kephas provides a composition implementation based on the Managed Extensibility Framework for Windows Store.

# The infrastructure
The infrastructure for composition includes:
* The interface *IConventionsRegistrar*, which is the contract for registering composition conventions.
* The interface *IConventionsBuilder*, which is the contract for defining conventions using a fluent API.
* The interface *ICompositionContainer*, which is the contract for components providing composition hosting.
* The class *CompositionContainerBuilderBase*, which provides a base implementation for builders of composition containers.

How the composition infrastructure works:
1. All the convention registrars are collected (simply all the classes implementing IConventionRegistrar) and then they are invoked to register the conventions.

1. The composition container builder registers the log manager, the configuration manager, and the platform manager with factory export providers.

1. The composition container builder registers all application services [link] according to their metadata provided by the [AppServiceContract] attribute.

1. The composition container is built using the provided conventions.

1. And last, the composition container registers itself as the service exporting ICompositionContainer.
