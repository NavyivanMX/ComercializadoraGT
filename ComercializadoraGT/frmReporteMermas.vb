Public Class frmReporteMermas

    Private Sub frmReporteMermas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        QUERY = "SELECT M.PRODUCTO LOTE,P.NOMBRE PRODUCTO,M.CANTIDAD,U.NOMBRE UNIDAD, M.FECHA FECHA,M.USUARIO,M.CONCEPTO,(SELECT DBO.REGRESATOTALPRECIO(M.PRODUCTO,M.CANTIDAD,M.UNIDAD))[$$ MERMA] FROM MERMAS M INNER JOIN TIENDAS R  ON M.TIENDA=R.CLAVE INNER JOIN LOTES L ON M.PRODUCTO=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP  INNER JOIN  UNIDADES U ON M.UNIDAD=U.CLAVE WHERE M.FECHA>=@INI AND M.FECHA<=@FIN AND M.TIENDA='" + frmPrincipal.SucursalBase + "' "
       

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTHASTA.Value.Date.AddDays(1))


        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

       
        CHECATABLA()
    End Sub
    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOTAL, C As Double
        TOTAL = 0
        C = 0
        For X = 0 To DGV.Rows.Count - 1
            C = C + DGV.Item(2, X).Value
            TOTAL = TOTAL + DGV.Item(7, X).Value
        Next
        LBLTOT.Text = FormatNumber(TOTAL).ToString()
        LBLC.Text = FormatNumber(C).ToString()
    End Sub

    Private Sub DGV_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        'If Me.DGV.Columns(e.ColumnIndex).Name = "DatoImagen" Then

        '    e.Value = New Bitmap("C:/FOTOSTIENDA/APPLETON ESPECIAL.JPG")


        '    '    'DGV.Rows(e.RowIndex).Cells(0).Value = Image.FromFile("C:/FOTOSTIENDA/APPLETON ESPECIAL.JPG")

        'End If

    End Sub
End Class