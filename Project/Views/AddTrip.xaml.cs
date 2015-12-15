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
        private User user;
        public AddTrip()
        {
            InitializeComponent();
            user = (User)PhoneApplicationService.Current.State["user"];
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
            Tripsss trip = new Tripsss();
            trip.Name = destination.Text;
            trip.Deadline = date;


            SaveTrip(trip);
            
            

        }

        private void SaveTrip(Tripsss trip)
        {
            if (IsValidName(trip))
            {
                user.AddTrip(trip);
                App.MobileService.GetTable<User>().UpdateAsync(user);
                NavigationService.Navigate(new Uri("/Views/Main.xaml?update=true", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("We're sorry, you can't use the same name twice.");
            }
            
        }
        private Boolean IsValidName(Tripsss trip)
        {
            if (user.GetTrips() == null)
            {
                // no trips yet, name valid
                return true;
            }
            // Just checks if name of trip == unique
            Boolean valid = true;
            foreach (Tripsss tripInList in user.GetTrips())
            {
                if (tripInList.Name.Equals(trip.Name))
                {
                    valid = false;
                }
            }
            return valid;
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
