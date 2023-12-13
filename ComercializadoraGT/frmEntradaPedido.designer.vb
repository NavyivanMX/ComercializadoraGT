<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntradaPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntradaPedido))
        Me.LBLPED = New System.Windows.Forms.TextBox
        Me.NOIMP = New System.Windows.Forms.Button
        Me.SIIMP = New System.Windows.Forms.Button
        Me.LBLTP = New System.Windows.Forms.Label
        Me.LBLSUC = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.LBLART = New System.Windows.Forms.Label
        Me.LBLTOTPED = New System.Windows.Forms.Label
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNBUS = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLPED
        '
        Me.LBLPED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LBLPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPED.Location = New System.Drawing.Point(140, 19)
        Me.LBLPED.MaxLength = 10
        Me.LBLPED.Name = "LBLPED"
        Me.LBLPED.Size = New System.Drawing.Size(86, 26)
        Me.LBLPED.TabIndex = 264
        '
        'NOIMP
        '
        Me.NOIMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NOIMP.Location = New System.Drawing.Point(819, 283)
        Me.NOIMP.Name = "NOIMP"
        Me.NOIMP.Size = New System.Drawing.Size(99, 59)
        Me.NOIMP.TabIndex = 270
        Me.NOIMP.Text = "Desmarcar Todos"
        Me.NOIMP.UseVisualStyleBackColor = True
        '
        'SIIMP
        '
        Me.SIIMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIIMP.Location = New System.Drawing.Point(819, 199)
        Me.SIIMP.Name = "SIIMP"
        Me.SIIMP.Size = New System.Drawing.Size(99, 59)
        Me.SIIMP.TabIndex = 269
        Me.SIIMP.Text = "Marcar Todos"
        Me.SIIMP.UseVisualStyleBackColor = True
        '
        'LBLTP
        '
        Me.LBLTP.AutoSize = True
        Me.LBLTP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTP.Location = New System.Drawing.Point(239, 46)
        Me.LBLTP.Name = "LBLTP"
        Me.LBLTP.Size = New System.Drawing.Size(0, 16)
        Me.LBLTP.TabIndex = 266
        '
        'LBLSUC
        '
        Me.LBLSUC.AutoSize = True
        Me.LBLSUC.BackColor = System.Drawing.Color.Transparent
        Me.LBLSUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSUC.Location = New System.Drawing.Point(239, 21)
        Me.LBLSUC.Name = "LBLSUC"
        Me.LBLSUC.Size = New System.Drawing.Size(0, 16)
        Me.LBLSUC.TabIndex = 265
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 263
        Me.Label4.Text = "No. de Pedido"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 74)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.Size = New System.Drawing.Size(774, 515)
        Me.DGV.TabIndex = 1050
        '
        'LBLART
        '
        Me.LBLART.AutoSize = True
        Me.LBLART.BackColor = System.Drawing.Color.Transparent
        Me.LBLART.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLART.Location = New System.Drawing.Point(89, 606)
        Me.LBLART.Name = "LBLART"
        Me.LBLART.Size = New System.Drawing.Size(68, 16)
        Me.LBLART.TabIndex = 1051
        Me.LBLART.Text = "Articulos"
        '
        'LBLTOTPED
        '
        Me.LBLTOTPED.AutoSize = True
        Me.LBLTOTPED.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOTPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOTPED.Location = New System.Drawing.Point(531, 606)
        Me.LBLTOTPED.Name = "LBLTOTPED"
        Me.LBLTOTPED.Size = New System.Drawing.Size(98, 16)
        Me.LBLTOTPED.TabIndex = 1052
        Me.LBLTOTPED.Text = "Total Pedido"
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(823, 493)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1201
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(830, 388)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1106
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Red
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.Location = New System.Drawing.Point(825, 74)
        Me.BTNBUS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUS.TabIndex = 1103
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'frmEntradaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 631)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.LBLTOTPED)
        Me.Controls.Add(Me.LBLART)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLPED)
        Me.Controls.Add(Me.NOIMP)
        Me.Controls.Add(Me.SIIMP)
        Me.Controls.Add(Me.LBLTP)
        Me.Controls.Add(Me.LBLSUC)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEntradaPedido"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada por Pedido de Bodega"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLPED As System.Windows.Forms.TextBox
    Friend WithEvents NOIMP As System.Windows.Forms.Button
    Friend WithEvents SIIMP As System.Windows.Forms.Button
    Friend WithEvents LBLTP As System.Windows.Forms.Label
    Friend WithEvents LBLSUC As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents LBLART As System.Windows.Forms.Label
    Friend WithEvents LBLTOTPED As System.Windows.Forms.Label
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
End Class
