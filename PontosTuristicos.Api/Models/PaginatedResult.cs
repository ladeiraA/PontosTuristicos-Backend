using System.Text.Json.Serialization;

namespace PontosTuristicos.Api.Models
{
    public class PaginatedResult<T>
    {
        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; set; } = new List<T>();
        
        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }
        
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }
        
        [JsonPropertyName("totalPages")]
        public int TotalPages => TotalItems > 0 && PageSize > 0 ? (int)Math.Ceiling(TotalItems / (double)PageSize) : 0;
        
        // Propriedades internas para cálculos (não serializadas no JSON)
        [JsonIgnore]
        public int PageSize { get; set; }
        
        [JsonIgnore]
        public bool HasNextPage => CurrentPage < TotalPages;
        
        [JsonIgnore]
        public bool HasPreviousPage => CurrentPage > 1;
    }
}