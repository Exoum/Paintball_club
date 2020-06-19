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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DB db = new DB();
        public Registration()
        {
            InitializeComponent();
            MainDate();
        }

        public void MainDate()
        {
            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM Gender", db.getConnection());
            MySqlDataReader genderreader;
            try
            {
                db.openConnection();
                genderreader = sqlCommand.ExecuteReader();
                while (genderreader.Read())
                {
                    string gender = genderreader.GetString("name");
                    Gender_ComboBox.Items.Add(gender);
                }
                db.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: \r\n" + ex);
            }
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Back_auth_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new Authorization().Show();
            this.Close();
        }

        private void Registration_btn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName_TextBox.Text.Length > 3 && LastName_TextBox.Text.Length > 3 && Gender_ComboBox.SelectedIndex != -1)
            {
                if ((DateTime.Now.Year - DataBorn_DatePicker.SelectedDate.Value.Year) < 18)
                {
                    MessageBox.Show("Ваш возраст не соответствует требованиям и должен быть 18+");
                }
                else
                {
                    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                    if (Email_TextBox.Text.Length > 0)
                    {
                        if (!rEMail.IsMatch(Email_TextBox.Text))
                        {
                            MessageBox.Show("Неверный формат почты!!!");
                            Email_TextBox.Text = "";
                        }
                        else
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter();

                            DataTable dtable = new DataTable();

                            MySqlCommand command1 = new MySqlCommand($"SELECT * FROM Users WHERE mail = @Log", db.getConnection());
                            command1.Parameters.Add("@Log", MySqlDbType.VarChar).Value = Encription.EncriptionString(Email_TextBox.Text);

                            adapter.SelectCommand = command1;
                            adapter.Fill(dtable);

                            if (dtable.Rows.Count > 0)
                            {
                                MessageBox.Show("Пользователь с таким Email уже существует!");
                            }
                            else
                            {
                                System.Text.RegularExpressions.Regex rPassword = new System.Text.RegularExpressions.Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
                                if (!rPassword.IsMatch(Password_PasswordBox.Password))
                                {
                                    MessageBox.Show("Введеный парол некоректен! Используйте (латинские заглавные и прописные буквы, а так же цифры и символы) Не менее 8-ми символов!!!");
                                    Password_PasswordBox.Password = "";
                                    PasswordRepeat_PasswordBox.Password = "";
                                }
                                else
                                {
                                    if (PasswordRepeat_PasswordBox.Password == Password_PasswordBox.Password)
                                    {
                                        if (Captcha_CheckBox.IsChecked == true)
                                        {
                                            db.openConnection();
                                            MySqlCommand command = new MySqlCommand($"INSERT INTO Users (firstName, lastName, gender, mail, password, dateBorn, registrationDate) VALUES(@firstName, @lastName, @gender, @mail, @password, @dateBorn, @registrationDate)", db.getConnection());
                                            command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = FirstName_TextBox.Text;
                                            command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = LastName_TextBox.Text;
                                            command.Parameters.Add("@gender", MySqlDbType.Int32).Value = Gender_ComboBox.SelectedIndex + 1;
                                            command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = Encription.EncriptionString(Email_TextBox.Text);
                                            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Encription.EncriptionString(Password_PasswordBox.Password);
                                            command.Parameters.Add("@dateBorn", MySqlDbType.DateTime).Value = DataBorn_DatePicker.SelectedDate;
                                            command.Parameters.Add("@registrationDate", MySqlDbType.DateTime).Value = DateTime.Now;
                                            command.ExecuteNonQuery();
                                            db.closeConnection();
                                            new Authorization().Show();
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Капча не пройдена!");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пароли не совпадают!!!");
                                    }
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
    }
}
