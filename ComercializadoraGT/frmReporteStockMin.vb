Public Class frmReporteStockMin
    Dim QUERY, QUERY2 As String
    Private Sub frmReporteStockMin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGADATOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If

        Dim CONCOL As Integer
        Dim COLUMNAENCONTRADA As Boolean

        COLUMNAENCONTRADA = False
        For CONCOL = 0 To DGV.Columns.Count - 1
            If DGV.Columns(CONCOL).Name = "IMAGEN" Then
                COLUMNAENCONTRADA = True
            End If
        Next
        If Not COLUMNAENCONTRADA Then
            Dim colImagen As DataGridViewImageColumn = New DataGridViewImageColumn()
            colImagen.Name = "IMAGEN"
            colImagen.HeaderText = "IMAGEN"
            Me.DGV.Columns.Add(colImagen)
        End If

        DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Dim col As DataGridViewColumn = DGV.Columns(0)
        col.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        QUERY = "SELECT P.CLAVE CODIGO,P.NOMBRE PRODUCTO,I.EXISTENCIA,P.STOCKMIN   FROM INVENTARIO I INNER JOIN  PRODUCTOS P ON P.CLAVE=I.CLAVE WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND I.EXISTENCIA<=P.STOCKMIN   ORDER BY P.NOMBRE"
        QUERY2 = "SELECT P.CLAVE,P.IMG FROM INVENTARIO I INNER JOIN  PRODUCTOS P ON P.CLAVE=I.CLAVE WHERE I.TIENDA='" + frmPrincipal.SucursalBase + "' AND I.EXISTENCIA<=P.STOCKMIN "

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        ' DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        PONERIMAGENES()

    End Sub
    Private Sub PONERIMAGENES()
        Dim IMG, PCLA As String
        Dim SQL As New SqlClient.SqlCommand(QUERY2, frmPrincipal.CONX)
        Dim LECTOR As SqlClient.SqlDataReader
        LECTOR = SQL.ExecuteReader
        While LECTOR.Read
            PCLA = LECTOR(0)
            IMG = LECTOR(1)
            For X = 0 To DGV.Rows.Count - 1
                If DGV.Item(1, X).Value = PCLA Then
                    If Me.DGV.Columns(0).Name = "IMAGEN" Then
                        Try
                            DGV.Item(0, X).Value = New Bitmap("C:/FOTOSPRICE/" + IMG + ".JPG")
                        Catch ex As Exception
                            DGV.Item(0, X).Value = New Bitmap("C:/FOTOSPRICE/PANASONIC.JPG")
                        End Try
                    End If
                End If
            Next

        End While
        LECTOR.Close()
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
End Class