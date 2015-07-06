# Application services
A Kephas application uses internally all kinds of services, built-in and custom ones. Structurally, an **application service** has a *service contract* (an interface) declaring its API and one or more *service implementations* of this service contract. A good design keeps the services loosely coupled, ideally with no dependencies at the contract level; this approach has the big advantage of allowing the replacement of implementations due to new or changed requirements with no or minimum side-effects.

> Consuming an application service implies using its contract and never its implementation.

## Aims of application services design
* Support metadata
* Declare the expected behavior at the service contract level, not at the implementation level
* Possibility to override a service implementation in a declarative way
* Possibility to prioritize the service implementations where a collection of them should be used