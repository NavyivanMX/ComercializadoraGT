<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelaNotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelaNotas))
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTTOT = New System.Windows.Forms.TextBox
        Me.DTFECHA = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTOBS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLEMP = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.LBLCLI = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(259, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 16)
        Me.Label9.TabIndex = 1090
        Me.Label9.Text = "Empleado"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(739, 279)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 24)
        Me.Label8.TabIndex = 1087
        Me.Label8.Text = "Total"
        '
        'TXTTOT
        '
        Me.TXTTOT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOT.Location = New System.Drawing.Point(727, 306)
        Me.TXTTOT.MaxLength = 5
        Me.TXTTOT.Name = "TXTTOT"
        Me.TXTTOT.ReadOnly = True
        Me.TXTTOT.Size = New System.Drawing.Size(91, 35)
        Me.TXTTOT.TabIndex = 1084
        Me.TXTTOT.Text = "0"
        Me.TXTTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DTFECHA
        '
        Me.DTFECHA.Enabled = False
        Me.DTFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHA.Location = New System.Drawing.Point(634, 43)
        Me.DTFECHA.Name = "DTFECHA"
        Me.DTFECHA.Size = New System.Drawing.Size(119, 26)
        Me.DTFECHA.TabIndex = 1077
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(671, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 1076
        Me.Label11.Text = "Fecha"
        '
        'TXTNOTA
        '
        Me.TXTNOTA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(44, 43)
        Me.TXTNOTA.MaxLength = 10
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(112, 26)
        Me.TXTNOTA.TabIndex = 1074
        Me.TXTNOTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(52, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 1073
        Me.Label2.Text = "Nota"
        '
        'TXTOBS
        '
        Me.TXTOBS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOBS.Location = New System.Drawing.Point(33, 142)
        Me.TXTOBS.MaxLength = 50
        Me.TXTOBS.Name = "TXTOBS"
        Me.TXTOBS.Size = New System.Drawing.Size(663, 26)
        Me.TXTOBS.TabIndex = 1063
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 1069
        Me.Label3.Text = "Observacin"
        '
        'LBLEMP
        '
        Me.LBLEMP.AutoSize = True
        Me.LBLEMP.BackColor = System.Drawing.Color.Transparent
        Me.LBLEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEMP.Location = New System.Drawing.Point(181, 53)
        Me.LBLEMP.Name = "LBLEMP"
        Me.LBLEMP.Size = New System.Drawing.Size(79, 16)
        Me.LBLEMP.TabIndex = 1092
        Me.LBLEMP.Text = "Empleado"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(33, 186)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(663, 327)
        Me.DGV.TabIndex = 1093
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(738, 142)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1096
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(738, 412)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 1097
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'LBLCLI
        '
        Me.LBLCLI.AutoSize = True
        Me.LBLCLI.BackColor = System.Drawing.Color.Transparent
        Me.LBLCLI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCLI.Location = New System.Drawing.Point(111, 90)
        Me.LBLCLI.Name = "LBLCLI"
        Me.LBLCLI.Size = New System.Drawing.Size(56, 16)
        Me.LBLCLI.TabIndex = 1114
        Me.LBLCLI.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1113
        Me.Label1.Text = "Cliente"
        '
        'frmCancelaNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(843, 529)
        Me.Controls.Add(Me.LBLCLI)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLEMP)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTTOT)
        Me.Controls.Add(Me.DTFECHA)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTOBS)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelaNotas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de Notas"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTTOT As System.Windows.Forms.TextBox
    Friend WithEvents DTFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTOBS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBLEMP As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents LBLCLI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
