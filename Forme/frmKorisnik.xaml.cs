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

namespace Apoteka.Forme
{
    /// <summary>
    /// Interaction logic for frmKorisnik.xaml
    /// </summary>
    public partial class frmKorisnik : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;

        public frmKorisnik()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
            PopuniPadajucuListu();
        }

        public frmKorisnik(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
            PopuniPadajucuListu();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajucuListu()
        {
            try
            {
                konekcija.Open();

                string vratiPozicije = @"select PozicijaID, NazivPozicije from tblPozicija";
                SqlDataAdapter daPozicija = new SqlDataAdapter(vratiPozicije, konekcija);
                DataTable dtPozicija = new DataTable();
                daPozicija.Fill(dtPozicija);
                cbPozicija.ItemsSource = dtPozicija.DefaultView;
                daPozicija.Dispose();
                dtPozicija.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuca lista nije popunjena", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
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
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@Grad", SqlDbType.NVarChar).Value = txtGrad.Text;
                cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@Kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@PozicijaID", SqlDbType.Int).Value = cbPozicija.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKorisnik
                                        set Ime=@Ime, Prezime=@Prezime, JMBG=@JMBG, Grad=@Grad, Adresa=@Adresa, Kontakt=@Kontakt, PozicijaID=@PozicijaID
                                        where KorisnikID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblKorisnik(Ime, Prezime, JMBG, Grad, Adresa, Kontakt, PozicijaID)
                                    values(@Ime, @Prezime, @JMBG, @Grad, @Adresa, @Kontakt, @PozicijaID)";
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

        private void btnDodajPoziciju_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmPozicija();
            prozor.ShowDialog();
            PopuniPadajucuListu();
        }
    }
}
