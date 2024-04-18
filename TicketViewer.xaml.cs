
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Avia1
{
    public partial class TicketViewer : Window
    {
        private ObservableCollection<Ticket> ticketCollection;

        public TicketViewer(ObservableCollection<Ticket> tickets)
        {
            InitializeComponent();
            ticketCollection = tickets;
            ticketViewerDataGrid.ItemsSource = ticketCollection;
        }

        private void CancelTicketButton_Click(object sender, RoutedEventArgs e)
        {
            // Отримуємо квиток, що відповідає кнопці "Відміна"
            Button button = sender as Button;
            Ticket ticket = button.DataContext as Ticket;

            // Видаляємо квиток з колекції
            ticketCollection.Remove(ticket);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
