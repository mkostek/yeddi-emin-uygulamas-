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
		protected	HtmlTextArea	aciklama;
		protected	HtmlInputButton		btn;

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
		#region Page baslat
		public void baslat(){
			komut=new OleDbCommand("select top 100 * from yeddi where cikti=0");
			komut.Connection=baglan;
			rd=komut.ExecuteReader();
			Response.Write("<table><tr><th>Sil</th><th>Ayrıntı</th><th>araç plaka</th><th>giris tarih</th><th>acıklama</th><th>çıktı mı?</th></tr>");
			while(rd.Read())
			{
				Response.Write("<tr><td><a onclick='Sil("+rd["id"]+")'>sil</a></td><td><a href=cikisVer.aspx?id="+rd["id"]+">ayrıntı</a></td><td>"+rd["aracPlaka"]+"</td><td>"+rd["girisTarih"]+"</td><td>"+rd["aciklama"].ToString().Substring(0,10)+"...</td><td>"+rd["cikti"]+"</td></tr>");
			}
			Response.Write("</table>");
		}
		#endregion
		#region sil
		public void sil(int id){
			komut=new OleDbCommand("delete from yeddi where id="+id+"");
			komut.Connection=baglan;
			int l=komut.ExecuteNonQuery();
			if(l==1)Response.Write("<script>alert('silme işlemi başarılı!');</script>");
		}
		#endregion
		#region load
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!String.IsNullOrEmpty(Request.QueryString["sil"])){
				sil(Convert.ToInt32(Request.QueryString["sil"]));
			}
			Response.Write(Request.QueryString["id"]);
			//------------------------------------------------------------------
			if(!IsPostBack)
			{
				baslat();
			}
			
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Click_Button_OK

		//----------------------------------------------------------------------
		protected void Click_Button_Ok(object sender, System.EventArgs e)
		{
			if(aciklama.Value.ToString().Length<20){
				Response.Write("<script>alert('aciklama bilgisi en az 20 karakter olmalıdır!');</script>");
			}else if(aracPlaka.Value.ToString().Length<4){
				Response.Write("<script>alert('plaka en az 4 karakterden oluşmalıdır!');</script>");
			}else{
			komut=new OleDbCommand("insert into yeddi(aracPlaka,girisTarih,aciklama) values('"+aracPlaka.Value.ToString()+"','"+DateTime.Now.ToString()+"','"+aciklama.Value.ToString()+"')");
			komut.Connection=baglan;
			int l=komut.ExecuteNonQuery();
			if(l==1)Response.Write("<script>alert('ekleme işlemi başarılı!');</script>");
			}
			baslat();
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Ara

		//----------------------------------------------------------------------
		protected void ara(object sender, System.EventArgs e)
		{
			if(Convert.ToString(aciklama.Value).Length==0 && Convert.ToString(aracPlaka.Value).Length==0)
				komut=new OleDbCommand("select top 100 * from yeddi where cikti=0");
			else if(Convert.ToString(aciklama.Value).Length==0)
				komut=new OleDbCommand("select * from yeddi where cikti=0  and aracPlaka='"+aracPlaka.Value+"' ");
			else if(Convert.ToString(aracPlaka.Value).Length==0)
				komut=new OleDbCommand("select * from yeddi where cikti=0 and aciklama like '%"+aciklama.Value+"%' ");
			else
				komut=new OleDbCommand("select * from yeddi where cikti=0 and aciklama like '%"+aciklama.Value+"%' and aracPlaka='"+aracPlaka.Value+"' ");
			komut.Connection=baglan;
			rd=komut.ExecuteReader();
			Response.Write("<table><tr><th>Sil</th><th>Ayrıntı</th><th>araç plaka</th><th>giris tarih</th><th>acıklama</th><th>çıktı mı?</th></tr>");
			while(rd.Read())
			{
				Response.Write("<tr><td><a href=aracGir.aspx?sil="+rd["id"]+">sil</a></td><td><a href=cikisVer.aspx?id="+rd["id"]+">ayrıntı</a></td><td>"+rd["aracPlaka"]+"</td><td>"+rd["girisTarih"]+"</td><td>"+rd["aciklama"]+"</td><td>"+rd["cikti"]+"</td></tr>");
			}
			Response.Write("</table>");
		}

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Add more events here...

		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#region Initialize Component
		protected override void RenderChildren(HtmlTextWriter output)
		{
			foreach(Control c in base.Controls)
			{
				c.RenderControl(output);
			}
		}
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
			btn.ServerClick+=new EventHandler(ara);
			//_Input_Name.ServerChange += new EventHandler(Changed_Input_Name);
			//------------------------------------------------------------------
		}
		#endregion
		//<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	}
}
