<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleAbonos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleAbonos))
        Me.LBLC = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLFEC = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLTOT = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.BackColor = System.Drawing.Color.Transparent
        Me.LBLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.ForeColor = System.Drawing.Color.Navy
        Me.LBLC.Location = New System.Drawing.Point(110, 69)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(19, 20)
        Me.LBLC.TabIndex = 1255
        Me.LBLC.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 1254
        Me.Label3.Text = "Cliente"
        '
        'TXTNOTA
        '
        Me.TXTNOTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(206, 15)
        Me.TXTNOTA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTNOTA.MaxLength = 100
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(172, 25)
        Me.TXTNOTA.TabIndex = 1253
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(153, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 20)
        Me.Label7.TabIndex = 1252
        Me.Label7.Text = "Nota"
        '
        'LBLFEC
        '
        Me.LBLFEC.AutoSize = True
        Me.LBLFEC.BackColor = System.Drawing.Color.Transparent
        Me.LBLFEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFEC.ForeColor = System.Drawing.Color.Navy
        Me.LBLFEC.Location = New System.Drawing.Point(215, 100)
        Me.LBLFEC.Name = "LBLFEC"
        Me.LBLFEC.Size = New System.Drawing.Size(19, 20)
        Me.LBLFEC.TabIndex = 1251
        Me.LBLFEC.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 20)
        Me.Label2.TabIndex = 1250
        Me.Label2.Text = "Fecha de consumo"
        '
        'LBLTOT
        '
        Me.LBLTOT.AutoSize = True
        Me.LBLTOT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOT.ForeColor = System.Drawing.Color.Navy
        Me.LBLTOT.Location = New System.Drawing.Point(540, 438)
        Me.LBLTOT.Name = "LBLTOT"
        Me.LBLTOT.Size = New System.Drawing.Size(21, 24)
        Me.LBLTOT.TabIndex = 1249
        Me.LBLTOT.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(465, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 1248
        Me.Label1.Text = "Total  $"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 143)
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
        Me.DGV.Size = New System.Drawing.Size(814, 278)
        Me.DGV.TabIndex = 1247
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(613, 8)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1245
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'frmDetalleAbonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 468)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLFEC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBLTOT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.Controls.Add(Me.DGV)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetalleAbonos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Abonos / Pagos"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLFEC As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLTOT As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
End Class
