﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModernDesign
{
    /// <summary>
    /// Interaction logic for MouseRight.xaml
    /// </summary>
    public partial class MouseRight : Window
    {
        public MouseRight()
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(Colors.Transparent);
            this.Topmost = true;
        }
    }
}
