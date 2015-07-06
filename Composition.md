# Foreword
While it is true that the composition (see also Inversion of Control or Dependency Injection) provides an abstraction level which, in the beginning, may be hard to understand with respect to the way it works, in the end it makes the application easier to keep under control, more extensible, more maintainable, and, very important, easier to unit test.

# Aims for composition
* Be implementation agnostic. This means that any DI/IoC/Composition framework could be used, provided that specific adapters are implemented.
* Write as little wire-up code as possible, ideally make the composition discover the parts "magically".
* Support by default application services.

# MEF integration
Kephas provides a composition implementation based on the Managed Extensibility Framework for Windows Store.