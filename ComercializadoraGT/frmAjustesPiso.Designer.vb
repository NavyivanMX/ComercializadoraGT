<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjustesPiso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesPiso))
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.LBLEXIS = New System.Windows.Forms.Label()
        Me.TXTCANT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BTNBUS = New System.Windows.Forms.Button()
        Me.LBLPRO = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(406, 254)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNCANCELAR.TabIndex = 1223
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(195, 254)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 1222
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'LBLEXIS
        '
        Me.LBLEXIS.AutoSize = True
        Me.LBLEXIS.BackColor = System.Drawing.Color.Transparent
        Me.LBLEXIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXIS.ForeColor = System.Drawing.Color.Navy
        Me.LBLEXIS.Location = New System.Drawing.Point(122, 121)
        Me.LBLEXIS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLEXIS.Name = "LBLEXIS"
        Me.LBLEXIS.Size = New System.Drawing.Size(19, 20)
        Me.LBLEXIS.TabIndex = 1219
        Me.LBLEXIS.Text = "0"
        '
        'TXTCANT
        '
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(13, 200)
        Me.TXTCANT.Margin = New System.Windows.Forms.Padding(4)
        Me.TXTCANT.MaxLength = 10
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(148, 26)
        Me.TXTCANT.TabIndex = 1121
        Me.TXTCANT.Text = "0"
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 161)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 20)
        Me.Label7.TabIndex = 1120
        Me.Label7.Text = "Cantidad a ajustar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 121)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 20)
        Me.Label5.TabIndex = 1218
        Me.Label5.Text = "Existencia"
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Black
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBUS.Location = New System.Drawing.Point(13, 13)
        Me.BTNBUS.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(145, 43)
        Me.BTNBUS.TabIndex = 1224
        Me.BTNBUS.Text = "        F10 Buscar"
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'LBLPRO
        '
        Me.LBLPRO.AutoSize = True
        Me.LBLPRO.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRO.Location = New System.Drawing.Point(13, 74)
        Me.LBLPRO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLPRO.Name = "LBLPRO"
        Me.LBLPRO.Size = New System.Drawing.Size(186, 20)
        Me.LBLPRO.TabIndex = 1232
        Me.LBLPRO.Text = "Nombre del Producto"
        '
        'frmAjustesPiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 381)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.LBLPRO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.LBLEXIS)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjustesPiso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents LBLEXIS As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents LBLPRO As Label
End Class
