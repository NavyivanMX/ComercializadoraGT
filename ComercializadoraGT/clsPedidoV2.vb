Public Class clsPedidoV2
    Dim DT As New Data.DataTable
    Public Sub New()
        DT.Columns.Add("Producto")
        DT.Columns.Add("Cantidad")
        DT.Columns.Add("Unidad")
        DT.Columns.Add("CantTotal")
        DT.Columns.Add("Existencia")
        DT.Columns.Add("CostoPromedio")
        DT.Columns.Add("Total")
        DT.Columns.Add("CG")
        DT.Columns.Add("CP")
        DT.Columns.Add("CU")
    End Sub
    Public Sub AgregaQuita(ByVal GRU As String, ByVal PRO As String, ByVal Cantidad As Double, ByVal Sumar As Boolean)
        Dim Cant As Double
        Cant = 0
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(7) = GRU And DT.Rows(X).Item(8) = PRO Then
                If Sumar Then
                    Cant = Cant + Cantidad + CType(DT.Rows(X).Item(1), Double)
                    DT.Rows(X).Item(1) = Cant
                Else
                    Cant = Cant - Cantidad + CType(DT.Rows(X).Item(1), Double)
                    DT.Rows(X).Item(1) = Cant
                End If
            End If
        Next
        VerificarDT()
    End Sub
    Public Sub ModificaCantidad(ByVal GRU As String, ByVal PRO As String, ByVal Cantidad As Double, ByVal CantidadTotal As Double)
        Dim CP As Double
        CP = 0
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(7) = GRU And DT.Rows(X).Item(8) = PRO Then
                CP = DT.Rows(X).Item(5)
                DT.Rows(X).Item(6) = CantidadTotal * CP
                DT.Rows(X).Item(1) = Cantidad
                DT.Rows(X).Item(3) = CantidadTotal
            End If
        Next
        VerificarDT()
    End Sub
    Public Sub Agregar(ByVal PRO As String, ByVal CANT As Double, ByVal UNI As String, ByVal CANTOT As Double, ByVal EXIS As Double, ByVal CPROM As Double, ByVal TOT As Double, ByVal CG As String, ByVal CP As String, ByVal CU As String)
        If DT.Columns.Count <= 0 Then
            DT.Columns.Add("Producto")
            DT.Columns.Add("Cantidad")
            DT.Columns.Add("Unidad")
            DT.Columns.Add("CantTotal")
            DT.Columns.Add("Existencia")
            DT.Columns.Add("CostoPromedio")
            DT.Columns.Add("Total")
            DT.Columns.Add("CG")
            DT.Columns.Add("CP")
            DT.Columns.Add("CU")
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

        Dim Total As Double
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(7) = CG And DT.Rows(X).Item(8) = CP Then
                If DT.Rows(X).Item(9) = CU Then
                    Encontrado = True
                    CANT = CANT + CType(DT.Rows(X).Item(1), Double)
                    CANTOT = CANTOT + CType(DT.Rows(X).Item(3), Double)
                    DT.Rows(X).Item(1) = CANT
                    DT.Rows(X).Item(3) = CANTOT
                    DT.Rows(X).Item(6) = CANTOT * DT.Rows(X).Item(5)
                Else
                    MessageBox.Show("Producto ya esta agregado en diferente Unidad: " + DT.Rows(X).Item(2), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If
            End If
        Next
        If Not Encontrado Then
            Dim ROW As System.Data.DataRow = DT.NewRow
            ROW(0) = PRO
            ROW(1) = CANT
            ROW(2) = UNI
            ROW(3) = CANTOT
            ROW(4) = EXIS
            ROW(5) = CPROM
            ROW(6) = TOT
            ROW(7) = CG
            ROW(8) = CP
            ROW(9) = CU
            DT.Rows.Add(ROW)
        End If
    End Sub
    Private Sub VerificarDT()
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(1) <= 0 Then
                DT.Rows.RemoveAt(X)
                Exit For
                Exit Sub
            End If
        Next
    End Sub
    Public Sub AsignarExistencia(ByVal PRO As String, ByVal Existencia As Double)
        Dim X As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(8) = PRO Then
                DT.Rows(X).Item(4) = Existencia
            End If
        Next
    End Sub
    Public Sub Quitar(ByVal GRU As String, ByVal PRO As String)
        Dim Encontrado As Boolean
        Encontrado = False
        Dim X As Integer
        Dim Pos As Integer
        For X = 0 To DT.Rows.Count - 1
            If DT.Rows(X).Item(7) = GRU And DT.Rows(X).Item(8) = PRO Then
                Encontrado = True
                Pos = X
            End If
        Next
        If Encontrado Then
            'DT.Rows(Pos).Item(2) = DT.Rows(Pos).Item(2) - 1
            'DT.Rows(Pos).Item(5) = (DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) - ((DT.Rows(Pos).Item(2) * DT.Rows(Pos).Item(4)) * DT.Rows(Pos).Item(3) / 100)
            DT.Rows(Pos).Item(1) = 0
            VerificarDT()
        End If
    End Sub
    Public Function Total() As Double
        Dim Tot As Double
        Tot = 0
        For X = 0 To DT.Rows.Count - 1
            Tot = Tot + CType(DT.Rows(X).Item(2), Double)
        Next
        Return Tot
    End Function
    Public Function CuentaElementos() As Double
        Try
            If DT.Rows.Count <= 0 Then
                Return 0
            Else
                Dim Elementos As Double
                Elementos = 0

                For X = 0 To DT.Rows.Count - 1
                    Elementos = Elementos + CType(DT.Rows(X).Item(1), Double)
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
            SQL.CommandText = "SELECT PRECIO FROM PRODUCTOSVTA WHERE CLAVE='" + DT.Rows(X).Item(0).ToString + "'"
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
    End Sub
    Public Sub EliminarNota()
        DT.Rows.Clear()
    End Sub
    Public Function PRODUCTOSVTAAgregados() As Data.DataTable
        Dim DTT As Data.DataTable
        DTT = DT
        DTT.Columns(0).SetOrdinal(1)
        Return DTT
    End Function

    Public Function ElementosAgregados() As Data.DataTable
        Return DT

        'Return DT
    End Function
End Class

