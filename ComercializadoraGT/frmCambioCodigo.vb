Public Class frmCambioCodigo
    Dim PN, PA As Boolean
    Private Sub frmCambioCodigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Private Sub CARGADATOS(ByVal A As Boolean)
        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim COD As String
        If A Then
            PA = False
            COD = TXTCLA.Text
        Else
            PN = False
            COD = TXTCLN.Text
        End If
        Dim SQL As New SqlClient.SqlCommand("SELECT NOMBRE,PRECIO FROM PRODUCTOS WHERE CLAVE='" + COD + "'", frmPrincipal.CONX)
        Dim LEC As SqlClient.SqlDataReader
        LEC = SQL.ExecuteReader
        If LEC.Read Then
            If A Then
                LBLNPA.Text = LEC(0)
                LBLPPA.Text = LEC(1)
                PA = True
            Else
                LBLNPN.Text = LEC(0)
                LBLPPN.Text = LEC(1)
                PN = True
            End If
        End If
        LEC.Close()
        SQL.Dispose()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1  ", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de Artículos", "Nombre o Descripción del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLA.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            LBLNPA.Text = frmClsBusqueda.TREG.Rows(0).Item(1)
            LBLPPA.Text = frmClsBusqueda.TREG.Rows(0).Item(2)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmClsBusqueda.BUSCAR("SELECT P.CLAVE CLAVE,P.NOMBRE,P.DESCRIPCION,G.NOMBRE GRUPO,P.PRECIO,P.ACTIVO FROM PRODUCTOS P INNER JOIN GRUPOS G ON P.GRUPO=G.CLAVE WHERE P.EMPRESA=" + frmPrincipal.Empresa + "  AND P.ACTIVO=1  ", " AND P.NOMBRE", " ORDER BY P.NOMBRE", "Búsqueda de Artículos", "Nombre o Descripción del Producto", "Producto(s)", 1, frmPrincipal.CadenaConexion, False)
        If frmClsBusqueda.DialogResult = Windows.Forms.DialogResult.Yes Then
            TXTCLN.Text = frmClsBusqueda.TREG.Rows(0).Item(0)
            LBLNPN.Text = frmClsBusqueda.TREG.Rows(0).Item(1)
            LBLPPN.Text = frmClsBusqueda.TREG.Rows(0).Item(2)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TXTCLN.Text) Or String.IsNullOrEmpty(TXTCLA.Text) Then
            MessageBox.Show("Debe escribir/buscar los códigos a intercambiar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        CARGADATOS(True)
        CARGADATOS(False)
        If Not PN Then
            Dim xyz As String
            xyz = MessageBox.Show("Se Creará un Código Nuevo, ¿Desea continuar?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If xyz <> 6 Then
                Exit Sub
            End If
        End If

        If Not frmPrincipal.CHECACONX Then
            Exit Sub
        End If
        Dim SQL As New SqlClient.SqlCommand("SPCAMBIOPRODUCTO", frmPrincipal.CONX)
        SQL.CommandType = CommandType.StoredProcedure
        SQL.CommandTimeout = 300
        SQL.Parameters.Add("@PO", SqlDbType.VarChar).Value = TXTCLA.Text
        SQL.Parameters.Add("@PD", SqlDbType.VarChar).Value = TXTCLN.Text
        SQL.Parameters.Add("@USU", SqlDbType.VarChar).Value = frmPrincipal.Usuario
        SQL.ExecuteNonQuery()
    End Sub

    Private Sub TXTCLA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLA.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLA.Text = "" Then
            Else
                CARGADATOS(True)
            End If
        End If
    End Sub

    Private Sub TXTCLN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCLN.KeyPress
        If e.KeyChar = Chr(13) Then
            If TXTCLN.Text = "" Then
            Else
                CARGADATOS(False)
            End If
        End If
    End Sub
End Class