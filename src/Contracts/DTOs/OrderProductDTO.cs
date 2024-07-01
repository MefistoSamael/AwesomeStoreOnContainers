namespace Contracts.DTO;

public class OrderProductDTO
{
    required public string ProductId { get; set; }

    required public int PurchasedAmount { get; set; }
}
