using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Project.Models;

namespace Project.Views
{
    public partial class Main : PhoneApplicationPage
    {

        public async Task<ObservableCollection<Tripsss>> getBooksFromCloudAsync()
        {
            List<Tripsss> books =
            await App.MobileService.GetTable<Tripsss>().Take(100).ToListAsync();
            return new ObservableCollection<Tripsss>(books);
        }
        // Define a member variable for storing the signed-in user. 
        private MobileServiceUser user;

        // Define a method that performs the authentication process
        // using a Facebook sign-in. 
        

        private async void test()
        {
            //List<Tripsss> books =
            //await App.MobileService.GetTable<Tripsss>().Take(100).ToListAsync();
            //return new ObservableCollection<Tripsss>(books);
            
            Tripsss trip = new Tripsss();
            trip.Deadline = DateTime.Now.AddDays(20);
            trip.Name = "yoniklonipony";

            trip.AddItem(new Item("blabla1"));
            trip.AddItem(new Item("blabla2"));
            trip.AddItem(new Item("blabla3"));

            Tripsss trip2 = new Tripsss();
            trip2.Deadline = DateTime.Now.AddDays(10);
            trip2.Name = "yoniklonipony";

            trip2.AddItem(new Item("blabla4"));
            trip2.AddItem(new Item("blabla5"));
            trip2.AddItem(new Item("blabla6"));

            User user = new User();
            user.Username = "Yoni";
            user.Password = "kloni";
            user.AddTrip(trip);
            user.AddTrip(trip2);
            await App.MobileService.GetTable<User>().InsertAsync(user);
            Debug.WriteLine("done");
            foreach (Item item in trip.GetItems())
            {
                Debug.WriteLine(item.Name);
            }

            //Tripsss trip = new Tripsss("bladkla", DateTime.Today.AddDays(18), "sssss");
            //Debug.WriteLine("start");
            //await App.MobileService.GetTable<Tripsss>().InsertAsync(trip);
            //Debug.WriteLine("end");

            /*
            List<Trip> tbl = await App.MobileService.GetTable<Trip>().Take(100).ToListAsync();
            MessageBox.Show(App.MobileService.GetTable<Trip>() +
                "");*/
        }
        public Main()
        {
            InitializeComponent();
            getBooksFromCloudAsync();
            test();
            /*
            tripList.Items.Add(new TripView(new Models.Trip("Naar Mali", new DateTime(2016, 8, 23))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Bali", new DateTime(2017, 7, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Hali", new DateTime(2018, 7, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Kali", new DateTime(2019, 12, 12))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Dali", new DateTime(2020, 2, 1))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Pali", new DateTime(2015, 5, 9))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Qali", new DateTime(2056, 8, 19))));
            tripList.Items.Add(new TripView(new Models.Trip("Naar Fali", new DateTime(2026, 9, 14))));
            tripList.Items.Add(new TripView(new Models.Trip("Nog eens naar Mali", new DateTime(2015, 8, 16))));*/
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
    }
}