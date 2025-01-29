public class Feature
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Feature(string name, string description = "")
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return Description != "" ? $"{Name} ({Description})" : Name;
    }
}

public class House
{
    public string Material { get; }
    public List<Feature> Features { get; }

    public House(string material)
    {
        Material = material;
        Features = new List<Feature>();
    }

    public void AddFeature(Feature feature)
    {
        Features.Add(feature);
    }

    public override string ToString()
    {
        return $"Материал: {Material}, Дополнительные постройки: {string.Join(", ", Features)}";
    }
}

public class Catalog
{
    private readonly List<House> _houses = new List<House>();

    public void AddHouse(House house)
    {
        _houses.Add(house);
    }

    public void Display()
    {
        Console.WriteLine("Каталог домов:");
        if (_houses.Count == 0)
        {
            Console.WriteLine("Каталог пуст.");
            return;
        }
        foreach (var house in _houses.Select((house, index) => (house, index)))
        {
            Console.WriteLine($"Дом {house.index + 1}: {house.house}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        Catalog catalog = new Catalog();

        catalog.AddHouse(new House("камень")
        {
            Features = { new Feature("бассейн"), new Feature("гараж") }
        });

        catalog.AddHouse(new House("кирпич")
        {
            Features = { new Feature("палисадник"), new Feature("тропинка") }
        });

        catalog.AddHouse(new House("камень"));

        catalog.Display();
    }
}