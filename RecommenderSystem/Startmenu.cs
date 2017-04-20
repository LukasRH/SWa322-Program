﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    class Startmenu : Menu
    {
        public Startmenu(string title) : base(title)
        {
            AddMenuItem(new MovieMenu("View all movies"), new MovieMenu("Rate movies"));
        }

        public Startmenu(string title, params MenuItemBase[] items) : base(title, items)
        {
        }
    }
}