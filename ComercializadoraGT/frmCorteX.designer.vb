<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorteX
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorteX))
        Me.LBLTOT = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBLCORTE = New System.Windows.Forms.Label
        Me.LBLCOS = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLG = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.BTNCC = New System.Windows.Forms.Button
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLTOT
        '
        Me.LBLTOT.AutoSize = True
        Me.LBLTOT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLTOT.Location = New System.Drawing.Point(56, 495)
        Me.LBLTOT.Name = "LBLTOT"
        Me.LBLTOT.Size = New System.Drawing.Size(25, 25)
        Me.LBLTOT.TabIndex = 1035
        Me.LBLTOT.Text = "0"
        Me.LBLTOT.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 471)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 1034
        Me.Label1.Text = "Venta Total "
        Me.Label1.Visible = False
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV2.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV2.Location = New System.Drawing.Point(614, 342)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.Size = New System.Drawing.Size(290, 119)
        Me.DGV2.TabIndex = 1037
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.AllowUserToOrderColumns = True
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV3.Location = New System.Drawing.Point(12, 342)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.Size = New System.Drawing.Size(577, 119)
        Me.DGV3.TabIndex = 1038
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(648, 323)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 16)
        Me.Label3.TabIndex = 1039
        Me.Label3.Text = "Resumen por Tipo de Pago"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(266, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 16)
        Me.Label4.TabIndex = 1040
        Me.Label4.Text = "Notas / Crditos /Cobranzas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(168, 323)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(236, 16)
        Me.Label5.TabIndex = 1041
        Me.Label5.Text = "Nota, Tipo de Cobro y Empleado"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 40)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV.Size = New System.Drawing.Size(700, 266)
        Me.DGV.TabIndex = 1042
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(767, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 1045
        Me.Label6.Text = "Corte Z Hoy:"
        '
        'LBLCORTE
        '
        Me.LBLCORTE.AutoSize = True
        Me.LBLCORTE.BackColor = System.Drawing.Color.Transparent
        Me.LBLCORTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCORTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLCORTE.Location = New System.Drawing.Point(836, 41)
        Me.LBLCORTE.Name = "LBLCORTE"
        Me.LBLCORTE.Size = New System.Drawing.Size(25, 25)
        Me.LBLCORTE.TabIndex = 1044
        Me.LBLCORTE.Text = "0"
        '
        'LBLCOS
        '
        Me.LBLCOS.AutoSize = True
        Me.LBLCOS.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLCOS.Location = New System.Drawing.Point(334, 495)
        Me.LBLCOS.Name = "LBLCOS"
        Me.LBLCOS.Size = New System.Drawing.Size(25, 25)
        Me.LBLCOS.TabIndex = 1046
        Me.LBLCOS.Text = "0"
        Me.LBLCOS.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(336, 471)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 1047
        Me.Label2.Text = "Costo Total"
        Me.Label2.Visible = False
        '
        'LBLG
        '
        Me.LBLG.AutoSize = True
        Me.LBLG.BackColor = System.Drawing.Color.Transparent
        Me.LBLG.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLG.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLG.Location = New System.Drawing.Point(646, 495)
        Me.LBLG.Name = "LBLG"
        Me.LBLG.Size = New System.Drawing.Size(25, 25)
        Me.LBLG.TabIndex = 1048
        Me.LBLG.Text = "0"
        Me.LBLG.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(648, 471)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(189, 16)
        Me.Label8.TabIndex = 1049
        Me.Label8.Text = "Ganancia antes de gastos"
        Me.Label8.Visible = False
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNIMPRIMIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(843, 440)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(80, 80)
        Me.BTNIMPRIMIR.TabIndex = 1033
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        Me.BTNIMPRIMIR.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(734, 203)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 59)
        Me.Button2.TabIndex = 1055
        Me.Button2.Text = "Cobranza"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(734, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 59)
        Me.Button1.TabIndex = 1054
        Me.Button1.Text = "Contado"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BTNCC
        '
        Me.BTNCC.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCC.ForeColor = System.Drawing.Color.Black
        Me.BTNCC.Location = New System.Drawing.Point(734, 138)
        Me.BTNCC.Name = "BTNCC"
        Me.BTNCC.Size = New System.Drawing.Size(149, 59)
        Me.BTNCC.TabIndex = 1053
        Me.BTNCC.Text = "Crédito"
        Me.BTNCC.UseVisualStyleBackColor = False
        '
        'frmCorteX
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 529)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNCC)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBLG)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBLCOS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLCORTE)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.LBLTOT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCorteX"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CorteX"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLTOT As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLCORTE As System.Windows.Forms.Label
    Friend WithEvents LBLCOS As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLG As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BTNCC As System.Windows.Forms.Button
End Class
