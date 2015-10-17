﻿using System;
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
    public partial class Main : PhoneApplicationPage
    {
        public Main()
        {
            InitializeComponent();

            tripList.Items.Add(new TripView(new Models.Trip("Naar Mali", new DateTime(2016, 8, 23))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Bali", new DateTime(2017, 7, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Hali", new DateTime(2018, 7, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Kali", new DateTime(2019, 12, 12))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Dali", new DateTime(2020, 2, 1))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Pali", new DateTime(2015, 5, 9))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Qali", new DateTime(2056, 8, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Fali", new DateTime(2026, 9, 14))));
            tripList.Items.Add(new TripView(new Models.Trip("Nog eens naar Mali", new DateTime(2015, 8, 16))));
        }

        private void tripList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/TripDetailView.xaml", UriKind.Relative));
        }
    }
}