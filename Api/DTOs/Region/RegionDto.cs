namespace Api.DTOs.Region;

public record RegionDto(
    int Id,
    string Name,
    int CountryId
);
