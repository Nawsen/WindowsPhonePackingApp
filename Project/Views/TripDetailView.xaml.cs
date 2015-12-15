using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using Project.Models;
using Windows.UI.ViewManagement;

namespace Project.Views
{
    public partial class TripDetailView : PhoneApplicationPage
    {
        public TextBox TextBoxTop { get; set; }
        private Tripsss Trip;
        private User user;
        public List<Item> EditedItems = new List<Item>();
        public TripDetailView()
        {
            InitializeComponent();
            user = (User)PhoneApplicationService.Current.State["user"];
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            ApplicationBarIconButton addItem = new ApplicationBarIconButton();
            addItem.IconUri = new Uri("/Assets/Images/add.png", UriKind.Relative);
            addItem.Text = "Add Trip";
            ApplicationBar.Buttons.Add(addItem);
            addItem.Click += new EventHandler(addItem_Click);

            InputPane.GetForCurrentView().Showing += onKeyboardShowing;
            InputPane.GetForCurrentView().Hiding += onKeyboardHidding;

            Tripsss trip = PhoneApplicationService.Current.State["trip"] as Tripsss;
            Trip = trip;
            Debug.WriteLine("Trip name:" + Trip.Name);
            tripName.Text = trip.Name;
            Debug.WriteLine("main loaded");
            update();

        }

        private void onKeyboardHidding(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            ApplicationBar.IsVisible = true;
        }

        private void onKeyboardShowing(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            ApplicationBar.IsVisible = false;
        }

        private void update()
        {
            itemList.Items.Clear();
            if (Trip.GetItems() != null)
            {
                foreach (Item item in Trip.GetItems())
                {
                    itemList.Items.Add(new TripListItemView(this, item, Trip, EditedItems));

                }
            }
            

        }
        private void insertItems(Tripsss trip)
        {
            if (trip.GetItems() != null)
            {
                foreach (Item item in trip.GetItems())
                {
                    itemList.Items.Add(new TripListItemView(this, item, Trip, EditedItems));
                }
            }
        }
        public void remove(TripListItemView item)
        {
            DeleteItem(Trip, item.Item);
            update();
        }
        private TripListItemView editingItem;
        private Item oldItem;
        public void edit(TripListItemView item)
        {
            text.Children.Remove(TextBoxTop);
            TextBoxTop = new TextBox();

            this.editingItem = item;
            oldItem = item.Item;
            ApplicationBar.IsVisible = false;

            TextBoxTop.Text = item.Item.Name;
            TextBoxTop.KeyDown += new KeyEventHandler(input_KeyDownEdit);
            TextBoxTop.Height = 70;

            text.Children.Add(TextBoxTop);


            TextBoxTop.Focus();
            
        }
        private void addItem_Click(object sender, EventArgs e)
        {
            
            text.Children.Remove(TextBoxTop);
            ApplicationBar.IsVisible = false;

            TextBoxTop = new TextBox();
            TextBoxTop.KeyDown += new KeyEventHandler(input_KeyDownAdd);
            TextBoxTop.Height = 70;


            text.Children.Add(TextBoxTop);

            TextBoxTop.Focus();

        }

        private void input_KeyDownAdd(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                t.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = true;
                Item item = new Item(t.Text);

                AddItem(Trip, item);
                
                
                
            }
        }

        private void updateTrip(Tripsss trip)
        {


            user.DeleteTrip(Trip);

            //trip.AddItem(item);
            user.AddTrip(trip);
            App.MobileService.GetTable<User>().UpdateAsync(user);
        }

        private Boolean IsValidName(Tripsss trip, Item item)
        {
            if (trip.GetItems() == null)
            {
                return true;
            }
            // Just checks if name of item == unique
            Boolean valid = true;
            foreach (Item itemInList in trip.GetItems())
            {
                if (itemInList.Name.Equals(item.Name))
                {
                    valid = false;
                }
            }
            return valid;
        }
        private void AddItem(Tripsss trip, Item item)
        {
            if (IsValidName(trip, item))
            {
                trip.AddItem(item);
                itemList.Items.Add(new TripListItemView(this, item, Trip, EditedItems));
                updateTrip(trip);
            }
            else
            {
                MessageBox.Show("We're sorry, you can't use the same name twice.");
            }
            //updateTrip(trip);
            ////user.DeleteTrip(Trip);
            //trip.AddItem(item);
            //user.AddTrip(trip);
            //App.MobileService.GetTable<User>().UpdateAsync(user);
        }
        private void updateItem(Tripsss trip, Item item)
        {
            trip.DeleteItem(item);
            trip.AddItem(item);
            updateTrip(trip);
        }
        private void EditItem(Tripsss trip, Item oldItem, Item newItem)
        {
            Debug.WriteLine(oldItem.Name);
            trip.DeleteItem(oldItem);
            
            trip.AddItem(newItem);
            updateTrip(trip);
        }

        private void DeleteItem(Tripsss trip, Item item)
        {
            trip.DeleteItem(item);
            updateTrip(trip);
        }
        private void input_KeyDownEdit(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                t.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = true;
                Item item = FindItem(Trip.GetItems(), editingItem.Item.Name);
                if (item != null)
                {
                    int index = FindIndex(Trip.GetItems(), item);
                    if (index != -1)
                    {
                        
                        Item newItem = new Item();
                        newItem.Name = TextBoxTop.Text;
                        newItem.Ready = item.Ready;


                        EditItem(Trip, item, newItem);
                        update();
                    }
                    
                }
            }
        }

        public Item FindItem(List<Item> items,string name)
        {
            Item foundItem = new Item();
            foreach (Item item in items)
            {
                if (item.Name == name)
                {
                    foundItem = item;
                }
            }
            return foundItem;
        }
        public int FindIndex(List<Item> items, Item item)
        {
            int index = -1;
            for (int i = 0; i < items.Count; i++)
            {
                Debug.WriteLine("TripDetailView >> FindIndex >> " + i + ": " + items[i].Name);
                if (items[i].Name == item.Name)
                {
                    index = i;
                }
            }
            return index;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(""+itemList.SelectedValue);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (PhoneApplicationService.Current.State.ContainsKey("tripUpdated"))
            {
                if ((Boolean) PhoneApplicationService.Current.State["tripUpdated"])
                {
                    //List<Item> items = PhoneApplicationService.Current.State["updatedItems"] as List<Item>;
                    foreach (Item item in EditedItems)
                    {
                        updateItem((Tripsss)PhoneApplicationService.Current.State["updatedTrip"],
                        item);
                        Debug.WriteLine(item.Name);
                    }
                    
                    PhoneApplicationService.Current.State["tripUpdated"] = false;
                }
            }
            PhoneApplicationService.Current.State["tripUpdated"] = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            
            
        }
    }
}