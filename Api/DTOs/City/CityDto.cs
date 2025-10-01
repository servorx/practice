namespace Api.DTOs.City;

public record CityDto(
    int Id,
    string Name,
    int RegionId,
    string RegionName
);
