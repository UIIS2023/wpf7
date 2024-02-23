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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Apoteka.Forme;

namespace Apoteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti
        private static string korisniciSelect = @"select KorisnikID as ID, Ime, Prezime, JMBG, Grad, Adresa, Kontakt, NazivPozicije as Pozicija
			from tblKorisnik join tblPozicija on tblKorisnik.PozicijaID=tblPozicija.PozicijaID";
        private static string pozicijeSelect = @"select PozicijaID as ID, NazivPozicije as 'Naziv pozicije' from tblPozicija";
        private static string proizvodiSelect = @"select ProizvodID as ID, NazivProizvoda as 'Naziv proizvoda', ProizvodjacProizvoda as 'Proizvođač', 
                                                         CenaProizvoda as 'Cena', RokTrajanja as 'Rok trajanja', TipProizvoda as Tip, Recept,
                                                         KolicinaNaStanju as Količina, NazivDobavljaca as Dobavljač 
                                                         from tblProizvod join tblDobavljac on tblProizvod.DobavljacID=tblDobavljac.DobavljacID";
        private static string receptiSelect = @"select ReceptID as ID, ImeKupca + ' ' + PrezimeKupca as 'Ime i prezime', NazivProizvoda as 'Naziv proizvoda'
                                                from tblRecept join tblKupac on tblRecept.KupacID = tblKupac.KupacID
                                                join tblProizvod on tblRecept.ProizvodID = tblProizvod.ProizvodID";
        private static string kupciSelect = @"select KupacID as ID, ImeKupca as Ime, PrezimeKupca as Prezime, DatumRodjenja as 'Datum rođenja',
                                                     AdresaKupca as Adresa, KontaktKupca as Kontakt from tblKupac";
        private static string loyaltyKarticeSelect = @"select LoyaltyKarticaID as ID, DatumVazenja as 'Datum važenja', ImeKupca + ' ' + PrezimeKupca as Kupac
                                                    from tblLoyaltyKartica join tblKupac on tblLoyaltyKartica.KupacID=tblKupac.KupacID";
        private static string dobavljaciSelect = @"select DobavljacID as ID, NazivDobavljaca as Dobavljač, KontaktDobavljaca as Kontakt from tblDobavljac";
        private static string racuniSelect = @"select RacunID as ID, DatumIzdavanja as 'Datum izdavanja', UkupnaCena as 'Ukupan iznos', BrojRacuna as 'Broj računa', 
                                                      ImeKupca + ' ' + PrezimeKupca as Kupac, Ime + ' ' + Prezime as Korisnik
                                              from tblRacun join tblKupac on tblRacun.KupacID=tblKupac.KupacID
                                                            join tblKorisnik on tblRacun.KorisnikID=tblKorisnik.KorisnikID";

        private static string proizvodiRacuniSelect = @"select ProizvodRacunID as ID, NazivProizvoda as 'Naziv proizvoda', BrojRacuna as 'Broj računa'
                                                        from tblProizvodRacun join tblRacun on tblProizvodRacun.RacunID = tblRacun.RacunID
					                                                          join tblProizvod on tblProizvodRacun.ProizvodID = tblProizvod.ProizvodID";
        private static string sastojciSelect = @"select SastojakID as ID, NazivSastojka as 'Naziv sastojka', KolicinaSastojka as 'Količina sastojka', 
                                                        JedinicaMere as 'Jedinica mere' from tblSastojak";
        private static string sastojciProizvodiSelect = @"select SastojakProizvodID as ID, NazivSastojka as 'Sastojak', NazivProizvoda as 'Naziv proizvoda'
                                                        from tblSastojakProizvod join tblSastojak on tblSastojakProizvod.SastojakID = tblSastojak.SastojakID
						                                                         join tblProizvod on tblSastojakProizvod.ProizvodID = tblProizvod.ProizvodID";

        #endregion

        #region Select sa uslovom
        private static string selectUslovKorisnici = @"select * from tblKorisnik where KorisnikID=";
        private static string selectUslovPozicije = @"select * from tblPozicija where PozicijaID=";
        private static string selectUslovProizvodi = @"select * from tblProizvod where ProizvodID=";
        private static string selectUslovRecepti = @"select * from tblRecept where ReceptID=";
        private static string selectUslovKupci = @"select * from tblKupac where KupacID=";
        private static string selectUslovLoyaltyKartice = @"select * from tblLoyaltyKartica where LoyaltyKarticaID=";
        private static string selectUslovDobavljaci = @"select * from tblDobavljac where DobavljacID=";
        private static string selectUslovRacuni = @"select * from tblRacun where RacunID=";
        private static string selectUslovProizvodiRacuni = @"select * from tblProizvodRacun where ProizvodRacunID=";
        private static string selectUslovSastojci = @"select * from tblSastojak where SastojakID=";
        private static string selectUslovSastojciProizvodi = @"select * from tblSastojakProizvod where SastojakProizvodID=";
        #endregion

        #region Delete upiti
        private static string KorisniciDelete = @"delete from tblKorisnik where KorisnikID=";
        private static string PozicijeDelete = @"delete from tblPozicija where PozicijaID=";
        private static string ProizvodiDelete = @"delete from tblProizvod where ProizvodID=";
        private static string ReceptiDelete = @"delete from tblRecept where ReceptID=";
        private static string KupciDelete = @"delete from tblKupac where KupacID=";
        private static string LoyaltyKarticeDelete = @"delete from tblLoyaltyKartica where LoyaltyKarticaID=";
        private static string DobavljaciDelete = @"delete from tblDobavljac where DobavljacID=";
        private static string RacuniDelete = @"delete from tblRacun where RacunID=";
        private static string ProizvodiRacuniDelete = @"delete from tblProizvodRacun where ProizvodRacunID=";
        private static string SastojciDelete = @"delete from tblSastojak where SastojakID=";
        private static string SastojciProizvodiDelete = @"delete from tblSastojakProizvod where SastojakProizvodID=";
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(korisniciSelect);
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }

            catch (SqlException)
            {
                MessageBox.Show("Neuspešno učitani podaci", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(korisniciSelect);

        }

        private void btnPozicija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(pozicijeSelect);
        }

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(proizvodiSelect);
        }

        private void btnRecept_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(receptiSelect);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kupciSelect);
        }

        private void btnLoyaltyKartica_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(loyaltyKarticeSelect);
        }

        private void btnDobavljač_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dobavljaciSelect);
        }

        private void btnRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(racuniSelect);
        }

        private void btnProizvodRacun_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(proizvodiRacuniSelect);
        }

        private void btnSastojak_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(sastojciSelect);
        }

        private void btnSatojakProizvod_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(sastojciProizvodiSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(korisniciSelect))
            {
                prozor = new frmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(pozicijeSelect))
            {
                prozor = new frmPozicija();
                prozor.ShowDialog();
                UcitajPodatke(pozicijeSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                prozor = new frmProizvod();
                prozor.ShowDialog();
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(receptiSelect))
            {
                prozor = new frmRecept();
                prozor.ShowDialog();
                UcitajPodatke(receptiSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                prozor = new frmKupac();
                prozor.ShowDialog();
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(loyaltyKarticeSelect))
            {
                prozor = new frmLoyaltyKartica();
                prozor.ShowDialog();
                UcitajPodatke(loyaltyKarticeSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                prozor = new frmDobavljac();
                prozor.ShowDialog();
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                prozor = new frmRacun();
                prozor.ShowDialog();
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiRacuniSelect))
            {
                prozor = new frmProizvodRacun();
                prozor.ShowDialog();
                UcitajPodatke(proizvodiRacuniSelect);
            }
            else if (ucitanaTabela.Equals(sastojciSelect))
            {
                prozor = new frmSastojak();
                prozor.ShowDialog();
                UcitajPodatke(sastojciSelect);
            }
            else if (ucitanaTabela.Equals(sastojciProizvodiSelect))
            {
                prozor = new frmSastojakProizvod();
                prozor.ShowDialog();
                UcitajPodatke(sastojciProizvodiSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(korisniciSelect))
            {
                PopuniFormu(selectUslovKorisnici);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(pozicijeSelect))
            {
                PopuniFormu(selectUslovPozicije);
                UcitajPodatke(pozicijeSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                PopuniFormu(selectUslovProizvodi);
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(receptiSelect))
            {
                PopuniFormu(selectUslovRecepti);
                UcitajPodatke(receptiSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                PopuniFormu(selectUslovKupci);
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(loyaltyKarticeSelect))
            {
                PopuniFormu(selectUslovLoyaltyKartice);
                UcitajPodatke(loyaltyKarticeSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                PopuniFormu(selectUslovDobavljaci);
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                PopuniFormu(selectUslovRacuni);
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiRacuniSelect))
            {
                PopuniFormu(selectUslovProizvodiRacuni);
                UcitajPodatke(proizvodiRacuniSelect);
            }
            else if (ucitanaTabela.Equals(sastojciSelect))
            {
                PopuniFormu(selectUslovSastojci);
                UcitajPodatke(sastojciSelect);
            }
            else if (ucitanaTabela.Equals(sastojciProizvodiSelect))
            {
                PopuniFormu(selectUslovSastojciProizvodi);
                UcitajPodatke(sastojciProizvodiSelect);
            }
        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(korisniciSelect))
                    {
                        frmKorisnik prozorKorisnik = new frmKorisnik(azuriraj, red);
                        prozorKorisnik.txtIme.Text = citac["Ime"].ToString();
                        prozorKorisnik.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorKorisnik.txtJMBG.Text = citac["JMBG"].ToString();
                        prozorKorisnik.txtGrad.Text = citac["Grad"].ToString();
                        prozorKorisnik.txtAdresa.Text = citac["Adresa"].ToString();
                        prozorKorisnik.txtKontakt.Text = citac["Kontakt"].ToString();
                        prozorKorisnik.cbPozicija.SelectedValue = citac["PozicijaID"].ToString();
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(pozicijeSelect))
                    {
                        frmPozicija prozorPozicija = new frmPozicija(azuriraj, red);
                        prozorPozicija.txtNazivPozicije.Text = citac["NazivPozicije"].ToString();
                        prozorPozicija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(proizvodiSelect))
                    {
                        frmProizvod prozorProizvod = new frmProizvod(azuriraj, red);
                        prozorProizvod.txtNazivProizvoda.Text = citac["NazivProizvoda"].ToString();
                        prozorProizvod.txtProizvodjacProizvoda.Text = citac["ProizvodjacProizvoda"].ToString();
                        prozorProizvod.txtCenaProizvoda.Text = citac["CenaProizvoda"].ToString();
                        prozorProizvod.dpRokTrajanja.SelectedDate = (DateTime)citac["RokTrajanja"];
                        prozorProizvod.txtTipProizvoda.Text = citac["TipProizvoda"].ToString();
                        prozorProizvod.cbxRecept.IsChecked = (bool)citac["Recept"];
                        prozorProizvod.txtKolicinaNaStanju.Text = citac["KolicinaNaStanju"].ToString();
                        prozorProizvod.cbDobavljac.SelectedValue = citac["DobavljacID"].ToString();
                        prozorProizvod.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(receptiSelect))
                    {
                        frmRecept prozorRecept = new frmRecept(azuriraj, red);
                        prozorRecept.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorRecept.cbProizvod.SelectedValue = citac["ProizvodID"].ToString();
                        prozorRecept.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupciSelect))
                    {
                        frmKupac prozorKupac = new frmKupac(azuriraj, red);
                        prozorKupac.txtImeKupca.Text = citac["ImeKupca"].ToString();
                        prozorKupac.txtPrezimeKupca.Text = citac["PrezimeKupca"].ToString();
                        prozorKupac.dpDatumRodjenja.SelectedDate = (DateTime)citac["DatumRodjenja"];
                        prozorKupac.txtAdresaKupca.Text = citac["AdresaKupca"].ToString();
                        prozorKupac.txtKontaktKupca.Text = citac["KontaktKupca"].ToString();
                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(loyaltyKarticeSelect))
                    {
                        frmLoyaltyKartica prozorKartice = new frmLoyaltyKartica(azuriraj, red);
                        prozorKartice.dpDatumVazenja.SelectedDate = (DateTime)citac["DatumVazenja"];
                        prozorKartice.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorKartice.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dobavljaciSelect))
                    {
                        frmDobavljac prozorDobavljac = new frmDobavljac(azuriraj, red);
                        prozorDobavljac.txtNazivDobavljaca.Text = citac["NazivDobavljaca"].ToString();
                        prozorDobavljac.txtKontaktDobavljaca.Text = citac["KontaktDobavljaca"].ToString();
                        prozorDobavljac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(racuniSelect))
                    {
                        frmRacun prozorRacun = new frmRacun(azuriraj, red);
                        prozorRacun.dpDatumIzdavanja.SelectedDate = (DateTime)citac["DatumIzdavanja"];
                        prozorRacun.txtUkupnaCena.Text = citac["UkupnaCena"].ToString();
                        prozorRacun.txtBrojRacuna.Text = citac["BrojRacuna"].ToString();
                        prozorRacun.cbKupac.SelectedValue = citac["KupacID"].ToString();
                        prozorRacun.cbKorisnik.SelectedValue = citac["KorisnikID"].ToString();
                        prozorRacun.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(proizvodiRacuniSelect))
                    {
                        frmProizvodRacun prozorProizvodRacun = new frmProizvodRacun(azuriraj, red);
                        prozorProizvodRacun.cbProizvod.SelectedValue = citac["ProizvodID"].ToString();
                        prozorProizvodRacun.cbRacun.SelectedValue = citac["RacunID"].ToString();
                        prozorProizvodRacun.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(sastojciSelect))
                    {
                        frmSastojak prozorSastojak = new frmSastojak(azuriraj, red);
                        prozorSastojak.txtNazivSastojka.Text = citac["NazivSastojka"].ToString();
                        prozorSastojak.txtKolicinaSastojka.Text = citac["KolicinaSastojka"].ToString();
                        prozorSastojak.txtJednicaMere.Text = citac["JedinicaMere"].ToString();
                        prozorSastojak.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(sastojciProizvodiSelect))
                    {
                        frmSastojakProizvod prozorSastojakProizvod = new frmSastojakProizvod(azuriraj, red);
                        prozorSastojakProizvod.cbSastojak.SelectedValue = citac["SastojakID"].ToString();
                        prozorSastojakProizvod.cbProizvod.SelectedValue = citac["ProizvodID"].ToString();
                        prozorSastojakProizvod.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(korisniciSelect))
            {
                ObrisiZapis(KorisniciDelete);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(pozicijeSelect))
            {
                ObrisiZapis(PozicijeDelete);
                UcitajPodatke(pozicijeSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiSelect))
            {
                ObrisiZapis(ProizvodiDelete);
                UcitajPodatke(proizvodiSelect);
            }
            else if (ucitanaTabela.Equals(receptiSelect))
            {
                ObrisiZapis(ReceptiDelete);
                UcitajPodatke(receptiSelect);
            }
            else if (ucitanaTabela.Equals(kupciSelect))
            {
                ObrisiZapis(KupciDelete);
                UcitajPodatke(kupciSelect);
            }
            else if (ucitanaTabela.Equals(loyaltyKarticeSelect))
            {
                ObrisiZapis(LoyaltyKarticeDelete);
                UcitajPodatke(loyaltyKarticeSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                ObrisiZapis(DobavljaciDelete);
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(racuniSelect))
            {
                ObrisiZapis(RacuniDelete);
                UcitajPodatke(racuniSelect);
            }
            else if (ucitanaTabela.Equals(proizvodiRacuniSelect))
            {
                ObrisiZapis(ProizvodiRacuniDelete);
                UcitajPodatke(proizvodiRacuniSelect);
            }
            else if (ucitanaTabela.Equals(sastojciSelect))
            {
                ObrisiZapis(SastojciDelete);
                UcitajPodatke(sastojciSelect);
            }
            else if (ucitanaTabela.Equals(sastojciProizvodiSelect))
            {
                ObrisiZapis(SastojciProizvodiDelete);
                UcitajPodatke(sastojciProizvodiSelect);
            }
        }

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da se odjavite?", "Potvrda odjavljivanja", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (rezultat == MessageBoxResult.Yes)
            {
                Login loginWindow = new Login();
                loginWindow.Show();
                this.Close();
            }
        }
    }
}
