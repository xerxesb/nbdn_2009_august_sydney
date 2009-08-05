<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" CodeFile="~/views/DepartmentBrowser.aspx.cs"  MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.infrastructure"%>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            <% this.model.each(item =>
{%>
        	<tr class="ListItem">
               		 <td>                     
                    <%=item.name%>
                	</td>
           	 </tr>    
           	 <%
              }); %>
	    </table>            
</asp:Content>
