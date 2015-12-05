using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;

namespace Project.Views
{
    public partial class TripListItemView : UserControl
    {
        public Models.Item Item { get; set; }
        private TripDetailView Tripv;
        public TripListItemView(TripDetailView tripv, Models.Item item)
        {
            InitializeComponent();
            this.Tripv = tripv;
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

        private void delete(object sender, RoutedEventArgs e)
        {
            Tripv.remove(this);
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            Tripv.edit(this);
            Tripv.TextBoxTop.Focus();
        }

    }
}
