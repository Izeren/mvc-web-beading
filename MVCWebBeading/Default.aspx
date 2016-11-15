<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBeading.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="FormStyles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1> BeadingProject</h1>
        <p> Please set the parametres for canvas </p>
    </div>
        <div>
            <label>Width:</label><input type="number", id="width"/>
        </div>
        <div>
            <label>Height:</label><input type="number", id="height"/>
        </div>
        <div>
            <label>BixelWidth:</label><input type="number", id="bixelwidth"/>
        </div>
        <div>
            <label>BixelHeight:</label><input type="number", id="bixelheight"/>
        </div>
        <div>
            <label>PathToTheImage:</label><input type="text", id="pathtotheimage"/>
        </div>
        <div>
            <button type="submit"> Load the image </button>
        </div>

    </form>
</body>
</html>
