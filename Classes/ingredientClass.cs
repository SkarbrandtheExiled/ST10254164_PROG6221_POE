using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    /// <summary>
    /// Name: Luke Michael Carolus
    /// StudentID: ST10254164
    /// Module: PROG6221
    /// References:
    /// Microsoft Learn, 2023. How to: Filter Data in a View. [Online] Available at: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-filter-data-in-a-view?view=netframeworkdesktop-4.8 [Accessed 26 June 2024].
    /// STACK OVERFLOW, 2011. How to Add a Scrollbar to Window in C#. [Online] Available at: https://stackoverflow.com/questions/6068860/how-to-add-a-scrollbar-to-window-in-c-sharp [Accessed 25 June 2024].
    /// Microsoft Learn, 2022. XAML code editor. [Online] Available at: https://learn.microsoft.com/en-us/visualstudio/xaml-tools/xaml-code-editor?view=vs-2022 [Accessed 20 June 2024].
    /// https://www.codeproject.com/Questions/1180559/How-do-I-add-at-an-array-with-user-input
    ///https://www.youtube.com/watch?v=1ZO-McTuxtw
    /// GeeksforGeeks, 2022. C# | List Class. [Online] Available at: https://www.geeksforgeeks.org/c-sharp-list-class/[Accessed 12 April 2024].
    /// GeeksforGeeks, 2023. C# Decision Making (if, if-else, if-else-if ladder, nested if, switch, nested switch). [Online] Available at: https://www.geeksforgeeks.org/c-sharp-decision-making-else-else-ladder-nested-switch-nested-switch/?ref=shm[Accessed 10 April 2024].
    /// Troelsen, A. & Japikse, P., 2022. Pro C# 10 with. NET 6: Foundational Principles and Practices in Programming.. 11 ed. s.l.:Apress.
    /// Youtube, 2020. WPF Tutorials. [Online] Availaible at: https://www.youtube.com/playlist?list=PLJJcOjd3n1Zegr2CaA78RWF9IIgeyq0xh [Accessed 21 June 2024].
    /// Youtube, 2021. Filtering, Sorting, and Grouping w/ Collection Views - EASY WPF (.NET CORE). [Online] Available at: https://www.youtube.com/watch?v=fBKW-spQboc&ab_channel=SingletonSean [Accessed 26 June 2024].
    /// Youtube, 2017. Intro to WPF: Learn the basics and best practices of WPF for C# [Online] Available at: https://www.youtube.com/watch?v=gSfMNjWNoX0&ab_channel=IAmTimCorey [Accessed 12 June 2024].
    /// </summary>

    //********************************************START OF FILE**********************************//
    public delegate void CalorieDisplayDelegate(double totalCalories, double calorieLimit);

    public class ingredientClass
    {
        //-------creation and declaration of fields that will be used to store user data-------//
        public string[] ingredientNames;
        public double[] ingredientQuantities;
        public string[] unitOfMeasurements;
        public List<string> steps;
        public List<string> recipeNames = new List<string>();
        public double[] calorieCount;
        public string[] foodGroup;

        private double[] originalQuantities;

        private MainWindow mainWindow;

        public ingredientClass()
        {
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        //---------------------------Ingrediants method----------------------------//
        //this method is responsible for handling all data relevant to the ingredients of the recipe
        public void Ingredients()
        {
            AddRecipe();

            string input = mainWindow.ShowInputDialog("Please enter the number of ingredients in the recipe:");
            if (int.TryParse(input, out int numIngredients))
            {
                ingredientNames = new string[numIngredients];
                ingredientQuantities = new double[numIngredients];
                originalQuantities = new double[numIngredients];
                unitOfMeasurements = new string[numIngredients];
                calorieCount = new double[numIngredients];
                foodGroup = new string[numIngredients];

                for (int i = 0; i < numIngredients; i++)
                {
                    ingredientNames[i] = mainWindow.ShowInputDialog($"Please enter the name of ingredient {i + 1}:");

                    if (!string.IsNullOrWhiteSpace(ingredientNames[i]))
                    {
                        while (true)
                        {
                            input = mainWindow.ShowInputDialog($"Please enter the quantity of {ingredientNames[i]}:");
                            if (double.TryParse(input, out ingredientQuantities[i]))
                            { 
                                originalQuantities[i] = ingredientQuantities[i];
                            break;
                        }
                            MessageBox.Show("Please enter a valid number for the quantity.");
                        }

                        unitOfMeasurements[i] = mainWindow.ShowInputDialog($"Please enter the unit of measurement for {ingredientNames[i]}:");

                        input = mainWindow.ShowInputDialog($"Please enter the number of calories for {ingredientNames[i]}:\n\n" +
                            "Please note:\n <300: a breakfast could be two eggs, 1 slice of multigrain bread, and 1 large apple which comes out to about 282 calories. Low-calorie breakfast foods include eggs, egg whites, fruit and yogurt, high protein waffles, vegetable frittatas, oatmeal, and toast.\n" +
                            "=300: calories is considered a light snack\n" +
                            ">300: more than 300 calories according to this POE is considered too much. Some examples of calorie-dense foods include full-fat dairy products, fatty beef, oils, nuts, and seeds.");
                        double.TryParse(input, out calorieCount[i]);

                        foodGroup[i] = mainWindow.ShowInputDialog($"Please enter the food group for {ingredientNames[i]}:");
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid name for the ingredient.");
                        i--;
                    }
                }

                input = mainWindow.ShowInputDialog("Please enter the number of steps:");
                if (int.TryParse(input, out int numSteps))
                {
                    steps = new List<string>(numSteps);

                    for (int i = 0; i < numSteps; i++)
                    {
                        steps.Add(mainWindow.ShowInputDialog($"Please enter step {i + 1}:"));
                    }
                }
                DisplayRecipe(recipeNames.Last());

                TotalCalories(DisplayCalories);
            }
        }

        public void DisplayRecipe(string selectedRecipeName)
        {
            StringBuilder recipeDetails = new StringBuilder();

            recipeDetails.AppendLine("Full recipe:");
            recipeDetails.AppendLine("----------------------------");

            if (ingredientNames == null || ingredientQuantities == null || unitOfMeasurements == null || calorieCount == null || foodGroup == null)
            {
                recipeDetails.AppendLine("No ingredients added.");
            }
            else
            {
                recipeDetails.AppendLine("Ingredients:");
                for (int i = 0; i < ingredientNames.Length; i++)
                {
                    if (ingredientNames[i] != null)
                    {
                        recipeDetails.AppendLine($"{ingredientQuantities[i]} {unitOfMeasurements[i]} of {ingredientNames[i]} (number of calories: {calorieCount[i]}, food group: {foodGroup[i]})");
                    }
                }
            }

            recipeDetails.AppendLine("------------------------");
            recipeDetails.AppendLine("Steps:");

            for (int i = 0; i < steps?.Count; i++)
            {
                if (steps[i] != null)
                {
                    recipeDetails.AppendLine($"{i + 1}: {steps[i]}");
                }
                else
                {
                    recipeDetails.AppendLine("no steps to display");
                }
            }
            recipeDetails.AppendLine("---------------------------");

            MessageBox.Show(recipeDetails.ToString(), "Recipe information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void QuantityScaling()
        {
            string input = mainWindow.ShowInputDialog("Please enter a value to indicate how much the recipe must be scaled:");
            if (double.TryParse(input, out double scalingNum))
            {
                if (ingredientQuantities != null && ingredientQuantities.Length > 0)
                {
                    for (int i = 0; i < ingredientQuantities.Length; i++)
                    {
                        ingredientQuantities[i] *= scalingNum;
                    }
                    ScalingRecipe recipeScale = new ScalingRecipe(ingredientNames, ingredientQuantities, unitOfMeasurements, calorieCount, foodGroup, steps);
                    recipeScale.DisplayScaling();
                }
                else
                {
                    MessageBox.Show("There are no ingredients to scale, please check that there ARE recipes to scale");
                }
            }
        }

        public void ResetQuantities()
        {
            if (originalQuantities != null && ingredientQuantities != null && originalQuantities.Length == ingredientQuantities.Length)
            {
                for (int i = 0; i < originalQuantities.Length; i++)
                {
                    ingredientQuantities[i] = originalQuantities[i];
                }
                MessageBox.Show("Ingredient quantities have been reset to their original values", "Reset Quantities", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No ingredient quantities to reset", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddRecipe()
        {
            string recipeName = mainWindow.ShowInputDialog("Please enter the name of the recipe:");
            if (!string.IsNullOrWhiteSpace(recipeName))
            {
                recipeNames.Add(recipeName);
                MessageBox.Show($"Recipe {recipeName} has been added.");
            }
        }

        public void DisplayAllRecipes()
        {
            if (recipeNames.Count == 0)
            {
                MessageBox.Show("No recipes to display.", "All Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Sort the recipe names alphabetically
            List<string> sortedRecipeNames = recipeNames.OrderBy(name => name).ToList();

            StringBuilder allRecipes = new StringBuilder("All Recipes:\n");

            for (int i = 0; i < sortedRecipeNames.Count; i++)
            {
                allRecipes.AppendLine($"{i + 1}. {sortedRecipeNames[i]}");
            }
            MessageBox.Show(allRecipes.ToString(), "All Recipes", MessageBoxButton.OK, MessageBoxImage.Information);
            foreach (var recipeName in recipeNames)
            {
                DisplayRecipe(recipeName);
            }
        }

            public void DisplayCalories(double totalCalories, double calorieLimit)
        {
            if (totalCalories > calorieLimit)
            {
                DisplayExceededCalories(totalCalories, calorieLimit);
            }
            else
            {
                DisplayTotalCalories(totalCalories, calorieLimit);
            }
        }

        public delegate void CalorieDisplayDelegate(double totalCalories, double calorieLimit);
        public static void DisplayExceededCalories(double totalCalories, double calorieLimit)
        {
            MessageBox.Show("A calorie is a unit of energy that measures how much energy food provides to the body. The body needs calories to work as it should. Dietary fats are nutrients in food that the body uses to build cell membranes, nerve tissue (like the brain), and hormones. Fat in our diet is a source of calories.\n" + "Fatty foods, such as fried foods, fatty meats, oils, butter, sugary treats, and candies are high - calorie foods.While many high - calorie foods are low in nutrients, vitamins, and minerals, there are also plenty of high - calorie foods that are surprisingly healthy.\n\n" +
                $"Number of calories ({totalCalories}) has exceeded the maximum limit of {calorieLimit} calories.");
        }

        public static void DisplayTotalCalories(double totalCalories, double calorieLimit)
        {
            MessageBox.Show($"Total calories: {totalCalories}");
        }
        public void TotalCalories(CalorieDisplayDelegate displayCalories)
        {
            double totalCalories = calorieCount.Sum();
            double calorieLimit = 300;
            displayCalories(totalCalories, calorieLimit);
        }

    }
}
//*************************************END OF FILE***********************************************//
