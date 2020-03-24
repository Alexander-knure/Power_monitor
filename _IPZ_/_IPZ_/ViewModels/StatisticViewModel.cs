using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using _IPZ_.Models;
using System.Collections.Generic;

namespace _IPZ_.ViewModels
{
    public class StatisticViewModel : INotifyPropertyChanged
    {

        public List<Statistic> Statistics { get; set; }
        public StatisticViewModel()
        {
            Statistics = StatisticList.GetStatistic();
        }

        #region ListViewImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChandged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}