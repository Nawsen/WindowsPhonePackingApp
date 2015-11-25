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
    public partial class TripDetailView : PhoneApplicationPage
    {

        public TripDetailView()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = false;
            ApplicationBarIconButton addItem = new ApplicationBarIconButton();
            addItem.IconUri = new Uri("/Assets/Images/add.png", UriKind.Relative);
            addItem.Text = "Add Trip";
            ApplicationBar.Buttons.Add(addItem);
            addItem.Click += new EventHandler(addItem_Click);

            Models.Trip trip = PhoneApplicationService.Current.State["trip"] as Models.Trip;
            tripName.Text = trip.Name;
            foreach (Models.Item item in trip.Items)
            {
                itemList.Items.Add(new TripListItemView(item));
            }

        }
        private void addItem_Click(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            TextBox t = new TextBox();
            t.Height = 70;
            text.Children.Add(t);
            t.Focus();

        }
        private void enterPressed(object sender, EventArgs e)
        {

        }

    }
}