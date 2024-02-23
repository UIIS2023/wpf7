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
    /// Interaction logic for frmProizvodRacun.xaml
    /// </summary>
    public partial class frmProizvodRacun : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmProizvodRacun()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }
        public frmProizvodRacun(bool azuriraj, DataRowView red)
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

                string vratiProizvode = @"select ProizvodID, NazivProizvoda from tblProizvod";
                SqlDataAdapter daProizvod = new SqlDataAdapter(vratiProizvode, konekcija);
                DataTable dtProizvod = new DataTable();
                daProizvod.Fill(dtProizvod);
                cbProizvod.ItemsSource = dtProizvod.DefaultView;
                daProizvod.Dispose();
                dtProizvod.Dispose();

                string vratiRacune = @"select RacunID, BrojRacuna from tblRacun";
                SqlDataAdapter daRacun = new SqlDataAdapter(vratiRacune, konekcija);
                DataTable dtRacun = new DataTable();
                daRacun.Fill(dtRacun);
                cbRacun.ItemsSource = dtRacun.DefaultView;
                daRacun.Dispose();
                dtRacun.Dispose();
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
                cmd.Parameters.Add("@ProizvodID", SqlDbType.Int).Value = cbProizvod.SelectedValue;
                cmd.Parameters.Add("@RacunID", SqlDbType.Int).Value = cbRacun.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblProizvodRacun
                                        set ProizvodID=@ProizvodID, RacunID=@RacunID
                                        where ProizvodRacunID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblProizvodRacun(ProizvodID, RacunID)
                                    values(@ProizvodID, @RacunID)";
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

        private void btnDodajProizvod_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmProizvod();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }

        private void btnDodajRacun_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmRacun();
            prozor.ShowDialog();
            PopuniPadajuceListe();
        }
    }
}
