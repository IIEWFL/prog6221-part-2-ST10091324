using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RecipeMaker2.UnitTests
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void calculateTotalCalories_DifferentCalories_TotalCaloriesIsCorrect()
        {
            Recipe recipe1 = new Recipe("Banana Pancakes");
            Ingredient ingredient1 = (new Ingredient("Banana", 2, "Pieces", 20, "Starchy foods"));
            Ingredient ingredient2 = (new Ingredient("Eggs", 2, "Whole", 35, "Chicken, fish, meat, eggs"));
            Ingredient ingredient3 = (new Ingredient("Oat Milk", 1.5, "Cup", 107, "Milk and diary products"));

            recipe1.addToIngredientList(ingredient1);
            recipe1.addToIngredientList(ingredient2);
            recipe1.addToIngredientList(ingredient3);

            double expectedCalories = 162;
            double actualCalories = recipe1.getTotalRecipeCalories();
            Assert.AreEqual(expectedCalories, actualCalories);
        }

        [TestMethod]
        public void calculateTotalCalories_SameCalories_TotalCaloriesIsCorrect()
        {
            Recipe recipe1 = new Recipe("Banana Pancakes");
            Ingredient ingredient1 = (new Ingredient("Banana", 2, "Pieces", 12, "Starchy foods"));
            Ingredient ingredient2 = (new Ingredient("Eggs", 2, "Whole", 58, "Chicken, fish, meat, eggs"));
            Ingredient ingredient3 = (new Ingredient("Oat Milk", 1.5, "Cup", 100, "Milk and diary products"));

            recipe1.addToIngredientList(ingredient1);
            recipe1.addToIngredientList(ingredient2);
            recipe1.addToIngredientList(ingredient3);

            double expectedCalories = 162;
            double actualCalories = recipe1.getTotalRecipeCalories();
            Assert.AreNotEqual(expectedCalories, actualCalories);
        }
    }
}
