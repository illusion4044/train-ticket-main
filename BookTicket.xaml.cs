using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Avia1
{
    public partial class BookTicket : Window
    {
        private ObservableCollection<Ticket> ticketCollection;
        private MainWindow mainWindow;
        private Dictionary<string, Dictionary<string, string>> languageResources;

        public BookTicket(ObservableCollection<Ticket> ticketCollection, MainWindow mainWindow)
        {
            InitializeComponent();
            this.ticketCollection = ticketCollection;
            this.mainWindow = mainWindow;

            languageResources = new Dictionary<string, Dictionary<string, string>>();
            //  дані для української мови
            var ukrainianResources = new Dictionary<string, string>();
            ukrainianResources.Add("EconomClass", "Економ клас");
            ukrainianResources.Add("StandartClass", "Стандарт клас");
            ukrainianResources.Add("BusinessClass", "Бізнес клас");
            ukrainianResources.Add("Kyiv", "Київ");
            ukrainianResources.Add("Lviv", "Львів");
            ukrainianResources.Add("Kharkiv", "Харків");
            ukrainianResources.Add("Odesa", "Одеса");
            ukrainianResources.Add("BilaTserkva", "Біла Церква");
            ukrainianResources.Add("destinationLabel", "Місце призначення");
            ukrainianResources.Add("tripTypeLabel", "Тип подорожі");
            ukrainianResources.Add("classLabel", "Клас");
            ukrainianResources.Add("nameLabel", "Ім'я");
            ukrainianResources.Add("bookTicketbutton", "Забронювати квиток");
            ukrainianResources.Add("changeLangbutton", "Змінити мову");
            ukrainianResources.Add("OneWay", "Один шлях");
            ukrainianResources.Add("Return", "Туди й назад");



            languageResources.Add("uk-UA", ukrainianResources);


            var englishResources = new Dictionary<string, string>();
            englishResources.Add("EconomClass", "Econom сlass");
            englishResources.Add("StandartClass", "Standart сlass");
            englishResources.Add("BusinessClass", "Business сlass");
            englishResources.Add("Kyiv", "Kyiv");
            englishResources.Add("Lviv", "Lviv");
            englishResources.Add("Kharkiv", "Kharkiv");
            englishResources.Add("Odesa", "Odesa");
            englishResources.Add("BilaTserkva", "Bila Tserkva");
            englishResources.Add("destinationLabel", "Destination");
            englishResources.Add("tripTypeLabel", "Trip type");
            englishResources.Add("classLabel", "Class");
            englishResources.Add("nameLabel", "Name");
            englishResources.Add("bookTicketbutton", "Book ticket");
            englishResources.Add("changeLangbutton", "Change language");
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
            EconomClass.Content = currentLanguageResources["EconomClass"];
            StandartClass.Content = currentLanguageResources["StandartClass"];
            BusinessClass.Content = currentLanguageResources["BusinessClass"];
            Kyiv.Content = currentLanguageResources["Kyiv"];
            Lviv.Content = currentLanguageResources["Lviv"];
            Kharkiv.Content = currentLanguageResources["Kharkiv"];
            Odesa.Content = currentLanguageResources["Odesa"];
            BilaTserkva.Content = currentLanguageResources["BilaTserkva"];
            destinationLabel.Content = currentLanguageResources["destinationLabel"];
            tripTypeLabel.Content = currentLanguageResources["tripTypeLabel"];
            classLabel.Content = currentLanguageResources["classLabel"];
            nameLabel.Content = currentLanguageResources["nameLabel"];
            bookTicketbutton.Content = currentLanguageResources["bookTicketbutton"];
            changeLangbutton.Content = currentLanguageResources["changeLangbutton"];
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
                MessageBox.Show("Невірний формат Email. Будь ласка, вкажіть правильну Email адресу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Ticket newTicket = new Ticket
            {
                Destination = (destinationComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                TripType = (tripTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                Class = (classComboBox.SelectedItem as ComboBoxItem).Content.ToString(),
                FullName = fullNameTextBox.Text,
                Email = emailTextBox.Text,
                OrderTime = DateTime.Now,
                 Status = "Квиток заброньовано"
            };

            ticketCollection.Add(newTicket);

            ClearInputFields();

            this.Close();
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
