Public Class frmOpcionesNotaCredito
    Dim LMP As New List(Of String)
    Dim LFP As New List(Of String)
    Dim LCP As New List(Of String)
    Dim CONZ As New SqlClient.SqlConnection
    Dim CADENA As String
    Public MP, FP, CP, COM As String
    Private Sub frmOpcionesNotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        CADENA = "Data Source=" + frmPrincipal.IPFE + ",1433;Network Library=DBMSSOCN;Initial Catalog=FEBAJAMAR;User ID=dbaadmin;Password=masterkey"
        CONZ.ConnectionString = CADENA
        CHECACONZ()
        OPLlenaComboBox(CBFP, LFP, "SELECT CLAVE,NOMBRE FROM FORMASPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBMP, LMP, "SELECT CLAVE,NOMBRE FROM METODOSPAGOS WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
        OPLlenaComboBox(CBCP, LCP, "SELECT CLAVE,NOMBRE FROM CONDICIONESDEPAGO WHERE ACTIVO=1 ORDER BY NOMBRE", CADENA, "Favor de Seleccionar", "")
    End Sub
    Private Function CHECACONZ() As Boolean
        If Me.CONZ.State = ConnectionState.Closed Or Me.CONZ.State = ConnectionState.Broken Then
            Try
                Me.CONZ.Open()
            Catch ex As Exception
                MessageBox.Show("La Conexión NO esta realizada, La Informacion No se ha Procesado, Intente en un momento por Favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End Try
        End If
        Return True
    End Function

    Private Sub BTNACEPTAR_Click(sender As Object, e As EventArgs) Handles BTNACEPTAR.Click
        If CBMP.SelectedIndex = 0 Or CBFP.SelectedIndex = 0 Or CBCP.SelectedIndex = 0 Then
            MessageBox.Show("Debe seleccionar las opciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("¿Es Correcta la información para Nota de Crédito?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If

        MP = LMP(CBMP.SelectedIndex)
        FP = LFP(CBFP.SelectedIndex)
        CP = LCP(CBCP.SelectedIndex)
        COM = TXTCOM.Text
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
End Class