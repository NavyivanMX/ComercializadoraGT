<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionSVenta
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CHKCRE = New System.Windows.Forms.CheckBox()
        Me.TXTNOTA = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.LBLNC = New System.Windows.Forms.Label()
        Me.LBLFV = New System.Windows.Forms.Label()
        Me.BTNMOSTRAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.LBLBON = New System.Windows.Forms.Label()
        Me.LBLDSV = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CHKCRE
        '
        Me.CHKCRE.AutoSize = True
        Me.CHKCRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCRE.Location = New System.Drawing.Point(25, 82)
        Me.CHKCRE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHKCRE.Name = "CHKCRE"
        Me.CHKCRE.Size = New System.Drawing.Size(137, 24)
        Me.CHKCRE.TabIndex = 1124
        Me.CHKCRE.Text = "Nota Crédito"
        Me.CHKCRE.UseVisualStyleBackColor = True
        '
        'TXTNOTA
        '
        Me.TXTNOTA.Enabled = False
        Me.TXTNOTA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(203, 82)
        Me.TXTNOTA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOTA.MaxLength = 100
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(171, 26)
        Me.TXTNOTA.TabIndex = 1121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 57)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 1122
        Me.Label1.Text = "Nota"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 192)
        Me.DGV.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(1005, 414)
        Me.DGV.TabIndex = 1123
        '
        'LBLNC
        '
        Me.LBLNC.AutoSize = True
        Me.LBLNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNC.Location = New System.Drawing.Point(16, 127)
        Me.LBLNC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLNC.Name = "LBLNC"
        Me.LBLNC.Size = New System.Drawing.Size(48, 20)
        Me.LBLNC.TabIndex = 1128
        Me.LBLNC.Text = "Nota"
        '
        'LBLFV
        '
        Me.LBLFV.AutoSize = True
        Me.LBLFV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFV.Location = New System.Drawing.Point(16, 158)
        Me.LBLFV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLFV.Name = "LBLFV"
        Me.LBLFV.Size = New System.Drawing.Size(48, 20)
        Me.LBLFV.TabIndex = 1129
        Me.LBLFV.Text = "Nota"
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Black
        Me.BTNMOSTRAR.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.xeyes1
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(644, 18)
        Me.BTNMOSTRAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNMOSTRAR.TabIndex = 1127
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.file_manager___copia
        Me.BTNGUARDAR.Location = New System.Drawing.Point(911, 18)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 1126
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.editdelete
        Me.BTNCANCELAR.Location = New System.Drawing.Point(781, 18)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNCANCELAR.TabIndex = 1125
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'LBLBON
        '
        Me.LBLBON.AutoSize = True
        Me.LBLBON.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLBON.Location = New System.Drawing.Point(479, 622)
        Me.LBLBON.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLBON.Name = "LBLBON"
        Me.LBLBON.Size = New System.Drawing.Size(160, 20)
        Me.LBLBON.TabIndex = 1144
        Me.LBLBON.Text = "Bonificación: 0.00"
        '
        'LBLDSV
        '
        Me.LBLDSV.AutoSize = True
        Me.LBLDSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDSV.Location = New System.Drawing.Point(21, 622)
        Me.LBLDSV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLDSV.Name = "LBLDSV"
        Me.LBLDSV.Size = New System.Drawing.Size(227, 20)
        Me.LBLDSV.TabIndex = 1143
        Me.LBLDSV.Text = "Devolución S/ Venta: 0.00"
        '
        'frmDevolucionSVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 652)
        Me.Controls.Add(Me.LBLBON)
        Me.Controls.Add(Me.LBLDSV)
        Me.Controls.Add(Me.LBLFV)
        Me.Controls.Add(Me.LBLNC)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.CHKCRE)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmDevolucionSVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devoluciones sobre Venta"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CHKCRE As System.Windows.Forms.CheckBox
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents LBLNC As System.Windows.Forms.Label
    Friend WithEvents LBLFV As System.Windows.Forms.Label
    Friend WithEvents LBLBON As System.Windows.Forms.Label
    Friend WithEvents LBLDSV As System.Windows.Forms.Label
End Class
