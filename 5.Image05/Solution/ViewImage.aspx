<%@ Page Language="C#" %>



<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>


<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"];
        const int BufferSize = 1024;
        if (id != null)
        {
            SqlConnection cn = 
                new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=PhotoDB;Integrated Security=True;");
            SqlCommand cmd = 
                new SqlCommand("select photo from PhotoTable where id=@id", cn);
            cmd.Parameters.AddWithValue("@id", id);

            cn.Open();
            using (SqlDataReader dr =
                      cmd.ExecuteReader(CommandBehavior.SequentialAccess))
            using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
            {
                long currentIndex = 0;
                byte[] buffer = new byte[BufferSize];
                int bytesRead;
                while (dr.Read())
                {
                    currentIndex = 0;
                    bytesRead = (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                    while (bytesRead != 0)
                    {
                        imageStream.Write(buffer, 0, bytesRead);
                        currentIndex += bytesRead;
                        bytesRead =
                        (int)dr.GetBytes(0, currentIndex, buffer, 0, BufferSize);
                    }
                }
                Response.BinaryWrite(imageStream.ToArray());
            }
        }
    }

</script>

