<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioCodigo
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
        Me.TXTCLA = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLNPA = New System.Windows.Forms.Label
        Me.LBLNPN = New System.Windows.Forms.Label
        Me.TXTCLN = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.LBLPPA = New System.Windows.Forms.Label
        Me.LBLPPN = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(168, 51)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCLA.MaxLength = 100
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(267, 25)
        Me.TXTCLA.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Código Anterior"
        '
        'LBLNPA
        '
        Me.LBLNPA.AutoSize = True
        Me.LBLNPA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNPA.Location = New System.Drawing.Point(165, 90)
        Me.LBLNPA.Name = "LBLNPA"
        Me.LBLNPA.Size = New System.Drawing.Size(75, 17)
        Me.LBLNPA.TabIndex = 34
        Me.LBLNPA.Text = "Producto"
        '
        'LBLNPN
        '
        Me.LBLNPN.AutoSize = True
        Me.LBLNPN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNPN.Location = New System.Drawing.Point(165, 184)
        Me.LBLNPN.Name = "LBLNPN"
        Me.LBLNPN.Size = New System.Drawing.Size(75, 17)
        Me.LBLNPN.TabIndex = 37
        Me.LBLNPN.Text = "Producto"
        '
        'TXTCLN
        '
        Me.TXTCLN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLN.Location = New System.Drawing.Point(168, 145)
        Me.TXTCLN.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCLN.MaxLength = 100
        Me.TXTCLN.Name = "TXTCLN"
        Me.TXTCLN.Size = New System.Drawing.Size(267, 25)
        Me.TXTCLN.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 17)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Código a Cambiar"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.Startup_Wizard
        Me.Button1.Location = New System.Drawing.Point(583, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 80)
        Me.Button1.TabIndex = 1354
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.xeyes1
        Me.Button2.Location = New System.Drawing.Point(467, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 46)
        Me.Button2.TabIndex = 1355
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Black
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.xeyes1
        Me.Button3.Location = New System.Drawing.Point(467, 134)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(45, 46)
        Me.Button3.TabIndex = 1356
        Me.Button3.UseVisualStyleBackColor = False
        '
        'LBLPPA
        '
        Me.LBLPPA.AutoSize = True
        Me.LBLPPA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPPA.Location = New System.Drawing.Point(165, 108)
        Me.LBLPPA.Name = "LBLPPA"
        Me.LBLPPA.Size = New System.Drawing.Size(56, 17)
        Me.LBLPPA.TabIndex = 1357
        Me.LBLPPA.Text = "Precio"
        '
        'LBLPPN
        '
        Me.LBLPPN.AutoSize = True
        Me.LBLPPN.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPPN.Location = New System.Drawing.Point(165, 201)
        Me.LBLPPN.Name = "LBLPPN"
        Me.LBLPPN.Size = New System.Drawing.Size(56, 17)
        Me.LBLPPN.TabIndex = 1358
        Me.LBLPPN.Text = "Precio"
        '
        'frmCambioCodigo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 297)
        Me.Controls.Add(Me.LBLPPN)
        Me.Controls.Add(Me.LBLPPA)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LBLNPN)
        Me.Controls.Add(Me.TXTCLN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LBLNPA)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioCodigo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio-Generación de Código"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTCLA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLNPA As System.Windows.Forms.Label
    Friend WithEvents LBLNPN As System.Windows.Forms.Label
    Friend WithEvents TXTCLN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LBLPPA As System.Windows.Forms.Label
    Friend WithEvents LBLPPN As System.Windows.Forms.Label
End Class
