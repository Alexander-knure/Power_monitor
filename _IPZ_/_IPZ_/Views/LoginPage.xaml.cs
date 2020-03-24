using System;
using _IPZ_.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _IPZ_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Color.FromHex("03bcac");
            lbUsername.TextColor = Color.Black;
            lbUsername.TextColor = Color.Black;

            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => SignInProcedure(s, e);
        }

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);
            if (user.CheckInfo())
            {
                DisplayAlert("Login", "Login Success", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login not correct", "OK");
            }
        }
    }
}