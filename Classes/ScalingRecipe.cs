using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ST10254164_PROG6221_POE.Classes
{
//********************************************START OF FILE**********************************//
    internal class ScalingRecipe
    {
        private string[] ingredientNames;
        private double[] ingredientQuantities;
        private string[] unitOfMeasurements;
        private double[] calorieCount;
        private string[] foodGroup;
        private List<string> steps;

        public ScalingRecipe(string[] ingredientNames, double[] ingredientQuantities, string[] unitOfMeasurements, double[] calorieCount, string[] foodGroup, List<string> steps)
        {
            this.ingredientNames = ingredientNames;
            this.ingredientQuantities = ingredientQuantities;
            this.unitOfMeasurements = unitOfMeasurements;
            this.calorieCount = calorieCount;
            this.foodGroup = foodGroup;
            this.steps = steps;
        }


        public void DisplayScaling()
        {
            StringBuilder scaledRecipeDetails = new StringBuilder();

            scaledRecipeDetails.AppendLine("Scaled Recipe:");
            scaledRecipeDetails.AppendLine("-----------------------");
            scaledRecipeDetails.AppendLine("Ingredients:");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                scaledRecipeDetails.AppendLine($"{ingredientQuantities[i]} {unitOfMeasurements[i]} of {ingredientNames[i]} (calories: {calorieCount[i]}, food group: {foodGroup[i]})");
            }
            scaledRecipeDetails.AppendLine("------------------------");
            scaledRecipeDetails.AppendLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                scaledRecipeDetails.AppendLine($"{i + 1}: {steps[i]}");
            }
            scaledRecipeDetails.AppendLine("---------------------------");

            MessageBox.Show(scaledRecipeDetails.ToString(), "Scaled Recipe Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
//*************************************END OF FILE***********************************************//