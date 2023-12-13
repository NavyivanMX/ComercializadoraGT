<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSoluciondeDevolucion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSoluciondeDevolucion))
        Me.CBAS = New System.Windows.Forms.ComboBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.LBLOBS = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.LBLREG = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.CBTM = New System.Windows.Forms.ComboBox
        Me.CBSOL = New System.Windows.Forms.ComboBox
        Me.LBLFEC = New System.Windows.Forms.Label
        Me.LBLPROD = New System.Windows.Forms.Label
        Me.LBLUNI = New System.Windows.Forms.Label
        Me.LBLLOTE = New System.Windows.Forms.Label
        Me.LBLCANT = New System.Windows.Forms.Label
        Me.LBLTI = New System.Windows.Forms.Label
        Me.LBLNP = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CBAS
        '
        Me.CBAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBAS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBAS.FormattingEnabled = True
        Me.CBAS.Location = New System.Drawing.Point(162, 459)
        Me.CBAS.Name = "CBAS"
        Me.CBAS.Size = New System.Drawing.Size(475, 28)
        Me.CBAS.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(71, 463)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 24)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = "Acción:"
        '
        'LBLOBS
        '
        Me.LBLOBS.AutoSize = True
        Me.LBLOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLOBS.ForeColor = System.Drawing.Color.Navy
        Me.LBLOBS.Location = New System.Drawing.Point(187, 309)
        Me.LBLOBS.Name = "LBLOBS"
        Me.LBLOBS.Size = New System.Drawing.Size(100, 20)
        Me.LBLOBS.TabIndex = 105
        Me.LBLOBS.Text = "No. Pedido"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(38, 305)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 24)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Observación:"
        '
        'LBLREG
        '
        Me.LBLREG.AutoSize = True
        Me.LBLREG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLREG.ForeColor = System.Drawing.Color.Navy
        Me.LBLREG.Location = New System.Drawing.Point(186, 229)
        Me.LBLREG.Name = "LBLREG"
        Me.LBLREG.Size = New System.Drawing.Size(100, 20)
        Me.LBLREG.TabIndex = 102
        Me.LBLREG.Text = "No. Pedido"
        Me.LBLREG.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(78, 226)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 24)
        Me.Label19.TabIndex = 101
        Me.Label19.Text = "Registro:"
        '
        'CBTM
        '
        Me.CBTM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTM.FormattingEnabled = True
        Me.CBTM.Location = New System.Drawing.Point(162, 425)
        Me.CBTM.Name = "CBTM"
        Me.CBTM.Size = New System.Drawing.Size(475, 28)
        Me.CBTM.TabIndex = 100
        '
        'CBSOL
        '
        Me.CBSOL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBSOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSOL.FormattingEnabled = True
        Me.CBSOL.Location = New System.Drawing.Point(162, 391)
        Me.CBSOL.Name = "CBSOL"
        Me.CBSOL.Size = New System.Drawing.Size(475, 28)
        Me.CBSOL.TabIndex = 99
        '
        'LBLFEC
        '
        Me.LBLFEC.AutoSize = True
        Me.LBLFEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFEC.ForeColor = System.Drawing.Color.Navy
        Me.LBLFEC.Location = New System.Drawing.Point(187, 266)
        Me.LBLFEC.Name = "LBLFEC"
        Me.LBLFEC.Size = New System.Drawing.Size(100, 20)
        Me.LBLFEC.TabIndex = 98
        Me.LBLFEC.Text = "No. Pedido"
        '
        'LBLPROD
        '
        Me.LBLPROD.AutoSize = True
        Me.LBLPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPROD.ForeColor = System.Drawing.Color.Navy
        Me.LBLPROD.Location = New System.Drawing.Point(186, 147)
        Me.LBLPROD.Name = "LBLPROD"
        Me.LBLPROD.Size = New System.Drawing.Size(100, 20)
        Me.LBLPROD.TabIndex = 97
        Me.LBLPROD.Text = "No. Pedido"
        '
        'LBLUNI
        '
        Me.LBLUNI.AutoSize = True
        Me.LBLUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNI.ForeColor = System.Drawing.Color.Navy
        Me.LBLUNI.Location = New System.Drawing.Point(412, 190)
        Me.LBLUNI.Name = "LBLUNI"
        Me.LBLUNI.Size = New System.Drawing.Size(100, 20)
        Me.LBLUNI.TabIndex = 96
        Me.LBLUNI.Text = "No. Pedido"
        '
        'LBLLOTE
        '
        Me.LBLLOTE.AutoSize = True
        Me.LBLLOTE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLOTE.ForeColor = System.Drawing.Color.Navy
        Me.LBLLOTE.Location = New System.Drawing.Point(187, 111)
        Me.LBLLOTE.Name = "LBLLOTE"
        Me.LBLLOTE.Size = New System.Drawing.Size(100, 20)
        Me.LBLLOTE.TabIndex = 95
        Me.LBLLOTE.Text = "No. Pedido"
        '
        'LBLCANT
        '
        Me.LBLCANT.AutoSize = True
        Me.LBLCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCANT.ForeColor = System.Drawing.Color.Navy
        Me.LBLCANT.Location = New System.Drawing.Point(187, 186)
        Me.LBLCANT.Name = "LBLCANT"
        Me.LBLCANT.Size = New System.Drawing.Size(100, 20)
        Me.LBLCANT.TabIndex = 94
        Me.LBLCANT.Text = "No. Pedido"
        Me.LBLCANT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LBLTI
        '
        Me.LBLTI.AutoSize = True
        Me.LBLTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTI.ForeColor = System.Drawing.Color.Navy
        Me.LBLTI.Location = New System.Drawing.Point(187, 73)
        Me.LBLTI.Name = "LBLTI"
        Me.LBLTI.Size = New System.Drawing.Size(100, 20)
        Me.LBLTI.TabIndex = 93
        Me.LBLTI.Text = "No. Pedido"
        '
        'LBLNP
        '
        Me.LBLNP.AutoSize = True
        Me.LBLNP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNP.ForeColor = System.Drawing.Color.Navy
        Me.LBLNP.Location = New System.Drawing.Point(187, 32)
        Me.LBLNP.Name = "LBLNP"
        Me.LBLNP.Size = New System.Drawing.Size(100, 20)
        Me.LBLNP.TabIndex = 92
        Me.LBLNP.Text = "No. Pedido"
        Me.LBLNP.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 425)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 24)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Tipo Merma:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(54, 391)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 24)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Solucion:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(71, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 24)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Producto:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(96, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 24)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(115, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Lote:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(74, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 24)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Cantidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(90, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 24)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Tienda:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(50, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 24)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "No. Pedido:"
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(604, 32)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 108
        Me.BTNBUSCAR.Text = "&B"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(609, 147)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 110
        Me.BTNCANCELAR.Text = "&E"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(609, 283)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 109
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmSoluciondeDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 517)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.CBAS)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.LBLOBS)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.LBLREG)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.CBTM)
        Me.Controls.Add(Me.CBSOL)
        Me.Controls.Add(Me.LBLFEC)
        Me.Controls.Add(Me.LBLPROD)
        Me.Controls.Add(Me.LBLUNI)
        Me.Controls.Add(Me.LBLLOTE)
        Me.Controls.Add(Me.LBLCANT)
        Me.Controls.Add(Me.LBLTI)
        Me.Controls.Add(Me.LBLNP)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSoluciondeDevolucion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solucion devolucion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBAS As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LBLOBS As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents LBLREG As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CBTM As System.Windows.Forms.ComboBox
    Friend WithEvents CBSOL As System.Windows.Forms.ComboBox
    Friend WithEvents LBLFEC As System.Windows.Forms.Label
    Friend WithEvents LBLPROD As System.Windows.Forms.Label
    Friend WithEvents LBLUNI As System.Windows.Forms.Label
    Friend WithEvents LBLLOTE As System.Windows.Forms.Label
    Friend WithEvents LBLCANT As System.Windows.Forms.Label
    Friend WithEvents LBLTI As System.Windows.Forms.Label
    Friend WithEvents LBLNP As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
End Class
