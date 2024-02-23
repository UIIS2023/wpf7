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
    /// Interaction logic for frmProizvod.xaml
    /// </summary>
    public partial class frmProizvod : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;

        public frmProizvod()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivProizvoda.Focus();
            PopuniPadajucuListu();
        }

        public frmProizvod(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivProizvoda.Focus();
            PopuniPadajucuListu();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajucuListu()
        {
            try
            {
                konekcija.Open();

                string vratiDobavljace = @"select DobavljacID, NazivDobavljaca from tblDobavljac";
                SqlDataAdapter daProizvod = new SqlDataAdapter(vratiDobavljace, konekcija);
                DataTable dtProizvod = new DataTable();
                daProizvod.Fill(dtProizvod);
                cbDobavljac.ItemsSource = dtProizvod.DefaultView;
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
                if ((txtCenaProizvoda.Text == "") || (txtKolicinaNaStanju.Text=="") || cbDobavljac.Text=="")
                throw new Exception("Podaci o ceni, količini na stanju i dobavljaču moraju biti popunjeni!");
                konekcija.Open();
                DateTime date = (DateTime)dpRokTrajanja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@NazivProizvoda", SqlDbType.NVarChar).Value = txtNazivProizvoda.Text;
                cmd.Parameters.Add("@ProizvodjacProizvoda", SqlDbType.NVarChar).Value = txtProizvodjacProizvoda.Text;
                cmd.Parameters.Add("@CenaProizvoda", SqlDbType.Decimal).Value = txtCenaProizvoda.Text;
                cmd.Parameters.Add("@RokTrajanja", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@TipProizvoda", SqlDbType.NVarChar).Value = txtTipProizvoda.Text;
                cmd.Parameters.Add("@Recept", SqlDbType.Bit).Value = Convert.ToInt32(cbxRecept.IsChecked);
                cmd.Parameters.Add("@KolicinaNaStanju", SqlDbType.Int).Value = txtKolicinaNaStanju.Text;
                cmd.Parameters.Add("@DobavljacID", SqlDbType.Int).Value = cbDobavljac.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblProizvod
                                        set NazivProizvoda=@NazivProizvoda, ProizvodjacProizvoda=@ProizvodjacProizvoda, CenaProizvoda=@CenaProizvoda, 
                                            RokTrajanja=@RokTrajanja, TipProizvoda=@TipProizvoda, Recept=@Recept, KolicinaNaStanju=@KolicinaNaStanju, 
                                            DobavljacID=@DobavljacID
                                        where ProizvodID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblProizvod(NazivProizvoda, ProizvodjacProizvoda, CenaProizvoda, RokTrajanja, TipProizvoda, 
                                                                Recept, KolicinaNaStanju, DobavljacID)
                                    values(@NazivProizvoda, @ProizvodjacProizvoda, @CenaProizvoda, @RokTrajanja, @TipProizvoda, @Recept, 
                                           @KolicinaNaStanju, @DobavljacID)";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);

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

        private void btnDodajDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            Window prozor = new frmDobavljac();
            prozor.ShowDialog();
            PopuniPadajucuListu();
        }
    }
}
