<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportevtaxCliente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportevtaxCliente))
        Me.DTDE = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTHASTA = New System.Windows.Forms.DateTimePicker()
        Me.CBCLI = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LBLNOT = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGV2 = New System.Windows.Forms.DataGridView()
        Me.LBLAT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.BTNMOSTRAR = New System.Windows.Forms.Button()
        Me.BTNARCHIVO = New System.Windows.Forms.Button()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTDE
        '
        Me.DTDE.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(145, 96)
        Me.DTDE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(172, 29)
        Me.DTDE.TabIndex = 1264
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(361, 101)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 22)
        Me.Label4.TabIndex = 1263
        Me.Label4.Text = "Hasta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(99, 103)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 22)
        Me.Label5.TabIndex = 1262
        Me.Label5.Text = "De"
        '
        'DTHASTA
        '
        Me.DTHASTA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTHASTA.Location = New System.Drawing.Point(449, 94)
        Me.DTHASTA.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTHASTA.Name = "DTHASTA"
        Me.DTHASTA.Size = New System.Drawing.Size(172, 29)
        Me.DTHASTA.TabIndex = 1261
        '
        'CBCLI
        '
        Me.CBCLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCLI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCLI.FormattingEnabled = True
        Me.CBCLI.Location = New System.Drawing.Point(143, 39)
        Me.CBCLI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBCLI.Name = "CBCLI"
        Me.CBCLI.Size = New System.Drawing.Size(599, 31)
        Me.CBCLI.TabIndex = 1259
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 46)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 23)
        Me.Label8.TabIndex = 1260
        Me.Label8.Text = "Cliente"
        '
        'LBLNOT
        '
        Me.LBLNOT.AutoSize = True
        Me.LBLNOT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNOT.ForeColor = System.Drawing.Color.Navy
        Me.LBLNOT.Location = New System.Drawing.Point(856, 645)
        Me.LBLNOT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLNOT.Name = "LBLNOT"
        Me.LBLNOT.Size = New System.Drawing.Size(26, 28)
        Me.LBLNOT.TabIndex = 1270
        Me.LBLNOT.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(699, 645)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 28)
        Me.Label3.TabIndex = 1269
        Me.Label3.Text = "Total nota $"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(40, 422)
        Me.DGV2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DGV2.Size = New System.Drawing.Size(1023, 209)
        Me.DGV2.TabIndex = 1268
        '
        'LBLAT
        '
        Me.LBLAT.AutoSize = True
        Me.LBLAT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAT.ForeColor = System.Drawing.Color.Navy
        Me.LBLAT.Location = New System.Drawing.Point(856, 366)
        Me.LBLAT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLAT.Name = "LBLAT"
        Me.LBLAT.Size = New System.Drawing.Size(26, 28)
        Me.LBLAT.TabIndex = 1267
        Me.LBLAT.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(636, 366)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 28)
        Me.Label2.TabIndex = 1266
        Me.Label2.Text = "Total consumo $"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(40, 149)
        Me.DGV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.DGV.Size = New System.Drawing.Size(1023, 209)
        Me.DGV.TabIndex = 1265
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(940, 15)
        Me.BTNMOSTRAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(123, 118)
        Me.BTNMOSTRAR.TabIndex = 1273
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'BTNARCHIVO
        '
        Me.BTNARCHIVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNARCHIVO.Location = New System.Drawing.Point(775, 39)
        Me.BTNARCHIVO.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNARCHIVO.Name = "BTNARCHIVO"
        Me.BTNARCHIVO.Size = New System.Drawing.Size(84, 30)
        Me.BTNARCHIVO.TabIndex = 1327
        Me.BTNARCHIVO.Text = "..."
        Me.BTNARCHIVO.UseVisualStyleBackColor = True
        '
        'frmReportevtaxCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 682)
        Me.Controls.Add(Me.BTNARCHIVO)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.LBLNOT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.LBLAT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTHASTA)
        Me.Controls.Add(Me.CBCLI)
        Me.Controls.Add(Me.Label8)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmReportevtaxCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas por cliente"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTHASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents CBCLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLNOT As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents LBLAT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents BTNARCHIVO As Button
End Class
