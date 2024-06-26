using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    internal class recipeChoiceClass
    {

        private MainWindow mainWindow;

        public recipeChoiceClass()
        {
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        public void RecipeChoice(ingredientClass recipeData)
        {
            if (recipeData.recipeNames.Count == 0)
            {
                MessageBox.Show("No recipes to display", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            viewAllRecipes recipeListWindow = new viewAllRecipes(recipeData.recipeNames);
            if (recipeListWindow.ShowDialog() == true)
            {
                string selectedRecipeName = recipeListWindow.SelectedRecipe;
                MessageBox.Show($"Selected Recipe: {selectedRecipeName}");
            }
        }
    }
}
//*************************************END OF FILE***********************************************//
