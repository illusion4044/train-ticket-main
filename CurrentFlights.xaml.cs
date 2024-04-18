using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Avia1
{
    public partial class CurrentFlightsWindow : Window
    {
        public static List<Flight> CurrentFlightsList = new List<Flight>();

        public CurrentFlightsWindow()
        {
            InitializeComponent();
            AddCurrentFlight("Київ", "Один шлях", "Бізнес клас");
            AddCurrentFlight("Біла Церква", "Один шлях", "Економ клас");
            AddCurrentFlight("Харків", "Туди й назад", "Бізнес клас");
            AddCurrentFlight("Одеса", "Туди й назад", "Бізнес клас");
        }

        public void AddCurrentFlight(string destination, string tripType, string ticketClass)
        {
            CurrentFlightsList.Add(new Flight
            {
                Destination = destination,
                TripType = tripType,
                Class = ticketClass
            });

            CurrentFlightsListBox.Items.Add($"{destination}, {tripType}, {ticketClass}");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
