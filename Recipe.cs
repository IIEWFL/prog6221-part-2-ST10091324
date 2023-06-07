using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker2
{
    public class Recipe
    {
        protected string nameOfRecipe;
        protected double quantityOfIngredient;
        protected double caloriesOfIngredient;
        protected string nameOfIngredient;
        protected string measurementOfIngredient;
        protected string foodGroupOfIngredient;
        protected string descriptionOfStep;
        protected List<Ingredient> ingredientList;
        protected List<Step> stepList;

        //declaring an mutator method
        public string getRecipeName() { return nameOfRecipe; }
        public void setIngredientQuantity(double quantityValue) { quantityOfIngredient = quantityValue; }
        public void setIngredientCalories(double ingredientCalories) { this.caloriesOfIngredient = ingredientCalories; }

        //declaring accessor methods
        public string getIngredientName() { return nameOfIngredient; }
        public double getIngredientQuantity() { return quantityOfIngredient; }
        public string getIngredientMeasurement() { return measurementOfIngredient; }
        public double getIngredientCalories() { return caloriesOfIngredient; }
        public string getIngredientFoodGroup() { return foodGroupOfIngredient; }
        public string getStepDescription() { return descriptionOfStep; }
        public List<Ingredient> getIngredientList() { return ingredientList; }

        public List<Step> getStepList() { return stepList; }

        public Recipe(string nameOfRecipe)
        {
            this.nameOfRecipe = nameOfRecipe;
            ingredientList = new List<Ingredient>();
            stepList = new List<Step>();
        }

        public Recipe(string nameOfIngredient, double quantityOfIngredient, string measurementOfIngredient, double caloriesOfIngredient, string foodGroupOfIngredient)
        {
            this.nameOfIngredient = nameOfIngredient;
            this.quantityOfIngredient = quantityOfIngredient;
            this.measurementOfIngredient = measurementOfIngredient;
            this.caloriesOfIngredient = caloriesOfIngredient;
            this.foodGroupOfIngredient = foodGroupOfIngredient;
        }

        public Recipe(string descriptionOfStep, int dummyValue) { this.descriptionOfStep = descriptionOfStep; }

        public void addToIngredientList(Ingredient ingredient) { ingredientList.Add(ingredient); }
        public void addToStepList(Step step) { stepList.Add(step); }

        public double getTotalRecipeCalories() {return ingredientList.Sum(x => x.getIngredientCalories());}

        public static void determineIfCaloriesExceedValue(double recipeCalories)
        {
           if(recipeCalories > 300)
           {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This recipe is more than 300 calories");
                Console.WriteLine("Eating less calories than you burn on a daily basis can help reduce your chances of getting life threating diseases");
                Console.WriteLine("Your weight will determine how much calories you should and should not be eating");
                Console.ResetColor();
           }
        }

    }
}
