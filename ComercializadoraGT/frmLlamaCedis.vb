Public Class frmLlamaCedis

    Dim LALM As New List(Of String)
    Public ALM As String
    Dim LEMP As New List(Of String)
    Public NALM As String
    Public EMP As String
    Private Sub frmLlamaCedis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        Dim ALGO As String
        ALGO = frmPrincipal.SucursalBase
        If frmPrincipal.SucursalBase = "PM" Or frmPrincipal.SucursalBase = "BPM" Or frmPrincipal.SucursalBase = "LOZA" Or frmPrincipal.SucursalBase = "ST" Or frmPrincipal.SucursalBase = "PRUEBAS" Then
            If Not OPLlenaComboBox(CBALM, LALM, LEMP, "SELECT A.CLAVE, A.EMPRESA, A.NOMBRECOMUN FROM TIENDAS A WHERE A.ACTIVO=1 ORDER BY A.NOMBRECOMUN", frmPrincipal.CadenaConexion) Then
                MessageBox.Show("Usted no cuenta con Almacenes asignados para realizar este movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
            Else
                OPCargaX(LALM, CBALM, frmPrincipal.SucursalBase)
            End If
        Else
            If Not OPLlenaComboBox(CBALM, LALM, LEMP, "SELECT A.CLAVE, A.EMPRESA, A.NOMBRECOMUN FROM TIENDAS A WHERE A.ACTIVO=1 AND (A.CLAVE='" + frmPrincipal.SucursalBase + "') ORDER BY A.NOMBRECOMUN", frmPrincipal.CadenaConexion) Then
                MessageBox.Show("Usted no cuenta con Almacenes asignados para realizar este movimiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = Windows.Forms.DialogResult.No
                Me.Close()
            Else

            End If
        End If

    End Sub

    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        ALM = LALM(CBALM.SelectedIndex)
        EMP = LEMP(CBALM.SelectedIndex)
        NALM = CBALM.Text
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
End Class