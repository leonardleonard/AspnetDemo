<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchBlogs.aspx.cs" Inherits="TestLuceneS.SearchBlogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:TextBox ID ="txtSerach" runat ="server" Width ="494px" />
    <asp:Button ID ="btnSearch" runat ="server" onclick ="btnSearch_Click" Text ="搜索" />
    <asp:Button ID ="CreateView" runat ="server" onclick ="CreateView_Click" Text ="创建索引" />
    <div>
        <asp:Repeater ID ="Repeater1" runat ="server">
        <ItemTemplate>
        <table>
                <tbody>
                    <tr>
                        <td style ="font-size : small; color: red" width="650">
                            <a  id ="link_prd_name" href ='<%#Eval("Id","/book.aspx?id={0}") %> '
                                target ="_blank" name ="link_prd_name">
                                <%#Eval( "Title") %>
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td align ="left">
                            <span style ="font-size : 12px; line-height: 20px">
                                <%#Eval( "ContentDescription") %></ span >
                        </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
        </asp:Repeater>
    </div >





    </form>
</body>
</html>
