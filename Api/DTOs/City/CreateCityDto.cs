namespace Api.DTOs.City;

public record CreateCityDto(
    string Name,
    int RegionId
);
