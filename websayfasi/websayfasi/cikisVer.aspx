<%@ Page
	Language           = "C#"
	AutoEventWireup    = "False"
	Inherits           = "websayfasi.cikisVer"
	ValidateRequest    = "false"
	EnableSessionState = "false"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>cikis Verme Sayfasi</title>

		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
		<meta http-equiv="PRAGMA" content="NO-CACHE" />

		<link href="websayfasi.css" type="text/css" rel="stylesheet" />
		
	</head>
	<body>
		<form id="Form_cikisVer" method="post" runat="server">

			<table>

				<tr>
					<td colspan="2">
						Çıkış yapmak
					</td>
				</tr>
				<input type="hidden"  id="id" runat="server"/> 
				<tr>
				<td>
						Arac Plaka
					</td>
					<td>
						<input id="aracPlaka" runat="server" />
					</td>
				</tr>				<tr>
				<td>
						Giriş Tarihi
					</td>
					<td>
						<input id="girisTarihi" runat="server" />
					</td>
				</tr>
				<tr>
				<td>
						Açıklama
					</td>
					<td>
						<input id="aciklama" runat="server" />
					</td>
				</tr>
				<tr>
				<td>
						Ucret
					</td>
					<td>
						<input id="ucret" runat="server" />
					</td>
				</tr>
				<tr>
				<tr>
				<td>
						Geçen gün
					</td>
					<td>
						<input id="gecenGun" runat="server" />
					</td>
				</tr>
					<td colspan="2">
					Çıktı 	<input type="submit" id="cikti" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2" align="center">
						<a href="?" >Buraya tıklat</a>
					</td>
				</tr>

			</table>

		</form>
	</body>
</html>
