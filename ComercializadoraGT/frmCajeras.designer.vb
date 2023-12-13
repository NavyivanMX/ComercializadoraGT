<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCajeras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCajeras))
        Me.LBL1 = New System.Windows.Forms.Label
        Me.TXTEMP = New System.Windows.Forms.TextBox
        Me.TXTPWD = New System.Windows.Forms.TextBox
        Me.LBLPWD = New System.Windows.Forms.Label
        Me.TXTANT = New System.Windows.Forms.TextBox
        Me.LBLANT = New System.Windows.Forms.Label
        Me.TXTNVA = New System.Windows.Forms.TextBox
        Me.LBLNVA = New System.Windows.Forms.Label
        Me.LBLEMP = New System.Windows.Forms.Label
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LBL1
        '
        Me.LBL1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL1.Location = New System.Drawing.Point(90, 28)
        Me.LBL1.Name = "LBL1"
        Me.LBL1.Size = New System.Drawing.Size(104, 27)
        Me.LBL1.TabIndex = 222
        Me.LBL1.Text = "Empleado"
        '
        'TXTEMP
        '
        Me.TXTEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEMP.Location = New System.Drawing.Point(200, 26)
        Me.TXTEMP.MaxLength = 4
        Me.TXTEMP.Name = "TXTEMP"
        Me.TXTEMP.Size = New System.Drawing.Size(76, 29)
        Me.TXTEMP.TabIndex = 0
        Me.TXTEMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPWD
        '
        Me.TXTPWD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPWD.Location = New System.Drawing.Point(189, 184)
        Me.TXTPWD.MaxLength = 10
        Me.TXTPWD.Name = "TXTPWD"
        Me.TXTPWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTPWD.Size = New System.Drawing.Size(210, 22)
        Me.TXTPWD.TabIndex = 3
        '
        'LBLPWD
        '
        Me.LBLPWD.AutoSize = True
        Me.LBLPWD.BackColor = System.Drawing.Color.Transparent
        Me.LBLPWD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPWD.Location = New System.Drawing.Point(2, 186)
        Me.LBLPWD.Name = "LBLPWD"
        Me.LBLPWD.Size = New System.Drawing.Size(171, 20)
        Me.LBLPWD.TabIndex = 223
        Me.LBLPWD.Text = " Repetir Contraseña"
        '
        'TXTANT
        '
        Me.TXTANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTANT.Location = New System.Drawing.Point(189, 122)
        Me.TXTANT.MaxLength = 10
        Me.TXTANT.Name = "TXTANT"
        Me.TXTANT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTANT.Size = New System.Drawing.Size(210, 22)
        Me.TXTANT.TabIndex = 1
        '
        'LBLANT
        '
        Me.LBLANT.AutoSize = True
        Me.LBLANT.BackColor = System.Drawing.Color.Transparent
        Me.LBLANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLANT.Location = New System.Drawing.Point(2, 124)
        Me.LBLANT.Name = "LBLANT"
        Me.LBLANT.Size = New System.Drawing.Size(171, 20)
        Me.LBLANT.TabIndex = 228
        Me.LBLANT.Text = "Contraseña Anterior"
        '
        'TXTNVA
        '
        Me.TXTNVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNVA.Location = New System.Drawing.Point(188, 150)
        Me.TXTNVA.MaxLength = 10
        Me.TXTNVA.Name = "TXTNVA"
        Me.TXTNVA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXTNVA.Size = New System.Drawing.Size(210, 22)
        Me.TXTNVA.TabIndex = 2
        '
        'LBLNVA
        '
        Me.LBLNVA.AutoSize = True
        Me.LBLNVA.BackColor = System.Drawing.Color.Transparent
        Me.LBLNVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNVA.Location = New System.Drawing.Point(16, 152)
        Me.LBLNVA.Name = "LBLNVA"
        Me.LBLNVA.Size = New System.Drawing.Size(157, 20)
        Me.LBLNVA.TabIndex = 230
        Me.LBLNVA.Text = "Nueva Contraseña"
        '
        'LBLEMP
        '
        Me.LBLEMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEMP.ForeColor = System.Drawing.Color.Blue
        Me.LBLEMP.Location = New System.Drawing.Point(16, 78)
        Me.LBLEMP.Name = "LBLEMP"
        Me.LBLEMP.Size = New System.Drawing.Size(104, 27)
        Me.LBLEMP.TabIndex = 232
        Me.LBLEMP.Text = "Empleado"
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(247, 229)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 5
        Me.BTNCANCELAR.Text = "&C"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(94, 229)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 4
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(314, 5)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 6
        Me.BTNBUSCAR.Text = "&B"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'frmCajeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(421, 332)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.LBLEMP)
        Me.Controls.Add(Me.TXTNVA)
        Me.Controls.Add(Me.LBLNVA)
        Me.Controls.Add(Me.TXTANT)
        Me.Controls.Add(Me.LBLANT)
        Me.Controls.Add(Me.TXTPWD)
        Me.Controls.Add(Me.LBLPWD)
        Me.Controls.Add(Me.LBL1)
        Me.Controls.Add(Me.TXTEMP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCajeras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cajeras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBL1 As System.Windows.Forms.Label
    Friend WithEvents TXTEMP As System.Windows.Forms.TextBox
    Friend WithEvents TXTPWD As System.Windows.Forms.TextBox
    Friend WithEvents LBLPWD As System.Windows.Forms.Label
    Friend WithEvents TXTANT As System.Windows.Forms.TextBox
    Friend WithEvents LBLANT As System.Windows.Forms.Label
    Friend WithEvents TXTNVA As System.Windows.Forms.TextBox
    Friend WithEvents LBLNVA As System.Windows.Forms.Label
    Friend WithEvents LBLEMP As System.Windows.Forms.Label
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
End Class
