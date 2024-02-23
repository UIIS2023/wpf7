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
    /// Interaction logic for frmDobavljac.xaml
    /// </summary>
    public partial class frmDobavljac : Window
    {
        SqlConnection konekcija = new SqlConnection();
        Konekcija kon = new Konekcija();
        private bool azuriraj;
        private DataRowView red;
        public frmDobavljac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivDobavljaca.Focus();
        }

        public frmDobavljac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivDobavljaca.Focus();
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
                cmd.Parameters.Add("@NazivDobavljaca", SqlDbType.NVarChar).Value = txtNazivDobavljaca.Text;
                cmd.Parameters.Add("@KontaktDobavljaca", SqlDbType.NVarChar).Value = txtKontaktDobavljaca.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblDobavljac
                                       set NazivDobavljaca = @NazivDobavljaca, KontaktDobavljaca=@KontaktDobavljaca
                                       where DobavljacID=@id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblDobavljac(NazivDobavljaca, KontaktDobavljaca)
                                    values(@NazivDobavljaca, @KontaktDobavljaca)";
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
