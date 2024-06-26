using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
    internal class deleteRecipeClass
    {
        //--------------------deleteData method---------------------------//
        //method must delete the data inputted by the user and loop the application back to the start
        public void DeleteData(ingredientClass recipeData)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete all your data?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
recipeData.recipeNames.Clear();
                    recipeData.ingredientNames = null;
                    recipeData.ingredientQuantities = null;
                    recipeData.unitOfMeasurements = null;
                    recipeData.steps = null;
                    MessageBox.Show("Data deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case MessageBoxResult.No:
                    recipeData.DisplayAllRecipes();
                    MessageBox.Show("Data still present", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                default:
                    MessageBox.Show("Please enter a valid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            }
        }
}
//--------------------------------END OF FILE--------------------------------//
