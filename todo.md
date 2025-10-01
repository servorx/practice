## 📌 1. Domain — Entities & ValueObjects
- [x] Crear el ddl.sql en `Infrastructure/Data`
- [x] Crear carpeta `Domain/Entities`
  - [x] `Country.cs`
  - [x] `Region.cs`
  - [x] `City.cs`
  - [x] `Company.cs`
  - [x] `Branch.cs`
- [x] Crear carpeta `Domain/ValueObjects`

## 📌 2. Infrastructure — Persistence
- [x] Crear `AppDbContext` en `Infrastructure/Persistence`
- [x] Configurar DbSets para todas las entidades
- [x] Crear carpeta `Configurations`
  - [x] `CountryConfiguration.cs`
  - [x] `RegionConfiguration.cs`
  - [x] `CityConfiguration.cs`
  - [x] `CompanyConfiguration.cs`
  - [x] `BranchConfiguration.cs`
- [x] Usar Fluent API para llaves primarias, foráneas y restricciones
- [x] Verificar conexión con `appsettings.json`

---

## 📌 3. Application — Abstractions
- [ ] Crear interfaces en `Application/Abstractions`
  - [ ] `ICountryRepository.cs`
  - [ ] `IRegionRepository.cs`
  - [ ] `ICityRepository.cs`
  - [ ] `ICompanyRepository.cs`
  - [ ] `IBranchRepository.cs`
- [ ] Definir `IUnitOfWork.cs` con métodos `SaveChangesAsync()`

---

## 📌 4. Infrastructure — Repositories & Unit of Work
- [ ] Implementar repositorios en `Infrastructure/Repositories`
  - [ ] `CountryRepository.cs`
  - [ ] `RegionRepository.cs`
  - [ ] `CityRepository.cs`
  - [ ] `CompanyRepository.cs`
  - [ ] `BranchRepository.cs`
- [ ] Implementar `UnitOfWork` en `Infrastructure/UnitOfWork`

---

## 📌 5. Application — Handlers (Casos de uso / CQRS)
- [ ] Crear carpeta `Application/Handlers/Countries`
  - [ ] `CreateCountryHandler.cs`
  - [ ] `GetCountriesHandler.cs`
  - [ ] `UpdateCountryHandler.cs`
  - [ ] `DeleteCountryHandler.cs`
- [ ] Repetir patrón para:
  - [ ] Regions
  - [ ] Cities
  - [ ] Companies
  - [ ] Branches

---

## 📌 6. Api Layer
- [ ] Crear carpeta `Api/DTOs`
  - [ ] `CountryDto.cs`
  - [ ] `RegionDto.cs`
  - [ ] `CityDto.cs`
  - [ ] `CompanyDto.cs`
  - [ ] `BranchDto.cs`
- [ ] Crear carpeta `Api/Mappings`
  - [ ] Configurar AutoMapper Profile (Domain ↔ DTO)
- [ ] Crear carpeta `Api/Controllers`
  - [ ] `CountriesController.cs`
  - [ ] `RegionsController.cs`
  - [ ] `CitiesController.cs`
  - [ ] `CompaniesController.cs`
  - [ ] `BranchesController.cs`
- [ ] Configurar endpoints CRUD para cada entidad

---

## 📌 7. Dependency Injection (DI)
- [ ] Registrar DbContext en `Program.cs`
- [ ] Registrar UnitOfWork
- [ ] Registrar Repositories
- [ ] Registrar AutoMapper
- [ ] Registrar MediatR (si se usa para Handlers CQRS)

---

## 📌 8. Configuración & DevOps
- [ ] Crear `docker-compose.yml` con MySQL + Backend
- [ ] Configurar `appsettings.Development.json` con connection string
- [ ] Probar migraciones EF Core  
- [ ] Ejecutar migraciones en la base de datos

## 📌 9. Testing 
- [ ] Crear proyecto de pruebas unitarias
- [ ] Probar Handlers individualmente
- [ ] Probar Handlers CQRS
- [ ] Probar Repositorios con BD en memoria
- [ ] Testear Controllers vía integración (Swagger/Postman)

## 📌 10. Extras (opcional)
- [ ] Autenticación con JWT
- [ ] Paginación y filtros en endpoints
- [ ] Validaciones con FluentValidation
- [ ] Logging centralizado (Serilog)
- [ ] Documentación en Swagger



# TODO 
verificar si en la configuracion se debe de colocar el mapeo de los campos de la tabla o del ValueObjects

