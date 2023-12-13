<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteFacturas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteFacturas))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.CBRFC = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CBCLI = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.DTDE = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DTHASTA = New System.Windows.Forms.DateTimePicker
        Me.LBLI = New System.Windows.Forms.Label
        Me.LBLS = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LBLT = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBRFC
        '
        Me.CBRFC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBRFC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBRFC.FormattingEnabled = True
        Me.CBRFC.Location = New System.Drawing.Point(92, 67)
        Me.CBRFC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBRFC.Name = "CBRFC"
        Me.CBRFC.Size = New System.Drawing.Size(309, 26)
        Me.CBRFC.TabIndex = 1240
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(44, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 18)
        Me.Label8.TabIndex = 1241
        Me.Label8.Text = "RFC"
        '
        'CBCLI
        '
        Me.CBCLI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCLI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCLI.FormattingEnabled = True
        Me.CBCLI.Location = New System.Drawing.Point(92, 28)
        Me.CBCLI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CBCLI.Name = "CBCLI"
        Me.CBCLI.Size = New System.Drawing.Size(599, 26)
        Me.CBCLI.TabIndex = 1238
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 18)
        Me.Label5.TabIndex = 1239
        Me.Label5.Text = "Cliente"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(23, 156)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Size = New System.Drawing.Size(964, 196)
        Me.DGV.TabIndex = 1237
        '
        'DTDE
        '
        Me.DTDE.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDE.Location = New System.Drawing.Point(265, 109)
        Me.DTDE.Name = "DTDE"
        Me.DTDE.Size = New System.Drawing.Size(130, 25)
        Me.DTDE.TabIndex = 1245
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(427, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 17)
        Me.Label4.TabIndex = 1244
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(231, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 17)
        Me.Label3.TabIndex = 1243
        Me.Label3.Text = "De"
        '
        'DTHASTA
        '
        Me.DTHASTA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHASTA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTHASTA.Location = New System.Drawing.Point(493, 107)
        Me.DTHASTA.Name = "DTHASTA"
        Me.DTHASTA.Size = New System.Drawing.Size(130, 25)
        Me.DTHASTA.TabIndex = 1242
        '
        'LBLI
        '
        Me.LBLI.AutoSize = True
        Me.LBLI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLI.ForeColor = System.Drawing.Color.Navy
        Me.LBLI.Location = New System.Drawing.Point(514, 360)
        Me.LBLI.Name = "LBLI"
        Me.LBLI.Size = New System.Drawing.Size(21, 22)
        Me.LBLI.TabIndex = 1249
        Me.LBLI.Text = "0"
        '
        'LBLS
        '
        Me.LBLS.AutoSize = True
        Me.LBLS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLS.ForeColor = System.Drawing.Color.Navy
        Me.LBLS.Location = New System.Drawing.Point(141, 360)
        Me.LBLS.Name = "LBLS"
        Me.LBLS.Size = New System.Drawing.Size(21, 22)
        Me.LBLS.TabIndex = 1248
        Me.LBLS.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(453, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 1247
        Me.Label2.Text = "IVA $"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 1246
        Me.Label1.Text = "Sub total  $"
        '
        'LBLT
        '
        Me.LBLT.AutoSize = True
        Me.LBLT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLT.ForeColor = System.Drawing.Color.Navy
        Me.LBLT.Location = New System.Drawing.Point(846, 360)
        Me.LBLT.Name = "LBLT"
        Me.LBLT.Size = New System.Drawing.Size(21, 22)
        Me.LBLT.TabIndex = 1251
        Me.LBLT.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(785, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 17)
        Me.Label7.TabIndex = 1250
        Me.Label7.Text = "Total $"
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(706, 28)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1236
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(23, 404)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV2.Size = New System.Drawing.Size(964, 196)
        Me.DGV2.TabIndex = 1252
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(809, 28)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1253
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(907, 36)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 1254
        Me.BTNELIMINAR.Text = "&E"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'frmReporteFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 627)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.LBLT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLI)
        Me.Controls.Add(Me.LBLS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTDE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTHASTA)
        Me.Controls.Add(Me.CBRFC)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CBCLI)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteFacturas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturas"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBRFC As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CBCLI As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents DTDE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTHASTA As System.Windows.Forms.DateTimePicker
    Friend WithEvents LBLI As System.Windows.Forms.Label
    Friend WithEvents LBLS As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBLT As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
End Class
