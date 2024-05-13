using System;
using System.Collections.Generic;

// Define the recipe class
class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Recipe(string name)
    {
        Name = name;
        Ingredients = new List<Ingredient>();
    }
}
// Define the Ingredient class
class Ingredient
{
    public string Name { get; set; }
    public int Calories { get; set; }
    public string FoodGroup { get; set; }
}

class Program
{
    // Delegate Notification when a recipe exceeds 300 calories
    delegate void RecipeCaloriesNotification(string recipeName, int totalCalories);


    static void Main(string[] args)
    {
        // Create a generic collection to store the recipes
        List<Recipe> recipes = new List<Recipe>();

        bool running = true;
        while (running)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add a recipe");
            Console.WriteLine("2. View all recipes");
            Console.WriteLine("3. Exit");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    AddRecipe(recipes);
                    break;
                case "2":
                    ViewRecipes(recipes);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
    static void AddRecipe(List<Recipe> recipes)
    {
        Console.WriteLine("Enter the name of the recipe:");
        string name = Console.ReadLine();

        Recipe recipe = new Recipe(name);
        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numIngredients; i++)
        {
            Console.WriteLine($"Enter the name of ingredient {i + 1}:");
            string ingredientName = Console.ReadLine();

            Console.WriteLine($"Enter the number of calories for {ingredientName}:");
            int calories = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Enter the food group for {ingredientName}:");
            string foodGroup = Console.ReadLine();

            Ingredient ingredient = new Ingredient
            {
                Name = ingredientName,
                Calories = calories,
                FoodGroup = foodGroup
            };
            recipe.Ingredients.Add(ingredient);
        }
        recipes.Add(recipe);
        Console.WriteLine("Recipe added successfully.");
    }

    static void ViewRecipes(List<Recipe> recipes)
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes found.");
        }
        else
        {
            recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));

            Console.WriteLine("Recipes");

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Enter the number of the recipe to view:");
            int recipeIndex = Convert.ToInt32(Console.ReadLine());

            if (recipeIndex >= 1 && recipeIndex <= recipes.Count)
            {
                Recipe selectedRecipe = recipes[recipeIndex - 1];
                Console.WriteLine();
                Console.WriteLine($"Recipe: {selectedRecipe.Name}");
                Console.WriteLine("Ingredients:");
                int totalCalories = 0;
                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name} ({ingredient.Calories} calories) - {ingredient.FoodGroup}");
                    totalCalories += ingredient.Calories;
                }
                Console.WriteLine();
                Console.WriteLine($"Total Calories: {totalCalories}");



                if (totalCalories > 300)
                {
                    Console.WriteLine("This recipe exceeds 300 calories");
                }
            }
            else
            {
                Console.WriteLine("Invalid recipe number.");
            }
        }
    }

}