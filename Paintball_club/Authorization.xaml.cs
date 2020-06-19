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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paintball_club
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        DB db = new DB();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Back_reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new Registration().Show();
            this.Close();
        }

        private void Authorization_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Login_TextBox.Text != "" && Password_PasswordBox.Password != "")
            {
                if (Captcha_CheckBox.IsChecked == true)
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();

                    DataTable dtable = new DataTable();

                    MySqlCommand command = new MySqlCommand($"SELECT * FROM Users WHERE mail = @Log AND password = @Pass", db.getConnection());
                    command.Parameters.Add("@Log", MySqlDbType.VarChar).Value = Encription.EncriptionString(Login_TextBox.Text);
                    command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Encription.EncriptionString(Password_PasswordBox.Password);

                    adapter.SelectCommand = command;
                    adapter.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        new MainForm((string)dtable.Rows[0][1],Login_TextBox.Text).Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такого пользователя не существует!");
                    }
                }
                else
                {
                    MessageBox.Show("Капча не пройдена!");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!!!");
            }
        }
    }
}
