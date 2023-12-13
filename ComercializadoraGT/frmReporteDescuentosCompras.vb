Public Class frmReporteDescuentosCompras

    Private Sub frmReporteDescuentosCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        'Dim colImagen As DataGridViewImageColumn = New DataGridViewImageColumn()
        'colImagen.Name = "DatoImagen"
        'colImagen.HeaderText = "DatoImagen"

        'Me.DGV.Columns.Add(colImagen)




        Dim QUERY As String
        QUERY = "SELECT C.NOORDEN,C.FACTURA,P.NOMBRE PROVEEDOR,PR.NOMBRE PRODUCTO,D.DESCUENTO [DESCUENTO $$],D.TOTAL [TOTAL CON DESCUENTO $$],C.USUARIO,C.FECHA [FECHA DE COMPRA]  FROM COMPRAS C INNER JOIN DETALLECOMPRAS D  ON C.TIENDA=D.TIENDA AND C.NOORDEN=D.NOORDEN INNER JOIN LOTES L ON L.CLAVE=D.PRODUCTO INNER JOIN PRODUCTOS PR  ON PR.CP=L.PRODUCTO INNER JOIN TIENDAS T  ON T.CLAVE=C.TIENDA INNER JOIN PROVEEDORES P ON P.EMPRESA=T.EMPRESA AND P.CLAVE=C.PROVEEDOR WHERE DESCUENTO<>0 AND C.TIENDA='" + frmPrincipal.SucursalBase + "' AND C.FECHA>=@INI AND C.FECHA<=@FIN"
        
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))



        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
End Class