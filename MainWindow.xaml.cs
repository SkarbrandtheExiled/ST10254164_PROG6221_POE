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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10254164_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ViewRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new RecipeListView(); // Replace with your RecipeListView control
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new AddRecipeView(); // Replace with your AddRecipeView control
        }

        private void SearchRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            //MainContent.Content = new SearchRecipesView(); // Replace with your SearchRecipesView control
        }

        private void Home(object sender, RoutedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
