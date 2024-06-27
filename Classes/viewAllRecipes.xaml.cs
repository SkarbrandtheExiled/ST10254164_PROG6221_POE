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

            //initialize ingredients and prepare the initial state
            this.ingredients = ingredients;

            //update the ListBox with all recipes initially
            UpdateRecipeListBox(ingredients.recipeNames);

            //display all recipes in the ListBox
            DisplayAllRecipes();

            //initialize the recipe list view and sorting
            InitialiseRecipeList();
        }

        public void InitialiseRecipeList()
        {
            //clears the listBox to prevent duplications or maintaining old data
            RecipeListBox.Items.Clear();
            //wrap the recipeNames list in a CollectionView
            recipeCollectionView = CollectionViewSource.GetDefaultView(ingredients.recipeNames);
            //set the CollectionView as the ItemsSource of the ListBox
            RecipeListBox.ItemsSource = recipeCollectionView;
            //sort recipes alphabetically by default
            recipeCollectionView.SortDescriptions.Add(new SortDescription(string.Empty, ListSortDirection.Ascending));
        }

        //----------------displayAllRecipes method--------------------//
        //method to display all recipes in the ListBox
        public void DisplayAllRecipes()
        {
            //clear the ListBox
            RecipeListBox.Items.Clear();
            //sort the recipe names alphabetically
            var sortedRecipeNames = ingredients.recipeNames.OrderBy(name => name).ToList();
            //add each recipe name to the ListBox
            foreach (var recipe in sortedRecipeNames)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        //-------------------filterName method-------------------------//
        //event handler for the "Filter By Name" button click
        public void FilterByNameButton_Click(object sender, RoutedEventArgs e)
        {
            string filterName = NameFilterTextBox.Text;
            if (string.IsNullOrWhiteSpace(filterName))
            {
                //if the filter text is empty, remove the filter
                recipeCollectionView.Filter = null;
            }
            else
            {
                //apply the filter to the CollectionView using lambda
                recipeCollectionView.Filter = item =>
                {
                    var recipeName = item as string;
                    return !(recipeName == null || !recipeName.Contains(filterName));
                };
            }
            //refresh the CollectionView to apply the filter
            recipeCollectionView.Refresh();
        }

        //--------------filterCalories method--------------------//
        //event handler for the "Filter By Calories" button click
        public void FilterByCaloriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(CaloriesFilterTextBox.Text, out double maxCalories))
            {
                //apply the filter to the CollectionView
                recipeCollectionView.Filter = item =>
                {
                    int index = ingredients.recipeNames.IndexOf(item as string);
                    //checks if the recipe's calorie count is within the limit
                    return index >= 0 && ingredients.calorieCount[index] <= maxCalories;
                };
                recipeCollectionView.Refresh();
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the calories filter", "invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //------------------updateRecipeListBox method----------------//
        //method to update the ListBox with filtered recipes
        public void UpdateRecipeListBox(List<string> filteredRecipes)
        {
            //clear the ListBox
            RecipeListBox.Items.Clear();
            //add each filtered recipe to the ListBox
            foreach (string recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe);
            }
        }

        //----------------selectButton method----------------//
        //event handler for the "Select" button click
        public void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            //get the selected recipe name from the ListBox
            SelectedRecipe = RecipeListBox.SelectedItem as string;
            if (SelectedRecipe != null)
            {
                //close the dialog and return the selected recipe
                DialogResult = true;
                Close();
            }
            else
            {
                //show a warning if no recipe is selected
                MessageBox.Show("Please select a recipe", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
