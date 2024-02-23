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
    /// Interaction logic for frmLoyaltyKartica.xaml
    /// </summary>
    public partial class frmLoyaltyKartica : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmLoyaltyKartica()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajucuListu();
        }
        public frmLoyaltyKartica(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajucuListu();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajucuListu()
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
                DateTime date = (DateTime)dpDatumVazenja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@DatumVazenja", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@KupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblLoyaltyKartica
                                        set DatumVazenja=@DatumVazenja, KupacID=@KupacID
                                        where LoyaltyKarticaID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblLoyaltyKartica(DatumVazenja, KupacID)
                                    values(@DatumVazenja, @KupacID)";
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
            PopuniPadajucuListu();
        }
    }
}
