Public Class frmEntradaTraspaso
    Dim DT As New DataTable
    Dim ACEPTADO As Boolean
    Dim RENGLON As Integer
    Dim NOMOV As Integer
    Private Sub frmEntradaTraspaso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        CARGADATOS()
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim DA As New SqlClient.SqlDataAdapter("SELECT D.NOTRASPASO [NO TRAS],P.NOMBRE PRODUCTO,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,D.RECIBIDO,R.NOMBRECOMUN ORIGEN,D.REGISTRO FROM TRASPASOS D INNER JOIN PRODUCTOS P  ON P.CP=D.PRODUCTO  INNER JOIN UNIDADES U  ON U.CLAVE=D.UNIDAD INNER JOIN TIENDAS R ON R.CLAVE=D.ORIGEN  WHERE D.DESTINO='" + frmPrincipal.SucursalBase + "' AND D.ACEPTADO=1 AND D.RECIBIDO=0", frmPrincipal.CONX)
        DT.Rows.Clear()
        DT.Columns.Clear()
        DA.Fill(DT)
        DGV.DataSource = DT

        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(2).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(4).ReadOnly = True
        DGV.Columns(6).ReadOnly = True
        DGV.Columns(7).ReadOnly = True


        'CHECATABLA()
        DGV.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DGV.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
    Private Sub CHECATABLA()
        If DT.Rows.Count <= 0 Then
            BTNGUARDAR.Enabled = False
        Else
            BTNGUARDAR.Enabled = True
        End If
    End Sub
    Private Function CHECASELECCION() As Boolean
        'Dim X As Integer
        'For X = 0 To DGV.Rows.Count - 1
        '    If (DGV.Item(5, X).Value = True And DGV.Item(6, X).Value = True) Then
        '        MessageBox.Show("Debe seleccionar solo una opción Recibido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '        Return False
        '    End If
        'Next
        Return True
    End Function
    Private Function GUARDAR2(ByVal REN As Integer) As Boolean
        If Not frmPrincipal.CHECACONX() Then
            Return False
        End If

        Dim X As Integer

        Dim SQLGUARDA As New SqlClient.SqlCommand("", frmPrincipal.CONX)
        For X = REN To DGV.Rows.Count - 1
            If DGV.Item(5, X).Value = True Then
                SQLGUARDA.CommandText = "UPDATE TRASPASOS SET RECIBIDO=1, FECHAENTE=GETDATE(),USUARIORECIBE='" + frmPrincipal.Usuario + "' WHERE NOTRASPASO=" + DGV.Item(0, X).Value.ToString + " AND REGISTRO=" + DGV(7, X).Value.ToString + ""
                SQLGUARDA.ExecuteNonQuery()
                ' GUARDAMOVIMIENTO(X)
                ACEPTADO = True
            End If
        Next

        MessageBox.Show("El traspaso se ha guardado con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Return True
    End Function
    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        If Not CHECASELECCION() Then
            Exit Sub
        End If
        Dim xyz As Short
        xyz = MessageBox.Show("Desea guardar la información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz = 6 Then
            RENGLON = 0
            ACEPTADO = False
            While Not GUARDAR2(RENGLON)
            End While
            If ACEPTADO Then
                'Dim REP As New RepDecomiso
                'Dim CI As New clsImprimir
                'CI.IMPRIMIR1(REP, "SELECT C.NODECOMISO,R.NOMBRECOMUN ORIGEN,LR.NOMBRECOMUN DESTINO,P.NOMBRE PRODUCTO,C.CANTIDAD,U.NOMBRE UNIDAD,c.FECHADECOM FROM DECOMISOS C INNER JOIN RESTAURANTES R ON C.ORIGEN=R.CLAVE INNER JOIN LOSRESTAURANTES LR ON C.DESTINO=LR.CLAVE INNER JOIN PRODUCTOS P ON C.PRODUCTO=P.CLAVE AND C.GRUPO=P.GRUPO INNER JOIN UNIDADES U ON C.UNIDAD=U.CLAVE WHERE C.ORIGEN='" + frmPrincipal.SucursalBase + "' AND C.ACEPTADO=1 AND C.FECHASUC>=GETDATE() ORDER BY P.NOMBRE", 3, frmPrincipal.CadenaConexion, LPARA, LTIPO, LVALO)
                frmPrincipal.CHECATRASDECO()
            End If
            CARGADATOS()
        End If
    End Sub
End Class