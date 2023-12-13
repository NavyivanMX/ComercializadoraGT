<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracion))
        Me.TXTCOPIAS = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TXTCA = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTCVC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CHKPIV = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.CHKMB = New System.Windows.Forms.CheckBox
        Me.TXTRES = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CHKICC = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTSA = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TXTCOPIAS
        '
        Me.TXTCOPIAS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIAS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIAS.Location = New System.Drawing.Point(320, 29)
        Me.TXTCOPIAS.MaxLength = 2
        Me.TXTCOPIAS.Name = "TXTCOPIAS"
        Me.TXTCOPIAS.Size = New System.Drawing.Size(91, 29)
        Me.TXTCOPIAS.TabIndex = 1226
        Me.TXTCOPIAS.Text = "0"
        Me.TXTCOPIAS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(94, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(146, 22)
        Me.Label21.TabIndex = 1227
        Me.Label21.Text = "# Copias Venta"
        '
        'TXTCA
        '
        Me.TXTCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCA.Location = New System.Drawing.Point(320, 76)
        Me.TXTCA.MaxLength = 2
        Me.TXTCA.Name = "TXTCA"
        Me.TXTCA.Size = New System.Drawing.Size(91, 29)
        Me.TXTCA.TabIndex = 1526
        Me.TXTCA.Text = "0"
        Me.TXTCA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(94, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 22)
        Me.Label3.TabIndex = 1527
        Me.Label3.Text = "# Copias Abonos"
        '
        'TXTCVC
        '
        Me.TXTCVC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCVC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCVC.Location = New System.Drawing.Point(320, 122)
        Me.TXTCVC.MaxLength = 2
        Me.TXTCVC.Name = "TXTCVC"
        Me.TXTCVC.Size = New System.Drawing.Size(91, 29)
        Me.TXTCVC.TabIndex = 1528
        Me.TXTCVC.Text = "0"
        Me.TXTCVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 22)
        Me.Label1.TabIndex = 1529
        Me.Label1.Text = "# Copias Vta. Cred."
        '
        'CHKPIV
        '
        Me.CHKPIV.AutoSize = True
        Me.CHKPIV.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKPIV.Location = New System.Drawing.Point(98, 255)
        Me.CHKPIV.Margin = New System.Windows.Forms.Padding(2)
        Me.CHKPIV.Name = "CHKPIV"
        Me.CHKPIV.Size = New System.Drawing.Size(248, 24)
        Me.CHKPIV.TabIndex = 1530
        Me.CHKPIV.Text = "Preguntar al Imprimir Venta"
        Me.CHKPIV.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(344, 366)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 1532
        Me.Button1.Text = "&c"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(98, 366)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 80)
        Me.Button2.TabIndex = 1531
        Me.Button2.Text = "&G"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CHKMB
        '
        Me.CHKMB.AutoSize = True
        Me.CHKMB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKMB.Location = New System.Drawing.Point(98, 289)
        Me.CHKMB.Margin = New System.Windows.Forms.Padding(2)
        Me.CHKMB.Name = "CHKMB"
        Me.CHKMB.Size = New System.Drawing.Size(246, 24)
        Me.CHKMB.TabIndex = 1533
        Me.CHKMB.Text = "Botón búsqueda al agregar"
        Me.CHKMB.UseVisualStyleBackColor = True
        '
        'TXTRES
        '
        Me.TXTRES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRES.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRES.Location = New System.Drawing.Point(320, 166)
        Me.TXTRES.MaxLength = 10
        Me.TXTRES.Name = "TXTRES"
        Me.TXTRES.Size = New System.Drawing.Size(91, 29)
        Me.TXTRES.TabIndex = 1534
        Me.TXTRES.Text = "0"
        Me.TXTRES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 22)
        Me.Label2.TabIndex = 1535
        Me.Label2.Text = "Resguardo de:"
        '
        'CHKICC
        '
        Me.CHKICC.AutoSize = True
        Me.CHKICC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKICC.Location = New System.Drawing.Point(98, 323)
        Me.CHKICC.Margin = New System.Windows.Forms.Padding(2)
        Me.CHKICC.Name = "CHKICC"
        Me.CHKICC.Size = New System.Drawing.Size(244, 24)
        Me.CHKICC.TabIndex = 1536
        Me.CHKICC.Text = "Imprimir Copia Vta. Crédito"
        Me.CHKICC.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 22)
        Me.Label4.TabIndex = 1538
        Me.Label4.Text = "Servicio Adicional:"
        '
        'TXTSA
        '
        Me.TXTSA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTSA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSA.Location = New System.Drawing.Point(320, 210)
        Me.TXTSA.MaxLength = 10
        Me.TXTSA.Name = "TXTSA"
        Me.TXTSA.Size = New System.Drawing.Size(91, 29)
        Me.TXTSA.TabIndex = 1537
        Me.TXTSA.Text = "0"
        Me.TXTSA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 459)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTSA)
        Me.Controls.Add(Me.CHKICC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTRES)
        Me.Controls.Add(Me.CHKMB)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CHKPIV)
        Me.Controls.Add(Me.TXTCVC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTCA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTCOPIAS)
        Me.Controls.Add(Me.Label21)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTCOPIAS As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TXTCA As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTCVC As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CHKPIV As CheckBox
    Private WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CHKMB As System.Windows.Forms.CheckBox
    Friend WithEvents TXTRES As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CHKICC As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTSA As System.Windows.Forms.TextBox
End Class
