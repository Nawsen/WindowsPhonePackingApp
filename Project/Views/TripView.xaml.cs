using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Wallet;
using Project.Models;

namespace Project.Views
{
    public partial class TripView : UserControl
    {
        private Models.Trip Trip;
        public TripView(Models.Trip trip)
        {
            InitializeComponent();
            Trip = trip;
            tripName.Text = trip.Name;
            //tripDate.Text = trip.Deadline.ToString();
            packingProg.Value = 60;
        }
         
        public Models.Trip getTrip()
        {
            return Trip;
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["deTripremove"] = this.Trip;
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["deTripedit"] = this.Trip;
        }
    }
}
