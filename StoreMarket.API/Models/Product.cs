using ConsoleStoreEngine.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleStoreEngine.Products
{
    [JsonDerivedType(typeof(Food), typeDiscriminator: "food")]
    [JsonDerivedType(typeof(Electronics), typeDiscriminator: "electronics")]
    [JsonDerivedType(typeof(Clothing), typeDiscriminator: "clothing")]

    public abstract class Product
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public int Id { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            string output = $"ID: {Id} | Name: {Name} | Price: {Price} | Quantity: {Quantity}";
            return output;
        }
        public void UpdateQuantity(int quantity)
        {
            Quantity += quantity;
        }
        public void UpdatePrice(decimal price)
        {
            Price = price;
        }

        public void ApplyDiscount(decimal percentage)
        {
            Price -= Price * (percentage / 100);
        }


    }
}
class Food : Product
{
    public DateTime ExpiryDate { get; private set; }
    public Food(string name, decimal price, int quantity, DateTime expiryDate) : base(name, price, quantity)
    {
        this.ExpiryDate = expiryDate;
    }
    public override string ToString()
    {
        return base.ToString() + $" | Expiry Date: {ExpiryDate}";
    }
}
class Electronics : Product
{
    public DateTime ManufactureDate { get; private set; }

    public Electronics(string name, decimal price, int quantity, DateTime manufactureDate) : base(name, price, quantity)
    {
        ManufactureDate = manufactureDate;
    }

    public override string ToString()
    {

        return base.ToString() + $" | Manufacture Date: {ManufactureDate}";
    }
}
class Clothing : Product
{
    public string Size { get; private set; }

    public Clothing(string name, decimal price, int quantity, string size) : base(name, price, quantity)
    {
        Size = size;
    }
    public override string ToString()
    {

        return base.ToString() + $" | Size: {Size}";
    }

}