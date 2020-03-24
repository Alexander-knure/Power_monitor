using _IPZ_.Models;
using _IPZ_.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _IPZ_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage : ContentPage
    {
        readonly ProductListviewModel ProductsList = new ProductListviewModel();
        StatisticViewModel sss = new StatisticViewModel();
        InputProduct ip;
        bool checkName;
        bool checkWeight;
        bool checkTime;
        public InputPage()
        {
            Title = "Input products"; //Title for UWP
            InitializeComponent();
            checkName = true;
            checkWeight = true;
            checkTime = true;
            this.BindingContext = ProductsList;
        }

        
        private void InputProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<string> names;
            names = ProductsList.GetNames(); //For searching
            var keyword = SearchBarProduct.Text;
            var suggestion = names.Where(c => c.ToLower().Contains(keyword.ToLower())).OrderBy(i => i);
            InputListView.ItemsSource = ProductsList.GetProducts(suggestion);
            InputListView.IsVisible = true;
            InputFrame.IsVisible = true;
            foreach (var i in suggestion)
            {
                if(keyword == i)
                {
                    ip.Name = SearchBarProduct.Text;
                    checkName = true;
                }
            }


            if (keyword == "")
            {
                InputListView.IsVisible = false;
                InputFrame.IsVisible = false;
            }
            foreach(var n in names)
            {
                if(keyword == n)
                {
                    checkName = true;
                }
                else
                {
                    checkName = false;
                }
            }
        }
        //Don`t works with grid, only list
        //private void InputListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem != null)
        //    {
        //        ip.Name = e.SelectedItem.ToString();
        //        InputProduct.Text = ip.Name;
        //        checkName = true;
        //    }
        //    else
        //        checkName = false;
        //}

        private void Name_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            ip.Name = b.Text.ToString();
            SearchBarProduct.Text = ip.Name;
            lbInputProduct.Text = ip.Name;
            checkName = true;
        }

        private void InputProduct_Unfocused(object sender, FocusEventArgs e)
        {
            InputListView.IsVisible = false;
            InputFrame.IsVisible = false;
        }

        private void InputWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = InputWeight.Text;
            float num;
           
            if (float.TryParse(InputWeight.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CreateSpecificCulture("fr-FR"), out num) ||
                float.TryParse(InputWeight.Text, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CreateSpecificCulture("en-GB"), out num))
            {
                if(num > 0 && num < 3000)
                {
                    checkWeight = true;
                    ip.Weight = num;
                    AddButton.Text = "Add";
                    AddButton.TextColor = Color.DarkSlateGray;
                    AddButton.BackgroundColor = Color.FromHex("#03bcac");
                }
                else if(num == 0)
                {
                    checkWeight = false;
                    AddButton.Text = $"Weight is empty";
                    AddButton.TextColor = Color.Black;
                    AddButton.BackgroundColor = Color.Red;
                }
                else if(num < 0)
                {
                    checkWeight = false;
                    AddButton.Text = $"Weight is negative";
                    AddButton.TextColor = Color.Black;
                    AddButton.BackgroundColor = Color.Red;
                }
                else if(num >= 3000)
                {
                    checkWeight = false;
                    AddButton.Text = $"Weight is heavy (great, than 3 kg)";
                    AddButton.TextColor = Color.Black;
                    AddButton.BackgroundColor = Color.Red;
                }
       
            }
            else if (InputWeight.Text.Length == 0)
            {
                checkWeight = false;
                AddButton.Text = $"Weight is empty";
                AddButton.TextColor = Color.Black;
                AddButton.BackgroundColor = Color.Red;
            }
            else
            {
                checkWeight = false;
                AddButton.Text = $"'{value}' is wrong!";
                AddButton.TextColor = Color.Black;
                AddButton.BackgroundColor = Color.Red;
            }
        }

        private void TimeMeal_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ip = new InputProduct(lbInputProduct.Text, float.Parse(InputWeight.Text));
            checkTime = true;
            ip.SetTime(TimeMeal.Time);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (checkName == true && checkWeight == true && checkTime == true)
            {
                button.Text = "Add";
                button.TextColor = Color.DarkSlateGray;
                button.BackgroundColor = Color.FromHex("#03bcac");

                lbInputProduct.Text = "Choosed: " + ip.Name + " " + ip.Weight + "gr " + ip.Time;
                StatisticList.AddInfoStatistic(ProductsList.Products, ip);
            }
            else if(checkName == false)
            {
                button.Text = "Name is wrong!";
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.Red;
            }
            else if (checkWeight == false)
            {
                button.Text = "Weight is wrong!";
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.Red;
            }
            else if (checkTime == false)
            {
                button.Text = "Time is wrong!";
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.Red;
            }
        }
    }
}