# Foreword
While it is true that the composition (see also Inversion of Control or Dependency Injection) provides an abstraction level which, in the beginning, may be hard to understand with respect to the way it works, in the end it makes the application easier to keep under control, more extensible, more maintainable, and, very important, easier to unit test.

# Application services
A Kephas application uses internally all kinds of services, built-in and custom ones. Structurally, an **application service** has a *service contract* (an interface) declaring its API and one or more *service implementations* of this service contract. A good design keeps the services loosely coupled, ideally with no dependencies at the contract level; this approach has the big advantage of allowing the replacement of implementations due to new or changed requirements with no or minimum side-effects.

> Consuming an application service implies using its contract and never its implementation.

## Aims of Kephas composition
* Declare the application service