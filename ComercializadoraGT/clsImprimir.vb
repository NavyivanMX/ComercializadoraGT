Imports CrystalDecisions
Imports System.Windows.Forms
Public Class clsImprimir
    Public Function IMPRIMIR1(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal QUERY As String, ByVal NCOPIAS As Integer, ByVal CADENA As String, ByVal PARA As List(Of String), ByVal TIPO As List(Of SqlDbType), ByVal VALO As List(Of DateTime)) As Boolean
        Dim REPO As CrystalDecisions.CrystalReports.Engine.ReportDocument
        REPO = REP
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
        Dim X As Integer
        DA.SelectCommand.Parameters.Clear()
        DA.SelectCommand.CommandTimeout = 300
        For X = 0 To PARA.Count - 1
            DA.SelectCommand.Parameters.Add(PARA.Item(X), TIPO.Item(X))
            DA.SelectCommand.Parameters(X).Value = VALO.Item(X)
        Next
        Dim DT As New DataTable
        DA.Fill(DT)
        REPO.SetDataSource(DT)
        REPO.PrintToPrinter(NCOPIAS, False, 0, 0)
        ABC.Close()
        DA.Dispose()
        Return False
    End Function
    Public Sub Abrir()

    End Sub
    Public Function IMPRIMIR3(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal QUERY As String, ByVal NCOPIAS As Integer, ByVal CADENA As String, ByVal PARA As List(Of String), ByVal TIPO As List(Of SqlDbType), ByVal VALO As List(Of DateTime)) As Boolean
        Dim REPO As CrystalDecisions.CrystalReports.Engine.ReportDocument
        REPO = REP
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim DA As New SqlClient.SqlCommand(QUERY, ABC)
        Dim X As Integer
        DA.Parameters.Clear()
        DA.CommandTimeout = 300
        For X = 0 To PARA.Count - 1
            DA.Parameters.Add(PARA.Item(X), TIPO.Item(X))
            DA.Parameters(X).Value = VALO.Item(X)
        Next
        Dim DT As New DataTable
        DT.Columns.Add("NOTAS")
        DT.Columns.Add("EMPLEADO")
        DT.Columns.Add("NOMBRE")
        DT.Columns.Add("TOTAL")
        DT.Columns.Add("NOCAJA")
        DT.Columns.Add("EMPRESA")
        DT.Columns.Add("DIRECCION")
        DT.Columns.Add("CIUDAD")
        DT.Columns.Add("RFC")
        DT.Columns.Add("TELEFONO")
        DT.Columns.Add("NOMBRECAJ")
        DT.Columns.Add("CZ")
   

        Dim LEC As SqlClient.SqlDataReader
        LEC = DA.ExecuteReader
        While LEC.Read
            Dim DOW As System.Data.DataRow = DT.NewRow
            DOW(0) = LEC(0)
            DOW(1) = LEC(1)
            DOW(2) = LEC(2)
            DOW(3) = LEC(3)
            DOW(4) = LEC(4)
            DOW(5) = LEC(5)
            DOW(6) = LEC(6)
            DOW(7) = LEC(7)
            DOW(8) = LEC(8)
            DOW(9) = LEC(9)
            DOW(10) = LEC(10)
            DOW(11) = LEC(11)
            DT.Rows.Add(DOW)
        End While
        LEC.Close()

        REPO.SetDataSource(DT)
        REPO.PrintToPrinter(NCOPIAS, False, 0, 0)
        ABC.Close()
        DA.Dispose()
        Return False
    End Function

    Public Function IMPRIMIR2(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal QUERY As String, ByVal NCOPIAS As Integer, ByVal CADENA As String) As Boolean

        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
        DA.SelectCommand.CommandTimeout = 300
        Dim DT As New DataTable
        DA.Fill(DT)
        REP.SetDataSource(DT)
        REP.PrintToPrinter(NCOPIAS, False, 0, 0)
        ABC.Close()
        DA.Dispose()
        Return False
    End Function
    Public Function MOSTRAR1(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal NV As String, ByVal QUERY As String, ByVal CADENA As String, ByVal PARA As List(Of String), ByVal TIPO As List(Of SqlDbType), ByVal VALO As List(Of DateTime)) As Boolean
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim FRM As New System.Windows.Forms.Form
        Dim CRV As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
        Dim X As Integer
        DA.SelectCommand.Parameters.Clear()
        For X = 0 To PARA.Count - 1
            DA.SelectCommand.Parameters.Add(PARA.Item(X), TIPO.Item(X))
            DA.SelectCommand.Parameters(X).Value = VALO.Item(X)
        Next
        DA.SelectCommand.CommandTimeout = 300
        Dim DT As New DataTable
        DA.Fill(DT)
        REP.SetDataSource(DT)
        CRV.ReportSource = REP
        ABC.Close()
        FRM.Controls.Add(CRV)
        CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CRV.Dock = System.Windows.Forms.DockStyle.Fill
        FRM.WindowState = FormWindowState.Maximized
        FRM.ShowDialog()
        Return False
    End Function
    Public Function MOSTRAR2(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal NV As String, ByVal QUERY As String, ByVal CADENA As String) As Boolean
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim FRM As New System.Windows.Forms.Form
        Dim CRV As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
        Dim DT As New DataTable
        DA.SelectCommand.CommandTimeout = 300
        DA.Fill(DT)
        REP.SetDataSource(DT)
        CRV.ReportSource = REP
        ABC.Close()
        CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        CRV.Dock = System.Windows.Forms.DockStyle.Fill
        FRM.Controls.Add(CRV)
        FRM.WindowState = FormWindowState.Maximized
        FRM.ShowDialog()
        Return False
    End Function
    Public Function GUARDAR1(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal QUERY As String, ByVal TIPOEXPORTAR As CrystalDecisions.Shared.ExportFormatType, ByVal Prog As String, ByVal Ext As String, ByVal MSG As String, ByVal NOMBREARCHIVO As String, ByVal CADENA As String, ByVal PARA As List(Of String), ByVal TIPO As List(Of SqlDbType), ByVal VALO As List(Of DateTime)) As Boolean
        Dim xyz As Short
        xyz = MessageBox.Show(MSG, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Function
        End If
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim SFD As New System.Windows.Forms.SaveFileDialog
        SFD.FileName = NOMBREARCHIVO
        SFD.Filter = "Archivos de " + Prog + " (*." + Ext + ")|*." + Ext + "|" + Chr(34) + "All files (*.*)|*.*;"
        If SFD.ShowDialog = DialogResult.OK Then
            Try
                If System.IO.File.Exists(SFD.FileName) = True Then
                    System.IO.File.Delete(SFD.FileName)
                End If
            Catch ex As Exception
                MessageBox.Show("La informacion No se puede Guardar, Archivo en Uso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End Try
            Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
            Dim X As Integer
            DA.SelectCommand.Parameters.Clear()
            For X = 0 To PARA.Count - 1
                DA.SelectCommand.Parameters.Add(PARA.Item(X), TIPO.Item(X))
                DA.SelectCommand.Parameters(X).Value = VALO.Item(X)
            Next
            Dim DT As New DataTable
            DA.SelectCommand.CommandTimeout = 300
            DA.Fill(DT)
            REP.SetDataSource(DT)
            REP.ExportToDisk(TIPOEXPORTAR, SFD.FileName)
            MessageBox.Show("El archivo ha sido Guardado Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        Return False
    End Function
    Public Function GUARDAR2(ByVal REP As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal QUERY As String, ByVal TIPOEXPORTAR As CrystalDecisions.Shared.ExportFormatType, ByVal Prog As String, ByVal Ext As String, ByVal MSG As String, ByVal CADENA As String) As Boolean
        Dim xyz As Short
        xyz = MessageBox.Show(MSG, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If xyz <> 6 Then
            Exit Function
        End If
        Dim ABC As New SqlClient.SqlConnection
        ABC.ConnectionString = CADENA
        ABC.Open()
        Dim SFD As New System.Windows.Forms.SaveFileDialog
        SFD.FileName = ""
        SFD.Filter = "Archivos de " + Prog + " (*." + Ext + ")|*." + Ext + "|" + Chr(34) + "All files (*.*)|*.*;"
        If SFD.ShowDialog = DialogResult.OK Then
            Try
                If System.IO.File.Exists(SFD.FileName) = True Then
                    System.IO.File.Delete(SFD.FileName)
                End If
            Catch ex As Exception
                MessageBox.Show("La informacion No se puede Guardar, Archivo en Uso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
                Exit Function
            End Try
            Dim DA As New SqlClient.SqlDataAdapter(QUERY, ABC)
            DA.SelectCommand.CommandTimeout = 300
            Dim DT As New DataTable
            DA.Fill(DT)
            REP.SetDataSource(DT)
            REP.ExportToDisk(TIPOEXPORTAR, SFD.FileName)
            MessageBox.Show("El archivo ha sido Guardado Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
        Return False
    End Function
End Class
