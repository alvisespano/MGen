<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleriaDetail.ascx.cs"
    Inherits="Netical.Fotografia.UIL.WUC_GalleriaDetail" %>
<%@ Register Src="~/Manager/UserControls/Message.ascx" TagName="Message" TagPrefix="wuc" %>

<wuc:Message ID="controlMessage" runat="server" Visible="false" />
<asp:FormView ID="fview" runat="server" DefaultMode="ReadOnly" DataKeyNames="UId"
    OnModeChanging="fview_ModeChanging" OnItemDeleting="fview_ItemDeleting" OnItemInserting="fview_ItemInserting"
    OnItemUpdating="fview_ItemUpdating" OnItemCommand="fview_ItemCommand" OnDataBound="fview_DataBound">
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
                    Categoria:
                </th>
                <td>
                    <asp:Label ID="dataCategoria" runat="server"/>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Titolo:
                </th>
                <td>
                    <asp:Label ID="dataTitolo" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Sede:
                </th>
                <td>
                    <asp:Label ID="dataSede" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Persona:
                </th>
                <td>
                    <asp:Label ID="dataPersona" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Indirizzo:
                </th>
                <td>
                    <asp:Label ID="dataIndirizzo" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Indirizzo2:
                </th>
                <td>
                    <asp:Label ID="dataIndirizzo2" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Città:
                </th>
                <td>
                    <asp:Label ID="dataCitta" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    CAP:
                </th>
                <td>
                    <asp:Label ID="dataCAP" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Provincia:
                </th>
                <td>
                    <asp:Label ID="dataProvincia" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Nazione:
                </th>
                <td>
                    <asp:Label ID="dataNazione" runat="server"/>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Telefono:
                </th>
                <td>
                    <asp:Label ID="dataTelefono" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Fax:
                </th>
                <td>
                    <asp:Label ID="dataFax" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="field">
                    Note:
                </th>
                <td>
                    <asp:Label ID="dataNote" runat="server" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
    <EditItemTemplate>
        <table>
            <tr>
                <th class="required">
                    Categoria:
                </th>
                <td>
                    <asp:DropDownList ID="dataCategoria" runat="server" 
                        DataTextField="Nome" 
                        DataValueField="UId" 
                        AppendDataBoundItems="true"
                        >
                        <asp:ListItem Value="0">Seleziona...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="rvdataCategoria" runat="server" Type="Integer" MinimumValue="1" MaximumValue="2147483647" ControlToValidate="dataCategoria" Display="Dynamic" ErrorMessage="Richiesto">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Titolo:
                </th>
                <td>
                    <asp:TextBox ID="dataTitolo" runat="server" />
                    <asp:RequiredFieldValidator ID="dataTitoloValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataTitolo">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Sede:
                </th>
                <td>
                    <asp:TextBox ID="dataSede" runat="server" />
                    <asp:RequiredFieldValidator ID="dataSedeValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataSede">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Persona:
                </th>
                <td>
                    <asp:TextBox ID="dataPersona" runat="server" />
                    <asp:RequiredFieldValidator ID="dataPersonaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataPersona">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Indirizzo:
                </th>
                <td>
                    <asp:TextBox ID="dataIndirizzo" runat="server" />
                    <asp:RequiredFieldValidator ID="dataIndirizzoValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataIndirizzo">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Indirizzo2:
                </th>
                <td>
                    <asp:TextBox ID="dataIndirizzo2" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="required">
                    Città:
                </th>
                <td>
                    <asp:TextBox ID="dataCitta" runat="server" />
                    <asp:RequiredFieldValidator ID="dataCittaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataCitta">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    CAP:
                </th>
                <td>
                    <asp:TextBox ID="dataCAP" runat="server" />
                    <asp:RequiredFieldValidator ID="dataCAPValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataCAP">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="dataCAPValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataCAP" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Provincia:
                </th>
                <td>
                    <asp:TextBox ID="dataProvincia" runat="server" />
                    <asp:RequiredFieldValidator ID="dataProvinciaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataProvincia">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Nazione:
                </th>
                <td>
                    <asp:DropDownList ID="dataNazione" runat="server" 
                        DataTextField="Nome" 
                        DataValueField="UId" 
                        AppendDataBoundItems="true"
                        >
                        <asp:ListItem Value="0">Seleziona...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="rvdataNazione" runat="server" Type="Integer" MinimumValue="1" MaximumValue="2147483647" ControlToValidate="dataNazione" Display="Dynamic" ErrorMessage="Richiesto">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Telefono:
                </th>
                <td>
                    <asp:TextBox ID="dataTelefono" runat="server" />
                    <asp:RequiredFieldValidator ID="dataTelefonoValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataTelefono">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="dataTelefonoValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataTelefono" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Fax:
                </th>
                <td>
                    <asp:TextBox ID="dataFax" runat="server" />
                    <asp:RegularExpressionValidator ID="dataFaxValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataFax" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Note:
                </th>
                <td>
                    <asp:TextBox ID="dataNote" runat="server" />
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
                    Categoria:
                </th>
                <td>
                    <asp:DropDownList ID="dataCategoria" runat="server" 
                        DataTextField="Nome" 
                        DataValueField="UId" 
                        AppendDataBoundItems="true"
                        >
                        <asp:ListItem Value="0">Seleziona...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="rvdataCategoria" runat="server" Type="Integer" MinimumValue="1" MaximumValue="2147483647" ControlToValidate="dataCategoria" Display="Dynamic" ErrorMessage="Richiesto">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Titolo:
                </th>
                <td>
                    <asp:TextBox ID="dataTitolo" runat="server" />
                    <asp:RequiredFieldValidator ID="dataTitoloValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataTitolo">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Sede:
                </th>
                <td>
                    <asp:TextBox ID="dataSede" runat="server" />
                    <asp:RequiredFieldValidator ID="dataSedeValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataSede">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Persona:
                </th>
                <td>
                    <asp:TextBox ID="dataPersona" runat="server" />
                    <asp:RequiredFieldValidator ID="dataPersonaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataPersona">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Indirizzo:
                </th>
                <td>
                    <asp:TextBox ID="dataIndirizzo" runat="server" />
                    <asp:RequiredFieldValidator ID="dataIndirizzoValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataIndirizzo">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Indirizzo2:
                </th>
                <td>
                    <asp:TextBox ID="dataIndirizzo2" runat="server" />
                </td>
            </tr>
            <tr>
                <th class="required">
                    Città:
                </th>
                <td>
                    <asp:TextBox ID="dataCitta" runat="server" />
                    <asp:RequiredFieldValidator ID="dataCittaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataCitta">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    CAP:
                </th>
                <td>
                    <asp:TextBox ID="dataCAP" runat="server" />
                    <asp:RequiredFieldValidator ID="dataCAPValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataCAP">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="dataCAPValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataCAP" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Provincia:
                </th>
                <td>
                    <asp:TextBox ID="dataProvincia" runat="server" />
                    <asp:RequiredFieldValidator ID="dataProvinciaValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataProvincia">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Nazione:
                </th>
                <td>
                    <asp:DropDownList ID="dataNazione" runat="server" 
                        DataTextField="Nome" 
                        DataValueField="UId" 
                        AppendDataBoundItems="true"
                        >
                        <asp:ListItem Value="0">Seleziona...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="rvdataNazione" runat="server" Type="Integer" MinimumValue="1" MaximumValue="2147483647" ControlToValidate="dataNazione" Display="Dynamic" ErrorMessage="Richiesto">*</asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Telefono:
                </th>
                <td>
                    <asp:TextBox ID="dataTelefono" runat="server" />
                    <asp:RequiredFieldValidator ID="dataTelefonoValidator" runat="server" ErrorMessage="Campo Richiesto"
                        ControlToValidate="dataTelefono">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="dataTelefonoValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataTelefono" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="required">
                    Fax:
                </th>
                <td>
                    <asp:TextBox ID="dataFax" runat="server" />
                    <asp:RegularExpressionValidator ID="dataFaxValidator2" runat="server" ErrorMessage="Dati inseriti non validi"
                        ControlToValidate="dataFax" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <th class="field">
                    Note:
                </th>
                <td>
                    <asp:TextBox ID="dataNote" runat="server" />
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
