Public Class frmInformacionAdicionalPG
    Public idPeriodo, idMes, idAño As String
    Dim LIAPER As New List(Of String)
    Dim LIAMES As New List(Of String)

    Dim LIAAÑO As New List(Of String)

    Private Sub BTNACEPTAR_Click(sender As Object, e As EventArgs) Handles BTNACEPTAR.Click
        idPeriodo = LIAPER(CBIAPER.SelectedIndex)
        idMes = LIAMES(CBIAMES.SelectedIndex)
        idAño = CBIAAÑO.Text
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub frmInformacionAdicionalPG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OPVisualizacionForm(Me)
        Me.Icon = frmPrincipal.Icon

        OPLlenaComboBox(CBIAPER, LIAPER, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATPERIODICIDAD WHERE ACTIVO=1 ORDER BY CLAVE", frmPrincipal.CadenaConexionFE)
        CBIAAÑO.Items.Clear()
        Dim añoactual As Integer
        añoactual = DatePart(DateInterval.Year, Now)
        CBIAAÑO.Items.Add((añoactual - 1).ToString)
        CBIAAÑO.Items.Add((añoactual).ToString)
        CBIAAÑO.Items.Add((añoactual + 1).ToString)
        CBIAAÑO.SelectedIndex = 1
    End Sub

    Private Sub CBIAPER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBIAPER.SelectedIndexChanged
        Try
            If LIAPER(CBIAPER.SelectedIndex) = "05" Then
                OPLlenaComboBox(CBIAMES, LIAMES, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATMESES WHERE ACTIVO=1 AND CLAVE IN ('13','14','15','16','17','18')", frmPrincipal.CadenaConexionFE)
            Else
                OPLlenaComboBox(CBIAMES, LIAMES, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATMESES WHERE ACTIVO=1 AND CLAVE IN ('01','02','03','04','05','06','07','08','09','10','11','12')", frmPrincipal.CadenaConexionFE)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class