using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using _IPZ_.ViewModels;
using Xamarin.Forms.Xaml;
using _IPZ_.Models;
using System.Collections.Generic;

namespace _IPZ_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        ProductListviewModel ProductsList = new ProductListviewModel();

        public ProductPage()
        {
            Title = "Food calorie table"; //Title for UWP
            InitializeComponent();
            this.BindingContext = ProductsList;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            List<string> names;
            names = ProductsList.GetNames(); //For searching
            var keyword = SearchProduct.Text;
            var suggestion = names.Where(c => c.ToLower().Contains(keyword.ToLower())).OrderBy(i => i);
            //SuggestionListView.ItemsSource = suggestion;
            SuggestionListView.ItemsSource = ProductsList.GetProducts(suggestion);

            SuggestionListView.IsVisible = true;
            ProductsListView.IsVisible = false;

            if(keyword == "")
            {
                SuggestionListView.IsVisible = false;
                ProductsListView.IsVisible = true;
            }
        }

        private void SearchProduct_Unfocused(object sender, FocusEventArgs e)
        {
            SuggestionListView.IsVisible = false;
            ProductsListView.IsVisible = true;
        }
    }
}
