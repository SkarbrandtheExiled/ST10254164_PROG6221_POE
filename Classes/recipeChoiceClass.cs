using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    internal class recipeChoiceClass
    {

        private MainWindow mainWindow;

        public recipeChoiceClass()
        {
            //get the current main window of the application
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }
        //-------------------recipeChoice method---------------------//
        // Method to handle the recipe choice
        public void RecipeChoice(ingredientClass recipeData)
        {
            if (recipeData.recipeNames.Count == 0)
            {
                //show an error message if no recipes are available
                MessageBox.Show("No recipes to display", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //create a new window to display the list of recipes
            viewAllRecipes recipeListWindow = new viewAllRecipes(recipeData);
            // Show the recipe list window and wait for the user to select a recipe
            if (recipeListWindow.ShowDialog() == true)
            {
                //get the selected recipe name from the recipe list window
                string selectedRecipeName = recipeListWindow.SelectedRecipe;
                //show a message with the selected recipe name
                MessageBox.Show($"Selected Recipe: {selectedRecipeName}\n");
                //display the details of the selected recipe
                recipeData.DisplayRecipe(selectedRecipeName);
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
