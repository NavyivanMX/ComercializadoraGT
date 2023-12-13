Public Class frmReporteCompras

    Dim QUER As String
    Private Sub frmReporteCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
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

        QUERY = "SELECT C.NOORDEN,C.FACTURA,PR.NOMBRE PROVEEDOR,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,D.TOTAL,C.USUARIO,C.FECHA  FROM COMPRAS C INNER JOIN DETALLECOMPRAS D ON D.NOORDEN=C.NOORDEN AND C.TIENDA=D.TIENDA INNER JOIN PROVEEDORES PR ON  C.PROVEEDOR=PR.CLAVE INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON U.CLAVE=D.UNIDAD WHERE C.FECHA>=@INI AND C.FECHA<=@FIN AND P.EMPRESA=" + frmPrincipal.Empresa + " AND C.TIENDA='" + frmPrincipal.SucursalBase + "'  ORDER BY C.NOORDEN "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
        DGV.Refresh()
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOTAL As Double
        TOTAL = 0
        For X = 0 To DGV.Rows.Count - 1
            TOTAL = TOTAL + DGV.Item(6, X).Value
        Next
        LBLTOT.Text = FormatNumber(TOTAL).ToString()
        LBLC.Text = DGV.Rows.Count
    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        frmPrincipal.CHECACONX()
        Dim REPI As New rptCompras
        QUER = "SELECT T.NOMBRECOMUN TIENDA,C.FACTURA,PR.NOMBRE PROVEEDOR,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,D.TOTAL,C.USUARIO,C.FECHA  FROM COMPRAS C INNER JOIN DETALLECOMPRAS D ON D.NOORDEN=C.NOORDEN AND C.TIENDA=D.TIENDA INNER JOIN PROVEEDORES PR ON  C.PROVEEDOR=PR.CLAVE INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON U.CLAVE=D.UNIDAD INNER JOIN TIENDAS T ON C.TIENDA=T.CLAVE WHERE C.FECHA>=@INI AND C.FECHA<=@FIN AND P.EMPRESA=" + frmPrincipal.Empresa + " AND C.TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY C.NOORDEN"

          MOSTRARREPORTE(REPI, "Reporte de Compras", BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1)), "Enviar a OneNote 2007")
    End Sub
    Private Sub GUARDAR()
        Dim REPI As New rptCompras
        QUER = "SELECT T.NOMBRECOMUN TIENDA,C.FACTURA,PR.NOMBRE PROVEEDOR,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD,D.TOTAL,C.USUARIO,C.FECHA  FROM COMPRAS C INNER JOIN DETALLECOMPRAS D ON D.NOORDEN=C.NOORDEN AND C.TIENDA=D.TIENDA INNER JOIN PROVEEDORES PR ON  C.PROVEEDOR=PR.CLAVE INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON U.CLAVE=D.UNIDAD INNER JOIN TIENDAS T ON C.TIENDA=T.CLAVE WHERE C.FECHA>=@INI AND C.FECHA<=@FIN AND P.EMPRESA=" + frmPrincipal.Empresa + " AND C.TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY C.NOORDEN"
        GUARDARREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1)), CrystalDecisions.Shared.ExportFormatType.Excel, "excel", "xls", "¿Desea guardar el reporte?", "Reporte compras", "Enviar One Note 2007")
    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
End Class