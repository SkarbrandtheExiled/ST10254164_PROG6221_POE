using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10254164_PROG6221_POE.Classes
{
    public partial class viewAllRecipes : Window
    {
        private ingredientClass ingredients;

        public viewAllRecipes()
        {
            InitializeComponent();
            ingredients = new ingredientClass();
            DisplayAllRecipes();
        }

        private void DisplayAllRecipes()
        {
            RecipeListBox.Items.Clear();
            var sortedRecipeNames = ingredients.recipeNames.OrderBy(name => name).ToList();
            foreach (var recipe in sortedRecipeNames)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        private void FilterByNameButton_Click(object sender, RoutedEventArgs e)
        {
            var filterName = NameFilterTextBox.Text;
            var filteredRecipes = ingredients.recipeNames
                .Where(name => name.Contains(filterName, StringComparison.OrdinalIgnoreCase))
                .OrderBy(name => name)
                .ToList();

            UpdateRecipeListBox(filteredRecipes);
        }

        private void FilterByCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CaloriesFilterTextBox.Text, out double maxCalories))
            {
                var filteredRecipes = ingredients.recipeNames
                    .Where((name, index) => ingredients.calorieCount[index] <= maxCalories)
                    .OrderBy(name => name)
                    .ToList();

                UpdateRecipeListBox(filteredRecipes);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the calories filter.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateRecipeListBox(List<string> filteredRecipes)
        {
            RecipeListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                string selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                ingredients.DisplayRecipe(selectedRecipeName);
            }
            else
            {
                MessageBox.Show("Please select a recipe from the list.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
