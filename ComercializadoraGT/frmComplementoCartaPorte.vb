Public Class frmComplementoCartaPorte
    Dim LVE As New List(Of String)
    Dim LCHO As New List(Of String)
    Dim LEDO As New List(Of String)

    Public DIS As Double
    Public ORIFECHA As DateTime
    Public DESFECHA As DateTime
    Public DESCP As String
    Public DESEDO As String
    Public IDVEH As String
    Public IDCHO As String
    Public ASECAR As String
    Public POLCAR As String
    Public MONCAR As Double
    Private Sub frmComplementoCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPLlenaComboBox(CBVE, LVE, "SELECT CLAVE,NOMBRE FROM VEHICULOSCARTAPORTE WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBCHO, LCHO, "SELECT CLAVE,NOMBRE FROM CHOFERESCARTAPORTE WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBEDO, LEDO, "SELECT CLAVE,CLAVE+ ' - '+ NOMBRE  FROM ESTADOS where PAIS='mex'", frmPrincipal.CadenaConexionFE)
    End Sub

    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        If TXTCP.Text.Length <> 5 Then
            OPMsgError("Código postal debe ser de 5 digitos")
            Exit Sub
        End If
        Try
            DIS = CType(TXTDIS.Text, Double)
            MONCAR = CType(TXTMONTO.Text, Double)
        Catch ex As Exception
            OPMsgError("Es necesario especificar la distancia y monto, puede ser valor 0 en monto")
            Exit Sub
        End Try
        If DIS <= 0 Then
            OPMsgError("Es necesario especificar la distancia y monto, puede ser valor 0 en monto")
            Exit Sub
        End If
        ORIFECHA = SUMARTIEMPOAFECHA(DTFSAL.Value, DTHORASAL.Value)
        DESFECHA = SUMARTIEMPOAFECHA(DTFLLEG.Value, DTHORALLEG.Value)
        DESCP = TXTCP.Text
        DESEDO = LEDO(CBEDO.SelectedIndex)
        IDVEH = LVE(CBVE.SelectedIndex)
        IDCHO = LCHO(CBCHO.SelectedIndex)
        ASECAR = TXTASEMA.Text
        POLCAR = TXTPOLMA.Text
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub
End Class