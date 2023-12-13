Public Class frmReporteXClientes
    Dim CLACLI As New List(Of String)
    Dim QUERY As String
    Private Sub frmReporteXClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        If Not CARGACLIENTES() Then
            MessageBox.Show("No hay clientes dados de alta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Private Function CARGACLIENTES() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        CLACLI.Clear()
        Dim SQLCLI As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0  ORDER BY NOMBRE ", frmPrincipal.CONX)
        Dim LECCLI As SqlClient.SqlDataReader
        LECCLI = SQLCLI.ExecuteReader
        While LECCLI.Read
            CLACLI.Add(LECCLI(0))
            CBCLI.Items.Add(LECCLI(1))
        End While
        LECCLI.Close()

        Try
            CBCLI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        QUERY = "SELECT PRODUCTO,SUM(CANTIDAD)CANTIDAD,SUM(TOTAL)TOTAL FROM VISTACONSUMOXCLIENTE WHERE CLIENTE='" + CLACLI(CBCLI.SelectedIndex) + "' AND TIENDA='" + frmPrincipal.SucursalBase + "' AND FECHA>=@INI AND FECHA<=@FIN GROUP BY PRODUCTO"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()

        Dim X As Integer
        Dim VENTA, CANT As Double
        VENTA = 0
        'COSTO = 0
        CANT = 0
        For X = 0 To DGV.Rows.Count - 1
            VENTA = VENTA + DGV.Item(2, X).Value
            'COSTO = COSTO + DGV.Item(3, X).Value
            CANT = CANT + DGV.Item(1, X).Value
        Next
        LBLV.Text = FormatNumber(VENTA).ToString()
        'LBLC.Text = FormatNumber(COSTO).ToString()
        LBLART.Text = FormatNumber(CANT).ToString
        'LBLGG.Text = FormatNumber(VENTA - COSTO).ToString()

    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub frmReporteXClientes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class