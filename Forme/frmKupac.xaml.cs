using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    /// Interaction logic for frmKupac.xaml
    /// </summary>
    public partial class frmKupac : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmKupac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeKupca.Focus();
        }

        public frmKupac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeKupca.Focus();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatumRodjenja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ImeKupca", SqlDbType.NVarChar).Value = txtImeKupca.Text;
                cmd.Parameters.Add("@PrezimeKupca", SqlDbType.NVarChar).Value = txtPrezimeKupca.Text;
                cmd.Parameters.Add("@DatumRodjenja", SqlDbType.DateTime).Value= datum;
                cmd.Parameters.Add("@AdresaKupca", SqlDbType.NVarChar).Value = txtAdresaKupca.Text;
                cmd.Parameters.Add("@KontaktKupca", SqlDbType.NVarChar).Value = txtKontaktKupca.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKupac
                                       set ImeKupca = @ImeKupca, PrezimeKupca=@PrezimeKupca, DatumRodjenja=@DatumRodjenja, 
                                           AdresaKupca=@AdresaKupca, KontaktKupca=@KontaktKupca
                                       where KupacID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblKupac(ImeKupca,PrezimeKupca, DatumRodjenja, AdresaKupca, KontaktKupca)
                                    values(@ImeKupca, @PrezimeKupca, @DatumRodjenja, @AdresaKupca, @KontaktKupca)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Došlo je do greške prilikom konverzije podataka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);

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
