# Sidub Platform - Authentication - Gremlin

This repository contains the Gremlin authentication library for the Sidub
Platform. It supports authentication when communicating with Gremlin
data services.

## Main Components
Introduced within this package is the `GremlinPasswordCredential` which
supports authentication against Gremlin data services. This is a simple
implementation involving a single password / key for access.

Service registration is required to register the Gremlin authentication
handlers by calling `IServiceCollection.AddSidubAuthenticationForGremlin();`.

## License
This project is dual-licensed under the AGPL v3 or a proprietary license. For
details, see [https://sidub.ca/licensing](https://sidub.ca/licensing) or the 
LICENSE.txt file.
