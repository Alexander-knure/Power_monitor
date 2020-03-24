using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace _IPZ_.Models
{
    public class InputProduct
    {
        public string Name { get; set; }

        public float Weight { get; set; }

        public DateTime Time { get; set; }

        public InputProduct()
        {
            Time = DateTime.Now;
        }

        public InputProduct(string name, float weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.Time = DateTime.Now;
        }

        public InputProduct(string name, float weight, DateTime time)
        {
            this.Name = name;
            this.Weight = weight;
            this.Time = time;
        }

        public void SetTime(TimeSpan ts)
        {
            Time = DateTime.Now;
            Time = new DateTime(Time.Year, Time.Month, Time.Day, ts.Hours, ts.Minutes, 0);
        }
    }
}
