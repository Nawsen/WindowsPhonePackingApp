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
using Project.Models;
using Windows.UI.ViewManagement;

namespace Project.Views
{
    public partial class TripDetailView : PhoneApplicationPage
    {
        public TextBox TextBoxTop { get; set; }
        private Trip Trip;
        public TripDetailView()
        {
            InitializeComponent();
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

            Models.Trip trip = PhoneApplicationService.Current.State["trip"] as Models.Trip;
            this.Trip = trip;
            tripName.Text = trip.Name;
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
            foreach (Models.Item item in Trip.Items)
            {
                itemList.Items.Add(new TripListItemView(this, item));

            }
        }
        public void remove(TripListItemView item)
        {
            this.Trip.Items.Remove(item.Item);
            itemList.Items.Remove(item);
        }
        private TripListItemView editingItem;
        public void edit(TripListItemView item)
        {
            text.Children.Remove(TextBoxTop);
            TextBoxTop = new TextBox();

            this.editingItem = item;
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
                itemList.Items.Add(new TripListItemView(this, new Models.Item(t.Text)));
            }
        }

        private void input_KeyDownEdit(object sender, KeyEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (e.Key == Key.Enter)
            {
                t.Visibility = Visibility.Collapsed;
                ApplicationBar.IsVisible = true;
                Item item = Trip.Items.Where(d => d.Equals(editingItem.Item)).First();
                if (item != null)
                {
                    int index = Trip.Items.FindIndex(x=> x.Equals(item));
                    
                    item.Name = t.Text;
                    editingItem.Item.Name = item.Name;
                    itemList.Items[index] = editingItem;
                    update();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(""+itemList.SelectedValue);
        }

    }
}