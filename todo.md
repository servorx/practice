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
- [x] Crear interfaces en `Application/Abstractions`
  - [x] `ICountryRepository.cs`
  - [x] `IRegionRepository.cs`
  - [x] `ICityRepository.cs`
  - [x] `ICompanyRepository.cs`
  - [x] `IBranchRepository.cs`
- [x] Definir `IUnitOfWork.cs` con métodos `SaveChangesAsync()`
- [] Crear `IUserRepository.cs`
---

## 📌 4. Infrastructure — Repositories & Unit of Work
<!-- se usa Task.CompletedTask porque se usa el UnitOfWork en el Handler -->
- [x] Implementar repositorios en `Infrastructure/Repositories`
  - [x] `CountryRepository.cs`
  - [x] `RegionRepository.cs`
  - [x] `CityRepository.cs`
  - [x] `CompanyRepository.cs`
  - [x] `BranchRepository.cs`
  - [] `UserRepository.cs`
- [x] Implementar `UnitOfWork` en `Infrastructure/UnitOfWork`

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
tengo que mirar bien los repositorios con lo de Task.CompletedTask o Task.CompletedTask;

cambiar todas las instancias de las interfaces a UnitOfWork