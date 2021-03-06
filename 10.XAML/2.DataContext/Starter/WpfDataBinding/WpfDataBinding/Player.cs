﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataBinding
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PreferColor { get; set; }
    }

    public class Players : ObservableCollection<Player>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PreferColor { get; set; }
    }
}
