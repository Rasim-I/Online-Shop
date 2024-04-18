using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OnlineShopModels.Models;

public class CartItem : INotifyPropertyChanged
{
    private Guid _id;
    private Guid _cartId;
    private Cart _cart;
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

    public Cart Cart
    {
        get => _cart;
        set => _cart = value;

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
        set
        { 
            _quantity = value;
            OnPropertyChanged(nameof(Quantity));
        } 
    }
    
    public CartItem(Guid cartId, Item item, Cart cart, int quantity)
    {
        Id = Guid.NewGuid();
        CartId = cartId;
        Item = item;
        Cart = cart;   //------
        Quantity = quantity;
    }
    
    public CartItem(){}
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}