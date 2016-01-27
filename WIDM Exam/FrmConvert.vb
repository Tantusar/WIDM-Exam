Public Class FrmConvert
    Private Sub comboVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboVersion.SelectedIndexChanged

    End Sub

    Private Sub FrmConvert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboVersion.DataSource = [Enum].GetValues(GetType(OldImport.FileVersion))
    End Sub

    Private Sub btnOld_Click(sender As Object, e As EventArgs) Handles btnOld.Click
        If OpenOld.ShowDialog() = DialogResult.OK Then
            txtOld.Text = OpenOld.FileName
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If SaveNew.ShowDialog() = DialogResult.OK Then
            txtNew.Text = SaveNew.FileName
        End If
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        Dim convert As New OldImport
        If convert.Convert(txtOld.Text, comboVersion.SelectedItem, txtNew.Text) = True Then
            MsgBox(GetLang("SavedSuccess"), MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtOld_TextChanged(sender As Object, e As EventArgs) Handles txtOld.TextChanged
        If txtOld.Text.EndsWith(".widm") Then
            comboVersion.SelectedItem = OldImport.FileVersion.v1
        ElseIf txtOld.Text.EndsWith(".widm2") Then
            comboVersion.SelectedItem = OldImport.FileVersion.v2
        End If
    End Sub
End Class