Public Class frmTrasladosCartaPorte
    Dim DT As New DataTable
    Dim DTPRIN As New DataTable
    Private Sub frmTrasladosCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)

        GENERAGRID("SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE ACTIVO=1")
    End Sub
    Public Sub GENERAGRID(ByVal QUERY As String)
        DTPRIN.Columns.Clear()
        DTPRIN.Columns.Add("CveOrigen")
        DTPRIN.Columns.Add("NombreOrigen")
        DTPRIN.Columns.Add("CveDestino")
        DTPRIN.Columns.Add("NombreDestino")
        DTPRIN.Columns.Add("Minutos", GetType(Integer))
        DTPRIN.Columns.Add("Kilometros", GetType(Integer))

        DT = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        Dim DR As DataRow
        Dim X, Y As Integer
        For X = 0 To DT.Rows.Count - 2
            For Y = X + 1 To DT.Rows.Count - 1
                DR = DTPRIN.NewRow
                DR(0) = DT.Rows(X).Item(0).ToString
                DR(1) = DT.Rows(X).Item(1).ToString
                DR(2) = DT.Rows(Y).Item(0).ToString
                DR(3) = DT.Rows(Y).Item(1).ToString
                DR(4) = 0
                DR(5) = 0
                DTPRIN.Rows.Add(DR)
            Next
        Next
        DGV.DataSource = DTPRIN
        Try
            DGV.Columns(0).ReadOnly = True
            DGV.Columns(1).ReadOnly = True
            DGV.Columns(2).ReadOnly = True
            DGV.Columns(3).ReadOnly = True
            For Each DC As DataGridViewColumn In DGV.Columns
                DC.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
            DGV.Columns(4).DefaultCellStyle = DgvCellFormatoNumerico(0)
            DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico(0)
            DGV.Columns(4).DefaultCellStyle = DgvCellEstilo(Color.LightYellow, Color.Black)
            DGV.Columns(5).DefaultCellStyle = DgvCellEstilo(Color.LightYellow, Color.Black)
        Catch ex As Exception

        End Try

        Dim DTDATOS As New DataTable
        DTDATOS = BDLlenatabla("SELECT ORIGEN, DESTINO,MINUTOS,KMS FROM ALMACENESCARTAPORTE", frmPrincipal.CadenaConexion)
        For X = 0 To DTDATOS.Rows.Count - 1
            For Y = 0 To DGV.Rows.Count - 1
                If DGV.Item(0, Y).Value.ToString = DTDATOS.Rows(X).Item(0).ToString And DGV.Item(2, Y).Value.ToString = DTDATOS.Rows(X).Item(1).ToString Then
                    DGV.Item(4, Y).Value = DTDATOS.Rows(X).Item(2).ToString
                    DGV.Item(5, Y).Value = DTDATOS.Rows(X).Item(3).ToString
                End If
            Next
        Next
    End Sub
    Private Function VALIDAR() As Boolean
        Dim X As Integer
        For X = 0 To DGV.RowCount - 1
            If DGV.Item(4, X).Value <= 0 Then
                OPMsgError("Es requerido especificar un aproximado de minutos de traslado")
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub GUARDAR()
        If Not VALIDAR() Then
            Exit Sub
        End If
        If OPMsgPreguntarSiNo("¿Desea guardar la información?") Then
            If Not frmPrincipal.CHECACONX Then
                Exit Sub
            End If
            Dim SQL As New SqlClient.SqlCommand("SPALMACENESCARTAPORTE", frmPrincipal.CONX)
            SQL.CommandType = CommandType.StoredProcedure
            SQL.CommandTimeout = 600
            SQL.Parameters.Add("@ORI", SqlDbType.VarChar)
            SQL.Parameters.Add("@DES", SqlDbType.VarChar)
            SQL.Parameters.Add("@MIN", SqlDbType.Int)
            SQL.Parameters.Add("@KMS", SqlDbType.Int)
            Dim X As Integer
            For X = 0 To DGV.RowCount - 1
                SQL.Parameters("@ORI").Value = DGV.Item(0, X).Value
                SQL.Parameters("@DES").Value = DGV.Item(2, X).Value
                SQL.Parameters("@MIN").Value = DGV.Item(4, X).Value
                SQL.Parameters("@KMS").Value = DGV.Item(5, X).Value
                SQL.ExecuteNonQuery()
            Next
            OPMsgGuardadoOK()
        End If

    End Sub
    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
End Class