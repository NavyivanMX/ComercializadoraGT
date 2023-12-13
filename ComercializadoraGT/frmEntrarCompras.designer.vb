<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntrarCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntrarCompras))
        Me.TXTFAC = New System.Windows.Forms.TextBox
        Me.LBLFACNOT = New System.Windows.Forms.Label
        Me.CBPRO = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        Me.TXTCON = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RBFAC = New System.Windows.Forms.RadioButton
        Me.RBNOT = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'TXTFAC
        '
        Me.TXTFAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFAC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFAC.Location = New System.Drawing.Point(136, 66)
        Me.TXTFAC.MaxLength = 20
        Me.TXTFAC.Name = "TXTFAC"
        Me.TXTFAC.Size = New System.Drawing.Size(252, 29)
        Me.TXTFAC.TabIndex = 0
        Me.TXTFAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLFACNOT
        '
        Me.LBLFACNOT.AutoSize = True
        Me.LBLFACNOT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFACNOT.Location = New System.Drawing.Point(46, 73)
        Me.LBLFACNOT.Name = "LBLFACNOT"
        Me.LBLFACNOT.Size = New System.Drawing.Size(80, 22)
        Me.LBLFACNOT.TabIndex = 337
        Me.LBLFACNOT.Text = "Factura"
        '
        'CBPRO
        '
        Me.CBPRO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPRO.FormattingEnabled = True
        Me.CBPRO.Location = New System.Drawing.Point(136, 107)
        Me.CBPRO.Name = "CBPRO"
        Me.CBPRO.Size = New System.Drawing.Size(448, 30)
        Me.CBPRO.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 22)
        Me.Label9.TabIndex = 335
        Me.Label9.Text = "Proveedor"
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.BackColor = System.Drawing.Color.White
        Me.BTNACEPTAR.Image = CType(resources.GetObject("BTNACEPTAR.Image"), System.Drawing.Image)
        Me.BTNACEPTAR.Location = New System.Drawing.Point(247, 264)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 3
        Me.BTNACEPTAR.UseVisualStyleBackColor = False
        '
        'TXTCON
        '
        Me.TXTCON.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCON.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCON.Location = New System.Drawing.Point(136, 144)
        Me.TXTCON.MaxLength = 300
        Me.TXTCON.Multiline = True
        Me.TXTCON.Name = "TXTCON"
        Me.TXTCON.Size = New System.Drawing.Size(448, 105)
        Me.TXTCON.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 22)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Concepto"
        '
        'RBFAC
        '
        Me.RBFAC.AutoSize = True
        Me.RBFAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBFAC.Location = New System.Drawing.Point(219, 22)
        Me.RBFAC.Name = "RBFAC"
        Me.RBFAC.Size = New System.Drawing.Size(110, 29)
        Me.RBFAC.TabIndex = 401
        Me.RBFAC.Text = "Factura"
        Me.RBFAC.UseVisualStyleBackColor = True
        '
        'RBNOT
        '
        Me.RBNOT.AutoSize = True
        Me.RBNOT.Checked = True
        Me.RBNOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBNOT.Location = New System.Drawing.Point(114, 22)
        Me.RBNOT.Name = "RBNOT"
        Me.RBNOT.Size = New System.Drawing.Size(79, 29)
        Me.RBNOT.TabIndex = 400
        Me.RBNOT.TabStop = True
        Me.RBNOT.Text = "Nota"
        Me.RBNOT.UseVisualStyleBackColor = True
        '
        'frmEntrarCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(614, 385)
        Me.Controls.Add(Me.RBFAC)
        Me.Controls.Add(Me.RBNOT)
        Me.Controls.Add(Me.TXTCON)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.TXTFAC)
        Me.Controls.Add(Me.LBLFACNOT)
        Me.Controls.Add(Me.CBPRO)
        Me.Controls.Add(Me.Label9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEntrarCompras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Elija las opciones de compra"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTFAC As System.Windows.Forms.TextBox
    Friend WithEvents LBLFACNOT As System.Windows.Forms.Label
    Friend WithEvents CBPRO As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
    Friend WithEvents TXTCON As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RBFAC As System.Windows.Forms.RadioButton
    Friend WithEvents RBNOT As System.Windows.Forms.RadioButton
End Class
