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

### Owner Controller
- **[Get] /Owner/userinfo** - Owner Details information retrieve
- **[Get] /Owner/showAllApartments** - Show all apartments uploaded by the requested owner
- **[Post] /Owner/AddApartment** - Apartment uploaded by the owner
- **[Delete] /Owner/DeleteApartment/:id** - Delete apartment with id
- **[Get] /Owner/Apartment/:id** - Get Apartment by id
- **[Put] /Owner/Apartment/:id** - update apartment by id

### Renter Controller
- **[Get] /Renter/Apartment/:id** - Get Apartment with id
- **[Get] "Renter/allApartments/ViewAllApartment** - Get all apartments &  added filtration if provided

## Object Diagram
![Blank diagram](https://github.com/ishanuzzal/HomeRenterService/assets/70796394/d1ed90dd-d257-452e-bb21-474786461a9b)
