using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Avia1
{
    public partial class TicketBase : Window
    {
        private ObservableCollection<Ticket> ticketCollection;
        private MainWindow mainWindow;

        public TicketBase(ObservableCollection<Ticket> tickets, MainWindow main)
        {
            InitializeComponent();
            ticketCollection = tickets;
            ticketBaseDataGrid.ItemsSource = ticketCollection;
            mainWindow = main;
        }

        private void CancelTicketButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо квиток, що відповідає кнопці Відміна
            Button button = sender as Button;
            Ticket ticket = button.DataContext as Ticket;

            // Видаляємо квиток з колекції
            ticketCollection.Remove(ticket);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow.Show();
        }
    }
}
