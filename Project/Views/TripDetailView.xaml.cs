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
    public partial class TripDetailView : PhoneApplicationPage
    {
        public TripDetailView()
        {
            InitializeComponent();

            Models.Trip trip = PhoneApplicationService.Current.State["trip"] as Models.Trip;
            tripName.Text = trip.Name;
            foreach (Models.Item item in trip.Items)
            {
                itemList.Items.Add(new TripListItemView(item));
            }
        }
    }
}