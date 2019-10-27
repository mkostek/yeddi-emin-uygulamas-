/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Asus
 * Tarih: 19.10.2019
 * Zaman: 11:34
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace websayfasi
{
	/// <summary>
	/// Description of cikisVer
	/// </summary>
	public class cikisVer : Page
	{
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Data

		protected	HtmlInputText	aracPlaka;
		protected	HtmlInputText	girisTarihi;
		protected	HtmlTextArea	aciklama;
		protected	HtmlInputText	gecenGun;
		protected	HtmlInputHidden	id;
		protected	HtmlInputText	ucret;
		protected	HtmlInputButton	cikti;
		

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Init & Exit (Open/Close DB connections here...)
		OleDbConnection baglan;
		OleDbCommand komut;
		OleDbDataReader rd;
		int idx;
		protected void PageInit(object sender, System.EventArgs e)
		{
			idx=Convert.ToInt32(Request.QueryString["id"]);
			baglan= new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=yedi.accdb;");
			baglan.Open();
		}
		//----------------------------------------------------------------------
		protected void PageExit(object sender, System.EventArgs e)
		{
		}

		#endregion
		#region kac gun geçti
		public int hesapla(DateTime giris){
			int fark=0;
			DateTime d=DateTime.Now;
			fark=(d.Year-giris.Year)*365+(d.Month-giris.Month)*30+(d.Day-giris.Day);
			return fark;
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			int deger=0;
			komut=new OleDbCommand("select * from yeddi where id="+idx+"");
			komut.Connection=baglan;
			rd=komut.ExecuteReader();
			//	Response.Write(@"Hello #Develop<br>");
			while(rd.Read())
			{
				id.Value=rd["id"].ToString();
				aracPlaka.Value=rd["aracPlaka"].ToString();
				girisTarihi.Value=rd["girisTarih"].ToString();
				aciklama.Value=rd["aciklama"].ToString();
				deger=hesapla(Convert.ToDateTime(rd["girisTarih"]));
				gecenGun.Value=deger.ToString();
				ucret.Value=(deger*5).ToString();
			}
			//------------------------------------------------------------------
			if(IsPostBack)
			{
			}
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Cıktımı?

		//----------------------------------------------------------------------
		protected void cekEt(object sender, System.EventArgs e)
		{
			komut=new OleDbCommand("update yeddi set cikti=true,cikisTarih='"+DateTime.Now+"',ucret="+ucret.Value+" where id="+id.Value+"");
			komut.Connection=baglan;
			int l=komut.ExecuteNonQuery();
			if(l==1)Response.Write("<script>alert('Güncelleme işlemi başarılı!,Anasayfaya yönlendiriliyorsunuz!')</script>");
			Response.AddHeader("REFRESH","1.1;Default.aspx");
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Add more events here...

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Initialize Component

		protected override void OnInit(EventArgs e)
		{	InitializeComponent();
			base.OnInit(e);
		}
		//----------------------------------------------------------------------
		private void InitializeComponent()
		{	//------------------------------------------------------------------
			this.Load	+= new System.EventHandler(Page_Load);
			this.Init   += new System.EventHandler(PageInit);
			this.Unload += new System.EventHandler(PageExit);
			//------------------------------------------------------------------
			cikti.ServerClick	 += new EventHandler(cekEt);
			//ServerChange += new EventHandler(Changed_Input_Name);
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	}
}
