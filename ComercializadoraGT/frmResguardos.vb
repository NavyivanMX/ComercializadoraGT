﻿Public Class frmResguardos
    Dim CAJA As Integer
    Dim CAJERA As Integer
    Dim NOMCAJERA As String
    Dim AVOLANTE As Boolean
    Private Sub frmResguardos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal VCAJA As Integer, ByVal VCAJERA As Integer, ByVal VNOMCAJERA As String, ByVal VAVOLOANTE As Boolean)
        CAJA = VCAJA
        CAJERA = VCAJERA
        NOMCAJERA = VNOMCAJERA
        TXTCANT.Text = "0"
        AVOLANTE = VAVOLOANTE
        Label13.Visible = AVOLANTE
        TXTCANT.Visible = AVOLANTE
        LBLCAJA.Text = CAJA.ToString
        LBLNOM.Text = NOMCAJERA
        LBLRD.Text = CARGASIGRESGUARDO.ToString
        CARGADATOS()
        Me.ShowDialog()
    End Sub
    Private Sub CARGADATOS()
        Dim QUERY As String
        QUERY = "select CLAVE REGISTRO,CANTIDAD=0,NOMBRE NOMINACION,IMPORTE=0.00,VALOR FROM NOMINACIONES ORDER BY VALOR DESC"
        DGV.DataSource = BDLlenatabla(QUERY, frmPrincipal.CadenaConexion)
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).Visible = False
        DGV.Columns(0).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
    End Sub
    Private Sub CHECATABLA()
        Dim X As Integer
        Dim TOT As Double
        For X = 0 To DGV.Rows.Count - 1
            TOT += DGV.Item(3, X).Value
        Next
        LBLTOT.Text = FormatNumber(TOT, 2).ToString
    End Sub
    Private Function CARGASIGRESGUARDO() As Integer
        If Not frmPrincipal.CHECACONX Then
            Return 1
        End If
        Dim REG As Integer
        REG = 1
        Dim SQL As New SqlClient.SqlCommand("SELECT DBO.SIGRESGUARDO('" + frmPrincipal.SucursalBase + "'," + CAJA.ToString + ")", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            REG = LEC(0)
        End If
        LEC.Close()
        SQL.Dispose()
        Return REG
    End Function

    Private Sub DGV_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim X As Integer
        For X = 0 To DGV.Rows.Count - 1
            DGV.Item(3, X).Value = DGV.Item(1, X).Value * DGV.Item(4, X).Value
        Next
        CHECATABLA()
    End Sub
    Private Sub GUARDAR()
        If frmPrincipal.RESGUARDO Then
            frmAutorizacionCredito.mostrar(1, "Autorización Resguardo")
            If frmAutorizacionCredito.DialogResult = Windows.Forms.DialogResult.Yes Then

            Else
                Exit Sub
            End If
        End If
 
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If


        Dim SR As Integer
        SR = CARGASIGRESGUARDO()
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO RESGUARDOS (TIENDA,FECHA,RESGUARDO,NOCAJA,CAJERA,NOMINACION,CANTIDAD,IMPORTE) VALUES (@TI,@FEC,@RES,@NOC,@CAJ,@NOM,@CANT,@IMP)", frmPrincipal.CONX)
        SQL.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        SQL.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        SQL.Parameters.Add("@RES", SqlDbType.Int).Value = SR
        SQL.Parameters.Add("@NOC", SqlDbType.Int).Value = CAJA
        SQL.Parameters.Add("@CAJ", SqlDbType.VarChar).Value = CAJERA
        SQL.Parameters.Add("@NOM", SqlDbType.Int)
        SQL.Parameters.Add("@CANT", SqlDbType.Int)
        SQL.Parameters.Add("@IMP", SqlDbType.Float)
        For X = 0 To DGV.Rows.Count - 1
            If DGV.Item(1, X).Value < 1 Then
            Else
                SQL.Parameters("@NOM").Value = DGV.Item(0, X).Value
                SQL.Parameters("@CANT").Value = DGV.Item(1, X).Value
                SQL.Parameters("@IMP").Value = DGV.Item(3, X).Value
                SQL.ExecuteNonQuery()
            End If
        Next
        frmPrincipal.VentaSinResguardo = 0
        'Dim VOL As Integer
        'Dim VG As Boolean = False        
        'Try

        '    VOL = CType(TXTCANT.Text, Integer)
        '    Dim SQLV As New SqlClient.SqlCommand("INSERT INTO RESGUARDOSVOLANTES (TIENDA,FECHA,RESGUARDO,NOCAJA,CAJERA,VOLANTES) VALUES (@TI,@FEC,@RES,@NOC,@CAJ,@CANT)", frmPrincipal.CONX)
        '    SQLV.Parameters.Add("@TI", SqlDbType.VarChar).Value = frmPrincipal.SucursalBase
        '    SQLV.Parameters.Add("@FEC", SqlDbType.DateTime).Value = DTDE.Value.Date
        '    SQLV.Parameters.Add("@RES", SqlDbType.Int).Value = SR
        '    SQLV.Parameters.Add("@NOC", SqlDbType.Int).Value = CAJA
        '    SQLV.Parameters.Add("@CAJ", SqlDbType.VarChar).Value = CAJERA
        '    SQLV.Parameters.Add("@CANT", SqlDbType.Int).Value = VOL
        '    SQLV.ExecuteNonQuery()
        '    If VOL > 0 Then
        '        VG = True
        '    End If



        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try


        Dim REP As New rptResguardos
        IMPRIMIRREPORTE(REP, BDLlenatabla(" SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOS R INNER JOIN tiendas T ON R.TIENDA=T.CLAVE INNER JOIN empleados E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        Dim REP2 As New rptResguardos
        IMPRIMIRREPORTE(REP2, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOS R INNER JOIN tiendas T ON R.TIENDA=T.CLAVE INNER JOIN empleados E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        'If VG Then
        '    Dim REP3 As New rptResguardoVolantes
        '    IMPRIMIRREPORTE(REP3, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.VOLANTES FROM RESGUARDOSVOLANTES R INNER JOIN TIENDAS T ON R.TIENDA=T.CLAVE INNER JOIN EMPLEADOSTIENDAS E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE  WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        '    Dim REP4 As New rptResguardoVolantes
        '    IMPRIMIRREPORTE(REP4, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.VOLANTES FROM RESGUARDOSVOLANTES R INNER JOIN TIENDAS T ON R.TIENDA=T.CLAVE INNER JOIN EMPLEADOSTIENDAS E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE  WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        'End If
        LBLRD.Text = CARGASIGRESGUARDO.ToString
        CARGADATOS()
        MessageBox.Show("La información ha sido Guardada Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Me.Close()
    End Sub
    Private Sub BTNIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNIMPRIMIR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SR As Integer
        SR = 2
        'If frmPrincipal.TipoTienda = 1 Then
        Dim REP As New rptResguardos
        IMPRIMIRREPORTE(REP, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOS R INNER JOIN tiendas T ON R.TIENDA=T.CLAVE INNER JOIN empleados E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        Dim REP2 As New rptResguardos
        IMPRIMIRREPORTE(REP2, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOS R INNER JOIN tiendas T ON R.TIENDA=T.CLAVE INNER JOIN empleados E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")


        'Else
        '    Dim REP As New rptResguardosC8
        '    IMPRIMIRREPORTE(REP, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOSPRO R INNER JOIN TIENDASPRO T ON R.TIENDA=T.CLAVE INNER JOIN EMPLEADOSTIENDASPRO E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")
        '    Dim REP2 As New rptResguardosC8
        '    IMPRIMIRREPORTE(REP2, BDLlenatabla("SELECT T.NOMBREFISCAL,T.DIRECCION,T.CIUDAD,T.RFC,R.FECHAREG FECHA,R.FECHAREG HORA,R.CAJERA,E.NOMBRE NOMCAJERA,R.NOCAJA,R.RESGUARDO,R.CANTIDAD,N.NOMBRE DENOMINACION,R.IMPORTE FROM RESGUARDOSPRO R INNER JOIN TIENDASPRO T ON R.TIENDA=T.CLAVE INNER JOIN EMPLEADOSTIENDASPRO E ON R.TIENDA=E.TIENDA AND R.CAJERA=E.CLAVE INNER JOIN NOMINACIONES N ON R.NOMINACION=N.CLAVE WHERE R.TIENDA='" + frmPrincipal.SucursalBase + "' AND R.FECHA=@INI AND R.NOCAJA=" + CAJA.ToString + " AND R.RESGUARDO=" + SR.ToString, frmPrincipal.CadenaConexion, DTDE.Value.Date, DTDE.Value.Date), 1, "")

        'End If

    End Sub
End Class