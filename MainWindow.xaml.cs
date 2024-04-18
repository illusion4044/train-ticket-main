using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace Avia1
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Ticket> ticketCollection = new ObservableCollection<Ticket>();
        private TicketBase ticketBaseWindow;
        private Dictionary<string, Dictionary<string, string>> languageResources;
        

        public MainWindow()
        {
            InitializeComponent();
            ticketBaseWindow = new TicketBase(ticketCollection, this);
            // Ініціалізація словника languageResources 
            languageResources = new Dictionary<string, Dictionary<string, string>>();

            //  дані для української мови
            var ukrainianResources = new Dictionary<string, string>();
            ukrainianResources.Add("LogoName", "Укрзалізниця");
            ukrainianResources.Add("DestinationLabel", "Місце призначення:");
            ukrainianResources.Add("TripTypeLabel", "Тип подорожі:");
            ukrainianResources.Add("ClassLabel", "Клас:");
            ukrainianResources.Add("fullNameLabel", "Повне ім'я:");
            ukrainianResources.Add("emailLabel", "Email");
            ukrainianResources.Add("orderTicket", "Замовити Квиток");
            ukrainianResources.Add("myTickets", "Мої квитки");
            ukrainianResources.Add("mainWordLabel", "Вітаємо ! Замовте квиток");
            ukrainianResources.Add("CurrentFlights", "Поточні рейси");
            ukrainianResources.Add("BookTicket", "Забронювати квиток");
            ukrainianResources.Add("EconomClass", "Економ клас");
            ukrainianResources.Add("StandartClass", "Стандарт клас");
            ukrainianResources.Add("BusinessClass", "Бізнес клас");
            ukrainianResources.Add("Kyiv", "Київ");
            ukrainianResources.Add("Lviv", "Львів");
            ukrainianResources.Add("Kharkiv", "Харків");
            ukrainianResources.Add("Odesa", "Одеса");
            ukrainianResources.Add("BilaTserkva", "Біла Церква");
            ukrainianResources.Add("ChangeLang", "Змінити мову");
            ukrainianResources.Add("OneWay", "Один шлях");
            ukrainianResources.Add("Return", "Туди й назад");


            languageResources.Add("uk-UA", ukrainianResources);

            //  дані для англійської мови
            var englishResources = new Dictionary<string, string>();
            englishResources.Add("LogoName", "Ukrzaliznytsia");
            englishResources.Add("DestinationLabel", "Destination:");
            englishResources.Add("TripTypeLabel", "Trip Type:");
            englishResources.Add("ClassLabel", "Class:");
            englishResources.Add("fullNameLabel", "Full name:");
            englishResources.Add("emailLabel", "Email");
            englishResources.Add("orderTicket", "Order ticket");
            englishResources.Add("myTickets", "My tickets");
            englishResources.Add("mainWordLabel", "Welcome ! Order the ticket");
            englishResources.Add("CurrentFlights", "Current trip");
            englishResources.Add("BookTicket", "Book ticket");
            englishResources.Add("EconomClass", "Econom сlass");
            englishResources.Add("StandartClass", "Standart сlass");
            englishResources.Add("BusinessClass", "Business сlass");
            englishResources.Add("Kyiv", "Kyiv");
            englishResources.Add("Lviv", "Lviv");
            englishResources.Add("Kharkiv", "Kharkiv");
            englishResources.Add("Odesa", "Odesa");
            englishResources.Add("BilaTserkva", "Bila Tserkva");
            englishResources.Add("ChangeLang", "Change language");
            englishResources.Add("OneWay", "One Way");
            englishResources.Add("Return", "Return");



            languageResources.Add("en-US", englishResources);

            ChangeLanguage("uk-UA");
        }

        // Метод для оновлення текстів на сторінці відповідно до поточної мови
        private void UpdateTextsForCurrentLanguage()
        {
            // Отримуємо тексти для поточної мови
            Dictionary<string, string> currentLanguageResources = languageResources[System.Threading.Thread.CurrentThread.CurrentUICulture.Name];

            // Оновлюємо тексти на сторінці
            LogoName.Content = currentLanguageResources["LogoName"];
            destinationLabel.Content = currentLanguageResources["DestinationLabel"];
            tripTypeLabel.Content = currentLanguageResources["TripTypeLabel"];
            ClassLabel.Content = currentLanguageResources["ClassLabel"];
            fullNameLabel.Content = currentLanguageResources["fullNameLabel"];
            emailLabel.Content = currentLanguageResources["emailLabel"];
            orderTicket.Content = currentLanguageResources["orderTicket"];
            myTickets.Content = currentLanguageResources["myTickets"];
            mainWordLabel.Content = currentLanguageResources["mainWordLabel"];
            CurrentFlights.Content = currentLanguageResources["CurrentFlights"];
            BookTicket.Content = currentLanguageResources["BookTicket"];
            EconomClass.Content = currentLanguageResources["EconomClass"];
            StandartClass.Content = currentLanguageResources["StandartClass"];
            BusinessClass.Content = currentLanguageResources["BusinessClass"];
            Kyiv.Content = currentLanguageResources["Kyiv"];
            Lviv.Content = currentLanguageResources["Lviv"];
            Kharkiv.Content = currentLanguageResources["Kharkiv"];
            Odesa.Content = currentLanguageResources["Odesa"];
            BilaTserkva.Content = currentLanguageResources["BilaTserkva"];
            ChangeLang.Content = currentLanguageResources["ChangeLang"];
            OneWay.Content = currentLanguageResources["OneWay"];
            Return.Content = currentLanguageResources["Return"];



        }
        private void ChangeLanguage(string culture)
        {
            // Встановлення глобалізації
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);

            // Оновлення тектсу 
            UpdateTextsForCurrentLanguage();
        }

        private void BookTicket_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(destinationComboBox.Text) ||
                string.IsNullOrWhiteSpace(tripTypeComboBox.Text) ||
                string.IsNullOrWhiteSpace(classComboBox.Text) ||
                string.IsNullOrWhiteSpace(fullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidName(fullNameTextBox.Text))
            {
                MessageBox.Show("Невірно вказане ім'я. Будь ласка, вказуйте тільки букви.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("Невірний Email формат. Будь ласка, вкажіть правильний Email адресу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Отримання даних місця призначення, типу подорожі та класу з ComboBox
            string destination = destinationComboBox.Text;
            string tripType = tripTypeComboBox.Text;
            string ticketClass = classComboBox.Text;

            //Перевірка, чи доступний рейс у поточному списку 
            bool isFlightAvailable = false;
            foreach (var flight in CurrentFlightsWindow.CurrentFlightsList)
            {
                if (flight.Destination == destination && flight.TripType == tripType && flight.Class == ticketClass)
                {
                    isFlightAvailable = true;
                    break;
                }
            }

            if (!isFlightAvailable)
            {
                MessageBox.Show($"Немає поточних квитків до {destination} в {ticketClass} для {tripType} типу подорожі.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Створення квитка
            Ticket newTicket = new Ticket
            {
                
                Destination = destination,
                TripType = tripType,
                Class = ticketClass,
                FullName = fullNameTextBox.Text,
                Email = emailTextBox.Text,
                OrderTime = DateTime.Now,
                 Status = "Замовлено з поточних рейсів"
            };

            // Додання квитка у список 
            ticketCollection.Add(newTicket);

            
            ClearInputFields();

            
            this.Hide();
            ticketBaseWindow.Show();
        }

        private void ClearInputFields()
        {
            destinationComboBox.Text = string.Empty;
            tripTypeComboBox.Text = string.Empty;
            classComboBox.Text = string.Empty;
            fullNameTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
        }

        private bool IsValidName(string name)
        {
            return IsValidEnglishName(name) || IsValidUkrainianName(name);
        }

        private bool IsValidEnglishName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        private bool IsValidUkrainianName(string name)
        {
            return Regex.IsMatch(name, @"^[а-яА-ЯіїІЇєЄґҐ]+$");
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@");
        }

        private void ViewTickets_Click(object sender, RoutedEventArgs e)
        {
            TicketViewer ticketViewerWindow = new TicketViewer(ticketCollection);
            ticketViewerWindow.Show();
        }

        private void CurrentFlightsButton_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentFlightsWindow currentFlightsWindow = new CurrentFlightsWindow();
            currentFlightsWindow.Show();
        }

        private void BookTicketButton_Click(object sender, RoutedEventArgs e)
        {
            BookTicket bookTicketWindow = new BookTicket(ticketCollection, this);
            bookTicketWindow.Show();
        }

       

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            foreach (Window window in Application.Current.Windows)
            {
                if (window != this)
                {
                    window.Close();
                }
            }
        }

        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            // Переклюення мови між українською та англійською
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "uk-UA")
                ChangeLanguage("en-US");
            else
                ChangeLanguage("uk-UA");
        }
    }
}
