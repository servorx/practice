namespace Api.DTOs.Region;

public record CreateRegionDto(
    string Name,
    int CountryId
);
