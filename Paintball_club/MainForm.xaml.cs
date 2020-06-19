using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Paintball_club
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        DB db = new DB();
        int index = 0;
        string NameUser;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(string Name, string Mail)
        {
            InitializeComponent();
            NameUser = Mail;
            UserName.Text = Name;
        }

        private void ProfileEdit_Click(object sender, RoutedEventArgs e)
        {
            Profile_Edit.Visibility = Visibility.Visible;
            btmain_grid.Visibility = Visibility.Hidden;
            Edit_BD_grid.Visibility = Visibility.Hidden;
            Dictionary_grid.Visibility = Visibility.Hidden;
            Email_lb.Content = NameUser;
            Gender_cb.Items.Clear();
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM Gender", db.getConnection());
            MySqlDataReader genderreader;
            try
            {
                db.openConnection();
                genderreader = sqlCommand.ExecuteReader();
                while (genderreader.Read())
                {
                    string gender = genderreader.GetString("name");
                    Gender_cb.Items.Add(gender);
                }
                db.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex);
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            new Authorization().Show();
            this.Close();
        }


        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void btmain_Click(object sender, RoutedEventArgs e)
        {
            Profile_Edit.Visibility = Visibility.Hidden;
            btmain_grid.Visibility = Visibility.Visible;
            Edit_BD_grid.Visibility = Visibility.Hidden;
            Dictionary_grid.Visibility = Visibility.Hidden;
            Gender_Client.Items.Clear();
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM Gender", db.getConnection());
            MySqlDataReader genderreader;
            try
            {
                db.openConnection();
                genderreader = sqlCommand.ExecuteReader();
                while (genderreader.Read())
                {
                    string gender = genderreader.GetString("name");
                    Gender_Client.Items.Add(gender);
                }
                db.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex);
            }
        }

        private void ListView_Exit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = ListView_Exit.SelectedIndex;
            switch (index)
            {
                case 0:
                    {
                        var result = MessageBox.Show("Вы точно хотите закрыть программу?", "", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                        else
                        {
                            this.Topmost = true;
                        }
                        ListView_Exit.SelectedIndex = -1;
                        index = 0;
                        break;
                    }
            }
        }

        private void Edit_BD_Click(object sender, RoutedEventArgs e)
        {
            Profile_Edit.Visibility = Visibility.Hidden;
            btmain_grid.Visibility = Visibility.Hidden;
            Edit_BD_grid.Visibility = Visibility.Visible;
            Dictionary_grid.Visibility = Visibility.Hidden;
            Table_Edit.IsReadOnly = true;
            Select_Table.Items.Clear();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SHOW TABLES", db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable dtable = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(dtable);
            try
            {
                for (int i = 0; i < dtable.Rows.Count; i++)
                    Select_Table.Items.Add(dtable.Rows[i][0]);
                db.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex);
            }
        }

        private void Select_Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Select_Table.SelectedIndex == 0)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Clients", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
            else if (Select_Table.SelectedIndex == 1)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Gender", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
            else if (Select_Table.SelectedIndex == 2)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Users", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
        }

        private void Del_str_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить запись?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (Convert.ToInt32(Table_Edit.SelectedItems.Count) >= 1)
                {
                    while (Table_Edit.SelectedItems.Count > 0)
                    {
                        db.openConnection();
                        DataRowView row = (DataRowView)(Table_Edit.SelectedItem);
                        int id = Convert.ToInt32(row.Row[0]);
                        row.Row.Delete();
                        MySqlCommand command = new MySqlCommand($"DELETE FROM {Select_Table.Text} WHERE id = @Id", db.getConnection());
                        command.Parameters.AddWithValue("@id", MySqlDbType.Int32).Value = id;
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись удалена");
                        db.closeConnection();
                    }
                }
                else
                {
                    MessageBox.Show("Строка не выбрана");
                }
            }
        }

        private void Update_table_Click(object sender, RoutedEventArgs e)
        {
            if (Select_Table.SelectedIndex == 0)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Clients", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
            else if (Select_Table.SelectedIndex == 1)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Gender", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
            else if (Select_Table.SelectedIndex == 2)
            {
                MySqlCommand command = new MySqlCommand("Select * FROM Users", db.getConnection());
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                Table_Edit.ItemsSource = dataTable.AsDataView();
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName_tb.Text.Length > 3 && LastName_tb.Text.Length > 3 && Gender_cb.SelectedIndex != -1)
            {
                if ((DateTime.Now.Year - DateBorn_dp.SelectedDate.Value.Year) < 18)
                {
                    MessageBox.Show("Ваш возраст не соответствует требованиям и должен быть 18+");
                }
                else
                {
                    if (Password_pb.Password.Length > 0 && RepeatPassword_pb.Password.Length > 0)
                    {
                        System.Text.RegularExpressions.Regex rPassword = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
                        if (!rPassword.IsMatch(Password_pb.Password))
                        {
                            MessageBox.Show("Введеный парол некоректен! Используйте (латинские заглавные и прописные буквы, а так же цифры и символы) Не менее 8-ми символов!!!");
                            Password_pb.Password = "";
                            RepeatPassword_pb.Password = "";
                        }
                        else
                        {
                            if (RepeatPassword_pb.Password == Password_pb.Password)
                            {

                                db.openConnection();
                                MySqlCommand command = new MySqlCommand($"UPDATE Users SET firstName = @firstName, lastName = @lastName, gender = @gender, password = @password, dateBorn = @dateBorn", db.getConnection());
                                command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = FirstName_tb.Text;
                                command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = LastName_tb.Text;
                                command.Parameters.Add("@gender", MySqlDbType.Int32).Value = Gender_cb.SelectedIndex + 1;
                                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Encription.EncriptionString(Password_pb.Password);
                                command.Parameters.Add("@dateBorn", MySqlDbType.DateTime).Value = DateBorn_dp.SelectedDate;
                                command.ExecuteNonQuery();
                                db.closeConnection();
                                MessageBox.Show("Данные изменены успешно!");
                            }
                            else
                            {
                                MessageBox.Show("Пароли не совпадают!!!");
                            }
                        }
                    }
                    else
                    {
                        db.openConnection();
                        MySqlCommand command = new MySqlCommand($"UPDATE Users SET firstName = @firstName, lastName = @lastName, gender = @gender, dateBorn = @dateBorn", db.getConnection());
                        command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = FirstName_tb.Text;
                        command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = LastName_tb.Text;
                        command.Parameters.Add("@gender", MySqlDbType.Int32).Value = Gender_cb.SelectedIndex + 1;
                        command.Parameters.Add("@dateBorn", MySqlDbType.DateTime).Value = DateBorn_dp.SelectedDate;
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Данные изменены успешно!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введены не все данные!!!");
            }
        }

        private void Save_Client_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName_Client.Text.Length > 3 && LastName_Client.Text.Length > 3 && MiddleName_Client.Text.Length > 3 && Gender_Client.SelectedIndex != -1)
            {
                if ((DateTime.Now.Year - DateBorn_Client.SelectedDate.Value.Year) < 18)
                {
                    MessageBox.Show("Ваш возраст не соответствует требованиям и должен быть 18+");
                }
                else
                {
                    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                    if (Mail_Client.Text.Length > 0)
                    {
                        if (!rEMail.IsMatch(Mail_Client.Text))
                        {
                            MessageBox.Show("Неверный формат почты!!!");
                            Mail_Client.Text = "";
                        }
                        else
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            DataTable dtable = new DataTable();

                            MySqlCommand command1 = new MySqlCommand($"SELECT * FROM Clients WHERE mail = @Log", db.getConnection());
                            command1.Parameters.Add("@Log", MySqlDbType.VarChar).Value = Encription.EncriptionString(Mail_Client.Text);

                            adapter.SelectCommand = command1;
                            adapter.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {
                                MessageBox.Show("Пользователь с таким Email уже существует!");
                            }
                            else
                            {
                                if (Phone_Client.Text.Length < 14)
                                {
                                    MessageBox.Show("Введеный номер некоректен!!!");
                                    Phone_Client.Text = "";
                                }
                                else
                                {
                                    db.openConnection();
                                    MySqlCommand command = new MySqlCommand($"INSERT INTO Clients (firstName, middleName ,lastName, gender, mail, phoneNumber , dateBorn, dateRegistration, lastVisit) VALUES(@firstName, @middleName ,@lastName, @gender, @mail, @phoneNumber ,@dateBorn, @dateRegistration, @lastVisit)", db.getConnection());
                                    command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = FirstName_Client.Text;
                                    command.Parameters.Add("@middleName", MySqlDbType.VarChar).Value = MiddleName_Client.Text;
                                    command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = LastName_Client.Text;
                                    command.Parameters.Add("@gender", MySqlDbType.Int32).Value = Gender_Client.SelectedIndex + 1;
                                    command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Mail_Client.Text;
                                    command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = Phone_Client.Text;
                                    command.Parameters.Add("@dateBorn", MySqlDbType.DateTime).Value = DateBorn_Client.SelectedDate;
                                    command.Parameters.Add("@dateRegistration", MySqlDbType.DateTime).Value = DateTime.Now;
                                    command.Parameters.Add("@lastVisit", MySqlDbType.DateTime).Value = DateTime.Now;
                                    command.ExecuteNonQuery();
                                    db.closeConnection();
                                    MessageBox.Show("Данные о клиенте успешно добавленны!");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Укажите почту!!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введены не все данные!!!");
            }
        }

        private void Dictionary_Click(object sender, RoutedEventArgs e)
        {
            Profile_Edit.Visibility = Visibility.Hidden;
            btmain_grid.Visibility = Visibility.Hidden;
            Edit_BD_grid.Visibility = Visibility.Hidden;
            Dictionary_grid.Visibility = Visibility.Visible;
            MySqlCommand command = new MySqlCommand("Select * FROM Clients", db.getConnection());
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
            Table_Clients.ItemsSource = dataTable.AsDataView();
        }
    }
}
