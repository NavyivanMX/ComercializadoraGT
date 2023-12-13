Public Class frmReportevtaxCliente
    Dim CLACLI As New List(Of String)
    Dim CLANOT As New List(Of String)
    Private Sub frmReportevtaxCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        OPLlenaComboBox(CBCLI, CLACLI, "SELECT CLAVE,NOMBRE,DIASCREDITO FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ORDER BY NOMBRE ", frmPrincipal.CadenaConexion)
    End Sub
    Private Function CHECAFECHAS() As Boolean
        If DTDE.Value.Date > DTHASTA.Value.Date Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then

            Exit Sub
        End If
        If Not CHECAFECHAS() Then
            MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT TIPO='NOTA DE VENTA',N.NOTA,DBO.FOLIOFACNOTA('" + frmPrincipal.Serie + "',N.NOTA)Factura,N.TOTAL,N.FECHA FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA WHERE D.PRODUCTO<>'CREDITO' AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " AND N.FECHA>=@INI AND N.FECHA<=@FIN GROUP BY N.NOTA,N.TOTAL,N.FECHA UNION ALL SELECT TIPO='NOTA DE CREDITO',N.NOTA,DBO.FOLIOFAC('" + frmPrincipal.Serie + "',N.NOTA)Factura,N.TOTAL,N.FECHA FROM NOTASDEVENTACREDITO N WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.CLIENTE=" + CLACLI(CBCLI.SelectedIndex) + " AND N.FECHA>=@INI AND N.FECHA<=@FIN "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()

        Dim X As Integer
        Dim TOTAL As Double
        TOTAL = 0
        For X = 0 To DGV.Rows.Count - 1
            TOTAL = TOTAL + DGV.Item(3, X).Value
        Next
        LBLAT.Text = FormatNumber(TOTAL).ToString()
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        Dim TI As Boolean
        If DGV.Item(0, DGV.CurrentRow.Index).Value = "NOTA DE VENTA" Then
            TI = True
        Else
            TI = False
        End If
        CARGANOTA(DGV.Item(1, DGV.CurrentRow.Index).Value, TI)
        CHECATABLA2()
    End Sub
    Private Sub CARGANOTA(ByVal NOTA As Integer, ByVal T As Boolean)
        Dim query As String
        If T = True Then
            query = "SELECT D.PRODUCTO CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT (NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.TOTAL  FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + NOTA.ToString + " "
        Else
            query = "SELECT D.PRODUCTO CLAVE,P.NOMBRE PRODUCTO,D.CANTIDAD,PRECIO=CONVERT (NUMERIC(15,2),(D.TOTAL/D.CANTIDAD),2),D.TOTAL  FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + NOTA.ToString + " "
        End If

        DGV2.DataSource = BDLlenatabla(query, frmPrincipal.CadenaConexion)
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV2.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub CHECATABLA2()
      
        Dim X As Integer
        Dim TOTAL As Double
        TOTAL = 0
        For X = 0 To DGV2.Rows.Count - 1
            TOTAL = TOTAL + DGV2.Item(4, X).Value
        Next
        LBLNOT.Text = FormatNumber(TOTAL).ToString()
    End Sub

    Private Sub frmReportevtaxCliente_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub

    Private Sub BTNARCHIVO_Click(sender As Object, e As EventArgs) Handles BTNARCHIVO.Click
        frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE FROM CLIENTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
        End If
    End Sub
End Class