<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FatturaGrid.ascx.cs" Inherits="WebUserControls.GenTest.FatturaGridView" %>
        <%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>

        <obout:Grid ID="grid" runat="server"
            EnableRecordHover="True"
            Width="100%"
            AllowAddingRecords="False" 
            AutoGenerateColumns="False"
            AllowFiltering="True"
            >
        </obout:Grid>
        <Columns>
			<obout:Column DataField="UId" HeaderText="Id" runat="server" Width="40"/>
			<obout:Column DataField="Intestatario" HeaderText="Intestatario" runat="server" Width="120" />
<obout:Column DataField="Numero" HeaderText="Numero" runat="server" Width="120" />
		</Columns>
         
