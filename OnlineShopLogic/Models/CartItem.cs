namespace OnlineShopLogic.Models;

public class CartItem
{
    private Guid _id;
    private Guid _cartId;
    private Guid _itemId;
    private Item _item;
    private int _quantity;

    public Guid Id
    {
        get => _id;
        set => _id = value;
    }

    public Guid CartId
    {
        get => _cartId;
        set => _cartId = value;
    }

    public Guid ItemId
    {
        get => _itemId;
        set => _itemId = value;
    }

    public Item Item
    {
        get => _item;
        set
        {
            _item = value;
            ItemId = value.Id;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public CartItem(Guid cartId, Item item, int quantity)
    {
        Id = Guid.NewGuid();
        CartId = cartId;
        Item = item;
        Quantity = quantity;
    }
    
    public CartItem(){}
}