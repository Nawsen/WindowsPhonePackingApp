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
using Project.Models;

namespace Project.Views
{
    public partial class TripListItemView : UserControl
    {
        public Item Item { get; set; }
        private TripDetailView Tripv;
        private Tripsss Trip;
        private List<Item> EditedItems; 
        public TripListItemView(TripDetailView tripv, Item item, Tripsss trip, List<Item> EditedItems)
        {
            InitializeComponent();
            this.Tripv = tripv;
            Item = item;
            Trip = trip;
            this.EditedItems = EditedItems;
            chItem.Content = item.Name;
            if (item.Ready)
            {
                chItem.IsChecked = true;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            Item.Ready = true;
            EditedItems.Add(Item);
            PhoneApplicationService.Current.State["tripUpdated"] = true;
            PhoneApplicationService.Current.State["updatedTrip"] = Trip;
            PhoneApplicationService.Current.State["updatedItem"] = Item;
            //PhoneApplicationService.Current.State["updatedItems"] = editedItems;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Item.Ready = false;
            PhoneApplicationService.Current.State["tripUpdated"] = true;
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            Tripv.remove(this);
            PhoneApplicationService.Current.State["tripUpdated"] = true;
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            Tripv.edit(this);
            Tripv.TextBoxTop.Focus();
            PhoneApplicationService.Current.State["tripUpdated"] = true;
        }

    }
}
