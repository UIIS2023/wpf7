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
    /// Interaction logic for frmRecept.xaml
    /// </summary>
    public partial class frmRecept : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmRecept()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public frmRecept(bool azuriraj, DataRowView red)
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

                string vratiProizvode = @"select ProizvodID, NazivProizvoda from tblProizvod";
                SqlDataAdapter daProizvod = new SqlDataAdapter(vratiProizvode, konekcija);
                DataTable dtProizvod = new DataTable();
                daProizvod.Fill(dtProizvod);
                cbProizvod.ItemsSource = dtProizvod.DefaultView;
                daProizvod.Dispose();
                dtProizvod.Dispose();
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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@KupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@ProizvodID", SqlDbType.Int).Value = cbProizvod.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRecept
                                        set KupacID=@KupacID, ProizvodID=@ProizvodID
                                        where ReceptID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblRacun(KupacID, ProizvodID)
                                    values(@KupacID, @ProizvodID)";
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

        private void btnDodajKupca_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmKupac();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }

        private void btnDodajProizvod_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmProizvod();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }
    }
}
