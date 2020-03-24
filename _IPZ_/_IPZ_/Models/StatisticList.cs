using System;
using System.Collections.Generic;
using System.Text;

namespace _IPZ_.Models
{
    public static class StatisticList
    {
        public static List<Statistic> Data { get; set; }

        static StatisticList()
        {
            Data = new List<Statistic>();
        }

        private static string GetCategory(List<Product> Products, string name)
        {
            string category = "";
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    category = i.Category;
                }
            }
            return category;
        }
        private static float GetWater(List<Product> Products, string name)
        {
            float water = 0.0f;
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    water = i.Water;
                }
            }
            return water;
        }
        private static float GetProteins(List<Product> Products, string name)
        {
            float proteins = 0.0f;
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    proteins = i.Proteins;
                }
            }
            return proteins;
        }
        public static float GetFats(List<Product> Products, string name)
        {
            float fats = 0.0f;
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    fats = i.Fats;
                }
            }
            return fats;
        }
        private static float GetCarbohydrates(List<Product> Products, string name)
        {
            float carbohydrates = 0.0f;
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    carbohydrates = i.Carbohydrates;
                }
            }
            return carbohydrates;
        }
        private static int GetEnergy(List<Product> Products, string name)
        {
            int energy = 0;
            foreach (var i in Products)
            {
                if (i.Name == name)
                {
                    energy = i.Energy;
                }
            }
            return energy;
        }

        private static List<string> GetNames(List<Product> Products)
        {
            List<string> s = new List<string>();
            foreach (var i in Products)
            {
                s.Add(i.Name);
            }
            return s;
        }

        private static List<Product> GetProducts(List<Product> Products, IEnumerable<string> name)
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

        public static void AddInfoStatistic(List<Product> Products, InputProduct input)
        {
            Statistic product_changed = new Statistic();
            product_changed.Name = input.Name;
            product_changed.Category = GetCategory(Products, input.Name);
            product_changed.Proteins = GetProteins(Products, input.Name)* input.Weight / 100;
            product_changed.Fats = GetFats(Products, input.Name)  * input.Weight / 100;
            product_changed.Carbohydrates = GetCarbohydrates(Products, input.Name) * input.Weight / 100;
            product_changed.Water = GetWater(Products, input.Name) * input.Weight / 100;
            product_changed.Energy = GetEnergy(Products, input.Name) * (int)input.Weight / 100;
            product_changed.Weight = input.Weight;
            product_changed.Time = input.Time;

            Data.Add(product_changed);
        }
        public static List<Statistic> GetStatistic()
        {
            List<Statistic> ls = new List<Statistic>();
            foreach(var i in Data)
            {
                Statistic s = new Statistic();
                s.Name = i.Name;
                s.Category = i.Category;
                s.Proteins = i.Proteins;
                s.Fats = i.Fats;
                s.Carbohydrates = i.Carbohydrates;
                s.Water = i.Water;
                s.Energy = i.Energy;
                s.Weight = i.Weight;
                s.Time = i.Time;

                ls.Add(s);
            }

            return ls;
        }
    }
}
