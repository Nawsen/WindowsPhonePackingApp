﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Project.Models;

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

            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton addTrip = new ApplicationBarIconButton();
            addTrip.IconUri = new Uri("/Assets/Images/add.png", UriKind.Relative);
            addTrip.Text = "Add Trip";
            ApplicationBar.Buttons.Add(addTrip);
            addTrip.Click += new EventHandler(addTrip_Click);
        }
        private void addTrip_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AddTrip.xaml", UriKind.Relative));

        }

        private void tripList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tripList.SelectedIndex != -1)
            {
                TripView tripView = (TripView)tripList.SelectedItem;
                PhoneApplicationService.Current.State["trip"] = tripView.getTrip();
                NavigationService.Navigate(new Uri("/Views/TripDetailView.xaml", UriKind.Relative));
            }
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            Trip t;

            if (PhoneApplicationService.Current.State.ContainsKey("deTripadd"))
            {
                t = (Trip)PhoneApplicationService.Current.State["deTripadd"];
                tripList.Items.Add(new TripView(t));
            }            //if (PhoneApplicationService.Current.State.ContainsKey("deTripedit"))
            //{
            //    t = (Trip)PhoneApplicationService.Current.State["deTripedit"];
            //    tripList.Items.Remove(t);
            //    tripList.Items.Add(new TripView(t));
            //}
            //if (PhoneApplicationService.Current.State.ContainsKey("deTripremove"))
            //{
            //    t = (Trip)PhoneApplicationService.Current.State["deTripremove"];
            //    tripList.Items.Remove(t);
            //}
        }

        public void remove(TripView item)
        {
            tripList.Items.Remove(item);
        }
    }
}