<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoAQuitar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoAQuitar))
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.CBUNI = New System.Windows.Forms.ComboBox
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNYES = New System.Windows.Forms.Button
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToOrderColumns = True
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(12, 38)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.Size = New System.Drawing.Size(762, 357)
        Me.DGV.TabIndex = 59
        '
        'CBUNI
        '
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Items.AddRange(New Object() {"Yds", "Mts", "Pzs"})
        Me.CBUNI.Location = New System.Drawing.Point(796, 172)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(180, 28)
        Me.CBUNI.TabIndex = 56
        '
        'TXTCANT
        '
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(826, 102)
        Me.TXTCANT.MaxLength = 10
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(121, 26)
        Me.TXTCANT.TabIndex = 10
        Me.TXTCANT.Text = "0"
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(851, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Cantidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(857, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Unidad"
        '
        'BTNYES
        '
        Me.BTNYES.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.BTNYES.Image = CType(resources.GetObject("BTNYES.Image"), System.Drawing.Image)
        Me.BTNYES.Location = New System.Drawing.Point(823, 237)
        Me.BTNYES.Name = "BTNYES"
        Me.BTNYES.Size = New System.Drawing.Size(153, 139)
        Me.BTNYES.TabIndex = 62
        Me.BTNYES.Text = " "
        Me.BTNYES.UseVisualStyleBackColor = True
        '
        'frmPedidoAQuitar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 435)
        Me.Controls.Add(Me.BTNYES)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBUNI)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DGV)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidoAQuitar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedido a Quitar el Producto:"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNYES As System.Windows.Forms.Button
End Class
