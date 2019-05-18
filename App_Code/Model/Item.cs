
public class Item
{
    private int id;
    private string name;
    private double pricePerItem;
    private string description;
    private int quantity;
    private string productImagePath;
    private double salePrice;

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

    public string Description
    {
        get { return description; }
        set { description = value; }
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

    public double SalePrice
    {
        get { return salePrice; }
        set { salePrice = value; }
    }
}