# The big picture
## Foreword
While it is true that the composition (see also Inversion of Control or Dependency Injection) provides an abstraction level which, in the beginning, may be hard to understand with respect to the way it works, in the end it makes the application easier to keep under control, more extensible, more maintainable, and, very important, easier to unit test.

## Services
A Kephas application uses internally all kinds of services. An application service has a service contract (an interface) declaring its API and one or more implementations of this service contract.
Consuming an application service implies using its contract and never its implementation. This approach has the big advantage of making services loosely coupled, keeping them orthogonal as much as possible.

## Aims of Kephas composition
* Declare the application service