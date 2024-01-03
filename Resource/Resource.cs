namespace ResourceService.Resources;

public class Resource {
    public int Id { get; set; }
    public required int MemberId { get; set; }
    public required int EventId { get; set; }
    public required string ThingToBring { get; set; }
}
