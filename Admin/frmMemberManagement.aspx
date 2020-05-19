<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMemberManagement.aspx.vb" Inherits="Admin_frmMemberManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:RadioButtonList ID="radMemberType" runat="server">
        </asp:RadioButtonList>
    
        <asp:Button ID="btnDisplayMembers" runat="server" Text="Display Members" />
    
                <%--########################################################################################################--%>
                    <asp:GridView ID="grdData" AutoGenerateColumns="false" runat="server">
                        <Columns>
                        
                        
                            <asp:BoundField     DataField="UserIdUS"     HeaderText="" />
                            
                            
                            <asp:BoundField     DataField="UserIdUS"     HeaderText="" />
                           
                                                                                                
                            <asp:BoundField     DataField="FullNameUS"         HeaderText="Full Name" />
                            <asp:BoundField     DataField="EmailUS"       HeaderText="Email" />
                            <%--<asp:BoundField     DataField="GenderName"  HeaderText="Number of Titles out" />--%>
                            
                            
                        </Columns>
                    </asp:GridView>
                    <%--########################################################################################################--%>
        

        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    
    </div>
    </form>
</body>
</html>
