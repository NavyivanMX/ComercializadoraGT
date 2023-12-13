Public Class clsPreNota
    Dim DT As New Data.DataTable
    Public Sub New()
        DT.Columns.Add("Código")
        DT.Columns.Add("Descripción")
        DT.Columns.Add("Cantidad")
        DT.Columns.Add("Descuento")
        DT.Columns.Add("Precio")
        DT.Columns.Add("Total")
        DT.Columns.Add("Tar")
        DT.Columns.Add("T.Tar")
    End Sub
    Private Sub ActualizaTar()
        Dim Precio, Total, Descuento, Cant As Double
        For X = 0 To DT.Rows.Count - 1
            Descuento = DT.Rows(X).Item(3)
            Cant = DT.Rows(X).Item(2)
            Precio = DT.Rows(X).Item(4)
            Total = Cant * Precio
            Total = Total - ((Total * Descuento) / 100)

            DT.Rows(X).Item(6) = Math.Round(Precio * (1 + My.Settings.ServicioAdicional), 2)
            DT.Rows(X).Item(7) = Math.Round((Cant * Precio) * (1 + My.Settings.ServicioAdicional), 2)
        Next
    End Sub
    Public Sub AgregaQuita(ByVal Platillo As String, ByVal Cantidad As Double, ByVal Sumar As Boolean)
        Dim Cant As Double
        Cant = 0
        Dim Precio, Total, Descuento As Double
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(0) = Platillo Then
                If Sumar Then
                    Cant = Cant + Cantidad + CType(DT.Rows(X).Item(2), Double)
                Else
                    Cant = Cant - Cantidad + CType(DT.Rows(X).Item(2), Double)
                End If
                Descuento = DT.Rows(X).Item(3)
                Precio = DT.Rows(X).Item(4)
                Total = Cant * Precio
                Total = Total - ((Total * Descuento) / 100)
                DT.Rows(X).Item(2) = Cant
                DT.Rows(X).Item(5) = Total
                DT.Rows(X).Item(6) = Math.Round(Precio * (1 + My.Settings.ServicioAdicional), 2)
                DT.Rows(X).Item(7) = Math.Round((Cant * Precio) * (1 + My.Settings.ServicioAdicional), 2)
            End If
        Next
        VerificarDT()
    End Sub
    Public Sub Agregar(ByVal Platillo As String, ByVal Descripcion As String, ByVal Cantidad As Double, ByVal Precio As Double, ByVal Descuento As Double)
        If DT.Columns.Count <= 0 Then
            DT.Columns.Add("Código")
            DT.Columns.Add("Descripción")
            DT.Columns.Add("Cantidad")
            DT.Columns.Add("Descuento")
            DT.Columns.Add("Precio")
            DT.Columns.Add("Total")
            DT.Columns.Add("Tar")
            DT.Columns.Add("T.Tar")
        End If
        'DT.Columns.Add("Código")
        'DT.Columns.Add("Descripción")
        'DT.Columns.Add("Cantidad")
        'DT.Columns.Add("Descuento", GetType(Double()))
        'DT.Columns.Add("Precio", GetType(Double()))
        'DT.Columns.Add("Total", GetType(Double()))
        Dim Encontrado As Boolean
        Encontrado = False
        Dim X As Integer
        Dim Cant As Double
        Cant = 0
        Dim Total As Double
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(0) = Platillo Then
                Encontrado = True
                Cant = Cant + Cantidad + CType(DT.Rows(X).Item(2), Double)
                If Descuento > DT.Rows(X).Item(3) Then
                    DT.Rows(X).Item(4) = Precio
                End If
                If Precio > DT.Rows(X).Item(4) Then
                    Precio = DT.Rows(X).Item(4)
                End If
                Total = Cant * Precio
                Total = Math.Round(Total - ((Total * Descuento) / 100), 2)
                DT.Rows(X).Item(2) = Cant
                DT.Rows(X).Item(3) = Descuento
                DT.Rows(X).Item(5) = Total
                DT.Rows(X).Item(6) = Math.Round(Precio * (1 + My.Settings.ServicioAdicional), 2)
                DT.Rows(X).Item(7) = Math.Round((Cant * Precio) * (1 + My.Settings.ServicioAdicional))
            End If
        Next
        If Not Encontrado Then
            Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            Dim MD As Double
            If Not frmPrincipal.CHECACONX Then
                Exit Sub
            End If

            SQL.CommandText = "SELECT DBO.MAXIMODESCUENTO('" + Platillo + "')"
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                MD = LEC(0)
            End If
            LEC.Close()
            If Descuento > MD And MD > 0 Then
                Descuento = MD
            End If
            Dim ROW As System.Data.DataRow = DT.NewRow

            ROW(0) = Platillo
            ROW(1) = Descripcion
            ROW(2) = Cantidad
            ROW(3) = Descuento
            ROW(4) = Precio
            Total = Math.Round((Cantidad * Precio) - ((Cantidad * Precio) * Descuento / 100), 2)
            ROW(5) = Total
            ROW(6) = Math.Round(Precio * (1 + My.Settings.ServicioAdicional), 2)
            ROW(7) = Math.Round((Cant * Precio) * (1 + My.Settings.ServicioAdicional), 2)
            DT.Rows.Add(ROW)
        End If
        VerificarDT()
    End Sub
    Private Sub VerificarDT()
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(2) <= 0 Then
                DT.Rows.RemoveAt(X)
                Exit For
                Exit Sub
            End If
        Next
        ActualizaTar()
    End Sub
    Public Sub Quitar(ByVal Platillo As String)
        Dim Encontrado As Boolean
        Encontrado = False
        Dim X As Integer
        Dim Pos As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(0) = Platillo Then
                Encontrado = True
                Pos = X
            End If
        Next
        If Encontrado Then
            DT.Rows(Pos).Item(2) = DT.Rows(Pos).Item(2) - 1
            DT.Rows(Pos).Item(5) = (DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) - ((DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) * DT.Rows(Pos).Item(3) / 100)
            DT.Rows(Pos).Item(6) = (DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) - ((DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) * DT.Rows(Pos).Item(3) / 100)
            VerificarDT()
        End If
    End Sub
    Public Sub ModificaPrecio(ByVal Articulo As String, ByVal Precio As Double)
        Dim Encontrado As Boolean
        Encontrado = False
        Dim X As Integer
        Dim Pos As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(0) = Articulo Then
                Encontrado = True
                Pos = X
            End If
        Next
        ''Ultimo Costo
        If Encontrado Then
            If Not frmPrincipal.CHECACONX Then
                Exit Sub
            End If
            If frmPrincipal.Usuario.ToUpper = "CYNTHIA" Or frmPrincipal.Usuario.ToUpper = "YOLY" Or frmPrincipal.Usuario.ToUpper = "ENRIQUE" Or frmPrincipal.Usuario.ToUpper = "WERA" Or frmPrincipal.Usuario.ToUpper = "CYNTHIA OB" Then
            Else
                Dim ULTPRE As Double
                Dim SQL As New SqlClient.SqlCommand("SELECT DBO.ELULTIMOCOSTOPRODUCTOTI('" + Articulo + "','" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
                Dim LEC As SqlClient.SqlDataReader
                LEC = SQL.ExecuteReader
                If LEC.Read Then
                    ULTPRE = LEC(0)
                End If
                LEC.Close()
                SQL.Dispose()
                'DT.Columns.Add("Código")
                'DT.Columns.Add("Descripción")
                'DT.Columns.Add("Cantidad")
                'DT.Columns.Add("Descuento")
                'DT.Columns.Add("Precio")
                'DT.Columns.Add("Total")
                If Precio < ULTPRE Then
                    MessageBox.Show("El último precio de Compra fue de: " + ULTPRE.ToString + ". No se permiten precios menores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Precio = ULTPRE
                End If
            End If
      

            DT.Rows(Pos).Item(3) = 0
            DT.Rows(Pos).Item(4) = Precio
            DT.Rows(Pos).Item(5) = (DT.Rows(Pos).Item(2) * Precio)
            VerificarDT()
        End If
    End Sub
    Public Function Total() As Double
        Dim Tot As Double
        Tot = 0
        Try
            For X = 0 To DT.Rows.Count - 1
                Tot = Tot + CType(DT.Rows(X).Item(5), Double)
            Next
        Catch ex As Exception

        End Try

        Return Tot
    End Function
    Public Function TotalTar() As Double
        Dim Tot As Double
        Tot = 0
        Try
            For X = 0 To DT.Rows.Count - 1
                Tot = Tot + CType(DT.Rows(X).Item(5), Double)
            Next
        Catch ex As Exception

        End Try

        Return Tot * (1 + My.Settings.ServicioAdicional)
    End Function
    Public Function CuentaElementos() As Integer
        Try
            If DT.Rows.Count <= 0 Then
                Return 0
            Else
                Dim Elementos As Integer
                Elementos = 0

                For X = 0 To DT.Rows.Count - 1
                    Elementos = Elementos + CType(DT.Rows(X).Item(2), Integer)
                Next
                Return Elementos
            End If
        Catch ex As Exception

        End Try

    End Function
    Public Sub PoneDescuento(ByVal Desc As Double)
        Dim X As Integer
        Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        Dim MD, PRE As Double
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        For X = 0 To DT.Rows.Count - 1
            SQL.CommandText = "SELECT DBO.MAXIMODESCUENTO('" + DT.Rows(X).Item(0).ToString + "')"
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                MD = LEC(0)
            End If
            LEC.Close()
            If Desc > MD And MD > 0 Then
                DT.Rows(X).Item(3) = MD
            Else
                DT.Rows(X).Item(3) = Desc
            End If
            SQL.CommandText = "SELECT PRECIO FROM PRODUCTOS WHERE CLAVE='" + DT.Rows(X).Item(0).ToString + "'"
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                PRE = LEC(0)
            End If
            LEC.Close()
            DT.Rows(X).Item(4) = PRE
        Next
        For X = 0 To DT.Rows.Count - 1
            DT.Rows(X).Item(5) = (DT.Rows(X).Item(2) * DT.Rows(X).Item(4)) - ((DT.Rows(X).Item(2) * DT.Rows(X).Item(4)) * DT.Rows(X).Item(3) / 100)
        Next
        VerificarDT()
    End Sub
    Public Sub EliminarNota()
        DT.Rows.Clear()
    End Sub
    Public Function ProductosAgregados() As Data.DataTable
        Dim DTT As Data.DataTable
        DTT = DT
        DTT.Columns(0).SetOrdinal(5)
        Return DTT
    End Function
    Public Function ElementosAgregados() As Data.DataTable
        Return DT

        'Return DT
    End Function
End Class
