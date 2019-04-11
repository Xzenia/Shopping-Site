
public class Item
{
    private int id;
    private string name;
    private double pricePerItem;
    private int quantity;
    private string productImagePath;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public double PricePerItem
    {
        get
        {
            return pricePerItem;
        }

        set
        {
            pricePerItem = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string ProductImagePath
    {
        get
        {
            return productImagePath;
        }

        set
        {
            productImagePath = value;
        }
    }
}