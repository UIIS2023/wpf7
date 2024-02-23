using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Apoteka.Forme
{
    /// <summary>
    /// Interaction logic for frmSastojak.xaml
    /// </summary>
    public partial class frmSastojak : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;

        public frmSastojak()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivSastojka.Focus();
        }

        public frmSastojak(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivSastojka.Focus();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@NazivSastojka", SqlDbType.NVarChar).Value = txtNazivSastojka.Text;
                cmd.Parameters.Add("@KolicinaSastojka", SqlDbType.NVarChar).Value = txtKolicinaSastojka.Text;
                cmd.Parameters.Add("@JedinicaMere", SqlDbType.NVarChar).Value = txtJednicaMere.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblSastojak
                                       set NazivSastojka = @NazivSastojka, KolicinaSastojka=@KolicinaSastojka, JedinicaMere=@JedinicaMere
                                       where SastojakID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblSastojak(NazivSastojka, KolicinaSastojka, JedinicaMere)
                                    values(@NazivSastojka, @KolicinaSastojka, @JedinicaMere)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
