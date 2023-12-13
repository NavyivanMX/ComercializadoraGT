Public Class frmAjustesComprasRestaurantes
    Dim CLARES, CLAPRO As New List(Of String)
    Dim ELRES As String
    Dim LAORD As Integer
    Dim ELLOTE As String
    Dim LUNI As New List(Of String)
    Private Sub frmAjustesComprasRestaurantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
        ACTIVAR(True)
        BTNGUARDAR.Enabled = False
        BTNELIMINAR.Enabled = False
        OPLlenaComboBox(CBRES, CLARES, "SELECT CLAVE,NOMBRECOMUN FROM TIENDAS WHERE CLAVE<>'PRUEBAS' ORDER BY NOMBRECOMUN", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBPRO, CLAPRO, "SELECT CLAVE,NOMBRE FROM PROVEEDORES WHERE ACTIVO=1 ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
    End Sub
    Private Sub CHECATABLA()
        If DGV.Rows.Count > 0 Then
            BTNBUSCAR.Enabled = True
        Else
            BTNBUSCAR.Enabled = False
            ACTIVAR(True)
            DGV.DataSource = Nothing
            BTNELIMINAR.Enabled = False
            BTNGUARDAR.Enabled = False
            Dim SQL As New SqlClient.SqlCommand("DELETE FROM COMPRAS WHERE TIENDA='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + LAORD.ToString, frmPrincipal.CONX)
            SQL.ExecuteNonQuery()
            LIMPIA()
        End If
    End Sub

    Private Sub ACTIVAR(ByVal V As Boolean)
        CBRES.Enabled = V
        TXTNOORDEN.Enabled = V
        CBPRO.Enabled = Not V
        TXTCON.Enabled = Not V

        'BTNCANCELAR.Enabled = Not V
        BTNBUSCAR.Enabled = Not V
        TXTCANT.Enabled = Not V
        'CBUNI.Enabled = Not V
        TXTCOS.Enabled = Not V
        TXTPRE.Enabled = Not V

        TXTSUB.Enabled = Not V
        TXTIVA.Enabled = Not V
        TXTTOT.Enabled = Not V
        CBUNI.Enabled = Not V
        CBTC.Enabled = Not V
        CHKFIN.Enabled = Not V
        CHKCF.Enabled = Not V
        CHKDOC.Enabled = Not V
    End Sub
    Private Sub LEER(ByVal V As Boolean)
        TXTCANT.Enabled = Not V
        TXTCOS.Enabled = Not V
        TXTPRE.Enabled = Not V
        TXTSUB.Enabled = Not V
        TXTIVA.Enabled = Not V
        TXTTOT.Enabled = Not V
        TXTCON.Enabled = Not V
    End Sub
    'Private Sub CARGAESTADOS(ByVal RES As String, ByVal NOORDEN As Integer)
    '    Dim SQL As New SqlClient.SqlCommand("SELECT ESNOTA,AGREGADOAFACTURA,REPUESTOPORFINANZAS,DOCENTRE FROM COMPRASRESTAURANTES WHERE RESTAURANTE='" + RES + "' AND NOORDEN=" + NOORDEN.ToString, CONZ)
    '    Dim LEC As SqlClient.SqlDataReader
    '    LEC = SQL.ExecuteReader
    '    If LEC.Read Then
    '        Try
    '            CBTC.SelectedIndex = LEC(0)
    '            'CHKF.Checked = Not CType(LEC(0), Boolean)
    '            CHKCF.Checked = CType(LEC(1), Boolean)
    '            CHKDOC.Checked = CType(LEC(3), Boolean)
    '            CHKFIN.Checked = CType(LEC(2), Boolean)
    '        Catch ex As Exception

    '        End Try
    '    End If
    '    LEC.Close()
    'End Sub
    Private Sub CARGADATOS()

        Dim QUERY As String
        QUERY = "SELECT PP.NOMBRE,D.PRODUCTO LOTE,P.NOMBRE PRODUCTO,P.DESCRIPCION,D.CANTIDAD,U.NOMBRE UNIDAD,(SELECT DBO.REGRESATOTALPRECIO(D.PRODUCTO,D.CANTIDAD,D.UNIDAD))TOTAL,C.FECHA  FROM COMPRAS C INNER JOIN DETALLECOMPRAS D  ON C.TIENDA=D.TIENDA AND C.NOORDEN=D.NOORDEN INNER JOIN LOTES L  ON D.PRODUCTO=L.CLAVE INNER JOIN PRODUCTOS P  ON L.PRODUCTO=P.CP INNER JOIN UNIDADES U  ON D.UNIDAD=U.CLAVE INNER JOIN PROVEEDORES PP ON PP.CLAVE=C.PROVEEDOR WHERE C.TIENDA='" + CLARES(CBRES.SelectedIndex) + "'"
        '' esta seccion se le quiteo a la consulta 19102010
        ''AND C.FECHA >=GETDATE()-30 "

        If TXTNOORDEN.Text <> "" Then
            LAORD = CType(TXTNOORDEN.Text, Integer)
            QUERY = QUERY + "AND C.NOORDEN=" + TXTNOORDEN.Text
        End If

        Dim DA As New SqlClient.SqlDataAdapter(QUERY, frmPrincipal.CONX)
        DA.SelectCommand.CommandTimeout = 300
        Dim DT As New DataTable
        DA.Fill(DT)
        DGV.DataSource = DT
        DGV.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        ELRES = CLARES(CBRES.SelectedIndex)
        'BTNBUSCAR.Enabled = True

        If DGV.RowCount <> 0 Then
            CARGADETALLES()
        End If
    End Sub
    Private Sub CARGADETALLES()
        Dim UNI As String
        UNI = ""
        ELLOTE = DGV.Item(1, DGV.CurrentRow.Index).Value.ToString
        Dim QUERY As String
        QUERY = "SELECT DT.NOORDEN ,D.CANTIDAD,D.UNIDAD,L.COSTOU,L.PRECIOU,(SELECT DBO.TOTALUNIDADMINIMATIENDA(D.PRODUCTO,D.CANTIDAD,D.UNIDAD))TUM,I.CANTIDAD INVENTARIO ,DT.IVA,DT.SUBTOTAL,DT.TOTAL,DT.PROVEEDOR, DT.AGREGADOAFACTURA ,DT.ESNOTA,DT.FECHA,DT.REPUESTOFINANZAS  FROM DETALLECOMPRAS D INNER JOIN COMPRAS  DT  ON DT.TIENDA=D.TIENDA AND DT.NOORDEN=D.NOORDEN INNER JOIN LOTES L  ON D.PRODUCTO=L.CLAVE LEFT JOIN INVPISOTIENDA I  ON D.PRODUCTO=I.PRODUCTO AND D.TIENDA=I.TIENDA INNER JOIN UNIDADES U ON D.UNIDAD=U.CLAVE INNER JOIN COMPRAS C ON C.NOORDEN=D.NOORDEN AND D.TIENDA=C.TIENDA INNER JOIN PROVEEDORES PP ON PP.CLAVE=C.PROVEEDOR  WHERE  D.TIENDA= '" + ELRES + "' AND D.PRODUCTO='" + ELLOTE + "'  "
        ''SE LE KITO ESTA PARTE A LA CONSULTA
        ''DT.FECHA >=GETDATE()-30 AND
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader

        If LEC.Read Then
            TXTCANT.Text = LEC(1)
            UNI = LEC(2)
            TXTCOS.Text = LEC(3)
            TXTPRE.Text = LEC(4)
            TXTTUM.Text = LEC(5)
            If LEC(5) Is DBNull.Value Then
                TXTEXIS.Text = "0"
            Else
                TXTEXIS.Text = LEC(6).ToString
            End If
            TXTSUB.Text = LEC(8)
            TXTIVA.Text = LEC(7).ToString
            TXTTOT.Text = LEC(9)
            REGRESA(LEC(10))

            'If (LEC(11) = True And LEC(14) = False) Or (LEC(12) = True And LEC(11) = True) Then
            '    LEER(True)
            '    BTNGUARDAR.Enabled = False
            '    BTNELIMINAR.Enabled = False
            'Else
            LEER(False)
            BTNGUARDAR.Enabled = True
            BTNELIMINAR.Enabled = True
            'End If
        End If
        LEC.Close()
        ACTIVAR(False)
        CARGAUNIDADES(ELLOTE, UNI)
    End Sub
    Private Sub CARGAUNIDADES(ByVal LOTE As String, ByVal UNI As String)
        Dim QUERY As String
        QUERY = "SELECT E.UNIDAD,U.NOMBRE FROM LOTES L INNER JOIN EQUIVALENCIAS E ON L.PRODUCTO=E.PRODUCTO INNER JOIN UNIDADES U ON E.UNIDAD=U.CLAVE WHERE L.CLAVE='" + LOTE + "'"
        Dim SQL As New SqlClient.SqlCommand(QUERY, frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        LUNI.Clear()
        CBUNI.Items.Clear()
        While LEC.Read
            LUNI.Add(LEC(0))
            CBUNI.Items.Add(LEC(1))
        End While
        LEC.Close()
        Dim X As Integer
        Try
            For X = 0 To LUNI.Count - 1
                If LUNI(X) = UNI Then
                    CBUNI.SelectedIndex = X
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TXTNOORDEN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNOORDEN.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Chr(13) Then
            If TXTNOORDEN.Text = "" Then
            Else
                CARGADATOS()
            End If
        End If
    End Sub
    Private Sub BTNCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCANCELAR.Click
        ACTIVAR(True)
        LEER(False)
        LIMPIA()
        BTNELIMINAR.Enabled = False
        BTNGUARDAR.Enabled = False
    End Sub
    Private Sub BTNBUSCAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNBUSCAR.Click
        CARGADATOS()
    End Sub

    Private Sub BTNELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNELIMINAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("¿Desea Eliminar la Compra de la Tienda?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        Dim xx As Integer
        For xx = 0 To DGV.Rows.Count - 1
            guardahistorial(CLARES(CBRES.SelectedIndex), TXTNOORDEN.Text, DGV.Item(0, xx).Value.ToString, "E", CType(DGV.Item(4, DGV.CurrentRow.Index).Value.ToString, Double))
        Next
        Dim SQL As New SqlClient.SqlCommand("DELETE FROM COMPRAS WHERE TIENDA='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + LAORD.ToString, frmPrincipal.CONX)
        SQL.ExecuteNonQuery()
        ' SQL.CommandText = "DELETE FROM DETALLECOMPRASRESTAURANTES WHERE RESTAURANTE='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + LAORD.ToString
        SQL.ExecuteNonQuery()
        ACTIVAR(True)
        DGV.DataSource = Nothing
        CHECATABLA()
        BTNELIMINAR.Enabled = False
        BTNGUARDAR.Enabled = False
    End Sub

    'Private Sub BTNQUITAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim xyz As Short
    '    xyz = MessageBox.Show("�Desea Eliminar El Registro de la Compra de la Tienda?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '    If xyz <> 6 Then
    '        Exit Sub
    '    End If
    '    guardahistorial(CLARES(CBRES.SelectedIndex), TXTNOORDEN.Text, ELLOTE, "E", CType(DGV.Item(4, DGV.CurrentRow.Index).Value.ToString, Double))
    '    Dim SQL As New SqlClient.SqlCommand("", frmPrincipal.CONX)
    '    SQL.CommandText = "DELETE FROM DETALLECOMPRASRESTAURANTES WHERE RESTAURANTE='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + LAORD.ToString + " and LOTE='" + DGV.Item(1, DGV.CurrentRow.Index).Value.ToString + "'"
    '    SQL.ExecuteNonQuery()
    '    CARGADATOS()
    '    DGV.Refresh()
    '    CHECATABLA()


    'End Sub
    Private Sub GUARDAR()
        guardahistorial(CLARES(CBRES.SelectedIndex), TXTNOORDEN.Text, ELLOTE, "A", CType(DGV.Item(4, DGV.CurrentRow.Index).Value.ToString, Double))
        Dim SQL As New SqlClient.SqlCommand("UPDATE DETALLECOMPRAS SET CANTIDAD=" + TXTCANT.Text + ", UNIDAD='" + LUNI(CBUNI.SelectedIndex) + "' WHERE TIENDA='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + TXTNOORDEN.Text + " AND PRODUCTO='" + ELLOTE + "'", frmPrincipal.CONX)
        SQL.CommandTimeout = 300
        SQL.ExecuteNonQuery()
        SQL.CommandText = "UPDATE LOTES SET COSTOU=" + TXTCOS.Text + " ,PRECIOU=" + TXTPRE.Text + " WHERE CLAVE='" + ELLOTE + "'"
        SQL.ExecuteNonQuery()
        SQL.CommandText = "UPDATE  DETALLECOMPRAS SET TOTAL=(SELECT DBO.REGRESATOTALPRECIO(PRODUCTO,CANTIDAD,UNIDAD)) WHERE TIENDA='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN=" + TXTNOORDEN.Text
        SQL.ExecuteNonQuery()
        SQL.CommandText = "UPDATE  COMPRAS SET SUBTOTAL='" + TXTSUB.Text + "',IVA='" + TXTIVA.Text + "',TOTAL='" + TXTTOT.Text + "',CONCEPTO='" + TXTCON.Text + "',PROVEEDOR='" + CLAPRO(CBPRO.SelectedIndex) + "' WHERE TIENDA='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN= '" + TXTNOORDEN.Text + "'"
        SQL.ExecuteNonQuery()
        'Dim abc As String
        'abc = "UPDATE  COMPRASRESTAURANTES SET REPUESTOPORFINANZAS='" + CHKFIN.Checked.ToString + "',"
        'abc += "ESNOTA='" + (Not CHKF.Checked).ToString + "',"
        'abc += "AGREGADOAFACTURA='" + CHKCF.Checked.ToString + "', "
        'abc += "DOCENTRE='" + CHKDOC.Checked.ToString + "'  WHERE RESTAURANTE='" + CLARES(CBRES.SelectedIndex) + "' "
        'abc += "AND NOORDEN= '" + TXTNOORDEN.Text + "'"
        'SQL.CommandText = "UPDATE  COMPRASRESTAURANTES SET REPUESTOPORFINANZAS='" + CHKFIN.Checked.ToString + "',ESNOTA='" + CBTC.SelectedIndex.ToString + "',AGREGADOAFACTURA='" + CHKCF.Checked.ToString + "', DOCENTRE='" + CHKDOC.Checked.ToString + "'  WHERE RESTAURANTE='" + CLARES(CBRES.SelectedIndex) + "' AND NOORDEN= '" + TXTNOORDEN.Text + "' "
        'SQL.ExecuteNonQuery()
        MessageBox.Show("La Informacin Ha Sido Guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        ACTIVAR(True)
        DGV.DataSource = Nothing

    End Sub

    Private Sub BTNGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGUARDAR.Click
        Dim xyz As Short
        xyz = MessageBox.Show("Desea Guardar la Información?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Sub
        End If
        GUARDAR()
        LIMPIA()
        ACTIVAR(True)
        BTNELIMINAR.Enabled = False
        BTNGUARDAR.Enabled = False
    End Sub
    'Public Function REGRESAX(ByVal LISTA As Object, ByVal CB As Object, ByVal VB As String, ByVal N As Integer) As String
    '    Dim Y As Integer
    '    If N = 0 Then     'BUSQUEDA DE CLAVE'
    '        For Y = 0 To CB.ITEMS.COUNT - 1
    '            CB.SELECTEDINDEX = Y
    '            If CB.TEXT = VB Then
    '                Return LISTA(Y)
    '            End If
    '        Next
    '    Else
    '        For Y = 0 To LISTA.COUNT - 1 'BUSCA NOMBRE'
    '            If LISTA(Y) = VB Then
    '                CB.SELECTEDINDEX = Y
    '                Return CB.TEXT
    '            End If
    '        Next
    '    End If
    '    Return ""
    'End Function
    Private Sub REGRESA(ByVal CPRO As String)
        Dim X As Integer
        For X = 0 To CBPRO.Items.Count - 1
            If CLAPRO(X) = CPRO Then
                CBPRO.SelectedIndex = X
            End If
        Next
    End Sub
    Private Sub LIMPIA()
        DGV.DataSource = Nothing
        TXTNOORDEN.Text = ""
        TXTCANT.Text = ""
        TXTCOS.Text = ""
        TXTPRE.Text = ""
        TXTTUM.Text = ""
        TXTEXIS.Text = ""
        TXTEXIS.Text = ""
        TXTSUB.Text = ""
        TXTIVA.Text = ""
        TXTTOT.Text = ""
        TXTCON.Text = ""

    End Sub
    Private Sub DGV_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        CARGADETALLES()
    End Sub
    Private Sub guardahistorial(ByVal restaurante As String, ByVal noorden As Integer, ByVal lote As String, ByVal tipo As String, ByVal cant As Double)
        Dim SQL As New SqlClient.SqlCommand("hisajustecomprasrestaurantes", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@res", SqlDbType.VarChar).Value = restaurante
        SQL.Parameters.Add("@orden", SqlDbType.Int).Value = noorden
        SQL.Parameters.Add("@lote", SqlDbType.VarChar).Value = lote
        SQL.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo
        SQL.Parameters.Add("@cant", SqlDbType.Float).Value = cant
        SQL.ExecuteNonQuery()
    End Sub
    Private Sub TXTCANT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCANT.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub

    Private Sub TXTCOS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOS.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub


    Private Sub TXTPRE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPRE.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub
    Private Sub TXTSUB_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTSUB.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub

    Private Sub TXTIVA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTIVA.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub

    Private Sub TXTTOT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOT.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False

        End If
    End Sub
End Class