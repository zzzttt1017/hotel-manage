﻿<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" %>

<script runat="server">
protected void Page_Load(object sender, EventArgs e)
{
    this.Label1.Text = Request.Form["content1"];
}

</script>

<!doctype html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>KindEditor ASP.NET</title>
    <link rel="stylesheet" href="/Adminhyl/TxtEditor/themes/default/default.css" />
	<link rel="stylesheet" href="/Adminhyl/TxtEditor/plugins/code/prettify.css" />
	<script  type="text/javascript" charset="utf-8" src="/Adminhyl/TxtEditor/kindeditor.js"></script>
	<script  type="text/javascript" charset="utf-8" src="/Adminhyl/TxtEditor/lang/zh_CN.js"></script>
	<script  type="text/javascript" charset="utf-8" src="/Adminhyl/TxtEditor/plugins/code/prettify.js"></script>
	<script>
		KindEditor.ready(function(K) {
			var editor1 = K.create('#content1', {
				cssPath : 'plugins/code/prettify.css',
				uploadJson : 'asp.net/upload_json.ashx',
				fileManagerJson : 'file_manager_json.ashx',
				allowFileManager : true,
				afterCreate : function() {
					var self = this;
					K.ctrl(document, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
					K.ctrl(self.edit.doc, 13, function() {
						self.sync();
						K('form[name=example]')[0].submit();
					});
				}
			});
			prettyPrint();
		});
	</script>
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <form id="example" runat="server">
        <textarea id="content1" cols="100" rows="8" style="width:700px;height:200px;visibility:hidden;" runat="server"></textarea>
        <br />
        <asp:Button ID="Button1" runat="server" Text="提交内容" /> (提交快捷键: Ctrl + Enter)
    </form>
</body>
</html>
