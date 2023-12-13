Public Class frmCredito
    Public CLACLI As New List(Of String)
    Dim CLACRE As New List(Of Double)
    Dim CLAD As New List(Of Integer)
    Dim LANOTA As Integer
    Dim LRFC As New List(Of String)
    Dim QUERY As String
    Dim PF As Boolean
    Dim VSA As Boolean
    Private Sub frmCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        'CARGACLIENTES()
        CHECAADEUDO()
    End Sub
    Public Sub MOSTRAR(ByVal CLIENTE As String, ByVal FAC As Boolean, ByVal SA As Boolean)
        VSA = SA
        PF = FAC
        CARGACLIENTES()
        OPCargaX(CLACLI, CBCLI, CLIENTE)
        LBLCRE.Text = CLACRE(CBCLI.SelectedIndex)
        LBLD.Text = CLAD(CBCLI.SelectedIndex)
        LBLTOT.Text = frmPrincipal.PRE.Total.ToString
        LBLTOTTC.Text = frmPrincipal.PRE.TotalTar.ToString
        If VSA Then
            LBLTOT.Text = frmPrincipal.PRE.TotalTar.ToString
            Label8.Text = "Total SA*:"
        Else
            LBLTOT.Text = frmPrincipal.PRE.Total.ToString
            Label8.Text = "Total:"
        End If
        Me.ShowDialog()
    End Sub
    Private Sub CARGACLIENTES()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        LRFC.Clear()
        CBCLI.Items.Clear()
        CLACLI.Clear()
        CLACRE.Clear()
        CLAD.Clear()
        Dim SQLGRUPO As New SqlClient.SqlCommand("SELECT CLAVE,NOMBRE,CREDITO,DIASCREDITO,RFC FROM CLIENTES   WHERE ACTIVO=1 AND TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ORDER BY NOMBRE", frmPrincipal.CONX)
        Dim LECGRUPO As SqlClient.SqlDataReader
        LECGRUPO = SQLGRUPO.ExecuteReader
        While LECGRUPO.Read
            CLACLI.Add(LECGRUPO(0))
            CBCLI.Items.Add(LECGRUPO(1))
            CLACRE.Add(LECGRUPO(2))
            CLAD.Add(LECGRUPO(3))
            LRFC.Add(LECGRUPO(4))
        End While
        LECGRUPO.Close()
        Try
            CBCLI.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Function CHECAADEUDO() As Boolean
        If Not frmPrincipal.CHECACONX Then
            Exit Function
        End If

        QUERY = "SELECT N.Nota,(N.TOTAL-(SELECT DBO.TOTALABONADONOTA(N.TIENDA,N.NOTA)))Adeudo,(Select Convert(Char(10),N.FECHA,103)) Consumo,(Select Convert(Char(10),DATEADD(dd,C.DIASCREDITO,N.FECHA),103)) Vencido FROM NOTASDEVENTACREDITO N INNER JOIN CLIENTES C ON C.CLAVE=N.CLIENTE AND C.TIENDA=N.TIENDA WHERE N.PAGADO=0 AND DATEDIFF(dd,N.FECHA,GETDATE())>C.DIASCREDITO AND C.CLAVE='" + CLACLI(CBCLI.SelectedIndex) + "' and n.tienda='" + frmPrincipal.SucursalBase + "' GROUP BY N.NOTA,N.FECHA,C.DIASCREDITO,N.TOTAL,N.TIENDA"

        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Refresh()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Return CHECATABLA()
    End Function
    Private Function CHECATABLA() As Boolean

        If DGV.Rows.Count > 0 Then
            '       MessageBox.Show("el cliente tiene adeudos vencidos, necesita autorización de un administrador para otorgar el credito", "aviso", MessageBoxButtons.OK)
            Return True
        End If
        Return False
    End Function
    Private Sub BTNACEPTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNACEPTAR.Click
        GUARDAR()
    End Sub
    Public Function CARGANOTA() As Integer
        'Try
        If Not frmPrincipal.CHECACONX() Then
            Exit Function
        End If
        Dim NUM As Integer
        NUM = 1
        Dim SQLMOV As New SqlClient.SqlCommand("SELECT DBO.SIGUIENTENOTACREDITO('" + frmPrincipal.SucursalBase + "')", frmPrincipal.CONX)
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
        'Catch ex As Exception
        '    Me.Close()
        'End Try
    End Function
    Private Sub GUARDAR()
        Dim AUTORIZA As String
        AUTORIZA = ""
        Dim TOT, TOTTC, TOTF, CRE As Double
        TOT = frmPrincipal.PRE.Total.ToString
        TOTTC = frmPrincipal.PRE.TotalTar.ToString
        CRE = LBLCRE.Text
        TOTF = TOT
        If VSA Then
            TOTF = TOTTC
        End If
        If TOTF > CRE Then
            MessageBox.Show("El total de la nota rebasa el credito disponible del cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Dim xyz As Short
            xyz = MessageBox.Show("¿Autorización para credito?", "Información", MessageBoxButtons.YesNo)
            If xyz = 6 Then
                frmAutorizacionCredito.mostrar(CLACLI(CBCLI.SelectedIndex), "Autorización Crédito")
                If frmAutorizacionCredito.DialogResult = Windows.Forms.DialogResult.Yes Then
                    AUTORIZA = frmAutorizacionCredito.USU
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            If CHECAADEUDO() Then
                MessageBox.Show("El cliente tiene adeudos vencidos, necesita autorización de un administrador para otorgar el credito", "aviso", MessageBoxButtons.OK)
                Dim xyz As Short
                xyz = MessageBox.Show("¿Autorización para credito?", "Información", MessageBoxButtons.YesNo)
                If xyz = 6 Then
                    frmAutorizacionCredito.mostrar(CLACLI(CBCLI.SelectedIndex), "Autorización Crédito")
                    If frmAutorizacionCredito.DialogResult = Windows.Forms.DialogResult.Yes Then
                        AUTORIZA = frmAutorizacionCredito.USU
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If

        LANOTA = CARGANOTA()
        Dim SQLGUARDA1 As New SqlClient.SqlCommand("INSERT INTO NOTASDEVENTACREDITO(TIENDA,CLIENTE,NOTA,TOTAL,ESTADO,NOCAJA,CAJERA,FECHA,PAGADO,AUTORIZO,SA) VALUES (@TI,@CLI,@NOTA,@TOT,@EDO,@NOCAJA,@EMP,GETDATE(),0,@AUT,@SA)", frmPrincipal.CONX)
        SQLGUARDA1.CommandTimeout = 300
        SQLGUARDA1.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLGUARDA1.Parameters.Add("@CLI", SqlDbType.VarChar).Value = CLACLI(CBCLI.SelectedIndex)
        SQLGUARDA1.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
        SQLGUARDA1.Parameters.Add("@TOT", SqlDbType.Float).Value = TOTF
        SQLGUARDA1.Parameters.Add("@EMP", SqlDbType.Int).Value = frmNotaDeVenta.NE
        SQLGUARDA1.Parameters.Add("@EDO", SqlDbType.Int).Value = 1
        SQLGUARDA1.Parameters.Add("@NOCAJA", SqlDbType.Int).Value = frmNotaDeVenta.CAJA
        SQLGUARDA1.Parameters.Add("@AUT", SqlDbType.VarChar).Value = AUTORIZA

        If VSA Then
            SQLGUARDA1.Parameters.Add("@SA", SqlDbType.Bit).Value = 1
        Else
            SQLGUARDA1.Parameters.Add("@SA", SqlDbType.Bit).Value = 0
        End If


        SQLGUARDA1.CommandTimeout = 300
        SQLGUARDA1.ExecuteNonQuery()
        SQLGUARDA1.Dispose()
        'TXTNOTA.Text = LANOTA.ToString



        Dim SQLDETALLES As New SqlClient.SqlCommand("INSERT INTO DETALLENOTASDEVENTACREDITO(TIENDA,NOTA,PRODUCTO,CANTIDAD,TOTAL,REGISTRO,DESCUENTO) VALUES (@TI,@NOTA,@PROD,@CANT,@TOT,@REG,@DES)", frmPrincipal.CONX)
        SQLDETALLES.CommandTimeout = 300
        SQLDETALLES.Parameters.Add("@TI", SqlDbType.VarChar)
        SQLDETALLES.Parameters.Add("@NOTA", SqlDbType.VarChar)
        SQLDETALLES.Parameters.Add("@PROD", SqlDbType.VarChar)
        SQLDETALLES.Parameters.Add("@CANT", SqlDbType.Float)
        SQLDETALLES.Parameters.Add("@TOT", SqlDbType.Float)
        SQLDETALLES.Parameters.Add("@DES", SqlDbType.Float)
        SQLDETALLES.Parameters.Add("@REG", SqlDbType.VarChar)
        SQLDETALLES.CommandTimeout = 300
        SQLDETALLES.Parameters("@TI").Value = frmPrincipal.SucursalBase
        SQLDETALLES.Parameters("@NOTA").Value = LANOTA
        Dim X As Integer
        For X = 0 To frmNotaDeVenta.DGV.Rows.Count - 1
            SQLDETALLES.Parameters("@PROD").Value = frmNotaDeVenta.DGV.Item(0, X).Value
            SQLDETALLES.Parameters("@CANT").Value = frmNotaDeVenta.DGV.Item(2, X).Value
            If VSA Then
                SQLDETALLES.Parameters("@TOT").Value = frmNotaDeVenta.DGV.Item(5, X).Value * (1 + (My.Settings.ServicioAdicional))
            Else
                SQLDETALLES.Parameters("@TOT").Value = frmNotaDeVenta.DGV.Item(5, X).Value
            End If
            SQLDETALLES.Parameters("@DES").Value = frmNotaDeVenta.DGV.Item(3, X).Value
            SQLDETALLES.Parameters("@REG").Value = X
            SQLDETALLES.ExecuteNonQuery()
        Next
        SQLDETALLES.Dispose()

        Dim total As Double
        total = CType(frmNotaDeVenta.TXTTOT.Text, Double)
        Try
            Dim SQLCLI As New SqlClient.SqlCommand("UPDATE CLIENTES SET CREDITO=CREDITO-" + TOTF.ToString + ",ADEUDO=ADEUDO+" + TOTF.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE=" + CLACLI(CBCLI.SelectedIndex) + " ", frmPrincipal.CONX)
            SQLCLI.CommandTimeout = 300
            SQLCLI.ExecuteNonQuery()
            SQLCLI.Dispose()
        Catch ex As Exception
            MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'DGV.Rows.Clear()
        'TXTCOD.Clear()
        'LBLPRE.Text = "0"
        'LBLEXIS.Text = "0"
        'TXTCANT.Text = "1"
        'TXTEFECTIVO.Text = "0.00"
        'LBLP.Text = "0"
        'LBLNOM.Text = "0"
        'CHECACANTIDADES()

        '    Exit Sub
        'End Try

        'Dim SQLGC As New SqlClient.SqlCommand("UPDATE CORTES SET PAGA=" + TXTEFECTIVO.Text.ToString + ",CAMBIO=" + TXTCAMBIO.Text + ",TOTAL=" + TXTEFECTIVO.Text + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString + "", frmPrincipal.CONX)
        'SQLGC.CommandTimeout = 300
        'SQLGC.ExecuteNonQuery()
        'SQLGC.Dispose()

        frmPrincipal.CI.Abrir()
        IMPRIMIRNOTA(LANOTA)

        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        'Dim SQLGUARDAR As New SqlClient.SqlCommand
        'SQLGUARDAR.Connection = frmPrincipal.CONX
        'SQLGUARDAR.CommandTimeout = 300
        'SQLGUARDAR.CommandType = CommandType.StoredProcedure
        'SQLGUARDAR.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        'SQLGUARDAR.Parameters.Add("@NOT", SqlDbType.Int).Value = LANOTA
        'SQLGUARDAR.CommandText = "SPCAMBIOPRECIOCREDITO"
        'Try
        '    SQLGUARDAR.ExecuteNonQuery()
        '    SQLGUARDAR.Dispose()
        'Catch ex As Exception
        '    SQLGUARDAR.Dispose()
        '    MessageBox.Show(ex.Message)
        'End Try
        'Dim SQLPRECIOSCLIENTES As New SqlClient.SqlCommand
        'SQLPRECIOSCLIENTES.Connection = frmPrincipal.CONX
        'SQLPRECIOSCLIENTES.CommandTimeout = 300
        'SQLPRECIOSCLIENTES.CommandType = CommandType.StoredProcedure
        'SQLPRECIOSCLIENTES.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        'SQLPRECIOSCLIENTES.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
        'SQLPRECIOSCLIENTES.Parameters.Add("@CRE", SqlDbType.Bit).Value = 1
        'SQLPRECIOSCLIENTES.CommandText = "SPPRECIOSCLIENTESVENTA"


        Dim SQLPC As New SqlClient.SqlCommand("SPPRECIOSCLIENTESVENTA", frmPrincipal.CONX)
        SQLPC.CommandType = CommandType.StoredProcedure
        SQLPC.CommandTimeout = 300
        SQLPC.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQLPC.Parameters.Add("@NOTA", SqlDbType.Int).Value = LANOTA
        SQLPC.Parameters.Add("@CRE", SqlDbType.Bit).Value = 1
        Try
            SQLPC.ExecuteNonQuery()
            SQLPC.Dispose()
        Catch ex As Exception
            MessageBox.Show("Error al modificar precios de clientes " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If PF Then
            Try
                Dim VF33 As New frmFacturar33
                VF33.MOSTRAR(LRFC(CBCLI.SelectedIndex), LANOTA.ToString, True)
            Catch ex As Exception
                MessageBox.Show("Error al cargar la ventana de facturación de forma automática", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        ' frmCambio.CAMBIO(CType(TXTCAMBIO.Text, Double))
        frmPrincipal.PRE.EliminarNota()
        frmNotaDeVenta.DGV.Refresh()
        frmNotaDeVenta.TXTCOD.Clear()
        frmNotaDeVenta.LBLPRE.Text = "0"
        frmNotaDeVenta.LBLEXIS.Text = "0"
        frmNotaDeVenta.TXTCANT.Text = "1"
        frmNotaDeVenta.LBLP.Text = "0"

        frmNotaDeVenta.CHECAPRODUCTOS()
        frmNotaDeVenta.TXTEFECTIVO.Text = "0"
        frmNotaDeVenta.TXTCOD.Focus()
        frmNotaDeVenta.TXTNOTA.Text = CARGANOTA()
        ' VALE = False
        frmNotaDeVenta.CBTP.SelectedIndex = 0
        frmNotaDeVenta.TXTDESC.Text = 0
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
    Public Function IMPRIMIRNOTA(ByVal LANOTA As Integer) As Boolean
        Try
            If Not frmPrincipal.CHECACONX() Then
                Exit Function
            End If
            Dim QUER As String
            Dim caja As Integer
            QUER = "SELECT S.NOMBRECOMUN,CL.NOMBRE CLIENTE,S.NOMBREFISCAL,D.NOTA,D.PRODUCTO CODIGO,P.NOMBRECORTO PRODUCTO,D.CANTIDAD,PRECIO=(D.TOTAL/D.CANTIDAD),D.TOTAL,SUBTOTAL=DBO.ELSUBTOTAL(D.PRODUCTO,D.TOTAL),IVA=DBO.ELIVA(D.PRODUCTO,D.TOTAL),CONVERT(VARCHAR(10),E.CLAVE) EMPLEADO,N.FECHA,S.DIRECCION,S.CIUDAD,S.RFC,S.TELEFONO,N.NOCAJA,TIPO='NOTA',VUNI='',D.DESCUENTO,S.COMENTARIO5 COMENTARIO1,S.COMENTARIO6 COMENTARIO2,S.COMENTARIO7 COMENTARIO3,S.COMENTARIO8 COMENTARIO4,CL.TELEFONO TEL,CL.DIRECCION DIR,S.CP,CR.RFC R,VNOM=S.COLONIA  FROM DETALLENOTASDEVENTACREDITO D INNER JOIN TIENDAS S ON D.TIENDA=S.CLAVE INNER JOIN PRODUCTOS P  ON D.PRODUCTO=P.CLAVE INNER JOIN NOTASDEVENTACREDITO N   ON D.TIENDA=N.TIENDA AND D.NOTA=N.NOTA INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  INNER JOIN CLIENTES CL   ON CL.CLAVE=N.CLIENTE AND N.TIENDA=CL.TIENDA left JOIN CLIENTERFC CR ON CR.CLIENTE=CL.CLAVE AND CL.TIENDA=CR.TIENDA AND CR.REGISTRO=0 WHERE S.CLAVE='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + frmNotaDeVenta.CAJA.ToString + " AND N.NOTA=" + LANOTA.ToString + "  "
            Dim DT As New DataTable
            DT = BDLlenatabla(QUER, frmPrincipal.CadenaConexion)
            If frmPrincipal.SucursalBase = "MZT" Then
                Dim REPI As New rptNotaDeVentaCreditoMZT
                IMPRIMIRREPORTE(REPI, DT, My.Settings.CopiasCredito, "")
            Else
                Dim REPI As New rptNotaDeVentaCredito
                IMPRIMIRREPORTE(REPI, DT, My.Settings.CopiasCredito, "")
            End If

            If My.Settings.ImpresionCopiaCredito Then
                If frmPrincipal.SucursalBase = "MZT" Then
                    Dim REPL As New rptNotaDeVentaCreditoCopiaMZT
                    IMPRIMIRREPORTE(REPL, DT, My.Settings.CopiasCredito, "")
                Else
                    Dim REPL As New rptNotaDeVentaCreditoCopia
                    IMPRIMIRREPORTE(REPL, DT, My.Settings.CopiasCredito, "")
                End If

            End If
        Catch ex As Exception
            OPMsgError(ex.Message)
            Dim xyz As Short
            xyz = MessageBox.Show("No se imprimió la nota, ¿Desea volver a intentar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If xyz = 6 Then
                Return False
            Else
                ' MessageBox.Show("Utilice la opción reimprimir nota ( " + TXTNOTA.Text + " )", "Información", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Return True
            End If
        End Try
        Return True
    End Function

    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        Me.Close()
    End Sub
    Public CLIENTE As String
    Private Sub CBCLI_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBCLI.KeyPress
        'If e.KeyChar = Chr(13) Then
        '    frmAutorizacionCredito.mostrar(CLACLI(CBCLI.SelectedIndex))
        '    LBLCRE.Text = CLACRE(CBCLI.SelectedIndex)
        '    LBLD.Text = CLAD(CBCLI.SelectedIndex)
        '    CHECAADEUDO()
        'End If
    End Sub

    Private Sub frmCredito_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            frmClsBusqueda.BUSCAR("SELECT CLAVE,NOMBRE,CREDITO,DIASCREDITO FROM CLIENTES   WHERE ACTIVO=1 AND TIENDA='" + frmPrincipal.SucursalBase + "' AND CLAVE<>0 ", " AND NOMBRE ", " ORDER BY NOMBRE ", "Busqueda de Clientes", "Nombre del Cliente", "Cliente(s)", 1, frmPrincipal.CadenaConexion, False)
            If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
                OPCargaX(CLACLI, CBCLI, frmClsBusqueda.TREG.Rows(0).Item(0).ToString)            
            End If
        End If
    End Sub
End Class
