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
    /// Interaction logic for frmRacun.xaml
    /// </summary>
    public partial class frmRacun : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmRacun()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public frmRacun(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiKupce = @"select KupacID, ImeKupca + ' ' + PrezimeKupca as kupac from tblKupac";
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupce, konekcija);
                DataTable dtKupac = new DataTable();
                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                daKupac.Dispose();
                dtKupac.Dispose();

                string vratiKorisnike = @"select KorisnikID, Ime + ' ' + Prezime as korisnik from tblKorisnik";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnike, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                daKorisnik.Dispose();
                dtKorisnik.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuća lista nije popunjena", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
                DateTime date = (DateTime)dpDatumIzdavanja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@DatumIzdavanja", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@UkupnaCena", SqlDbType.Decimal).Value = txtUkupnaCena.Text;
                cmd.Parameters.Add("@BrojRacuna", SqlDbType.NVarChar).Value = txtBrojRacuna.Text;
                cmd.Parameters.Add("@KupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@KorisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRacun
                                        set DatumIzdavanja=@DatumIzdavanja, UkupnaCena=@UkupnaCena, BrojRacuna=@BrojRacuna, 
                                            KupacID=@KupacID, KorisnikID=@KorisnikID
                                        where RacunID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblRacun(DatumIzdavanja, UkupnaCena, BrojRacuna, KupacID, KorisnikID)
                                    values(@DatumIzdavanja, @UkupnaCena, @BrojRacuna, @KupacID, @KorisnikID)";
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

        private void btnDodajKupca_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmKupac();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmKorisnik();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }
    }
}
