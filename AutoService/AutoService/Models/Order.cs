namespace AutoService.Models;

public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public string ClientId { get; set; }
    public Client Client { get; set; }
    
    public string CarId { get; set; }
    public Car Car { get; set; }
}