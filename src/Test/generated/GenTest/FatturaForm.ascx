<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FatturaForm.ascx.cs" Inherits="WebUserControls.FatturaForm" %>
		<%@ Register Src="~/Manager/UserControls/Message.ascx" TagName="Message" TagPrefix="wuc" %>

		<wuc:Message ID="controlMessage" runat="server" Visible="false" />
		<asp:FormView ID="fview" runat="server" DefaultMode="ReadOnly" DataKeyNames="UId"
			OnModeChanging="fviewModeChanging" OnItemDeleting="fviewItemDeleting" OnItemInserting="fviewItemInserting"
			OnItemUpdating="fviewItemUpdating" OnItemCommand="fviewItemCommand" OnDataBound="fviewDataBound">
			<HeaderTemplate>
				<asp:Image ID="imgNew" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\add.gif" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
				<asp:LinkButton ID="btnNew" runat="server"  ImageAlign="TextTop" ImageUrl="~\Manager\Images\add.gif" Text="Nuovo" CommandName="New" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
				<asp:Image ID="imgEdit" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\pencil.gif" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
				<asp:LinkButton ID="btnEdit" runat="server" Text="Modifica" CommandName="Edit" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
				<asp:Image ID="imgDelete" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\cross.gif" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
				<asp:LinkButton ID="btnDelete" runat="server" Text="Elimina" CommandName="Delete" Visible='<%# fview.CurrentMode == FormViewMode.ReadOnly %>' />
			</HeaderTemplate>
			<ItemTemplate>
				<div>
					<hr size="1" style="height:1px;color:#ddd;text-align:left;margin:5px 0 5px 0;" />
				</div>
				<table>
				<tr>
            <th class="field">
                Intestatario:
            </th>
            <td>
                <asp:Label ID="dataIntestatario" runat="server"/>
            </td>
        </tr>
        
<tr>
            <th class="field">
                Descrizione:
            </th>
            <td>
                <asp:Label ID="dataDescrizione" runat="server"/>
            </td>
        </tr>
        
<tr>
            <th class="field">
                Numero:
            </th>
            <td>
                <asp:Label ID="dataNumero" runat="server"/>
            </td>
        </tr>
        
<tr>
            <th class="field">
                Data:
            </th>
            <td>
                <asp:Label ID="dataData" runat="server"/>
            </td>
        </tr>
        
				</table>
			</ItemTemplate>
			<EditItemTemplate>
				<table>
				<tr>
            <th class="required">
                Intestatario:
            </th>
            <td>
                <asp:TextBox ID="dataIntestatario" runat="server" />
                <asp:RequiredFieldValidator ID="rfvdataIntestatario" runat="server" ErrorMessage="Campo Richiesto"
                    ControlToValidate="dataIntestatario">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
<tr>
            <th class="field">
                Descrizione:
            </th>
            <td>
                <asp:TextBox ID="dataDescrizione" runat="server" />
            </td>
        </tr>
        
<tr>
            <th class="required">
                Numero:
            </th>
            <td>
                <asp:TextBox ID="dataNumero" runat="server" />
				<asp:RequiredFieldValidator ID="rfvdataNumero" runat="server" ErrorMessage="Campo Richiesto" ControlToValidate="dataNumero">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revdataNumero" runat="server" ErrorMessage=\Dati inseriti non validi"
					ControlToValidate="dataNumero" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </td>
        </tr>
        
<tr>
            <th class="required">
                Data:
            </th>
            <td>
                <asp:TextBox ID="dataData" runat="server" />
                <asp:RequiredFieldValidator ID="rfvdataData" runat="server" ErrorMessage="Campo Richiesto"
                    ControlToValidate="dataData">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
				</table>
				<div>
					<hr size="1" style="height:1px;color:#ddd;text-align:left;margin:5px 0 5px 0;" />
				</div>
			</EditItemTemplate>
			<InsertItemTemplate>
				<table>
				<tr>
            <th class="required">
                Intestatario:
            </th>
            <td>
                <asp:TextBox ID="dataIntestatario" runat="server" />
                <asp:RequiredFieldValidator ID="rfvdataIntestatario" runat="server" ErrorMessage="Campo Richiesto"
                    ControlToValidate="dataIntestatario">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
<tr>
            <th class="field">
                Descrizione:
            </th>
            <td>
                <asp:TextBox ID="dataDescrizione" runat="server" />
            </td>
        </tr>
        
<tr>
            <th class="required">
                Numero:
            </th>
            <td>
                <asp:TextBox ID="dataNumero" runat="server" />
				<asp:RequiredFieldValidator ID="rfvdataNumero" runat="server" ErrorMessage="Campo Richiesto" ControlToValidate="dataNumero">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revdataNumero" runat="server" ErrorMessage=\Dati inseriti non validi"
					ControlToValidate="dataNumero" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </td>
        </tr>
        
<tr>
            <th class="required">
                Data:
            </th>
            <td>
                <asp:TextBox ID="dataData" runat="server" />
                <asp:RequiredFieldValidator ID="rfvdataData" runat="server" ErrorMessage="Campo Richiesto"
                    ControlToValidate="dataData">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
				</table>
				<div>
					<hr size="1" style="height:1px;color:#ddd;text-align:left;margin:5px 0 5px 0;" />
				</div>
			</InsertItemTemplate>
			<EmptyDataTemplate>
				<div>
					Nessun elemento da visualizzare.
				</div>
				<div>
					<hr size="1" style="height:1px;color:#ddd;text-align:left;margin:5px 0 5px 0;" />
				</div>
				<asp:Image ID="imgNew" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\add.gif" />
				<asp:LinkButton ID="btnNew" runat="server" Text="Nuovo" CommandName="New" />
			</EmptyDataTemplate>
			<FooterTemplate>
				<asp:Image ID="imgInsert" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\add.gif" Visible='<%# fview.CurrentMode == FormViewMode.Insert %>' />
				<asp:LinkButton ID="btnInsert" runat="server" Text="Inserisci" CommandName="Insert" Visible='<%# fview.CurrentMode == FormViewMode.Insert %>' />
				<asp:Image ID="imgSave" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\disk.gif" Visible='<%# fview.CurrentMode == FormViewMode.Edit %>' />
				<asp:LinkButton ID="btnSave" runat="server" Text="Aggiorna" CommandName="Update" Visible='<%# fview.CurrentMode == FormViewMode.Edit %>' />
				<asp:Image ID="imgCancel" runat="server" ImageAlign="AbsMiddle" ImageUrl="~\Manager\Images\lt.gif" Visible='<%# fview.CurrentMode == FormViewMode.Insert || fview.CurrentMode == FormViewMode.Edit %>' />
				<asp:LinkButton ID="btnCancel" runat="server" Text="Annulla" CausesValidation="false" CommandName="Cancel" Visible='<%# fview.CurrentMode == FormViewMode.Insert || fview.CurrentMode == FormViewMode.Edit %>' />
			</FooterTemplate>
		</asp:FormView>
        
