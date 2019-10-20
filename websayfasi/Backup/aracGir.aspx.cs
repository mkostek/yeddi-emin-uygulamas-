/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: Asus
 * Tarih: 18.10.2019
 * Zaman: 12:19
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
	/// Description of WebForm1
	/// </summary>
	public class WebForm1 : Page
	{	
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Data

		protected	HtmlInputButton		_Button_Ok;
		protected	HtmlInputText		_Input_Name;
		protected	HtmlInputText			aracPlaka;
		protected	HtmlInputText		aciklama;		

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Init & Exit (Open/Close DB connections here...)
		OleDbConnection baglan;
		OleDbCommand komut;
		OleDbDataReader rd;
		protected void PageInit(object sender, System.EventArgs e)
		{
			baglan= new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=yedi.accdb;");
			baglan.Open();
			
		//	komut.CommandType=CommandType.Text;	
		}
		//----------------------------------------------------------------------
		protected void PageExit(object sender, System.EventArgs e)
		{
	
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Page Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Write(Request.QueryString["id"]);
			//------------------------------------------------------------------
			if(IsPostBack)
			{
				//DateTime.Now();

			}
			komut=new OleDbCommand("select * from yeddi");
			komut.Connection=baglan;
			rd=komut.ExecuteReader();
			Response.Write("<table><tr><th>Sil</th><th>Ayrıntı</th><th>araç plaka</th><th>giris tarih</th><th>acıklama</th><th>çıktı mı?</th></tr>");
			while(rd.Read())
			{
				Response.Write("<tr><td><a href=Sil.aspx?id="+rd["id"]+">sil</a></td><td><a href=cikisVer.aspx?id="+rd["id"]+">ayrıntı</a></td><td>"+rd["aracPlaka"]+"</td><td>"+rd["girisTarih"]+"</td><td>"+rd["aciklama"]+"</td><td>"+rd["cikti"]+"</td></tr>");
			}
			Response.Write("</table>");
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Click_Button_OK

		//----------------------------------------------------------------------
		protected void Click_Button_Ok(object sender, System.EventArgs e)
		{
				komut=new OleDbCommand("insert into yeddi(aracPlaka,girisTarih,aciklama) values('"+aracPlaka.Value.ToString()+"','"+DateTime.Now.ToString()+"','"+aciklama.Value.ToString()+"')");
				komut.Connection=baglan;
				int l=komut.ExecuteNonQuery();
				if(l==1)Response.Write("<script>alert('ekleme işlemi başarılı!');</script>");
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Change_Input_Name

		//----------------------------------------------------------------------
	/*	protected void Changed_Input_Name(object sender, System.EventArgs e)
		{
			Response.Write( _Input_Name.Value + " has changed!<br>");
		}*/

		#endregion
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
			_Button_Ok.ServerClick	 += new EventHandler(Click_Button_Ok);
			//_Input_Name.ServerChange += new EventHandler(Changed_Input_Name);
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	}
}
