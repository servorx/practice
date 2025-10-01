namespace Api.DTOs.Region;

public record UpdateRegionDto(
    int Id,
    string Name,
    int CountryId
);
