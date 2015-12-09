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
using Windows.System;
using Project.Models;

namespace Project.Views
{
    public partial class AddTrip : PhoneApplicationPage
    {
        public AddTrip()
        {
            InitializeComponent();

            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBarIconButton addTrip = new ApplicationBarIconButton();
            addTrip.IconUri = new Uri("/Assets/Images/save.png", UriKind.Relative);
            addTrip.Text = "Save Trip";
            ApplicationBar.Buttons.Add(addTrip);
            addTrip.Click += new EventHandler(addTrip_Click);

        }

        private void addTrip_Click(object sender, EventArgs e)
        {
            DateTime date = (DateTime) myDate.Value;
            TextBox dest = destination;

            PhoneApplicationService.Current.State["deTripadd"] = new Trip(dest.Text, date);
            NavigationService.Navigate(new Uri("/Views/Main.xaml", UriKind.Relative));
            

        }

        private void Destination_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Focus();
            }
        }
    }
}
