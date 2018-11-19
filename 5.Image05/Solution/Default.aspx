<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select id from PhotoTable", cn);

            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            lst.DataSource = dt;
            lst.DataTextField = "id";
            lst.DataBind();

            dr.Close();
            cn.Close();
        }
    }

    protected void lst_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = lst.SelectedValue.ToString();
        //img.ImageUrl = "ViewImage.aspx?id=" + id;
        img.ImageUrl = "ViewImage.ashx?id=" + id;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UploadImage.aspx">上載檔案</asp:HyperLink>
            <asp:ListBox ID="lst" runat="server" AutoPostBack="True" Height="129px" Width="307px" OnSelectedIndexChanged="lst_SelectedIndexChanged"></asp:ListBox>
            <asp:Image ID="img" runat="server"></asp:Image>
        </div>
    </form>
</body>
</html>
