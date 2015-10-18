using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace Project.Views
{
    public partial class TripListItemView : UserControl
    {
        private Models.Item Item;
        public TripListItemView(Models.Item item)
        {
            InitializeComponent();
            Item = item;
            chItem.Content = item.Name;
            if (item.Ready)
            {
                chItem.IsChecked = true;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            Item.Ready = true;
            
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Item.Ready = false;
        }

    }
}
