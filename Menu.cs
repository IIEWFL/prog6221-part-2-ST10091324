using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeMaker2
{
    public delegate void warningMessageDelegate(double recipeCalories);
    internal class Menu
    {
        private List<Recipe> recipeList = new List<Recipe>();
        private string ingredientFoodGroup;
        private double ingredientQuantity;
        private int numberOfSteps;
        private double increaseQuantityBy;
        private string ingredientName;
        private string unitsOfMeasurement;
        private string stepDescription = "";
        private Recipe recipeObj;
        private Ingredient ingredientsObj;
        private Step stepsObj;
        private double ingredientCalories;
        //prints a specific symbol n times for format purposes
        public static void printSymbols(char printCharacter, int printAmount)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }
            Console.WriteLine();
        }

        //Overloads the method above to display the symbols as well as the string in between
        public static void printSymbols(char printCharacter, int printAmount, string word)
        {
            for (int i = 0; i < printAmount; i++)
            {
                Console.Write(printCharacter);
            }

            Console.Write(" " + word + " ");

            for (int j = 0; j < printAmount; j++)
            {
                Console.Write(printCharacter);
            }

            Console.WriteLine();
        }

        private void determineFoodGroup(int foodGroup, int otherCounter)
        {
            if (foodGroup == 1)
            {
                ingredientFoodGroup = "Starchy foods";
            }
            else if (foodGroup == 2)
            {
                ingredientFoodGroup = "Vegetables and fruits";
            }
            else if (foodGroup == 3)
            {
                ingredientFoodGroup = "Dry beans, peas, lentils and soya";
            }
            else if (foodGroup == 4)
            {
                ingredientFoodGroup = "Chicken, fish, meat and eggs";
            }
            else if (foodGroup == 5)
            {
                ingredientFoodGroup = "Milk and diary products";
            }
            else if (foodGroup == 6)
            {
                ingredientFoodGroup = "Fats and oil";
            }
            else if (foodGroup == 7)
            {
                ingredientFoodGroup = "Water";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect option selected, please enter correct option");
                Console.ResetColor();
                printSymbols('=', 46);
                displayFoodGroupMenu(otherCounter);
            }
        }

        private void displayFoodGroupMenu(int counter)
        {
            int foodGroupSelection = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Select ingredient " + counter + "'s food group:");
            Console.WriteLine("Enter 1 for Starchy foods");
            Console.WriteLine("Enter 2 for Vegetables and fruits");
            Console.WriteLine("Enter 3 for Dry beans, peas, lentils and soya");
            Console.WriteLine("Enter 4 for Chicken, fish, meat and eggs");
            Console.WriteLine("Enter 5 for Milk and diary products");
            Console.WriteLine("Enter 6 for Fats and oil");
            Console.WriteLine("Enter 7 for Water");
            Console.Write("Enter choice: ");
            foodGroupSelection = Convert.ToInt16(Console.ReadLine());
            Console.ResetColor();
            determineFoodGroup(foodGroupSelection, counter);
        }

        private void getIngredientsFromUser(int ingredientsToAdd)
        {
            int ingredientIncrementor = 1;
            for (int i = 0; i < ingredientsToAdd; i++)
            {
                Console.Write("Enter ingredient " + ingredientIncrementor + "'s name: ");
                ingredientName = Console.ReadLine();

                Console.Write("Enter ingredient " + ingredientIncrementor + "'s quantity: ");
                ingredientQuantity = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter ingredient " + ingredientIncrementor + "'s unit of measurement: ");
                unitsOfMeasurement = Console.ReadLine();

                Console.Write("Enter the amount of calories for ingredient " + ingredientIncrementor + ": ");
                ingredientCalories = Convert.ToDouble(Console.ReadLine());

                displayFoodGroupMenu(ingredientIncrementor);

                //passes the user input into the constructor and assigns their values to their instance fields
                ingredientsObj = new Ingredient(ingredientName, ingredientQuantity, unitsOfMeasurement, ingredientCalories, ingredientFoodGroup);
                //assigns the recipe object with all the information to the ingredient list
                recipeObj.addToIngredientList(ingredientsObj);

                ingredientIncrementor++;
                printSymbols('=', 46);
            }
        }

        private void getDescriptionsFromUser()
        {
            int stepsIncrementor = 1;

            Console.Write("Enter number of steps: ");
            numberOfSteps = Convert.ToInt32(Console.ReadLine());

            for (int j = 0; j < numberOfSteps; j++)
            {
                Console.Write("Enter description of step " + stepsIncrementor + ": ");
                stepDescription = Console.ReadLine();

                stepsObj = new Step(stepDescription, 1);
                /*
                 * The concatentuation of the two list was taken from StackOverflow
                 * written by Kristy
                 * available at: https://stackoverflow.com/questions/42954843/add-a-list-to-another-list-in-c-sharp
                */
                recipeObj.addToStepList(stepsObj);

                stepsIncrementor++;

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe captured");
            Console.ResetColor();
        }

        public void addRecipe()
        {
            Console.Write("Enter number of recipes to add: ");
            int numberOfRecipe = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfRecipe; i++)
            {
                int recipeCounter = 1;
                //Gets the name of the recipe
                printSymbols('=', 6, "Capturing " + recipeCounter + " recipe");
                Console.Write("Enter name of the recipe: ");
                string recipeName = Console.ReadLine();
                //passes the name of the recipe to recipe constructor and assigns it to the instance field
                recipeObj = new Recipe(recipeName);

                Console.Write("Enter number of ingredients to add: ");
                int numberOfIngredients = Convert.ToInt32(Console.ReadLine());
                //gets the ingredient data from the user
                getIngredientsFromUser(numberOfIngredients);

                //gets the description data from the user
                getDescriptionsFromUser();

                //adds the entire recipe object to the recipe list after all recipe objects have been created
                recipeList.Add(recipeObj);
                recipeCounter++;
            }
        }

        private void scaleQuantities()
        {
            if (ingredientsObj == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No quantities available to modify");
            }
            else
            {
                double tempQuantity;
                Console.Write("Increase Quantity by: ");
                increaseQuantityBy = Convert.ToDouble(Console.ReadLine());

                if (increaseQuantityBy > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Increase factor cannot exceed 3");
                }
                else
                {
                    foreach (Ingredient quantity in recipeObj.getIngredientList())
                    {
                        tempQuantity = (quantity.getIngredientQuantity() * increaseQuantityBy);
                        quantity.setIngredientQuantity(tempQuantity);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Quantities increased");
                }
            }
        }

        private void resetQuantities()
        {
            if (ingredientsObj == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No quantities available to modify");
            }
            else if (increaseQuantityBy == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Original quantities were never changed");
            }
            else
            {
                int tempQuantity;

                foreach (Ingredient quantity in recipeObj.getIngredientList())
                {
                    tempQuantity = (int)(quantity.getIngredientQuantity() / increaseQuantityBy);
                    quantity.setIngredientQuantity(tempQuantity);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quantities reset");
            }
        }

        private void clearListData(string choice)
        {
            /*
                * Checks if the arrays have elements in them
                * if there are no elements, nothing happens and a message is displayed to the user
                * if there are elements, they will be "cleared"
            */
            if (recipeObj.getIngredientList() == null && recipeObj.getStepList() == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nothing to clear");
            }
            else
            {
                switch (choice)
                {
                    case "y":
                        recipeList.Clear();
                        recipeObj.getIngredientList().Clear();
                        recipeObj.getStepList().Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Recipe/s cleared");
                        break;
                    case "n":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No recipe/s cleared because of selection");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect input entered, no recipe/s deleted");
                        break;
                }
            }
        }

        public void printAllRecipes()
        {
            if (recipeList.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes to display, please add recipes first");
                Console.ResetColor();
            }

            printSymbols('=', 6, "Displaying recipes in alphabetical order");
            List<string> sortedRecipeList = recipeList.Select(x => x.getRecipeName()).OrderBy(x => x).ToList();
            int recipeIncrementor = 1;
            Console.ForegroundColor = ConsoleColor.Magenta;

            foreach (string element in sortedRecipeList)
            {
                
                Console.WriteLine("recipe {0}: {1}", recipeIncrementor, element);
                recipeIncrementor++; 
            }
            Console.ResetColor();
        }

        public void printSpecificRecipe()
        {
            int recipeCounter = 1; 

            printSymbols('=', 46);
            Console.WriteLine("Select a recipe to display:");
            for (int i = 0; i < recipeList.Count; i++)
            {
                Console.WriteLine("Enter {0} for recipe {0}", recipeCounter, recipeList[i].getRecipeName());
                recipeCounter++;
            }
            int recipeSelected = Convert.ToInt32(Console.ReadLine());

            if (recipeSelected >= 1 && recipeSelected <= recipeList.Count)
            {
                Recipe foundRecipe = recipeList[recipeSelected - 1];
                printSymbols('=', 46);
                Console.WriteLine("Displaying {0} recipe:", foundRecipe.getRecipeName());

                int countIngredient = 1;
                int countSteps = 1;
                foreach (Ingredient element1 in foundRecipe.getIngredientList())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Ingredient {0}: {1} {2} of {3} ({4} calories) belongs to {5}", countIngredient, element1.getIngredientQuantity(),
                                        element1.getIngredientMeasurement(), element1.getIngredientName(), element1.getIngredientCalories(), element1.getIngredientFoodGroup()
                                        );
                    Console.ResetColor();
                }

                var mDelegate = new warningMessageDelegate(Recipe.determineIfCaloriesExceedValue);
                mDelegate(recipeObj.getTotalRecipeCalories());

                foreach (Step element2 in foundRecipe.getStepList())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Step {0}: {1}", countSteps, element2.getStepDescription());
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid recipe selection");
                Console.ResetColor();
            }
        }


        public Boolean checkIfObjectNull(Recipe recipe)
        {
            Boolean isNull = false;
            if (recipe == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available to display, please check spelling or add new recipe");
                Console.ResetColor();
                isNull = true;
            }
            return isNull;
        }
        public void displayMenu()
        {
            int userChoice = 0;
            //Running the application until the user decides to close it
            while (userChoice != 6)
            {
                printSymbols('=', 15, " Recipe Maker ");
                Console.WriteLine("Enter 1 to add recipe/s");
                Console.WriteLine("Enter 2 to display list of added recipe");
                Console.WriteLine("Enter 3 to display specific recipe");
                Console.WriteLine("Enter 4 to increase ingredient quantities by either 0.5, 2 or 3");
                Console.WriteLine("Enter 5 to reset ingredient quantities");
                Console.WriteLine("Enter 6 to delete added recipe");
                Console.WriteLine("Enter 7 to exit system");

                try
                {
                    Console.Write("Enter choice: ");
                    userChoice = Convert.ToInt32(Console.ReadLine());

                    //Depending on the number the user enters, a specific action will be performed
                    switch (userChoice)
                    {
                        case 1:
                            addRecipe();
                            break;
                        case 2:
                            printAllRecipes();
                            break;
                        case 3:
                            printSpecificRecipe();
                            break;
                        case 4:
                            scaleQuantities();
                            break;
                        case 5:
                            resetQuantities();
                            break;
                        case 6:
                            string clearListChoice = " ";
                            while (clearListChoice != "y" && clearListChoice != "n")
                            {
                                Console.Write("Are you sure you would like to clear the arrays? Enter y or n: ");
                                clearListChoice = Console.ReadLine();
                                clearListData(clearListChoice);
                                Console.ResetColor();
                            }
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid number choice entered, please enter correct option");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input entered, please enter correct input");
                }
                Console.ResetColor();
            }
        }
    }
}
