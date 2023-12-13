Public Class frmAnalisisVenta

    Private Sub frmAnalisisVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT  N.NOTA,TP.NOMBRE TIPOPAGO,D.CANTIDAD,P.NOMBRE PRODUCTO,D.DESCUENTO,P.IVA LLEVAIVA,SUBTOTAL = (D.TOTAL - (DBO.ELIVA(D.PRODUCTO, D.TOTAL))),DBO.ELIVA(D.PRODUCTO,D.TOTAL) IVA,D.TOTAL FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN TIENDAS T ON N.TIENDA=T.CLAVE INNER JOIN TIPOSPAGOS TP ON N.TIPOPAGO=TP.CLAVE INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.FECHA>=@INI AND N.FECHA<=@FIN"
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        QUERY = "SELECT D.NOTA NOTACREDITO,D.ABONO,D.NOTAVENTA ,IVADELABONO=DBO.IVACREDITO2(D.TIENDA,D.NOTA,D.ABONO) FROM ABONOSCREDITOS D INNER JOIN TIENDAS T ON D.TIENDA=T.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.FECHA>=@INI AND D.FECHA<=@FIN "
        DGV2.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date.AddDays(1))
        DGV2.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim S, I, T, IC As Double
        S = 0
        I = 0
        T = 0
        IC = 0
        For X = 0 To DGV.Rows.Count - 1
            S += DGV.Item(6, X).Value
            I += DGV.Item(7, X).Value
            T += DGV.Item(8, X).Value
        Next
        For X = 0 To DGV2.Rows.Count - 1
            IC += DGV2.Item(3, X).Value
        Next
        LBLS.Text = "SubTotal: " + FormatNumber(S, 2).ToString
        LBLI.Text = "Iva: " + FormatNumber(I, 2).ToString
        LBLT.Text = "Total: " + FormatNumber(T, 2).ToString
        LBLNOTA.Text = "Nota: En el corte debió salir un SubTotal de: " + (S - IC).ToString + ", un Iva de: " + (I + IC).ToString + ", y un Total de: " + T.ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CARGADATOS()
    End Sub
    Private Sub CARGADETALLEABONO(ByVal NC As Integer)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim QUERY As String
        QUERY = "SELECT D.NOTA,D.CANTIDAD,P.NOMBRE,D.DESCUENTO,D.TOTAL,DBO.ELIVA(D.PRODUCTO,D.TOTAL) IVA FROM DETALLENOTASDEVENTACREDITO D INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE WHERE D.TIENDA='" + frmPrincipal.SucursalBase + "' AND D.NOTA ='" + NC.ToString + "'"
        DGV3.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
    End Sub

    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        Try
            CARGADETALLEABONO(DGV2.Item(0, DGV2.CurrentRow.Index).Value)
        Catch ex As Exception

        End Try
    End Sub
End Class

