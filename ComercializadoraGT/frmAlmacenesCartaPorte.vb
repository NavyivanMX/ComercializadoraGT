Public Class frmAlmacenesCartaPorte
    Dim LALM As New List(Of String)
    Dim LEDO As New List(Of String)
    Private Sub frmAlmacenesCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        OPLlenaComboBox(CBALM, LALM, "select CLAVE,NOMBRECOMUN from TIENDAS where ACTIVO=1", frmPrincipal.CadenaConexion)
        OPLlenaComboBox(CBEDO, LEDO, "SELECT CLAVE,CLAVE+ ' - '+ NOMBRE  FROM ESTADOS where PAIS='mex'", frmPrincipal.CadenaConexionFE)
    End Sub
    Private Sub LIMPIAR()
        TXTRFC.Text = ""
        TXTUBI.Text = ""
        TXTRESP.Text = ""
        TXTTRI.Text = ""
        TXTRES.Text = ""
        TXTCALLE.Text = ""
        TXTNOEXT.Text = ""
        TXTNOINT.Text = ""
        TXTCOL.Text = ""
        TXTLOC.Text = ""
        TXTREF.Text = ""
        TXTMUN.Text = ""

        TXTPAIS.Text = "MEX - México"
        TXTCP.Text = ""
    End Sub
    Private Sub CARGADATOS()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        LIMPIAR()
        Dim SQL As New SqlClient.SqlCommand("SELECT RFC,IDUBICACION,RESPONSABLE,NUMREGIDTRIB,RESIDENCIAFISCAL,CALLE,NOEXT,NOINT,COLONIA,LOCALIDAD,REFERENCIA,MUNICIPIO,ESTADO,PAIS,CP FROM INFOALMACENESCARTAPORTE WHERE ALMACEN='" + LALM(CBALM.SelectedIndex) + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            TXTRFC.Text = LEC(0)
            TXTUBI.Text = LEC(1)
            TXTRESP.Text = LEC(2)
            TXTTRI.Text = LEC(3)
            TXTRES.Text = LEC(4)
            TXTCALLE.Text = LEC(5)
            TXTNOEXT.Text = LEC(6)
            TXTNOINT.Text = LEC(7)
            TXTCOL.Text = LEC(8)
            TXTLOC.Text = LEC(9)
            TXTREF.Text = LEC(10)
            TXTMUN.Text = LEC(11)
            OPCargaX(LEDO, CBEDO, LEC(12))
            TXTCP.Text = LEC(14)

        End If
        LEC.Close()
        SQL.Dispose()
    End Sub

    Private Sub CBALM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBALM.SelectedIndexChanged
        CARGADATOS()
    End Sub

    Private Sub BTNINFO_Click(sender As Object, e As EventArgs) Handles BTNINFO.Click
        frmInfo.Mostrar("Información llenado Almacenes Carta Porte", "Especificaciones:", "- Opciones marcadas con * son requeridas cuando el traslado es por autotransporte " + Chr(13) + " - Es requerido cuando algun almacen origen o destino es fuera del pais " + Chr(13) + "")
    End Sub
    Private Sub GUARDAR()
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPINFOALMACENESCARTAPORTE", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.Parameters.Add("@ALM", SqlDbType.VarChar).Value = LALM(CBALM.SelectedIndex)

        SQL.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TXTRFC.Text
        SQL.Parameters.Add("@IDU", SqlDbType.VarChar).Value = TXTUBI.Text
        SQL.Parameters.Add("@RESP", SqlDbType.VarChar).Value = TXTRESP.Text
        SQL.Parameters.Add("@TRI", SqlDbType.VarChar).Value = TXTTRI.Text
        SQL.Parameters.Add("@RES", SqlDbType.VarChar).Value = TXTRES.Text
        SQL.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TXTCALLE.Text
        SQL.Parameters.Add("@NOEXT", SqlDbType.VarChar).Value = TXTNOEXT.Text
        SQL.Parameters.Add("@NOINT", SqlDbType.VarChar).Value = TXTNOINT.Text
        SQL.Parameters.Add("@COL", SqlDbType.VarChar).Value = TXTCOL.Text
        SQL.Parameters.Add("@LOC", SqlDbType.VarChar).Value = TXTLOC.Text
        SQL.Parameters.Add("@REF", SqlDbType.VarChar).Value = TXTREF.Text
        SQL.Parameters.Add("@MUN", SqlDbType.VarChar).Value = TXTMUN.Text
        SQL.Parameters.Add("@EST", SqlDbType.VarChar).Value = LEDO(CBEDO.SelectedIndex)
        SQL.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = "MEX"
        SQL.Parameters.Add("@CP", SqlDbType.VarChar).Value = TXTCP.Text
        SQL.ExecuteNonQuery()
        OPMsgGuardadoOK()
    End Sub

    Private Sub BTNGUARDAR_Click(sender As Object, e As EventArgs) Handles BTNGUARDAR.Click
        GUARDAR()
    End Sub
End Class