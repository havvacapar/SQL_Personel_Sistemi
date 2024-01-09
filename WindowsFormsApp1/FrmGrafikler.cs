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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-KRTI2VK1\\WINCCFLEX2014;Initial Catalog=PersonelVT;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //GRAFİK-1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select PerSehir, count(*) From Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();  
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
                //Sqle ("select PerSehir, count(*) From Tbl_Personel group by PerSehir") yazdığımızda 2 adet veri geliyor.
                //Bunlardan 0.indeks x koordinatında, 1.indeks y koordinatında olsun.
            }
            baglanti.Close();

            //GRAFİK-2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select PerMeslek, avg(PerMaas) From Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
                //Sqle ("select PerMeslek, avg(PerMaas) From Tbl_Personel group by PerMeslek") yazdığımızda 2 adet veri geliyor.
                //Bunlardan 0.indeks x koordinatında, 1.indeks y koordinatında olsun.
            }
            baglanti.Close();


        }
    }
}
