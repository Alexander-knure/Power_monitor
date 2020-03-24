using _IPZ_.Models;
using _IPZ_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace _IPZ_.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticPage : ContentPage
    {
        //StatisticViewModel StatisticList = new StatisticViewModel();
        List<Statistic> s = new List<Statistic>();
        public StatisticPage()
        {
            Title = "Statistic"; //Title for UWP
            InitializeComponent();
            s = StatisticList.GetStatistic();
            this.BindingContext = s;
            lbStatistic.Text = s.Count().ToString();
        }

        private void lbStatistic_BindingContextChanged(object sender, EventArgs e)
        {
            lbStatistic.Text = s.Count().ToString();
            lbStatistic.Text = s[0].Name;
           
        }
    }
}