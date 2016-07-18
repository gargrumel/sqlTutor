Public Class docs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles menuList.SelectedIndexChanged
        txtInfo.Text = menuList.SelectedValue.ToString
    End Sub
End Class