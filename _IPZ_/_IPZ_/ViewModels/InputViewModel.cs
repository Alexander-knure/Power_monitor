using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _IPZ_.Models;
using Xamarin.Forms;

namespace _IPZ_.ViewModels
{
    public class InputViewModel : ContentPage
    {
        public InputViewModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}