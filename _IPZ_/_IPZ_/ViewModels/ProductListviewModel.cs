using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using _IPZ_.Models;
using System.Collections.Generic;

namespace _IPZ_.ViewModels
{
    public class ProductListviewModel : INotifyPropertyChanged
    {
        public List<Product> Products { get; set; }
        public List<Product> SuggestProducts { get; set; }
        public ProductListviewModel()
        {
            Products = new List<Product>()
            {
            new Product() {  Category = "", Name="Apricots", Water = 86, Proteins = 0.9f, Fats = 0, Carbohydrates=10.5f, Energy=46},
            new Product() {  Category = "", Name="Pineapple", Water = 86, Proteins = 0.4f, Fats = 0, Carbohydrates=11.8f, Energy=48},
            new Product() {  Category = "", Name="Apple", Water = 1, Proteins = 20, Fats = 0, Carbohydrates=0, Energy=100},
            new Product() {  Category = "", Name="Onion", Water = 1, Proteins = 20, Fats = 0, Carbohydrates=0, Energy=100},
            new Product() {  Category = "", Name="Corn", Water = 1, Proteins = 20, Fats = 2231, Carbohydrates=0, Energy=100},
            };
        }
        public ProductListviewModel(string category, string name, float water, float proteins, float fats, float carbohydrates, int energy)
        {
            SuggestProducts = new List<Product>();
            Products = new List<Product>()
            {
                new Product() {Category = category, Name = name, Water = water, Proteins = proteins, 
                    Fats = fats, Carbohydrates = carbohydrates, Energy = energy }
            };
        }
       public List<string> GetNames()
        {
            List<string> s = new List<string>();
            foreach (var i in Products)
            {
                s.Add(i.Name);
            }

            return s;
        }

        public List<Product> GetProducts(IEnumerable<string> name)
        {
            List<Product> s = new List<Product>();
            foreach (var n in name)
            {
                foreach (var i in Products)
                {
                    if (i.Name == n)
                    {
                        s.Add(i);
                    }
                }
            }

            return s;
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
