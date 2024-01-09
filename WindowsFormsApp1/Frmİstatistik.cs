using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KRTI2VK1\\WINCCFLEX2014;Initial Catalog=PersonelVT;Integrated Security=True");


        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //TOPLAM PEROSNEL SAYISI

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count (*) from Tbl_Personel ", baglanti); //1 tane satır bize verdiği, kaç adet olduğunu yazan satır.
            SqlDataReader dr1 = komut1.ExecuteReader(); //data okuyucu
            while (dr1.Read()) //rd1 komutu okuma işlemi yaptığı müddetçe
            {
                lblToplamPer.Text = dr1[0].ToString(); // bize verdiği 1 satır 0. indeks oluyor. 0.indeksi lblToplamPere yazdırdık.
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count (*) from Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader(); //data okuyucu
            while (dr2.Read()) //dr1 komutu okuma işlemi yaptığı müddetçe
            {
                lblEvliPer.Text = dr2[0].ToString(); // bize verdiği 1 satır 0. indeks oluyor. 0.indeksi lblToplamPere yazdırdık.
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count (*) from Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader(); //data okuyucu
            while (dr3.Read()) //dr3 komutu okuma işlemi yaptığı müddetçe
            {
                lblBekarPer.Text = dr3[0].ToString(); // bize verdiği 1 satır 0. indeks oluyor. 0.indeksi lblToplamPere yazdırdık.
            }
            baglanti.Close();

            //ŞEHİR SAYISI

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct (PerSehir)) from Tbl_Personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader(); //data okuyucu
            while (dr4.Read()) //dr4 komutu okuma işlemi yaptığı müddetçe
            {
                lblSehirPer.Text = dr4[0].ToString(); // bize verdiği 1 satır 0. indeks oluyor. 0.indeksi lblToplamPere yazdırdık.
            }
            baglanti.Close();

            //TOPLAM MAAŞ (SUM komutu ile toplama yapılır.)

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text= dr5[0].ToString();  
            }
            baglanti.Close();

            //ORTALAMA MAAŞ(AVG komutu ile ortalama hesaplanır.)
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from Tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text= dr6[0].ToString();
            }
            baglanti.Close();



        }
    }
}
