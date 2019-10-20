<%@ Page
	Language           = "C#"
	AutoEventWireup    = "false"
	Inherits           = "websayfasi.WebForm1"
	ValidateRequest    = "false"
	EnableSessionState = "false"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>WebForm1</title>

		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
		<meta http-equiv="PRAGMA" content="NO-CACHE" />

		<link href="websayfasi.css" type="text/css" rel="stylesheet" />
		
	</head>
	<body>
		<form id="Form_WebForm1" method="post" runat="server">

			<table>

				<tr>
					<td colspan="2">
						Table
					</td>
				</tr>

				<tr>
				<td>
						arac Plaka
					</td>
					<td>
						<input id="aracPlaka" runat="server" />
					</td>
					
				</tr>
				<tr>
				<td>
					aciklama
					</td>
					<td>
					<input id="aciklama" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<input id="_Button_Ok" type="submit" value="Ekle" runat="server" />
					</td>
				</tr>

				<tr>
					<td colspan="2" align="center">
						<a href="?" >Click Here</a>
					</td>
				</tr>

			</table>

		</form>
	</body>
</html>
