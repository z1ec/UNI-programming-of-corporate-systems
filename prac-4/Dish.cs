using System;

public enum DishCategory
{
    Drinks,
    Salads,
    ColdSnacks,
    HotSnacks,
    Soups,
    HotDishes,
    Desserts
}

public class Dish
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Ingredients { get; private set; } = string.Empty;
    public string Weight { get; private set; } = string.Empty;
    public double Price { get; private set; }
    public DishCategory Category { get; private set; }
    public int CookTime { get; private set; }
    public string[] Types { get; private set; } = Array.Empty<string>();

    public Dish(int id, string name, string ingredients, string weight,
                double price, DishCategory category, int cookTime, params string[] types)
    {
        CreateDish(id, name, ingredients, weight, price, category, cookTime, types);
    }

    // Создание блюда (через ref для демонстрации)
    public void CreateDish(ref int id, string name, string ingredients, string weight,
                    double price, DishCategory category, int cookTime, params string[] types)
    {
        Id = id;
        Name = name;
        Ingredients = ingredients;
        Weight = weight;
        Price = price;
        Category = category;
        CookTime = cookTime;
        Types = types;
    }

    // Перегрузка — удобный вариант
    public void CreateDish(int id, string name, string ingredients, string weight,
                    double price, DishCategory category, int cookTime, params string[] types)
    {
        Id = id;
        Name = name;
        Ingredients = ingredients;
        Weight = weight;
        Price = price;
        Category = category;
        CookTime = cookTime;
        Types = types;
    }

    // Редактирование блюда
    public void EditDish(string? name = null, string? ingredients = null,
                         string? weight = null, double? price = null,
                         DishCategory? category = null, int? cookTime = null,
                         params string[] types)
    {
        if (name != null) Name = name;
        if (ingredients != null) Ingredients = ingredients;
        if (weight != null) Weight = weight;
        if (price.HasValue) Price = price.Value;
        if (category.HasValue) Category = category.Value;
        if (cookTime.HasValue) CookTime = cookTime.Value;
        if (types.Length > 0) Types = types;
    }

    // Вывод информации
    public void PrintDish()
    {
        Console.WriteLine($"[{Id}] {Name} — {Price} руб. ({Weight})");
        Console.WriteLine($"Категория: {Category}, Готовка: {CookTime} мин.");
        Console.WriteLine($"Типы: {string.Join(", ", Types)}");
        Console.WriteLine($"Состав: {Ingredients}");
        Console.WriteLine("----------------------------------");
    }

    // "Удаление" блюда (out)
    public void DeleteDish(out bool isDeleted)
    {
        isDeleted = true;
    }
}
