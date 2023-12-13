Public Class frmEntrarCompras
    Dim CLAPRO As New List(Of String)
    Public CLAVEPRO, NOMPRO, NOTAFAC, CONCEPTO As String
    Public ESNOTA, APLICAIVA As Boolean
    Dim LIN As New List(Of Boolean)
    Dim LIF As New List(Of Boolean)
    Dim NOORDEN As String
    Dim FEC As DateTime
    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        If RBFAC.Checked Then
            If Not VALIDAPROVEEDORFACTURA() Then
                MessageBox.Show("La Factura " + TXTFAC.Text + " del Proveedor " + CBPRO.Text + " ya se Encuentra Registrada, No se permite capturar 2 Veces una factura en una Compra. Referencias: No Orden: " + NOORDEN.ToString + ", Fecha: " + FormatDateTime(FEC, DateFormat.ShortDate).ToString, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        End If

        ESNOTA = RBNOT.Checked
        If ESNOTA Then
            APLICAIVA = LIN(CBPRO.SelectedIndex)
        Else
            APLICAIVA = LIF(CBPRO.SelectedIndex)
        End If


        CLAVEPRO = CLAPRO(CBPRO.SelectedIndex)
        NOMPRO = CBPRO.Text
        NOTAFAC = TXTFAC.Text
        CONCEPTO = TXTCON.Text
        TXTFAC.Focus()
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub
    Private Function VALIDAPROVEEDORFACTURA() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Return False
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT FACTURA,NOORDEN,FECHA FROM COMPRAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + CLAPRO(CBPRO.SelectedIndex).ToString + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            NOORDEN = LEC(1)
            FEC = LEC(2)
            LEC.Close()
            Return False
        Else
            LEC.Close()
        End If
        'Dim SQLFR As New SqlClient.SqlCommand("SELECT FACTURA,REGISTRO,FECHA FROM GASTOSCAJACHICA WHERE RESTAURANTE='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + CLAPRO(CBPRO.SelectedIndex).ToString + "' AND FACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        'Dim LECFR As SqlClient.SqlDataReader
        'LECFR = SQLFR.ExecuteReader
        'If LECFR.Read Then
        '    NOORDEN = LECFR(1)
        '    FEC = LECFR(2)
        '    LECFR.Close()
        '    Return False
        'Else
        '    LECFR.Close()
        'End If
        Dim SQLCC As New SqlClient.SqlCommand("SELECT NUMFACTURA,REGISTRO,FECHA FROM FACTURAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND PROVEEDOR='" + CLAPRO(CBPRO.SelectedIndex).ToString + "' AND NUMFACTURA='" + TXTFAC.Text + "'", frmPrincipal.CONX)
        Dim LECCC As SqlClient.SqlDataReader
        LECCC = SQLCC.ExecuteReader
        If LECCC.Read Then
            NOORDEN = LECCC(1)
            FEC = LECCC(2)
            LECCC.Close()
            Return False
        Else
            LECCC.Close()
        End If
        Return True
    End Function
    Private Sub frmEntrarCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If Not CARGAPROVEEDORES() Then
            MessageBox.Show("Favor de dar de alta proveedores activos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Me.Close()
        End If
    End Sub
    Private Function CARGAPROVEEDORES() As Boolean
        CBPRO.Items.Clear()
        CLAPRO.Clear()
        LIN.Clear()
        LIF.Clear()
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim SQLCARGASUC As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,FACTURAIVA,NOTAIVA FROM PROVEEDORES WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQLCARGASUC.ExecuteReader
        While LECTOR.Read
            CLAPRO.Add(LECTOR(0))
            CBPRO.Items.Add(LECTOR(1))
            LIF.Add(LECTOR(2))
            LIN.Add(LECTOR(3))
        End While
        LECTOR.Close()
        Try
            CBPRO.SelectedIndex = 0
            Return True
        Catch ex As Exception
            MessageBox.Show("Favor de Asignar Proveedores a Compras o Ambos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End Try
    End Function

    Private Sub TXTFAC_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFAC.KeyPress
        If e.KeyChar = Chr(13) Then
            CBPRO.Focus()
        End If
    End Sub

    Private Sub CBPRO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBPRO.KeyPress
        If e.KeyChar = Chr(13) Then
            TXTCON.Focus()
        End If
    End Sub

    Private Sub TXTCON_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCON.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNACEPTAR.Focus()
        End If
    End Sub
    Private Sub RBFAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBFAC.CheckedChanged
        If RBFAC.Checked Then
            LBLFACNOT.Text = "Factura"
        Else
            LBLFACNOT.Text = "Nota"
        End If
    End Sub

    Private Sub RBNOT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNOT.CheckedChanged
        If RBNOT.Checked Then
            LBLFACNOT.Text = "Nota"
        Else
            LBLFACNOT.Text = "Factura"
        End If
    End Sub

    Private Sub frmEntrarCompras_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,FACTURAIVA,NOTAIVA FROM PROVEEDORES", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Proveedores", "Nombre del Proveedor", "Proveedores(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAPRO, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class