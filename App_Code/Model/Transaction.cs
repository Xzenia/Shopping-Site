using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public class Transaction
{
    private int memberId;

    public int MemberId
    {
        get { return memberId; }
        set { memberId = value; }
    }
    private string date;

    public string Date
    {
        get { return date; }
        set { date = value; }
    }
    private string time;

    public string Time
    {
        get { return time; }
        set { time = value; }
    }
    private string fullName;

    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }
    private string itemName;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    private double pricePerItem;

    public double PricePerItem
    {
        get { return pricePerItem; }
        set { pricePerItem = value; }
    }
    private double totalItemPrice;

    public double TotalItemPrice
    {
        get { return totalItemPrice; }
        set { totalItemPrice = value; }
    }
    private double totalTransactionPrice; 

    public double TotalTransactionPrice
    {
        get { return totalTransactionPrice; }
        set { totalTransactionPrice = value; }
    }
}