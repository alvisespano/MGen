<%@ Control Language="C#" ClassName="FatturaFormFields" %>
        <asp:FormView ID="$ID$" runat="server">
	        <ItemTemplate>
		        <table border="0" cellpadding="3" cellspacing="1">
			    <tr>
	        <td>Intestatario:</td>
	        <td>
		        <asp:TextBox ID="dataIntestatario" runat="server"
		            Text='<%# Bind("Intestatario") %>'
		            MaxLength="50">
		        </asp:TextBox>
		        <asp:RequiredFieldValidator ID="ReqVal_dataIntestatario" runat="server"
		    Display="Dynamic"
		    ControlToValidate="dataIntestatario"
		    ErrorMessage="Field is required">
		 </asp:RequiredFieldValidator>
		
	        </td>
        </tr>
        
<tr>
	        <td>Descrizione:</td>
	        <td>
		        <asp:TextBox ID="dataDescrizione" runat="server"
		            Text='<%# Bind("Descrizione") %>'
		            MaxLength="50">
		        </asp:TextBox>
		        
	        </td>
        </tr>
        
<tr>
	        <td>Numero:</td>
	        <td>
		        <asp:TextBox ID="dataNumero" runat="server"
		            Text='<%# Bind("Numero") %>'
		            MaxLength="50">
		        </asp:TextBox>
		        <asp:RequiredFieldValidator ID="ReqVal_dataNumero" runat="server"
		    Display="Dynamic"
		    ControlToValidate="dataNumero"
		    ErrorMessage="Field is required">
		 </asp:RequiredFieldValidator>
		
	        </td>
        </tr>
        
<tr>
	        <td>Data:</td>
	        <td>
		        <asp:TextBox ID="dataData" runat="server"
		            Text='<%# Bind("Data") %>'
		            MaxLength="50">
		        </asp:TextBox>
		        <asp:RequiredFieldValidator ID="ReqVal_dataData" runat="server"
		    Display="Dynamic"
		    ControlToValidate="dataData"
		    ErrorMessage="Field is required">
		 </asp:RequiredFieldValidator>
		
	        </td>
        </tr>
                			
		        </table>
	        </ItemTemplate>
        </asp:FormView>
        
