using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ST10254164_PROG6221_POE.Classes
{
    /// <summary>
    /// Name: Luke Michael Carolus
    /// StudentID: ST10254164
    /// Module: PROG6221
    /// </summary>
    /// 
//********************************************START OF FILE**********************************//

    public partial class viewAllRecipes : Window
    {
        private ingredientClass ingredients;

        private ICollectionView recipeCollectionView;


        public string SelectedRecipe { get; private set; }

        public viewAllRecipes(ingredientClass ingredients)
        {
            InitializeComponent();

            // Initialize ingredients and prepare the initial state
            this.ingredients = ingredients;

            // Update the ListBox with all recipes initially
            UpdateRecipeListBox(ingredients.recipeNames);

            // Display all recipes in the ListBox
            DisplayAllRecipes();

            // Initialize the recipe list view and sorting
            InitializeRecipeList();
        }

        public void InitializeRecipeList()
        {
            //clears the listBox to prevent duplications or maintaining old data
            RecipeListBox.Items.Clear();
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
            foreach (string recipe in filteredRecipes)
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
                MessageBox.Show("Please select a recipe", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
