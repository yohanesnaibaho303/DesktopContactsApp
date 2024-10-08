﻿using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email =  emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            //connection database and create table
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) //using disposable from sqlite to automatically stop the connetion once use it
            {
                connection.CreateTable<Contact>(); //create table if its not exist, but if exist ignore create table instead Insert to the exist table
                connection.Insert(contact);
            }

            // after click save the window automatically closed
            Close();
        }
    }
}
