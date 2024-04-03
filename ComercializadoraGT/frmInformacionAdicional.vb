Public Class frmInformacionAdicional
    Dim LIAPER As New List(Of String)
    Dim LIAMES As New List(Of String)
    Dim LIAAÑO As New List(Of String)
    Private Sub frmInformacionAdicional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OPVisualizacionForm(Me)
        Me.Icon = frmPrincipal.Icon
        OPLlenaComboBox(CBIAPER, LIAPER, "SELECT CLAVE,CLAVE +' - '+NOMBRE FROM CSATPERIODICIDAD WHERE ACTIVO=1 ORDER BY CLAVE", CADENA)

    End Sub
End Class