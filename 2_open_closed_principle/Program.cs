using static DesignPatterns.ProductFilter;

namespace DesignPatterns;

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
        //foreach(var items in pf.F



        //better filter
        //using better filter
        BetterFilter bf = new();
        Console.WriteLine("Green products(new): ");

        foreach(var item in bf.Filter(products, new ColorSpecification(Color.Green)))
        {
            Console.WriteLine($"- {item.Name} is green");
        }


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
        foreach (var p in products)
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
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }

    }


    public class SizeSpecification : ISpecification<Product>
    {
        //Size size;

        public SizeSpecification()
        {

        }

        public bool IsSatisfied(Product t)
        {
            throw new NotImplementedException();
        }
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var item in items)
                if (spec.IsSatisfied(item))
                    yield return item;
        }
    }


   
}