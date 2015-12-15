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
        private User user;

        public async Task<ObservableCollection<Tripsss>> getBooksFromCloudAsync()
        {
            List<Tripsss> books =
            await App.MobileService.GetTable<Tripsss>().Take(100).ToListAsync();
            return new ObservableCollection<Tripsss>(books);
        }

        private async void test()
        {
            //List<Tripsss> books =
            //await App.MobileService.GetTable<Tripsss>().Take(100).ToListAsync();
            //return new ObservableCollection<Tripsss>(books);
            
            //Tripsss trip = new Tripsss();
            //trip.Deadline = DateTime.Now.AddDays(20);
            //trip.Name = "yoniklonipony";

            //trip.AddItem(new Item("blabla1"));
            //trip.AddItem(new Item("blabla2"));
            //trip.AddItem(new Item("blabla3"));

            //Tripsss trip2 = new Tripsss();
            //trip2.Deadline = DateTime.Now.AddDays(10);
            //trip2.Name = "yoniklonipony";

            //trip2.AddItem(new Item("blabla4"));
            //trip2.AddItem(new Item("blabla5"));
            //trip2.AddItem(new Item("blabla6"));

            //User user = new User();
            //user.Username = "JonasVerplassen";
            //user.Password = "kloni";
            
            //user.AddTrip(trip);
            //user.AddTrip(trip2);
            //await App.MobileService.GetTable<User>().InsertAsync(user);
            //Debug.WriteLine("done");
            //foreach (Item item in trip.GetItems())
            //{
            //    Debug.WriteLine(item.Name);
            //}

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
            try
            {
                if (NavigationContext.QueryString["update"].Contains("true"))
                {
                    update();
                }
            }
            catch
            {
            }

            user = (User) PhoneApplicationService.Current.State["user"];
            insertTrips(user);
            

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

        private async void update()
        {
            ObservableCollection<User> ocUsers = await UpdateCurrentUser();
            User updatedUser = ocUsers.ToList().Where(u => u.Username.Equals(user.Username)).First();
            user = updatedUser;
            tripList.Items.Clear();
            insertTrips(user);
        }

        private void insertTrips(User user)
        {
            if (user.GetTrips() != null)
            {
                foreach (Tripsss trip in user.GetTrips())
                {
                    tripList.Items.Add(new TripView(trip));
                }
            }
        }
        public async Task<ObservableCollection<User>> UpdateCurrentUser()
        {
            List<User> users =
            await App.MobileService.GetTable<User>().Take(100).ToListAsync();
            return new ObservableCollection<User>(users);
        }
        
        private void addTrip_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AddTrip.xaml", UriKind.Relative));

            //tripList.Items.Add(new TripView(new Models.Trip("Nog eens naar Mali", new DateTime(2015, 8, 16))));
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
            Tripsss t;

            if (PhoneApplicationService.Current.State.ContainsKey("deTripadd"))
            {
                t = (Tripsss)PhoneApplicationService.Current.State["deTripadd"];
                tripList.Items.Add(new TripView(t));
            }

            //if (PhoneApplicationService.Current.State.ContainsKey("deTripedit"))
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