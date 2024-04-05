# HomeRenterService
HomeRenterService is a RESTful web API built using .NET, which provides a set of endpoints for owners to rent out their homes and for renters to find their desired homes conveniently. The service aims to offer nearby options within a short time frame and with reasonable pricing.
## Features
- JWT token-based authentication
- Generics repository pattern for database operations
- Model layer for defining entities and data contracts
- Separate Controller for Owners and Renters
- Swagger UI for easy API testing

## Api Endpoints
### Account Controller
- **[Post] /Owner/register** - Registration for Owner
- **[Post] /Renter/register** - Registration for Renter
- **[Post] /login** - authenticate user and return JWT token

