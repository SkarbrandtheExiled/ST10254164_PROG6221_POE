using System;
using System.Collections.Generic;
using System.ComponentModel;
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
/// <summary>
/// Name: Luke Michael Carolus
/// StudentID: ST10254164
/// Module: PROG6221
/// </summary>
/// 
    public partial class viewAllRecipes : Window
    {
        private ingredientClass ingredients;
        private ICollectionView recipeCollectionView;

        public string SelectedRecipe { get; private set; }

        public viewAllRecipes(List<string> recipeNames)
        {
            InitializeComponent();
            ingredients = new ingredientClass();
            DisplayAllRecipes();
            InitializeRecipeList();
        }

        public void InitializeRecipeList()
        {
            // Wrap the recipeNames list in a CollectionView
            recipeCollectionView = CollectionViewSource.GetDefaultView(ingredients.recipeNames);
            // Set the CollectionView as the ItemsSource of the ListBox
            RecipeListBox.ItemsSource = recipeCollectionView;
            // Sort recipes alphabetically by default
            recipeCollectionView.SortDescriptions.Add(new SortDescription(string.Empty, ListSortDirection.Ascending));
        }

        public void DisplayAllRecipes()
        {
            RecipeListBox.Items.Clear();
            var sortedRecipeNames = ingredients.recipeNames.OrderBy(name => name).ToList();
            foreach (var recipe in sortedRecipeNames)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        public void FilterByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string filterName = NameFilterTextBox.Text;
            if (string.IsNullOrWhiteSpace(filterName))
            {
                // If the filter text is empty, remove the filter
                recipeCollectionView.Filter = null;
            }
            else
            {
                // Apply the filter to the CollectionView
                recipeCollectionView.Filter = item =>
                {
                    var recipeName = item as string;
                    return !(recipeName == null || !recipeName.Contains(filterName));
                };
            }
            recipeCollectionView.Refresh();
        }

        public void FilterByCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CaloriesFilterTextBox.Text, out double maxCalories))
            {
                recipeCollectionView.Filter = item =>
                {
                    int index = ingredients.recipeNames.IndexOf(item as string);
                    return index >= 0 && ingredients.calorieCount[index] <= maxCalories;
                };
                recipeCollectionView.Refresh();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the calories filter", "invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void UpdateRecipeListBox(List<string> filteredRecipes)
        {
            RecipeListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        public void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedRecipe = RecipeListBox.SelectedItem as string;
            if (SelectedRecipe != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
