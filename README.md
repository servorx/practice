# API de prueba

Este proyecto es una **API de prueba** construida con **.NET 9**, diseñada con buenas prácticas como **Unit of Work**, **Repository Pattern**, **AutoMapper**, **FluentValidation** y soporte para **Swagger/OpenAPI**.

Sirve como base para proyectos más grandes donde se requiera una arquitectura limpia y escalable.

---

## 🚀 Tecnologías utilizadas

- **.NET 9 Web API**
- **Entity Framework Core** (con PostgreSQL)
- **Unit of Work & Repository Pattern**
- **AutoMapper** (mapeo entre entidades y DTOs)
- **FluentValidation** (validación de DTOs)
- **Swagger / OpenAPI** (documentación y pruebas de la API)
- **Rate Limiting** (protección contra abuso de peticiones)
- **CORS Policies** (control de orígenes permitidos)

---

## 📂 Estructura del proyecto

# File Tree: practice

```
├── .git/ 🚫 (auto-hidden)
├── Api/
│   ├── Auth/
│   │   └── AuthController.cs
│   ├── Controllers/
│   │   ├── BranchController.cs
│   │   ├── CityController.cs
│   │   ├── CompanyController.cs
│   │   ├── CountryController.cs
│   │   └── RegionController.cs
│   ├── DTOs/
│   │   ├── Auth/
│   │   │   ├── LoginRequestDto.cs
│   │   │   ├── LoginResponseDto.cs
│   │   │   └── RegisterUserDto.cs
│   │   ├── Branch/
│   │   │   ├── BranchDto.cs
│   │   │   ├── CreateBranchDto.cs
│   │   │   └── UpdateBranchDto.cs
│   │   ├── City/
│   │   │   ├── CityDto.cs
│   │   │   ├── CreateCityDto.cs
│   │   │   └── UpdateCityDto.cs
│   │   ├── Company/
│   │   │   ├── CompanyDto.cs
│   │   │   ├── CreateCompanyDto.cs
│   │   │   └── UpdateCompanyDto.cs
│   │   ├── Country/
│   │   │   ├── CountryDto.cs
│   │   │   ├── CreateCountryDto.cs
│   │   │   └── UpdateCountryDto.cs
│   │   └── Region/
│   │       ├── CreateRegionDto.cs
│   │       ├── RegionDto.cs
│   │       └── UpdateRegionDto.cs
│   ├── Extensions/
│   │   └── ApplicationServiceExtensions.cs
│   ├── Mappings/
│   │   ├── BranchProfile.cs
│   │   ├── CityProfile.cs
│   │   ├── CompanyProfile.cs
│   │   ├── CountryProfile.cs
│   │   └── RegionProfile.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── bin/ 🚫 (auto-hidden)
│   ├── obj/ 🚫 (auto-hidden)
│   ├── .dockerignore
│   ├── Api.Dockerfile
│   ├── Api.csproj
│   ├── Api.http
│   ├── Program.cs
│   ├── appsettings.Development.json
│   └── appsettings.json
├── Application/
│   ├── Abstractions/
│   │   ├── IAuthSerivce.cs
│   │   ├── IBranchRepository.cs
│   │   ├── ICityRepository.cs
│   │   ├── ICompanyRepository.cs
│   │   ├── ICountryRepository.cs
│   │   ├── IRegionRepository.cs
│   │   ├── IUnitOfWork.cs
│   │   └── IUserRepository.cs
│   ├── Branches/
│   │   ├── CreateBranch.cs
│   │   ├── CreateBranchHandler.cs
│   │   ├── CreateBranchValidator.cs
│   │   ├── UpdateBranch.cs
│   │   ├── UpdateBranchHandler.cs
│   │   └── UpdateBranchValidator.cs
│   ├── Cities/
│   │   ├── CreateCity.cs
│   │   ├── CreateCityHandler.cs
│   │   ├── CreateCityValidator.cs
│   │   ├── UpdateCity.cs
│   │   ├── UpdateCityHandler.cs
│   │   └── UpdateCityValidator.cs
│   ├── Companies/
│   │   ├── CreateCompany.cs
│   │   ├── CreateCompanyHandler.cs
│   │   ├── CreateCompanyValidator.cs
│   │   ├── UpdateCompany.cs
│   │   ├── UpdateCompanyHandler.cs
│   │   └── UpdateCompanyValidator.cs
│   ├── Countries/
│   │   ├── CreateCountry.cs
│   │   ├── CreateCountryHandler.cs
│   │   ├── CreateCountryValidator.cs
│   │   ├── UpdateCountry.cs
│   │   ├── UpdateCountryHandler.cs
│   │   └── UpdateCountryValidator.cs
│   ├── Regions/
│   │   ├── CreateRegion.cs
│   │   ├── CreateRegionHandler.cs
│   │   ├── CreateRegionValidator.cs
│   │   ├── UpdateRegion.cs
│   │   ├── UpdateRegionHandler.cs
│   │   └── UpdateRegionValidator.cs
│   ├── bin/ 🚫 (auto-hidden)
│   ├── obj/ 🚫 (auto-hidden)
│   └── Application.csproj
├── Domain/
│   ├── Entities/
│   │   ├── Branch.cs
│   │   ├── City.cs
│   │   ├── Company.cs
│   │   ├── Country.cs
│   │   ├── Region.cs
│   │   └── User.cs
│   ├── ValueObjects/
│   │   ├── Adress.cs
│   │   ├── ContactName.cs
│   │   ├── Email.cs
│   │   ├── EntityName.cs
│   │   ├── EntityNumber.cs
│   │   ├── Password.cs
│   │   ├── PhoneNumber.cs
│   │   ├── Role.cs
│   │   └── UkNiu.cs
│   ├── bin/ 🚫 (auto-hidden)
│   ├── obj/ 🚫 (auto-hidden)
│   └── Domain.csproj
├── Infrastructure/
│   ├── Data/
│   │   ├── ddl.sql
│   │   └── dml.sql
│   ├── Persistence/
│   │   ├── Configurations/
│   │   │   ├── BranchConfig.cs
│   │   │   ├── CityConfig.cs
│   │   │   ├── CompanyConfig.cs
│   │   │   ├── CountryConfig.cs
│   │   │   ├── RegionConfig.cs
│   │   │   └── UserConfig.cs
│   │   ├── Repositories/
│   │   │   ├── BranchRepository.cs
│   │   │   ├── CityRepository.cs
│   │   │   ├── CompanyRepository.cs
│   │   │   ├── CountryRepository.cs
│   │   │   ├── RegionRepository.cs
│   │   │   └── UserRepository.cs
│   │   └── AppDbContext.cs
│   ├── UnitOfWork/
│   │   └── UnitOfWork.cs
│   ├── bin/ 🚫 (auto-hidden)
│   ├── obj/ 🚫 (auto-hidden)
│   ├── services/
│   │   └── JwtService.cs
│   └── Infrastructure.csproj
├── docker/
│   └── docker-compose.yml
├── .gitignore
├── README.md
├── practice.sln
└── todo.md
```

---
*Generated by FileTree Pro Extension*


## ⚙️ Configuración

### 1. Clonar el repositorio
```bash
git clone <url>
cd <nombre-del-proyecto>
```

### 2. Configurar la base de datos
```json
"ConnectionStrings": {
  "Postgres": "Host=localhost;Database=cleanshop_db;Username=postgres;Password=tu_password"
}
```

### 3. Crear la base de datos
```bash
docker-compose up -d
```

### 4. Ejecutar la aplicación
```bash
dotnet run
```

## Swagger
Swagger se puede acceder a través de la siguiente URL:

`https://localhost:5001/swagger/index.html`