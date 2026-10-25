<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Tarea_3.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Calculadora</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> &nbsp; Calculadora Web</h1> 
            <br />
            <label>Ingrese el primer número:</label>
            <asp:TextBox ID="tn1" runat="server"></asp:TextBox>
            <br />
            Ingrese el segundo número:<asp:TextBox ID="tn2" runat="server"></asp:TextBox>
            <br />
            <br />
            Resultado:
            <asp:Label ID="lresultado" runat="server" Text="0"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="doperacion" runat="server">
                <asp:ListItem>Suma</asp:ListItem>
                <asp:ListItem>Resta</asp:ListItem>
                <asp:ListItem>División</asp:ListItem>
                <asp:ListItem>Multiplicación</asp:ListItem>
                <asp:ListItem>Potencia</asp:ListItem>
                <asp:ListItem>Exponente</asp:ListItem>
            
            </asp:DropDownList>

        </div>
        <p>
            <asp:RadioButton ID="rsuma" runat="server" GroupName="operacion" Text="Suma"  />
        </p>
        <p>
            <asp:RadioButton ID="rresta" runat="server" GroupName="operacion" Text="Resta"  />
        </p>
        <p>
            <asp:RadioButton ID="rDivision" runat="server" GroupName="operacion" Text="División"  />
        </p>
        <p>
            <asp:RadioButton ID="rmultiplicacion" runat="server" GroupName="operacion" Text="Multiplicación"  />
        </p>
        <p>
            <asp:RadioButton ID="rpotencia" runat="server" GroupName="operacion" Text="Potencia"  />
        </p>
        <p>
            <asp:RadioButton ID="rexponte" runat="server" GroupName="operacion" Text="Exponente"  />
        </p>
        <p>
        <asp:Button ID="bresultado" runat="server" Height="38px" Text="Aceptar" Width="128px" OnClick="bresultado_Click" BackColor="White" BorderColor="White" />
        </p>
    </form>
</body>
</html>
