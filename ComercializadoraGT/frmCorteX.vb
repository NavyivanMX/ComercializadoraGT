Public Class frmCorteX
    Dim DTX As New DateTimePicker
    Dim DTZ As New DateTimePicker
    Dim DTQ As New DateTimePicker
    Dim NOMCAJERA As String
    Dim NOCAJA As Integer
    Dim ANT As Boolean
    Dim TARJETAS As Double
    Dim CHEQUES As Double
    Dim DTCOS As New DataTable
    Dim CREDITO As Integer
    Private Sub frmCorteX_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        BTNIMPRIMIR.Visible = frmPrincipal.CorteXX

    End Sub

    Public Sub VISTA(ByVal CAJA As Integer, ByVal NOMBRE As String)
        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If
        If CREDITO <= 0 Then
            CREDITO = 1
        End If
        ANT = False
        NOCAJA = CAJA
        NOMCAJERA = NOMBRE
        Dim NOZ As String
        NOZ = ""
        Dim SP As Boolean = False
        Dim SQL As New SqlClient.SqlCommand("SELECT FECHAX,FECHAZ,CZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + CAJA.ToString, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If LEC(0) Is DBNull.Value Then
                LEC.Close()
            Else
                SP = True
                DTX.Value = LEC(0)
                DTZ.Value = LEC(1)
                NOZ = LEC(2)
            End If
        End If
        LEC.Close()
        LBLCORTE.Text = NOZ
        If DTX.Value < DTZ.Value Then
            DTQ.Value = DTZ.Value
        Else
            DTQ.Value = DTX.Value
        End If

        Dim QUERY As String
        'QUERY = "SELECT P.COSTO * SUM(D.CANTIDAD) COSTO  FROM DETALLENOTASDEVENTA  D INNER JOIN PRODUCTOS P  ON P.CLAVE = D.PRODUCTO INNER JOIN NOTASDEVENTA N  ON N.TIENDA = D.TIENDA AND N.NOTA = D.NOTA WHERE N.FECHA >=@FEC GROUP BY P.COSTO "
        'Dim DACOS As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        'DACOS.SelectCommand.Parameters.Add("@FEC", SqlDbType.DateTime)
        'DACOS.SelectCommand.Parameters("@FEC").Value = DTQ.Value
        QUERY = ""
        frmPrincipal.CHECACONX()
        'DACOS.Fill(DTCOS)
        If CREDITO = 1 Then
            QUERY = "SELECT N.CAJERA Clave,E.NOMBRE Nombre,COUNT(n.nota)[Nota/Vale], SUM (N.TOTAL) Total, Forma='Notas' FROM NOTASDEVENTA N INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.ESTADO=1 AND N.TIPOPAGO=1 AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI GROUP BY NOCAJA,N.CAJERA,E.NOMBRE "
        End If
        If CREDITO = 2 Then
            QUERY = "SELECT N.CAJERA Clave,E.NOMBRE Nombre,COUNT(n.nota)[Creditos], SUM (N.TOTAL) Total, Forma='Credito' FROM NOTASDEVENTACREDITO N INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.ESTADO=1 AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI GROUP BY NOCAJA,N.CAJERA,E.NOMBRE "
        End If
        If CREDITO = 3 Then
            QUERY = "SELECT N.CAJERA Clave,E.NOMBRE Nombre,COUNT(n.nota)[Cobranzas], SUM (N.TOTAL) Total, Forma='Cobranza' FROM NOTASCOBRANZAPRO N INNER JOIN EMPLEADOS E  ON N.TIENDA=E.TIENDA AND N.CAJERA=E.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI GROUP BY NOCAJA,N.CAJERA,E.NOMBRE "

        End If
        QUERY = "SELECT CAJERA,NOMBRE,COUNT(NOTA)NOTAS,SUM(TOTAL) TOTAL,FORMA,TIPOPAGO FROM VVENTATIPOPAGO WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND NOCAJA=" + CAJA.ToString + " AND FECHA>=@INI GROUP BY CAJERA,NOMBRE,FORMA,TIPOPAGO "


        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTQ.Value, DTQ.Value)

        'Dim DA As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        'DA.SelectCommand.Parameters.Add("@FEC", SqlDbType.DateTime)
        'DA.SelectCommand.Parameters("@FEC").Value = DTQ.Value
        'Dim DT As New DataTable
        'frmPrincipal.CHECACONX()
        'DA.Fill(DT)
        'Dim DS As New DataSet
        'DA.Fill(DS, "TB")
        'DGV.DataSource = DS.Tables("TB")
        DGV.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()

        'Dim DA2 As New SqlClient.SqlDataAdapter("SELECT d.Tipodepago,sum(d.total)Total FROM VISTATIPOSPAGOS d  WHERE d.TIENDA='" + frmPrincipal.SucursalBase + "' AND d.NOCAJA=" + CAJA.ToString + " AND d.FECHA>=@FEC group by d.TIPoDEPAGO", frmPrincipal.CONX)
        'DA2.SelectCommand.Parameters.Add("@FEC", SqlDbType.DateTime)
        'DA2.SelectCommand.Parameters("@FEC").Value = DTQ.Value
        'Dim DT2 As New DataTable
        'frmPrincipal.CHECACONX()
        'DA2.Fill(DT2)
        DGV2.DataSource = BDLlenatabla("SELECT d.Tipodepago,sum(d.total)Total FROM VISTATIPOSPAGOS d  WHERE d.TIENDA='" + frmPrincipal.SucursalBase + "' AND d.NOCAJA=" + CAJA.ToString + " AND d.FECHA>=@INI group by d.TIPoDEPAGO", frmPrincipal.CadenaConexion, DTQ.Value, DTQ.Value)
        DGV2.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'Dim DA3 As New SqlClient.SqlDataAdapter("SELECT T.NOMBRE [Tipo de Pago],N.Nota,N.Cajera,N.Total,Forma='Nota'  FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS T  ON n.TIPOPAGO=T.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@FEC ", frmPrincipal.CONX)
        'DA3.SelectCommand.Parameters.Add("@FEC", SqlDbType.DateTime)
        'DA3.SelectCommand.Parameters("@FEC").Value = DTQ.Value
        'Dim DT3 As New DataTable
        'frmPrincipal.CHECACONX()
        'DA3.Fill(DT3)

        If CREDITO = 1 Then
            QUERY = "SELECT T.NOMBRE [Tipo de Pago],N.Nota,N.Cajera,N.Total,Forma='Nota'  FROM NOTASDEVENTA N INNER JOIN TIPOSPAGOS T  ON n.TIPOPAGO=T.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI "
        End If
        If CREDITO = 2 Then
            QUERY = "SELECT [Tipo de Pago]='Crdito',N.Nota,N.Cajera,N.Total,Forma='Crédito'  FROM NOTASDEVENTACREDITO N  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI "
        End If
        If CREDITO = 3 Then
            QUERY = "SELECT T.NOMBRE [Tipo de Pago],N.Nota,N.Cajera,N.Total,Forma='Cobranza'  FROM NOTASCOBRANZAPRO N INNER JOIN TIPOSPAGOS T  ON n.TIPOPAGO=T.CLAVE  WHERE N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + CAJA.ToString + " AND N.FECHA>=@INI "
        End If

        DGV3.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion, DTQ.Value, DTQ.Value)
        DGV3.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV3.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()

        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV2.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()



        Dim SQLREG As New SqlClient.SqlCommand("", frmPrincipal.CONX)
        SQLREG.CommandText = "SELECT SUM(N.TOTAL)TARJETAS FROM NOTASDEVENTA N WHERE N.ESTADO=1 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + NOCAJA.ToString + " AND N.FECHA>=@FEC AND N.TIPOPAGO=2"
        SQLREG.Parameters.Clear()
        SQLREG.Parameters.Add("@FEC", SqlDbType.DateTime)
        SQLREG.Parameters("@FEC").Value = DTQ.Value
        Dim LECREG As SqlClient.SqlDataReader
        LECREG = SQLREG.ExecuteReader
        If LECREG.Read Then
            If LECREG(0) Is DBNull.Value Then
                TARJETAS = 0
            Else
                TARJETAS = LECREG(0)
            End If
        End If
        LECREG.Close()

        SQLREG.CommandText = "SELECT SUM(D.TOTAL)CHEQUES FROM NOTASDEVENTA N INNER JOIN DETALLENOTASDEVENTA D ON N.TIENDA=D.TIENDA AND N.NOTA=D.NOTA INNER JOIN PRODUCTOS P ON D.PRODUCTO=P.CLAVE INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE N.ESTADO=1 AND N.TIENDA='" + frmPrincipal.SucursalBase + "' AND N.NOCAJA=" + NOCAJA.ToString + " AND N.FECHA>=@FEC AND N.TIPOPAGO=3"
        SQLREG.Parameters.Clear()
        SQLREG.Parameters.Add("@FEC", SqlDbType.DateTime)
        SQLREG.Parameters("@FEC").Value = DTQ.Value
        LECREG = SQLREG.ExecuteReader
        If LECREG.Read Then
            If LECREG(0) Is DBNull.Value Then
                CHEQUES = 0
            Else
                CHEQUES = LECREG(0)
            End If
        End If
        LECREG.Close()

        VENTACOSTO()
        CHECATABLA()

        Me.Text = "Total Cobrado en la CAJA # " + CAJA.ToString
        Try
            Me.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CHECATABLA()
        Dim TOTAL As Double
        Dim GT As String
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            TOTAL = TOTAL + DGV.Item(3, X).Value
        Next
        LBLTOT.Text = "$" + TOTAL.ToString
        GT = LBLTOT.Text - LBLCOS.Text
        LBLG.Text = "$" + GT
    End Sub
    Private Sub VENTACOSTO()
        Dim COS As Double

        For X = 0 To DTCOS.Rows.Count - 1
            COS = COS + DTCOS.Rows(X).Item(0)
        Next
        LBLCOS.Text = "$" + COS.ToString
    End Sub
   
    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim XYZ As Short
        XYZ = MessageBox.Show("Deseas realizar el corte X?", "Mensaje", MessageBoxButtons.YesNo)
        If XYZ <> 6 Then
            Exit Sub
        End If

        If Not frmPrincipal.CHECACONX() Then
            Exit Sub
        End If

        Dim FX, FZ, FQ As New DateTimePicker
        Dim SQL2 As New SqlClient.SqlCommand("SELECT FECHAX,FECHAZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL2.ExecuteReader
        If LEC.Read Then
            FX.Value = LEC(0)
            FZ.Value = LEC(1)
        End If
        LEC.Close()

        If FX.Value > FZ.Value Then
            FQ.Value = FX.Value
        Else
            FQ.Value = FZ.Value
        End If

        Dim TOTALENCORTE As Double
        Dim TOTALNOTAS, REGISTRO As Integer
        Try
            Dim Q1 As New SqlClient.SqlCommand("SELECT SUM(TOTAL)TOTAL,COUNT(NOTAS)NOTAS FROM TOTALCORTE WHERE ESTADO=1 AND TIENDA='" + frmPrincipal.SucursalBase + "' AND NOCAJA=" + NOCAJA.ToString + " AND FECHA>=@FEC AND TIPOPAGO=1", frmPrincipal.CONX)
            Q1.Parameters.Add("@FEC", SqlDbType.DateTime)
            Q1.Parameters("@FEC").Value = FQ.Value
            Dim L1 As SqlClient.SqlDataReader
            L1 = Q1.ExecuteReader
            If L1.Read Then
                Dim NE As Double
                If L1(0) Is DBNull.Value Then
                    TOTALENCORTE = 0
                    TOTALNOTAS = 0
                    NE = 0
                Else
                    TOTALENCORTE = L1(0)
                    TOTALNOTAS = L1(1)
                    NE = L1(0)
                End If

                L1.Close()
                Dim Q2 As New SqlClient.SqlCommand("UPDATE CORTES SET EFECTIVO=" + NE.ToString + " WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString, frmPrincipal.CONX)
                Q2.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        '''''''''''''HISTORIAL CORTES'''''''''''''''
        Dim SQLREG As New SqlClient.SqlCommand("SELECT MAX(REGISTRO)REG FROM HISTORIALCORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString + " AND TIPOCORTE='X'", frmPrincipal.CONX)
        Dim LECREG As SqlClient.SqlDataReader
        LECREG = SQLREG.ExecuteReader
        If LECREG.Read Then
            If LECREG(0) Is DBNull.Value Then
                REGISTRO = 0
            Else
                REGISTRO = LECREG(0)
                REGISTRO = REGISTRO + 1
            End If
        End If
        LECREG.Close()

        Dim CZ As Integer
        SQLREG.CommandText = "select CZ FROM CORTES WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString
        LECREG = SQLREG.ExecuteReader
        If LECREG.Read Then
            CZ = LECREG(0)
        End If
        LECREG.Close()

        Dim QUERY As String
        QUERY = "INSERT INTO HISTORIALCORTES (TIENDA,CAJA,CAJERA,TIPOCORTE,NOTAS,TOTAL,FECHA,REGISTRO,EFECTIVO,TARJETAS,CHEQUES,NOCORTE) VALUES ('" + frmPrincipal.SucursalBase + "'," + NOCAJA.ToString + ",'" + NOMCAJERA + "','X'," + TOTALNOTAS.ToString + "," + TOTALENCORTE.ToString + ",GETDATE()," + REGISTRO.ToString + "," + TOTALENCORTE.ToString + "," + TARJETAS.ToString + "," + CHEQUES.ToString + "," + CZ.ToString + ")"
        Dim SQLHC As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        SQLHC.ExecuteNonQuery()

        '''''''''''''''''''''''''''''''''''aki termina historial cortes''''''''''''''''''''''''''''

      
        Dim SQLy As New SqlClient.SqlCommand("UPDATE CORTES SET FECHAX=GETDATE() WHERE TIENDA='" + frmPrincipal.SucursalBase + "' AND CAJA=" + NOCAJA.ToString + " ", frmPrincipal.CONX)
        SQLy.ExecuteNonQuery()

       
        frmPrincipal.CI.Abrir()
        Me.Close()
    End Sub

    Private Sub frmCorteX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CREDITO = 1
        VISTA(NOCAJA, NOMCAJERA)
    End Sub

    Private Sub BTNCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCC.Click
        CREDITO = 2
        VISTA(NOCAJA, NOMCAJERA)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CREDITO = 3
        VISTA(NOCAJA, NOMCAJERA)
    End Sub
End Class
