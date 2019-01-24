<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Mshan.DatabaseDocument._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div style=" margin:5px auto; width:950px; text-align:center; font-size:28pt;">
    公交平台表结构
</div>
<div style=" float:left;"></div>
<div style=" margin:5px auto; width:950px;">
    <% int i = 1;
        foreach (System.Collections.Generic.KeyValuePair<string, Mshan.DatabaseDocument.TableEntity.Table> kvp in userTable)
      {
          %>
          <div style="font-size:18; font-weight:150; padding:10px 0"><%=i++%>&bull;<%=kvp.Key %>(<%=kvp.Value.Comments %>) </div>
          <table width="900" border="2" style=" margin:5px 3px;">
                     <tr>       
                            <td colspan=3>
                                <%=kvp.Key %>(<%=kvp.Value.TableSpace %>)<%=kvp.Value.Comments %>
                            </td>
                    </tr>
                    <tr>       
                            <td style="width:20%">
                                列名
                            </td>
                            <td style="width:20%">
                                类型
                            </td>
                            <td style="width:60%">
                                注释
                            </td>
                    </tr>  
                      <%foreach (System.Collections.Generic.KeyValuePair<string, Mshan.DatabaseDocument.TableEntity.Column> column in kvp.Value.Columns)
                                  { %>
                    <tr>       
                            <td>

                                  <%=column.Key %>
                                
                            </td>
                            <td>
                                 <%=column.Value.ColumnType %>(<%=column.Value.ColumnLength %>)
                            </td>
                            <td>
                                 <%=column.Value.Comments %><br />
                                  默认值：<%=System.String.IsNullOrEmpty(column.Value.DefaultValue)?"无": column.Value.DefaultValue%>
                            </td>
                    </tr>
                    <%} %>

                    <tr>       
                            <td colspan=3>
                                                 <%foreach (System.Collections.Generic.KeyValuePair<string, Mshan.DatabaseDocument.TableEntity.Index> index in kvp.Value.Indexes)
                      { %>    
                            <%=index.Value.Uniqueness%>索引: <%=index.Key%><br />
                             (
                              <%foreach (System.Collections.Generic.KeyValuePair<string, string> indexColumn in index.Value.Columns)
                                { %>
                                <%=indexColumn.Key + " " + indexColumn.Value%><br />
                                <%} %>
                             )<br />
                             表空间：<%=index.Value.TableSpace %> <br />
                             <%} %>
                            </td>
                    </tr> 
                   
                     <%foreach (System.Collections.Generic.KeyValuePair<string, Mshan.DatabaseDocument.TableEntity.Trigger> trigger in kvp.Value.Triggeres)
                              { %>   
                    <tr>   
                            <td colspan=3>
                                 触发器：
                             <%=trigger.Key %><br />
                             <%=trigger.Value.TriggeringEvent %><br />
                             <%=trigger.Value.TriggerBody %>

                            </td>
                            <%} %>
                    </tr>
          
          </table>
              <br />
              
     <% } %>
     </div>
</asp:Content>
