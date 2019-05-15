Public Class Menu
    Dim AddEditForm As New AddEdit()
    Dim UserListForm As New UserList()
    Dim MasterDataEditForm As New MasterDataEdit()

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddBtn.Click

        AddEditForm.ShowDialog()

    End Sub

    Private Sub UserListBtn_Click(sender As Object, e As EventArgs) Handles UserListBtn.Click

        UserListForm.ShowDialog()

    End Sub

    Private Sub MasterEditListBtn_Click(sender As Object, e As EventArgs) Handles MasterEditListBtn.Click

        MasterDataEditForm.ShowDialog()

    End Sub

    Private Sub EndBtn_Click(sender As Object, e As EventArgs) Handles EndBtn.Click
        Me.Close()
    End Sub

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
