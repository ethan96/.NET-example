<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.IO" %>

<!DOCTYPE html>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
          byte[] fileData = null;
  if (FileUpload1 != null) {
    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0)) {

      string fn = Path.GetFileName(FileUpload1.PostedFile.FileName);
      try {

        Stream str = FileUpload1.PostedFile.InputStream;
        int len = (int)str.Length;
        fileData = new byte[len];
        str.Read(fileData, 0, len);
        str.Close();

        SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand("INSERT INTO PhotoTable (photo) VALUES (@photo)", cn);
        SqlParameter param1 = new SqlParameter("@photo", SqlDbType.Image);
        param1.Value = fileData;
        cmd.Parameters.Add(param1);
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        Response.Redirect("default.aspx");
      }
      catch (Exception ex) {
        Label1.Text = "發生錯誤 : " + ex.Message;

      }

    }
  }

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
  <br />
    <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
  <br />
  <asp:Label ID="Label1" runat="server"></asp:Label>

  </div>
  </form>
</body>
</html>
