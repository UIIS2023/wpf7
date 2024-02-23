using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Apoteka
{
    public partial class Login : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        public Login()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtUsername.Focus();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String username, password;
            username = txtUsername.Text;
            password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nisu sva polja popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                String izTabele = "SELECT * from tblKorisnik where Ime=@username and JMBG=@password";
                SqlDataAdapter sda = new SqlDataAdapter(izTabele, konekcija);
                sda.SelectCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                sda.SelectCommand.Parameters.AddWithValue("@password", txtPassword.Password);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtUsername.Text;
                    password = txtPassword.Password;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Unete informacije nisu tačne", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija.Close();
            }
        }
    }
}
