<%@ Page Title="" Language="C#" MasterPageFile="~/Adminhyl/Adminhyl.Master" AutoEventWireup="true"
    CodeBehind="SuggestionList.aspx.cs" Inherits="HotelWebProject.Adminhyl.SuggestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="book-title">
            投诉时间</div>
        <div class="book-title">
            客户姓名</div>
        <div class="book-title">
            联系电话</div>
        <div class="book-title">
            电子邮件</div>
        <div class="book-title" style="width: 324px;">
            消费情况</div>
        <div class="book-title" style="width: 100px;">
            操作</div>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="book-title">
                    <%#Eval("SuggestTime", "{0:yyyy-MM-dd HH:mm}")%>
                </div>
                <div class="book-title">
                    <%#Eval("CustomerName")%>
                </div>
                <div class="book-title">
                    <%#Eval("PhoneNumber")%>
                </div>
                <div class="book-title">
                    <%#Eval("Email")%>
                </div>
                <div class="book-title" style="width: 324px;">
                   <%#Eval("ConsumeDesc")%>
                </div>
                <div class="book-title" style="width: 100px;">
                    <asp:LinkButton ID="lbtnPass" OnClientClick="return confirm('确定受理投诉?')" OnClick="btnOperation_Click" CommandArgument='<%#Eval("SuggestionId")%>'  runat="server">受理投诉</asp:LinkButton>
                </div>
                <div class="bookdetail">
                    <div class="book-comment">
                        具体投诉说明：<%#Eval("SuggestionDesc")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
</asp:Content>
