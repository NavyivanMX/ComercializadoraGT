Public Class frmReporteCreditosAutorizados
    Dim CLACLI As New List(Of String)
    Dim Query As String
    Private Sub frmReporteCreditosAutorizados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGACLIENTES()
    End Sub
    Private Function CARGACLIENTES() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        Query = "SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE <>0  ORDER BY NOMBRE"
       OPLlenaComboBox(CBCLI, CLACLI, Query, frmPrincipal.CadenaConexion, "Todos los clientes", "''")
        Try
            CBCLI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CARGADATOS()
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Query = "SELECT C.NOMBRE CLIENTE,N.NOTA,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))[ADEUDO $$],N.FECHA CONSUMO,N.AUTORIZO FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C  ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA  "
        If CBCLI.SelectedIndex = 0 Then
            Query = Query + " WHERE "
        Else
            Query = Query + " WHERE C.CLAVE='" + CLACLI(CBCLI.SelectedIndex) + "' AND "
        End If
        Query = Query + " N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.AUTORIZO IS NOT NULL AND N.AUTORIZO<>'' AND N.FECHA>=@INI AND N.FECHA<=@FIN GROUP BY N.NOTA,N.FECHA,C.DIASCREDITO,N.TOTAL,N.TIENDA,C.NOMBRE,N.AUTORIZO "

        DGV.DataSource = BDLlenatabla(Query, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub frmReporteCreditosAutorizados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If

    End Sub
End Class