<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReimpresionPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReimpresionPedido))
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.LBLPED = New System.Windows.Forms.TextBox
        Me.LBLTP = New System.Windows.Forms.Label
        Me.LBLSUC = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.BTNBUS = New System.Windows.Forms.Button
        Me.LBLTOTPED = New System.Windows.Forms.Label
        Me.LBLART = New System.Windows.Forms.Label
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(29, 78)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Size = New System.Drawing.Size(705, 485)
        Me.DGV.TabIndex = 1055
        '
        'LBLPED
        '
        Me.LBLPED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LBLPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPED.Location = New System.Drawing.Point(213, 17)
        Me.LBLPED.MaxLength = 10
        Me.LBLPED.Name = "LBLPED"
        Me.LBLPED.Size = New System.Drawing.Size(86, 26)
        Me.LBLPED.TabIndex = 1052
        '
        'LBLTP
        '
        Me.LBLTP.AutoSize = True
        Me.LBLTP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTP.Location = New System.Drawing.Point(312, 44)
        Me.LBLTP.Name = "LBLTP"
        Me.LBLTP.Size = New System.Drawing.Size(0, 16)
        Me.LBLTP.TabIndex = 1054
        '
        'LBLSUC
        '
        Me.LBLSUC.AutoSize = True
        Me.LBLSUC.BackColor = System.Drawing.Color.Transparent
        Me.LBLSUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSUC.Location = New System.Drawing.Point(312, 19)
        Me.LBLSUC.Name = "LBLSUC"
        Me.LBLSUC.Size = New System.Drawing.Size(0, 16)
        Me.LBLSUC.TabIndex = 1053
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(99, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 1051
        Me.Label4.Text = "No. de Pedido"
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Red
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.Location = New System.Drawing.Point(774, 78)
        Me.BTNBUS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUS.TabIndex = 1104
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'LBLTOTPED
        '
        Me.LBLTOTPED.AutoSize = True
        Me.LBLTOTPED.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTPED.Location = New System.Drawing.Point(591, 583)
        Me.LBLTOTPED.Name = "LBLTOTPED"
        Me.LBLTOTPED.Size = New System.Drawing.Size(98, 16)
        Me.LBLTOTPED.TabIndex = 1106
        Me.LBLTOTPED.Text = "Total Pedido"
        '
        'LBLART
        '
        Me.LBLART.AutoSize = True
        Me.LBLART.BackColor = System.Drawing.Color.Transparent
        Me.LBLART.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLART.Location = New System.Drawing.Point(149, 583)
        Me.LBLART.Name = "LBLART"
        Me.LBLART.Size = New System.Drawing.Size(68, 16)
        Me.LBLART.TabIndex = 1105
        Me.LBLART.Text = "Articulos"
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(774, 467)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1202
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'frmReimpresionPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 614)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.LBLTOTPED)
        Me.Controls.Add(Me.LBLART)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLPED)
        Me.Controls.Add(Me.LBLTP)
        Me.Controls.Add(Me.LBLSUC)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReimpresionPedido"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reimpresion de pedido"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents LBLPED As System.Windows.Forms.TextBox
    Friend WithEvents LBLTP As System.Windows.Forms.Label
    Friend WithEvents LBLSUC As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents LBLTOTPED As System.Windows.Forms.Label
    Friend WithEvents LBLART As System.Windows.Forms.Label
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
End Class
