Public Class frmReportedeGastosdeCajaChica
   
    Private Sub frmReportedeGastosdeCajaChica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Try
            frmPrincipal.CHECACONX()
            If Not CHECAFECHAS() Then
                MessageBox.Show("El rango de fechas esta incorrecto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim QUERY As String
            QUERY = "SELECT G.FACTURA FACTURA, G.FECHAFACTURA [FECHA FACTURA],P.NOMBRE PROVEEDOR,G.SUBTOTAL,G.IVA,G.TOTAL,(SELECT DBO.REGRESACONCEPTOSUBCONCEPTO(G.CONCEPTO,G.SUBCONCEPTO))CONCEPTO FROM GASTOSCAJACHICA G INNER JOIN TIENDAS T ON T.CLAVE=G.TIENDA INNER JOIN PROVEEDORES P  ON T.EMPRESA=P.EMPRESA AND P.CLAVE=G.PROVEEDOR WHERE G.TIENDA='" + frmPrincipal.SucursalBase + "' AND T.EMPRESA=" + frmPrincipal.Empresa + " AND G.FECHA>=@INI AND G.FECHA<@FIN "

         
            DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))
            DGV.Refresh()
            DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            CHECATABLA()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub CHECATABLA()
        Try
            Dim S, I, T As Double
            S = 0
            I = 0
            T = 0
            Dim X As Integer
            For X = 0 To DGV.Rows.Count - 1
                S = S + DGV.Item(3, X).Value
                I = I + DGV.Item(4, X).Value
                T = T + DGV.Item(5, X).Value
            Next
            LBLSUB.Text = "$" & FormatNumber(S, 2).ToString
            LBLIVA.Text = "$" & FormatNumber(I, 2).ToString
            LBLTOT.Text = "$" & FormatNumber(T, 2).ToString

        Catch ex As Exception

        End Try
            End Sub

    Private Sub BTNCARGA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCARGA.Click
        CARGADATOS()
    End Sub
End Class