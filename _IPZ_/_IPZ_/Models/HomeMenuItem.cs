using System;
using System.Collections.Generic;
using System.Text;

namespace _IPZ_.Models
{
    public enum MenuItemType
    {
        Browse,
        ProductTable,
        Info,
        InputWindow,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
