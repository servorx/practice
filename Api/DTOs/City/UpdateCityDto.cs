namespace Api.DTOs.City;

public record UpdateCityDto(
    int Id,
    string Name,
    int RegionId
);
