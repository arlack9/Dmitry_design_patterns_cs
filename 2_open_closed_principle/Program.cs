﻿namespace DesignPatterns;

public enum Color
{
    Red, Green , Blue
}

public enum Size
{
    Small,Medium,Large,Huge
}

public class Product
{
    public string Name;
    public Color Color;
    public Size Size;

    public Product(string name, Color color, Size size)
    {
        if(name == null)
        {
            throw new ArgumentNullException("name");
        }

        Name = name;
        Color = color;
        Size = size;
    }
}


public class Demo
{
    static void Main(string[] args)
    {
        var apple = new Product("Apple",Color.Green,Size.Small);
        var tree = new Product("Tree", Color.Green, Size.Large);
        var house = new Product("House", Color.Blue, Size.Large);


        Product[] products = { apple, tree, house };

        var pf = new ProductFilter();
        Console.WriteLine("Green products (old)");

    }
}


public class ProductFilter
{
    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach (var p in products)
            if (p.Size == size)
                yield return p;
    }


    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
    {
        foreach(var p in products)
        {
            if (p.Size == size && p.Color == color)
                yield return p;
        }
    }


    //interfaces

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }


    //implementations

    public class ColorSpecification : ISpecification<Product>
    {

    }
}