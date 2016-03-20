<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleriaGrid.ascx.cs" Inherits="Netical.Fotografia.UIL.WUC_GalleriaGrid" %>

<obout:Grid ID="grid" runat="server" 
    CallbackMode="false"
    AutoGenerateColumns="false" 
    AllowAddingRecords="false"
    Serialize="false" 
    AutoPostBackOnSelect="true"
    OnLoad="gridGalleria_Load"
    OnSelect="gridGalleria_OnSelect"
    OnRowDataBound="gridGalleria_RowDataBound"
    >
    <Columns>
        <obout:Column DataField="UId" HeaderText="Id" runat="server" Width="40"/>
        <obout:Column HeaderText="Categoria" runat="server" Width="120"/>
        <obout:Column DataField="Titolo" HeaderText="Titolo" runat="server" Width="120" />
    </Columns>
</obout:Grid>
