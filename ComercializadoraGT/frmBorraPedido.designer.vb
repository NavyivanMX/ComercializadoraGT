<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorraPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorraPedido))
        Me.LBL1 = New System.Windows.Forms.Label
        Me.TXTPED = New System.Windows.Forms.TextBox
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LBL1
        '
        Me.LBL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL1.Location = New System.Drawing.Point(53, 40)
        Me.LBL1.Name = "LBL1"
        Me.LBL1.Size = New System.Drawing.Size(288, 27)
        Me.LBL1.TabIndex = 216
        Me.LBL1.Text = "Numero del Pedido a Borrar"
        '
        'TXTPED
        '
        Me.TXTPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPED.Location = New System.Drawing.Point(120, 70)
        Me.TXTPED.Name = "TXTPED"
        Me.TXTPED.Size = New System.Drawing.Size(83, 22)
        Me.TXTPED.TabIndex = 215
        Me.TXTPED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Image = CType(resources.GetObject("BTNACEPTAR.Image"), System.Drawing.Image)
        Me.BTNACEPTAR.Location = New System.Drawing.Point(108, 108)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 214
        '
        'frmBorraPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 256)
        Me.Controls.Add(Me.LBL1)
        Me.Controls.Add(Me.TXTPED)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBorraPedido"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Borrar Pedido"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBL1 As System.Windows.Forms.Label
    Friend WithEvents TXTPED As System.Windows.Forms.TextBox
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
End Class
