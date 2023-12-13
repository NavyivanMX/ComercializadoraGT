Public Class frmCatalogo
    Dim CLAGRU As New List(Of String)
    Dim CLAPROD As New List(Of String)
    Dim LCP As New List(Of String)
    Dim CC As New ColorConverter
    Dim QUERY2 As String
    Dim QUERY As String
    Private Sub frmCatalogo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGAGRUPOS()
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






        QUERY = "SELECT P.CLAVE CODIGO,P.NOMBRE PRODUCTO,P.PRECIO,G.NOMBRE GRUPO FROM PRODUCTOS P INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO AND G.EMPRESA=P.EMPRESA "
        QUERY2 = " SELECT p.clave,p.IMG FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE AND P.EMPRESA=G.EMPRESA "
        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "
                QUERY2 = QUERY2 + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "

            Else
                QUERY = QUERY + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
                QUERY2 = QUERY2 + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
            End If
        End If
        QUERY = QUERY + " AND P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1 AND P.CLAVE<>'CREDITO' AND P.CLAVE<>'999' ORDER BY G.NOMBRE,P.NOMBRE "
        QUERY2 = QUERY2 + " AND P.EMPRESA=" + frmPrincipal.Empresa + " AND P.ACTIVO=1 AND P.CLAVE<>'CREDITO' AND P.CLAVE<>'999' ORDER BY G.NOMBRE,P.NOMBRE "
        'Dim DA As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        'Dim DT As New DataTable

        'DA.Fill(DT)
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        PONERIMAGENES()





        ' CHECATABLA()
    End Sub

    Private Sub BTNMOSTRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMOSTRAR.Click
        CARGADATOS()
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim VENTA, COSTO, CANT As Double
        VENTA = 0
        COSTO = 0
        CANT = 0
        For X = 0 To DGV.Rows.Count - 1
            VENTA = VENTA + DGV.Item(3, X).Value
            COSTO = COSTO + DGV.Item(4, X).Value
            CANT = CANT + DGV.Item(5, X).Value
        Next

    End Sub
    Private Sub CARGAGRUPOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        CBGRU.Items.Clear()
        CLAGRU.Clear()
        CBGRU.Items.Add("Todos los grupos")
        CLAGRU.Add("")
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE FROM GRUPOS WHERE ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECGRUPO As SqlClient.SqlDataReader
        LECGRUPO = SQLGRUPO.ExecuteReader
        While LECGRUPO.Read
            CLAGRU.Add(LECGRUPO(0))
            CBGRU.Items.Add(LECGRUPO(1))
        End While
        LECGRUPO.Close()
        Try
            CBGRU.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Private Function CARGAPRODUCTOS() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If
        CBPRO.Items.Clear()
        CLAPROD.Clear()
        LCP.CLEAR()
        CBPRO.Items.Add("Todos los productos")
        CLAPROD.Add("")
        LCP.ADD("")
        Dim SQLPRO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,CP FROM PRODUCTOS WHERE GRUPO='" + CLAGRU(CBGRU.SelectedIndex) + "' AND ACTIVO=1 AND EMPRESA=" + frmPrincipal.Empresa + " AND CLAVE<>'CREDITO' AND CLAVE<>'999' ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECPRO As SqlClient.SqlDataReader
        LECPRO = SQLPRO.ExecuteReader
        While LECPRO.Read
            CLAPROD.Add(LECPRO(0))
            CBPRO.Items.Add(LECPRO(1))
            LCP.Add(LECPRO(0))
        End While
        LECPRO.Close()
        Try
            CBPRO.SelectedIndex = 0
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub CBGRU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBGRU.SelectedIndexChanged
        CARGAPRODUCTOS()
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

    Private Sub DGV_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        ''EL PEDO ERA K CUANDO CAMBIABAS A IMAGEN... ESTE EVENTO SE VOLVIA A EJECUTAR... Y COMO YA ESTABA ABIERTOS TE MARCABA EL ERROR
    End Sub
    Private Sub IMPRIMIR()
        Dim DT As New DataTable
        Dim DTTEMP As New DataTable
        Dim REP As New rpcCatalogo
        Dim QUERY3

        QUERY3 = "SELECT P.CLAVE CODIGO,P.NOMBRE PRODUCTO,P.PRECIO,G.NOMBRE GRUPO,P.IMG FROM PRODUCTOS P INNER JOIN GRUPOS G ON G.CLAVE=P.GRUPO AND G.EMPRESA=P.EMPRESA "
        If CBGRU.SelectedIndex = 0 Then
            If CBPRO.SelectedIndex = 0 Then
            Else
            End If
        Else
            If CBPRO.SelectedIndex = 0 Then
                QUERY3 = QUERY3 + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' "
            Else
                QUERY3 = QUERY3 + " WHERE G.CLAVE='" + CLAGRU(CBGRU.SelectedIndex) + "' AND P.CLAVE='" + CLAPROD(CBPRO.SelectedIndex) + "' "
            End If
        End If
        QUERY3 = QUERY3 + " AND P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1 ORDER BY G.NOMBRE,P.NOMBRE "


        DT = BDLlenatabla(QUERY3, frmPrincipal.CadenaConexion)
        DTTEMP = BDLlenatabla(QUERY3, frmPrincipal.CadenaConexion)

        DT.Rows.Clear()
        DT.Columns.RemoveAt(4)
        DT.Columns.Add("Imagen", GetType(Byte()))

        Dim X As Integer
        Dim DR As DataRow

        For X = 0 To DTTEMP.Rows.Count - 1
            DR = DT.NewRow
            DR(0) = DTTEMP.Rows(X).Item(0)
            DR(1) = DTTEMP.Rows(X).Item(1)
            DR(2) = DTTEMP.Rows(X).Item(2)
            DR(3) = DTTEMP.Rows(X).Item(3)
            Try
                DR(4) = Image2Bytes(Image.FromFile("C:\FOTOSPRICE\" + DTTEMP.Rows(X).Item(4).ToString + ".JPG "))
            Catch ex As Exception
                DR(4) = Image2Bytes(Image.FromFile("C:\FOTOSPRICE\PANASONIC.JPG "))
            End Try
            DT.Rows.Add(DR)
        Next

        MOSTRARREPORTE(REP, "Catalogo", DT, "Enviar a OneNote 2007")

    End Sub

    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        IMPRIMIR()
    End Sub

    Private Sub frmCatalogo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,GRUPO,NOMBRE,DESCRIPCION FROM PRODUCTOS  ", " WHERE NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Productos", "Nombre del Producto", "Productos(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLAGRU, CBGRU, frmClsBusqueda.TREG.Rows(0).Item(1).ToString)
                OPCargaX(CLAPROD, CBPRO, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)
            End If
        End If
    End Sub
End Class
