Public Class frmConversorHuevos
    Private OPC As Integer
    Private Sub frmConversorHuevos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
        OPVisualizacionForm(Me)
        LLAMAOPCION()
    End Sub

    Private Sub LLAMAOPCION()
        Dim VNV As New frmSeleccionConversion
        VNV.ShowDialog()
        If VNV.DialogResult = Windows.Forms.DialogResult.Yes Then
            OPC = VNV.OPC
            CARGADATOS(OPC)
        Else
            Me.Close()
        End If
    End Sub
    Private Sub CARGADATOS(ByVal OPC As Integer)
        If OPC > 2 Or OPC < 1 Then
            Exit Sub
        End If
        If OPC = 1 Then 'cajas piezas
            LBLKGPZ.Text = "Piezas"
            DGV2.DataSource = BDLlenatabla("select * FROM VCONVERSORHUEVOSOUTPUTPIEZAS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        End If
        If OPC = 2 Then 'cajas kilos
            LBLKGPZ.Text = "Kilos"
            DGV2.DataSource = BDLlenatabla("select * FROM VCONVERSORHUEVOSOUTPUTKILOS WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        End If

        DGV.DataSource = BDLlenatabla("select * FROM VCONVERSORHUEVOSINPUT WHERE TIENDA='" + frmPrincipal.SucursalBase + "' ORDER BY NOMBRE", frmPrincipal.CadenaConexion)
        DGV.Columns(7).Visible = False
        DGV.Columns(6).Visible = False

        DGV2.Columns(4).Visible = False
        DGV2.Columns(3).Visible = False

        DGV2.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV2.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()

        DGV.Columns(1).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(2).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(3).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(4).DefaultCellStyle = DgvCellFormatoNumerico()
        DGV.Columns(5).DefaultCellStyle = DgvCellFormatoNumerico()


        DGV.Columns(0).ReadOnly = True
        DGV.Columns(1).ReadOnly = True
        DGV.Columns(3).ReadOnly = True
        DGV.Columns(4).ReadOnly = True
        DGV.Columns(5).ReadOnly = True

        DGV2.Columns(0).ReadOnly = True
        DGV2.Columns(1).ReadOnly = True

        DgvAjusteEncabezado(DGV, 0)
        DgvAjusteEncabezado(DGV2, 0)
    End Sub

    Private Sub BTNVTA_Click(sender As Object, e As EventArgs) Handles BTNVTA.Click
        If Not Validar() Then
            Exit Sub
        End If
        ''TODO: implementar E/S y Kardex
    End Sub
    Private Function Validar() As Boolean
        Dim X As Integer
        Dim ConvertirSeleccionado, DestinoSeleccionado As Boolean
        Dim TotalKilosSeleccionados As Double
        Dim TotalKilosConvertidos As Double
        TotalKilosSeleccionados = 0
        TotalKilosConvertidos = 0
        ConvertirSeleccionado = False
        DestinoSeleccionado = False
        For X = 0 To DGV.RowCount - 1
            If DGV.Item(2, X).Value > DGV.Item(1, X).Value Then
                DGV.CurrentCell = DGV.Rows(X).Cells(2)
                OPMsgError("Cantidad seleccionada mayor a la existencia")
                Return False
            End If
            If DGV.Item(2, X).Value > 0 Then
                ConvertirSeleccionado = True
            End If
            TotalKilosSeleccionados += DGV.Item(5, X).Value
        Next
        If Not ConvertirSeleccionado Then
            OPMsgError("Ninguna cantidad a convertir seleccionada")
            Return False
        End If

        For X = 0 To DGV2.RowCount - 1
            TotalKilosConvertidos += DGV2.Item(2, X).Value
            If DGV2.Item(2, X).Value > 0 Then
                DestinoSeleccionado = True
            End If
        Next

        If OPC = 2 Then
            If TotalKilosConvertidos < (TotalKilosSeleccionados * 0.9) Or TotalKilosConvertidos > (TotalKilosConvertidos * 1.1) Then
                OPMsgError("Rango de kilos convertidos excede al +- 10%")
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Dim X As Integer

        For X = 0 To DGV.RowCount - 1
            DGV.Item(5, X).Value = (DGV.Item(2, X).Value * DGV.Item(3, X).Value)
        Next
    End Sub
End Class