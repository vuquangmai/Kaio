<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Prjs.Portal.Report.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/clipboard.js/1.5.3/clipboard.min.js"></script>
     <script type="text/javascript">
         new Clipboard(".fw-code-copy-button", {
             text: function (trigger) {
                 return $(trigger).parent().find('code').first().text().trim();
             }
         });
        </script>
    <style>
    .fw-code-copy {
  display: block;
  position: relative;
  width: 400px;
  height: 30px;
  background: #FFE;
  border: thin solid #FF0;
  margin-bottom: 0.5em;
  padding: 0.5em;
}
.fw-code-copy-button {
  position: absolute;
  top: 8px;
  right: 8px;
  padding: 0.25em;
  border: thin solid #777;
  background: #800080;
  color: #FFF;
}
.fw-code-copy-button:hover {
  border: thin solid #DDD;
  background: #992699;
  cursor: pointer;
}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <span class="fw-code-copy">
  <span class="fw-code-copy-button">Copy</span>
  <code>&lt;link rel=&quot;stylesheet&quot; href=&quot;style-1.css&quot;&gt;</code>
</span>
<span class="fw-code-copy">
  <span class="fw-code-copy-button">Copy</span>
  <code>&lt;link rel=&quot;stylesheet&quot; href=&quot;style-2.css&quot;&gt;</code>
</span>
<span class="fw-code-copy">
  <span class="fw-code-copy-button">Copy</span>
  <code>&lt;link rel=&quot;stylesheet&quot; href=&quot;style-3.css&quot;&gt;</code>
</span>
    </div>
    </form>
</body>
</html>
