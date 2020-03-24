using System;
using System.Collections.Generic;
using System.Text;

namespace _IPZ_.Models
{
    public class Statistic
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public float Water { get; set; }
        public float Proteins { get; set; }
        public float Fats { get; set; }
        public float Carbohydrates { get; set; }
        public int Energy { get; set; }
        public float Weight { get; set; }
        public DateTime Time { get; set; }
    }
}
