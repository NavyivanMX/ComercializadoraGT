Imports System.Drawing.Color
Public Class frmPagoMixto
    Dim FZ As New DateTimePicker
    'Dim LISTATOTAL As New List(Of Double)
    Dim LISTAEMPLEADOS As New List(Of Integer)
    Dim LISTATP As New List(Of Integer)
    Dim LISTACANTIDADES As New List(Of Double)
    Dim NOTAS As New List(Of Integer)
    Dim CAJERA As Integer
    Dim NOMBRE As String
    Dim NOCAJA As Integer
    Dim TIPOSPAGOS As Integer
    Dim LANOTA As Integer

    Public Sub MOSTRAR(ByVal CAJA As Integer, ByVal CAJER As Integer, ByVal NOMCAJ As String)
        NOCAJA = CAJA
        CAJERA = CAJER
        NOMBRE = NOMCAJ
        ' DGV.Rows.Clear()

        'NOTASAGREGADAS()
        CHECATABLA()
        COLOR(CAJA)
        CHECACHK()
        Me.ShowDialog()
    End Sub
    Private Sub COLOR(ByVal CAJA As Integer)
        'If CAJA = 1 Then
        '    Me.BackColor = System.Drawing.Color.CadetBlue
        'End If
        'If CAJA = 2 Then
        '    Me.BackColor = System.Drawing.Color.DarkSalmon
        'End If
        'If CAJA = 3 Then
        '    Me.BackColor = System.Drawing.Color.DarkSeaGreen
        'End If
        'If CAJA = 4 Then
        '    Me.BackColor = System.Drawing.Color.BurlyWood
        'End If
        'If CAJA = 5 Then
        '    Me.BackColor = System.Drawing.Color.YellowGreen
        'End If
    End Sub
    Private Sub CHECACHK()
        TXTEFECTIVO.BackColor = System.Drawing.Color.White
        TXTTARJETA.BackColor = System.Drawing.Color.White
        ' TXTCHEQUE.BackColor = System.Drawing.Color.White
        TXTEFECTIVO.Enabled = CHKEFECTIVO.Checked
        TXTTARJETA.Enabled = CHKTARJETA.Checked
        'TXTCHEQUE.Enabled = CHKCHEQUE.Checked
        TIPOSPAGOS = 0
        If CHKEFECTIVO.Checked Then
            TIPOSPAGOS = TIPOSPAGOS + 1
            TXTEFECTIVO.BackColor = System.Drawing.Color.Cyan
        End If
        If CHKTARJETA.Checked Then
            TIPOSPAGOS = TIPOSPAGOS + 1
            TXTTARJETA.BackColor = System.Drawing.Color.Cyan
        End If
        'If CHKCHEQUE.Checked Then
        '    TIPOSPAGOS = TIPOSPAGOS + 1
        '    TXTCHEQUE.BackColor = System.Drawing.Color.Cyan
        'End If
        CHECACANTIDADES()
    End Sub
    Dim TTTOTAL As Double
    Private Function CHECACANTIDADES() As Boolean
        BTNCOBRAR.Enabled = False
        Dim TOTAL, EFECTIVO, TARJETA, CHEQUE, TOTPAGO As Double
        EFECTIVO = 0
        TARJETA = 0
        CHEQUE = 0
        TOTPAGO = 0

        If CHKEFECTIVO.Checked Then
            Try
                If TXTEFECTIVO.Text = "" Then
                    EFECTIVO = 0
                Else
                    EFECTIVO = CType(TXTEFECTIVO.Text, Double)
                End If
            Catch ex As Exception
                Return False
            End Try
        End If
        If CHKTARJETA.Checked Then
            Try
                If TXTTARJETA.Text = "" Then
                    TARJETA = 0
                Else
                    TARJETA = CType(TXTTARJETA.Text, Double)
                End If
            Catch ex As Exception
                Return False
            End Try
        End If
        'If CHKCHEQUE.Checked Then
        '    Try
        '        If TXTCHEQUE.Text = "" Then
        '            CHEQUE = 0
        '        Else
        '            CHEQUE = CType(TXTCHEQUE.Text, Double)
        '        End If
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'End If
        TOTPAGO = EFECTIVO + TARJETA '+ CHEQUE
        TTTOTAL = TOTPAGO
        Try
            TOTAL = CType(TXTTOT.Text, Double)
        Catch ex As Exception
            Return False
        End Try
        If TOTPAGO >= TOTAL Then
            TXTFALTA.Text = 0
            BTNCOBRAR.Enabled = True
            TXTCAMBIO.Text = FormatNumber(TOTPAGO - TOTAL).ToString()
        Else
            TXTFALTA.Text = (TOTAL - TOTPAGO).ToString
            TXTCAMBIO.Text = 0
        End If
        Return True
    End Function
    Private Function HAYZ() As Boolean
        frmPrincipal.CHECACONX()
        Try
            Dim SQL As New SqlClient.SqlCommand("SELECT FECHAZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString + " ", frmPrincipal.CONX)
            Dim LEC As SqlClient.SqlDataReader
            LEC = SQL.ExecuteReader
            If LEC.Read Then
                FZ.Value = LEC(0)
            Else
                MessageBox.Show("NO LEYO")
            End If
            LEC.Close()
            If FZ.Value.Date < Now.Date Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Function CHECAVALORES() As Boolean
        Dim TARJETA, CHEQUE, EFECTIVO, TOTAL As Double
        TARJETA = 0
        CHEQUE = 0
        EFECTIVO = 0
        If TIPOSPAGOS = 2 Then
            TOTAL = CType(TXTTOT.Text, Double)
            If CHKTARJETA.Checked Then
                TARJETA = CType(TXTTARJETA.Text, Double)
                If TARJETA = 0 Then
                    MessageBox.Show("La cantidad en tarjeta NO debe estar en cero, favor de escribir los valores correctos o desactivar la casilla tarjetas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                If TARJETA >= TOTAL Then
                    MessageBox.Show("La cantidad en tarjeta es mayor o igual que el total, favor de seleccionar un solo tipo de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                'CHEQUE = CType(TXTCHEQUE.Text, Double)
                'If CHEQUE = 0 Then
                '    MessageBox.Show("La Cantidad en Cheque NO debe estar en Cero, Favor de Escribir los Valores Correctos o desactivar la Casilla Cheques", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '    Return False
                'End If
                'If CHEQUE >= TOTAL Then
                '    MessageBox.Show("La Cantidad en Cheque es Mayor o Igual que el Total, Favor de seleccionar Un solo Tipo de Pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '    Return False
                'End If
                'If CHEQUE + TARJETA > TOTAL Then
                '    MessageBox.Show("La Cantidad en Cheque + Tarjeta es Mayor que el Total, Favor de Escribir los Valores Correctos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '    Return False
                'End If
            ElseIf CHKTARJETA.Checked And CHKEFECTIVO.Checked Then
                TARJETA = CType(TXTTARJETA.Text, Double)
                If TARJETA = 0 Then
                    MessageBox.Show("La cantidad en tarjeta NO debe estar en cero, favor de escribir los valores correctos o desactivar la casilla tarjetas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                EFECTIVO = CType(TXTEFECTIVO.Text, Double)
                If EFECTIVO = 0 Then
                    MessageBox.Show("La cantidad en efectivo NO debe estar en cero, favor de escribir los valores correctos o desactivar la casilla efectivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                If TARJETA > TOTAL Then
                    MessageBox.Show("La cantidad en tarjeta es mayor o igual que el total, favor de realizar los cambios necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                'ElseIf CHKCHEQUE.Checked And CHKEFECTIVO.Checked Then
                '    CHEQUE = CType(TXTCHEQUE.Text, Double)
                '    If CHEQUE = 0 Then
                '        MessageBox.Show("La Cantidad en Cheque NO debe estar en Cero, Favor de Escribir los Valores Correctos o desactivar la Casilla Cheques", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '        Return False
                '    End If
                EFECTIVO = CType(TXTEFECTIVO.Text, Double)
                If EFECTIVO = 0 Then
                    MessageBox.Show("La cantidad en efectivo NO debe estar en cero, favor de escribir los valores correctos o desactivar la casilla efectivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
                'If CHEQUE > TOTAL Then
                '    MessageBox.Show("La Cantidad en Cheque es Mayor o Igual que el Total, Favor de Realizar los Cambios Necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                '    Return False
                'End If
            Else
                If CHKTARJETA.Checked Then
                    TARJETA = CType(TXTTARJETA.Text, Double)
                End If
                'If CHKCHEQUE.Checked Then
                '    CHEQUE = CType(TXTCHEQUE.Text, Double)
                'End If
                If (TARJETA > TOTAL) Then
                    MessageBox.Show("La cantidad en tarjeta es mayor que el total, favor de realizar los cambios necesarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
            End If
        End If
        If TIPOSPAGOS = 3 Then
            TOTAL = CType(TXTTOT.Text, Double)
            If CHKTARJETA.Checked Then
                TARJETA = CType(TXTTARJETA.Text, Double)
                If TARJETA = 0 Then
                    MessageBox.Show("La cantidad en tarjeta NO debe estar en cero, favor de escribir los valores correctos o desactivar la Casilla tarjetas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                End If
            End If
            'If CHKCHEQUE.Checked Then
            '    CHEQUE = CType(TXTCHEQUE.Text, Double)
            '    If CHEQUE = 0 Then
            '        MessageBox.Show("La Cantidad en Cheque NO debe estar en Cero, Favor de Escribir los Valores Correctos o desactivar la Casilla Cheques", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '        Return False
            '    End If
            'End If
            'If CHEQUE + TARJETA > TOTAL Then
            '    MessageBox.Show("La Cantidad en Cheque + Tarjeta es Mayor que el Total, Favor de Escribir los valores Correctos y Desactivar Tipo de Pago Efectivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '    Return False
            'End If
        End If
        If TIPOSPAGOS = 1 Then
            TOTAL = CType(TXTTOT.Text, Double)
            If CHKTARJETA.Checked Then
                TARJETA = CType(TXTTARJETA.Text, Double)
                If TARJETA <> TOTAL Then
                    MessageBox.Show("La cantidad en tarjeta es diferente que el total, favor de escribir los valores correctos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Return False
                Else
                    Return True
                End If
            End If
            'If CHKCHEQUE.Checked Then
            '    CHEQUE = CType(TXTCHEQUE.Text, Double)
            '    If TARJETA <> TOTAL Then
            '        MessageBox.Show("La Cantidad en Cheque es Diferente que el Total, Favor de Escribir los valores Correctos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            '        Return False
            '    Else
            '        Return True
            '    End If
            'End If
        End If
        Return True
    End Function
    Dim NOTA As Integer
    Private Function CARGANOTA() As Integer
        Try
            frmPrincipal.CHECACONX()
            Dim NUM As Integer
            NUM = 1
            Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTENOTA('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
            Dim LECTOR As SqlClient.SqlDataReader
            LECTOR = SQLMOV.ExecuteReader
            If LECTOR.Read Then
                NUM = LECTOR(0)
                LECTOR.Close()
                Return NUM
            Else
                LECTOR.Close()
                Return NUM
            End If
        Catch ex As Exception
            Me.Close()
        End Try


        
    End Function
    Private Sub AGREGARNOTA()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA (TIENDA,NOTA,FECHA,TOTAL,EMPLEADO,ESTADO,NOCAJA,CAJERA,TIPOPAGO) VALUES ()", frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
    End Sub
    Private Function IMPRIMIRNOTA() As Boolean
        Try
            frmPrincipal.CHECACONX()
            Dim QUER As String
            QUER = "SELECT S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRE PRODUCTO,D.CANTIDAD,P.PRECIO,D.TOTAL,SUBTOTAL=(D.TOTAL/(1+" + frmPrincipal.IVA.ToString + ")),IVA=(D.TOTAL-(D.TOTAL/(1+" + frmPrincipal.IVA.ToString + "))),E.NOMBRE EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,C.PAGA,C.CAMBIO,N.NOCAJA,TIPO='NOTA',VNOM='',VUNI=''  FROM DETALLENOTASDEVENTA D INNER JOIN TIENDAS S  ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P  ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTA N  ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE INNER JOIN CORTES C  ON N.TIENDA=C.TIENDA AND N.NOCAJA=C.CAJA  WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + NOCAJA.ToString + " AND N.ESTADO=3 "
            'Dim REPI As New rptNotaDeVenta
            'Dim CI As New clsImprimir
            'CI.IMPRIMIR2(REPI, QUER, 1, frmPrincipal.CadenaConexion)
            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptNotaVentaMZT
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            Else
                Dim REPI As New rptNotaDeVenta
                IMPRIMIRREPORTE(REPI, BDLlenatabla(QUER, frmPrincipal.CadenaConexion), 1, "")
            End If
        Catch ex As Exception
            Dim xyz As Short
            xyz = MessageBox.Show("No se imprimi la nota, Desea volver a intentar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz = 6 Then
                Return False
            Else
                MessageBox.Show("Utilice la opción reimprimir nota ", "información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        End Try
        Return True
    End Function
    'Private Function CUPON(ByVal CANT As Double) As Integer
    '    If Not frmPrincipal.CHECACONX Then
    '        Exit Function
    '    End If
    '    Dim NOCUPON As Integer
    '    Dim SQL As New SqlClient.SqlCommand("SELECT MAX(NOCUPON)CUPON FROM CUPONPROMOCION WHERE PROMOCION=1 AND SUCURSAL='" + frmPrincipal.SucursalBase + "'", frmPrincipal.CONX)
    '    Dim LECTOR As SqlClient.SqlDataReader
    '    LECTOR = SQL.ExecuteReader
    '    If LECTOR.Read Then
    '        If LECTOR(0) Is DBNull.Value Then
    '            LECTOR.Close()
    '            NOCUPON = 1
    '        Else
    '            Dim NUM As Integer
    '            NUM = CType(LECTOR(0), Integer)
    '            NUM = NUM + 1
    '            LECTOR.Close()
    '            NOCUPON = NUM
    '        End If
    '    End If
    '    Dim QQ2 As String
    '    QQ2 = "INSERT INTO CUPONPROMOCION(SUCURSAL,PROMOCION,NOCUPON,TOTAL,FECHA) VALUES ('" + frmPrincipal.SucursalBase + "',1," + NOCUPON.ToString + "," + CANT.ToString + ",GETDATE())"
    '    Dim SQL2 As New SqlClient.SqlCommand(QQ2, frmPrincipal.CONX)
    '    SQL2.ExecuteNonQuery()
    '    Return NOCUPON
    'End Function
    Private Sub BTNCOBRAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCOBRAR.Click
        If Not CHECACANTIDADES() Then
            MessageBox.Show("Los valores no son correctos, favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        If Not CHECAVALORES() Then
            Exit Sub
        End If
        Dim EFECTIVO, TARJETA, CHEQUE, NETOEFECTIVO, TOTAL, PCTEFECTIVO, PCTCHEQUE, PCTTARJETA As Double
        Dim TP As Integer
        Dim NETOTOT As Double
        NETOTOT = 0
        NETOTOT = CType(TXTTOT.Text, Double)
        If HAYZ() Then
            Dim xyz As Short
            xyz = MessageBox.Show("Se ha realizado un corte Z este día, la(s) nota(s) cobrada(s) aparecerán  en el corte del día siguiente, Desea continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz <> 6 Then
                Exit Sub
            End If
            Try
                frmPrincipal.CHECACONX()
                Dim TOT, CAMB As Double
                Try
                    TOT = CType(TXTEFECTIVO.Text, Double)
                    CAMB = CType(TXTCAMBIO.Text, Double)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Exit Sub
                End Try
                Dim SQLGC As New SqlClient.SqlCommand("UPDATE CORTES SET PAGA=" + TTTOTAL.ToString + ",CAMBIO=" + CAMB.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString, frmPrincipal.CONX)
                SQLGC.ExecuteNonQuery()


                If TIPOSPAGOS = 1 Then
                    If CHKEFECTIVO.Checked Then
                        TP = 1
                    End If
                    If CHKTARJETA.Checked Then
                        TP = 2
                    End If
                    'If CHKCHEQUE.Checked Then
                    '    TP = 3
                    'End If
                    ' ''LA NOTA K NUMERO ES...Y ES UN INSERT AKI...

                    LANOTA = CARGANOTA()
                    Dim QUERY As String
                    QUERY = "INSERT INTO NOTASDEVENTA (TIENDA,NOTA,FECHA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO) VALUES('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + ",@FEC," + NETOTOT.ToString + ",3," + NOCAJA.ToString + "," + CAJERA.ToString + "," + TP.ToString + ")"
                    Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
                    SQL.Parameters.Clear()
                    SQL.Parameters.Add("@FEC", SqlDbType.DateTime)
                    SQL.Parameters("@FEC").Value = FZ.Value.Date.AddHours(33)
                    SQL.ExecuteNonQuery()

                    Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@SUC,@NOTA,@PLAT,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
                    SQLDETALLES.Parameters.Add("@SUC", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@PLAT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@CANT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@TOT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)

                    SQLDETALLES.Parameters("@SUC").Value = frmPrincipal.SucursalBase
                    SQLDETALLES.Parameters("@NOTA").Value = LANOTA.ToString
                    Dim X As Integer
                    For X = 0 To DGV.Rows.Count - 1
                        SQLDETALLES.Parameters("@PLAT").Value = DGV.Item(0, X).Value
                        SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, X).Value
                        SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, X).Value
                        SQLDETALLES.Parameters("@TOT").Value = DGV.Item(4, X).Value
                        SQLDETALLES.Parameters("@REG").Value = X
                        SQLDETALLES.ExecuteNonQuery()
                    Next
                    ''TERMINA UN TIPO DE PAGO Y HAY Z

                Else
                    EFECTIVO = 0
                    TARJETA = 0
                    CHEQUE = 0
                    NETOEFECTIVO = 0
                    TOTAL = 0
                    PCTTARJETA = 0
                    PCTCHEQUE = 0
                    PCTEFECTIVO = 0

                    TOTAL = CType(TXTTOT.Text, Double)
                    LISTATP.Clear()
                    If CHKTARJETA.Checked Then
                        TARJETA = CType(TXTTARJETA.Text, Double)
                        LISTATP.Add(2)
                        PCTTARJETA = TARJETA / TOTAL
                        LISTACANTIDADES.Add(TARJETA)
                    End If
                    'If CHKCHEQUE.Checked Then
                    '    CHEQUE = CType(TXTCHEQUE.Text, Double)
                    '    LISTATP.Add(3)
                    '    PCTCHEQUE = CHEQUE / TOTAL
                    '    LISTACANTIDADES.Add(CHEQUE)
                    'End If

                    If CHKEFECTIVO.Checked Then
                        EFECTIVO = CType(TXTEFECTIVO.Text, Double)
                        LISTATP.Add(1)
                        NETOEFECTIVO = TOTAL - TARJETA - CHEQUE
                        PCTEFECTIVO = NETOEFECTIVO / TOTAL
                        LISTACANTIDADES.Add(NETOEFECTIVO)
                    End If
                    Dim N As Integer
                    ''''''''''''''''''''''''''''agregar nota y pago mixto
                    Dim IMP, TOTA As Double
                    For X = 0 To LISTATP.Count - 1
                        IMP = 0
                        TOTA = TOTAL
                        If LISTATP(X) = 2 Then
                            IMP = TOTA * PCTTARJETA
                        End If
                        'If LISTATP(X) = 3 Then
                        '    IMP = TOTA * PCTCHEQUE
                        'End If
                        If LISTATP(X) = 1 Then
                            IMP = TOTA * PCTEFECTIVO
                        End If


                        LANOTA = CARGANOTA()
                        Dim SQL As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA (TIENDA,NOTA,FECHA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO) VALUES ('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + " ,@FEC," + IMP.ToString + ",3," + NOCAJA.ToString + "," + CAJERA.ToString + "," + LISTATP(X).ToString + ")", frmPrincipal.CONX)
                        SQL.Parameters.Clear()
                        SQL.Parameters.Add("@FEC", SqlDbType.DateTime)
                        SQL.Parameters("@FEC").Value = FZ.Value.Date.AddHours(33)
                        SQL.ExecuteNonQuery()
                        SQL.Parameters.Clear()
                        If X = 0 Then
                            Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@SUC,@NOTA,@PLAT,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
                            SQLDETALLES.Parameters.Add("@SUC", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@PLAT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@CANT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@TOT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)


                            SQLDETALLES.Parameters("@SUC").Value = frmPrincipal.SucursalBase
                            SQLDETALLES.Parameters("@NOTA").Value = LANOTA.ToString
                            For N = 0 To DGV.Rows.Count - 1
                                SQLDETALLES.Parameters("@PLAT").Value = DGV.Item(0, N).Value
                                SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, N).Value
                                SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, N).Value
                                SQLDETALLES.Parameters("@TOT").Value = DGV.Item(4, N).Value
                                SQLDETALLES.Parameters("@REG").Value = N
                                SQLDETALLES.ExecuteNonQuery()
                            Next
                        Else
                            SQL.CommandText = "INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO) VALUES ('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + ",999,0,0," + X.ToString + ")"
                            SQL.ExecuteNonQuery()
                        End If
                    Next
                End If
                ' TERMINA HAY Z Y PAGO MIXTO 
                'frmReportes.ABRIR()
                ''Dim REPTICKET As New TicketCaja
                'Dim QUER As String
                'QUER = "SELECT N.EMPLEADO CLAVEEMPLEADO,E.NOMBRE EMPLEADO,N.NOTA,N.NOCAJA, Total=(SUM (TOTAL)),SubTotal=(SUM(TOTAL)/1.15),IVA=((SUM(TOTAL)/1.15)*.15),M.NOMBRE EMPRESA,M.DIRECCION,M.CIUDAD,M.RFC,M.TELEFONO,M.COMENTARIO1,M.COMENTARIO2,C.PAGA,C.CAMBIO,T.NOMBRE TIPOPAGO FROM NOTASDEVENTA2 N INNER JOIN EMPLEADOSSUCURSALES E ON N.EMPLEADO=E.EMPLEADO AND N.SUCURSAL=E.SUCURSAL INNER JOIN EMPRESASUCURSAL M ON M.SUCURSAL=N.SUCURSAL INNER JOIN CORTES C ON N.SUCURSAL=C.SUCURSAL AND N.NOCAJA=C.CAJA INNER JOIN TIPOSPAGOS T ON N.TIPOPAGO=T.CLAVE WHERE N.SUCURSAL='" + frmPrincipal.SucursalBase + "' AND N.ESTADO=3 AND N.NOCAJA=" + NOCAJA.ToString + " GROUP BY N.EMPLEADO,E.EMPLEADO,E.NOMBRE,M.NOMBRE,M.DIRECCION,M.CIUDAD,M.RFC,M.TELEFONO,N.NOTA,N.NOCAJA,M.COMENTARIO1,M.COMENTARIO2,C.PAGA,C.CAMBIO,T.NOMBRE"
                ''frmReportes.IMPRIMIR(REPTICKET, "Ticket de Caja", QUER)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        Else
            Try
                frmPrincipal.CHECACONX()
                Dim TOT, CAMB As Double
                Try
                    TOT = CType(TXTEFECTIVO.Text, Double)
                    CAMB = CType(TXTCAMBIO.Text, Double)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Exit Sub
                End Try
                Dim SQLGC As New SqlClient.SqlCommand("UPDATE CORTES SET PAGA=" + TTTOTAL.ToString + ",CAMBIO=" + CAMB.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString, frmPrincipal.CONX)
                SQLGC.ExecuteNonQuery()

                If TIPOSPAGOS = 1 Then
                    If CHKEFECTIVO.Checked Then
                        TP = 1
                    End If
                    If CHKTARJETA.Checked Then
                        TP = 2
                    End If
                    'If CHKCHEQUE.Checked Then
                    '    TP = 3
                    'End If
                    '''''''''''insert
                    ''LA NOTA K NUMERO ES...Y ES UN INSERT AKI...

                    LANOTA = CARGANOTA()
                    Dim QUERY As String
                    QUERY = "INSERT INTO NOTASDEVENTA (TIENDA,NOTA,FECHA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO) VALUES('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + ",GETDATE()," + NETOTOT.ToString + ",3," + NOCAJA.ToString + "," + CAJERA.ToString + "," + TP.ToString + ")"
                    Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
                    SQL.ExecuteNonQuery()

                    Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@SUC,@NOTA,@PLAT,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
                    SQLDETALLES.Parameters.Add("@SUC", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@PLAT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@CANT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@TOT", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
                    SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)


                    SQLDETALLES.Parameters("@SUC").Value = frmPrincipal.SucursalBase
                    SQLDETALLES.Parameters("@NOTA").Value = LANOTA.ToString
                    Dim X As Integer
                    For X = 0 To DGV.Rows.Count - 1
                        SQLDETALLES.Parameters("@PLAT").Value = DGV.Item(0, X).Value
                        SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, X).Value
                        SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, X).Value
                        SQLDETALLES.Parameters("@TOT").Value = DGV.Item(4, X).Value
                        SQLDETALLES.Parameters("@REG").Value = X
                        SQLDETALLES.ExecuteNonQuery()
                    Next

                Else
                    EFECTIVO = 0
                    TARJETA = 0
                    CHEQUE = 0
                    NETOEFECTIVO = 0
                    TOTAL = 0
                    PCTTARJETA = 0
                    PCTCHEQUE = 0
                    PCTEFECTIVO = 0

                    TOTAL = CType(TXTTOT.Text, Double)
                    LISTATP.Clear()
                    If CHKTARJETA.Checked Then
                        TARJETA = CType(TXTTARJETA.Text, Double)
                        LISTATP.Add(2)
                        PCTTARJETA = TARJETA / TOTAL
                        LISTACANTIDADES.Add(TARJETA)
                    End If
                    'If CHKCHEQUE.Checked Then
                    '    CHEQUE = CType(TXTCHEQUE.Text, Double)
                    '    LISTATP.Add(3)
                    '    PCTCHEQUE = CHEQUE / TOTAL
                    '    LISTACANTIDADES.Add(CHEQUE)
                    'End If

                    If CHKEFECTIVO.Checked Then
                        EFECTIVO = CType(TXTEFECTIVO.Text, Double)
                        LISTATP.Add(1)
                        NETOEFECTIVO = TOTAL - TARJETA - CHEQUE
                        PCTEFECTIVO = NETOEFECTIVO / TOTAL
                        LISTACANTIDADES.Add(NETOEFECTIVO)
                    End If
                    Dim N As Integer

                    Dim IMP, TOTA As Double

                    For X = 0 To LISTATP.Count - 1
                        IMP = 0
                        TOTA = TOTAL
                        If LISTATP(X) = 2 Then
                            IMP = TOTA * PCTTARJETA
                        End If
                        If LISTATP(X) = 3 Then
                            IMP = TOTA * PCTCHEQUE
                        End If
                        If LISTATP(X) = 1 Then
                            IMP = TOTA * PCTEFECTIVO
                        End If
                        '''''''''''''''''''''''''''''INSERTAR

                        LANOTA = CARGANOTA()
                        Dim SQL As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTA (TIENDA,NOTA,FECHA,TOTAL,ESTADO,NOCAJA,CAJERA,TIPOPAGO) VALUES ('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + " ,@FEC," + IMP.ToString + ",3," + NOCAJA.ToString + "," + CAJERA.ToString + "," + LISTATP(X).ToString + ")", frmPrincipal.CONX)
                        SQL.Parameters.Clear()
                        SQL.Parameters.Add("@FEC", SqlDbType.DateTime)
                        SQL.Parameters("@FEC").Value = FZ.Value.Date.AddHours(33)
                        SQL.ExecuteNonQuery()
                        SQL.Parameters.Clear()
                        If X = 0 Then
                            Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@SUC,@NOTA,@PLAT,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
                            SQLDETALLES.Parameters.Add("@SUC", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@PLAT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@CANT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@TOT", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
                            SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)


                            SQLDETALLES.Parameters("@SUC").Value = frmPrincipal.SucursalBase
                            SQLDETALLES.Parameters("@NOTA").Value = LANOTA.ToString
                            For N = 0 To DGV.Rows.Count - 1
                                SQLDETALLES.Parameters("@PLAT").Value = DGV.Item(0, N).Value
                                SQLDETALLES.Parameters("@CANT").Value = DGV.Item(2, N).Value
                                SQLDETALLES.Parameters("@DES").Value = DGV.Item(3, N).Value
                                SQLDETALLES.Parameters("@TOT").Value = DGV.Item(4, N).Value
                                SQLDETALLES.Parameters("@REG").Value = N
                                SQLDETALLES.ExecuteNonQuery()
                            Next
                        Else
                            SQL.CommandText = "INSERT INTO DETALLENOTASDEVENTA(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES ('" + frmPrincipal.SucursalBase + "'," + LANOTA.ToString + ",999,0,0," + X.ToString + ",0)"
                            SQL.ExecuteNonQuery()
                        End If
                    Next
                End If
                'frmReportes.ABRIR()
                ''Dim REPTICKET As New TicketCaja
                'Dim QUER As String
                'QUER = "SELECT N.EMPLEADO CLAVEEMPLEADO,E.NOMBRE EMPLEADO,N.NOTA,N.NOCAJA, Total=(SUM (TOTAL)),SubTotal=(SUM(TOTAL)/1.15),IVA=((SUM(TOTAL)/1.15)*.15),M.NOMBRE EMPRESA,M.DIRECCION,M.CIUDAD,M.RFC,M.TELEFONO,M.COMENTARIO1,M.COMENTARIO2,C.PAGA,C.CAMBIO,TIPOPAGO='PAGO MIXTO' FROM NOTASDEVENTA N INNER JOIN EMPLEADOSSUCURSALES E ON N.EMPLEADO=E.EMPLEADO AND N.SUCURSAL=E.SUCURSAL INNER JOIN EMPRESASUCURSAL M ON M.SUCURSAL=N.SUCURSAL INNER JOIN CORTES C ON N.SUCURSAL=C.SUCURSAL AND N.NOCAJA=C.CAJA WHERE N.SUCURSAL='" + frmPrincipal.SucursalBase + "' AND N.ESTADO=3 AND N.NOCAJA=" + NOCAJA.ToString + " GROUP BY N.EMPLEADO,E.EMPLEADO,E.NOMBRE,M.NOMBRE,M.DIRECCION,M.CIUDAD,M.RFC,M.TELEFONO,N.NOTA,N.NOCAJA,M.COMENTARIO1,M.COMENTARIO2,C.PAGA,C.CAMBIO"
                '' frmReportes.IMPRIMIR(REPTICKET, "Ticket de Caja", QUER)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try
        End If
        'frmReportes.ABRIR()
        While Not IMPRIMIRNOTA()
        End While
        'If CUENTAELEMENTOS("1") <> 0 Then
        '    MessageBox.Show("FAVOR DE CORTAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    While Not IMPRIMESECCIONES("1", "NOTA")
        '    End While
        'End If
        'If CUENTAELEMENTOS("2") <> 0 Then
        '    MessageBox.Show("FAVOR DE CORTAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    While Not IMPRIMESECCIONES("2", "NOTA")
        '    End While
        'End If
        'If CUENTAELEMENTOS("3") <> 0 Then
        '    MessageBox.Show("FAVOR DE CORTAR EL TICKET", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    While Not IMPRIMESECCIONES("3", "NOTA")
        '    End While
        'End If
        'Dim VMS As New frmCambio
        'VMS.MOSTRAR("Cambio de Caja", TXTCAMBIO.Text)
        'frmPrincipal.CHECATRASDECO()
        If TIPOSPAGOS = 1 Then
            MessageBox.Show("Favor de utilizar esta opción solamente en pagos mixtos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Dim SQL9 As New SqlClient.SqlCommand("UPDATE NOTASDEVENTA SET ESTADO=1 WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND ESTADO=3 AND NOCAJA=" + NOCAJA.ToString, frmPrincipal.CONX)
        SQL9.ExecuteNonQuery()
        CHECATABLA()
        'Me.DialogResult = Windows.Forms.DialogResult.Yes
        frmPrincipal.PRE.EliminarNota()
        DGV.Refresh()
        frmNotaDeVenta.DGV.Refresh()
        frmNotaDeVenta.CBTP.SelectedIndex = 0
        frmNotaDeVenta.TXTNOTA.Text = CARGANOTA()
        Me.Close()
    End Sub
    'Private Sub NOTASAGREGADAS()
    '    DGV.Rows.Clear()
    '    If Not frmPrincipal.CHECACONX() Then
    '        Exit Sub
    '    End If
    '    For X = 0 To LISTANOTAS.Count - 1
    '        Dim SQL As New SqlClient.SqlCommand("SELECT D.NOTA,D.TELA,P.DESCRIPCION,D.EQUIVALENCIA CANTIDAD,P." + frmPrincipal.SucursalBase + ",D.TOTAL FROM DETALLENOTASDEVENTA D INNER JOIN PRODUCTOS P ON D.TELA=P.CLAVE WHERE D.SUCURSAL='" + frmPrincipal.SucursalBase + "' AND D.NOTA=" + LISTANOTAS(X).ToString, frmPrincipal.CONX)
    '        Dim LECTOR As SqlClient.SqlDataReader
    '        LECTOR = SQL.ExecuteReader
    '        Dim ITEMS As Integer
    '        While LECTOR.Read
    '            DGV.Rows.Add(1)
    '            ITEMS = DGV.Rows.Count - 1
    '            DGV.Item(0, ITEMS).Value = LECTOR(0)
    '            DGV.Item(1, ITEMS).Value = LECTOR(1)
    '            DGV.Item(2, ITEMS).Value = LECTOR(2)
    '            DGV.Item(3, ITEMS).Value = LECTOR(3)
    '            DGV.Item(4, ITEMS).Value = LECTOR(4)
    '            DGV.Item(5, ITEMS).Value = LECTOR(5)
    '        End While
    '        LECTOR.Close()
    '    Next
    '    LISTATOTAL.Clear()
    '    LISTAEMPLEADOS.Clear()
    '    For X = 0 To LISTANOTAS.Count - 1
    '        Dim SQL2 As New SqlClient.SqlCommand("SELECT EMPLEADO,TOTAL FROM NOTASDEVENTA WHERE SUCURSAL='" + frmPrincipal.SucursalBase + "' AND NOTA=" + LISTANOTAS(X).ToString, frmPrincipal.CONX)
    '        Dim LECTOR2 As SqlClient.SqlDataReader
    '        LECTOR2 = SQL2.ExecuteReader
    '        If LECTOR2.Read Then
    '            LISTAEMPLEADOS.Add(LECTOR2(0))
    '            LISTATOTAL.Add(LECTOR2(1))
    '        End If
    '        LECTOR2.Close()
    '    Next
    '    CHECATABLA()
    'End Sub
    Private Function CUENTAELEMENTOS(ByVal CLA As String) As Integer
        Dim QUERY As String
        Dim REG As Integer
        QUERY = "SELECT COUNT(D.PRODUCTO)PRODUCTO FROM DETALLENOTASDEVENTA D INNER JOIN NOTASDEVENTA N ON D.NOTA=N.NOTA AND D.TIENDA=N.TIENDA INNER JOIN PRODUCTOS P ON D.PLATILLO=P.CLAVE INNER JOIN SECCIONESIMPRESION S ON P.SECCIONIMP=S.CLAVE WHERE D.RESTAURANTE='" + frmPrincipal.SucursalBase + "' AND N.ESTADO=3 AND S.CLAVE=" + CLA
        Dim SQQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LECC As SqlClient.SqlDataReader
        LECC = SQQL.ExecuteReader
        If LECC.Read Then
            REG = LECC(0)
        End If
        LECC.Close()
        Return REG
    End Function
    Private Sub CHECATABLA()
        If DGV.Rows.Count = 0 Then
            BTNCOBRAR.Enabled = False
            TXTSUB.Text = 0
            TXTIVA.Text = 0
            TXTTOT.Text = 0
        Else
            Dim X As Integer
            Dim TOTAL As Double
            TOTAL = 0
            For X = 0 To DGV.Rows.Count - 1
                TOTAL = TOTAL + DGV.Item(4, X).Value
            Next
            FormatNumber(TOTAL).ToString()
            TXTTOT.Text = FormatNumber(TOTAL).ToString()
            TXTIVA.Text = FormatNumber(TOTAL * 0.16).ToString()
            TXTSUB.Text = FormatNumber(TOTAL - CType(TXTIVA.Text, Double)).ToString()
            BTNCOBRAR.Enabled = True
            CHECACANTIDADES()
        End If
    End Sub
    Private Sub TXTEFECTIVO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTEFECTIVO.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            BTNCOBRAR.Focus()
        End If
    End Sub

    Private Sub CHKTARJETA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKTARJETA.CheckedChanged
        CHECACHK()
    End Sub

    Private Sub CHKCHEQUE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CHECACHK()
    End Sub

    Private Sub TXTTARJETA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTARJETA.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            BTNCOBRAR.Focus()
        End If
    End Sub

    Private Sub TXTCHEQUE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If Char.IsPunctuation(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            BTNCOBRAR.Focus()
        End If
    End Sub

    Private Sub TXTEFECTIVO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTEFECTIVO.TextChanged
        CHECACANTIDADES()
    End Sub

    Private Sub TXTTARJETA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTARJETA.TextChanged
        CHECACANTIDADES()
    End Sub

    Private Sub CHKEFECTIVO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKEFECTIVO.CheckedChanged
        CHECACHK()
    End Sub

    Private Sub frmPagoMixto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CHKTARJETA.Visible = frmPrincipal.PagoTarjeta
        TXTTARJETA.Visible = frmPrincipal.PagoTarjeta
        DGV.DataSource = frmPrincipal.PRE.ElementosAgregados
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        CHECATABLA()
    End Sub
End Class