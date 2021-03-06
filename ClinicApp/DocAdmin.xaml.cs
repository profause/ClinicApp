﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ClinicApp
{
    /// <summary>
    /// Interaction logic for DocAdmin.xaml
    /// </summary>
    public partial class DocAdmin : Window
    {
       Drug drug =new Drug();
        Patient p = new Patient();
        public DocAdmin()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int a, b;
            LoginUserName.Text = CurrentUserLoggedInData.FirstName + " " + CurrentUserLoggedInData.LastName;
            lbTotalDrugs.Content = a = drug.TotalDrugsInStock("Drugs");
            lbRegisteredPatients.Content = p.TotalRegisteredPatient();
                b = drug.TotalDrugsInStock("PrescribedDrugs");
             lbAvailableDrugs.Content = a - b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DocAddPatient newPatient = new DocAddPatient();
            newPatient.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ViewPatient viewPatient = new ViewPatient {MenuAction = "doc"};
            //viewPatient.ShowDialog();  
            viewPatientWin view = new viewPatientWin { MenuAction = "doc" };
            view.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //ViewPatient viewPatient = new ViewPatient {MenuAction = "doc" };
            //viewPatient.ShowDialog();
            viewPatientWin view = new viewPatientWin { MenuAction = "doc" };
            view.ShowDialog();
        }

        private void Logout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LogUserOut();
        }
        private void LogUserOut()
        {

            var response = MessageBox.Show("Do you really want to Logout", "Exit",
                MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (response == MessageBoxResult.No)
            {

            }
            else
            {

                CurrentUserLoggedInData.ClearUserData();
                new MainWindow().Show();
                Hide();
            }
        }

        private void historyBnt_Click(object sender, RoutedEventArgs e)
        {
            //ViewPatient viewPatient = new ViewPatient { MenuAction = "History" };
            //viewPatient.ShowDialog();
            viewPatientWin view = new viewPatientWin();
            view.ShowDialog();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            int a, b;
            lbTotalDrugs.Content = a = drug.TotalDrugsInStock("Drugs");
            lbRegisteredPatients.Content = p.TotalRegisteredPatient();
            b = drug.TotalDrugsInStock("PrescribedDrugs");
            lbAvailableDrugs.Content = a - b;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var response = MessageBox.Show("Please be sure to Logout first", "Exit",
               MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

            if (response == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
