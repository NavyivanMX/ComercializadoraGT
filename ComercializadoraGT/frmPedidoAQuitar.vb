Public Class frmPedidoAQuitar
    Dim CLAUNI As New List(Of String)
    Public LOTE As String
    Public PEDIDO As Integer
    Public CANT As Double
    Public UNIDAD As String
    Private Sub frmPedidoAQuitar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal PRO As String, ByVal NPRO As String)
        CARGADATOS(PRO)
        Me.ShowDialog()
    End Sub
    Private Sub CARGADATOS(ByVal PRO As String)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
  

        Dim QUERY As String
        QUERY = "SELECT PED.NOPEDIDO,C.NOMBRECOMUN TIENDA,D.LOTE,P.NOMBRE PRODUCTO,D.CANTIDAD,U.NOMBRE UNIDAD FROM PEDIDOS PED INNER JOIN DETALLEPEDIDOS D ON PED.NOPEDIDO=D.NOPEDIDO INNER JOIN TIENDAS C ON PED.TIENDA=C.CLAVE INNER JOIN LOTES L ON D.LOTE=L.CLAVE INNER JOIN PRODUCTOS P ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE WHERE PED.ESTADO=0  AND L.PRODUCTO='" + PRO + "'"
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        Dim DT As New DataTable
        DA.Fill(DT)
        DGV.DataSource = DT
        DGV.Refresh()
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
        CARGAEQUIVALENCIAS(PRO)
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            BTNYES.Enabled = False
        Else
            BTNYES.Enabled = True
        End If
    End Sub
    Private Function CANTIDADNETA(ByVal GRUPO As String, ByVal PRO As String) As Double
        Dim C1, C2, CANT As Integer
        C1 = 0
        C2 = 0
        Try
            CANT = CType(TXTCANT.Text, Double)
        Catch ex As Exception
            Exit Function
        End Try
        Dim SQL As New SqlClient.SqlCommand("SELECT CANTIDAD,CANTIDAD2 FROM EQUIVALENCIAS WHERE PRODUCTO='" + PRO + "'  AND UNIDAD='" + CLAUNI(CBUNI.SelectedIndex) + "' AND UNIDAD2='" + +"' ", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            C1 = LEC(0)
            C2 = LEC(1)
            LEC.Close()
        Else
            LEC.Close()
            Return 0
        End If
        Return ((CANT / C1) * C2)
    End Function
    Private Function CARGAEQUIVALENCIAS(ByVal PRO As String) As Boolean
        CLAUNI.Clear()
        CBUNI.Items.Clear()
        Dim SQL As New SqlClient.SqlCommand("SELECT U.UNIDAD,E.NOMBRE FROM EQUIVALENCIAS U INNER JOIN UNIDADES E ON U.UNIDAD=E.CLAVE INNER JOIN PRODUCTOS P ON U.PRODUCTO=P.CP AND U.UNIDAD2=P.UVENTA  WHERE U.PRODUCTO='" + PRO + "' ", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        While LEC.Read
            CLAUNI.Add(LEC(0))
            CBUNI.Items.Add(LEC(1))
        End While
        LEC.Close()
        Try
            CBUNI.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub BTNYES_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNYES.Click
        LOTE = DGV.Item(2, DGV.CurrentRow.Index).Value
        PEDIDO = DGV.Item(0, DGV.CurrentRow.Index).Value
        CANT = CType(TXTCANT.Text, Double)
        UNIDAD = CLAUNI(CBUNI.SelectedIndex)
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM DETALLEPEDIDOS WHERE NOPEDIDO=" + PEDIDO.ToString + " AND LOTE='" + LOTE + "'", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        SQL.CommandText = "ACTUALIZAVIRTUAL"
        SQL.CommandType = CommandType.StoredProcedure
        SQL.ExecuteNonQuery()
    End Sub
End Class