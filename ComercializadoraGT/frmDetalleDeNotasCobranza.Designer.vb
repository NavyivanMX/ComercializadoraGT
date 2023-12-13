<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleDeNotasCobranza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleDeNotasCobranza))
        Me.LBLA = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TXTNOTA = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LBLB = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBLE = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNIMPRIMIR = New System.Windows.Forms.Button
        Me.BTNMOSTRAR = New System.Windows.Forms.Button
        Me.LBLC = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LBLD = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LBLA
        '
        Me.LBLA.AutoSize = True
        Me.LBLA.BackColor = System.Drawing.Color.Transparent
        Me.LBLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLA.ForeColor = System.Drawing.Color.Navy
        Me.LBLA.Location = New System.Drawing.Point(191, 136)
        Me.LBLA.Name = "LBLA"
        Me.LBLA.Size = New System.Drawing.Size(19, 20)
        Me.LBLA.TabIndex = 1255
        Me.LBLA.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(111, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 1254
        Me.Label3.Text = "Cliente"
        '
        'TXTNOTA
        '
        Me.TXTNOTA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOTA.Location = New System.Drawing.Point(195, 57)
        Me.TXTNOTA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTNOTA.MaxLength = 100
        Me.TXTNOTA.Name = "TXTNOTA"
        Me.TXTNOTA.Size = New System.Drawing.Size(172, 25)
        Me.TXTNOTA.TabIndex = 1253
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(130, 20)
        Me.Label7.TabIndex = 1252
        Me.Label7.Text = "Folio Cobranza"
        '
        'LBLB
        '
        Me.LBLB.AutoSize = True
        Me.LBLB.BackColor = System.Drawing.Color.Transparent
        Me.LBLB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLB.ForeColor = System.Drawing.Color.Navy
        Me.LBLB.Location = New System.Drawing.Point(191, 167)
        Me.LBLB.Name = "LBLB"
        Me.LBLB.Size = New System.Drawing.Size(19, 20)
        Me.LBLB.TabIndex = 1251
        Me.LBLB.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 20)
        Me.Label2.TabIndex = 1250
        Me.Label2.Text = "Fecha de pago"
        '
        'LBLE
        '
        Me.LBLE.AutoSize = True
        Me.LBLE.BackColor = System.Drawing.Color.Transparent
        Me.LBLE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLE.ForeColor = System.Drawing.Color.Navy
        Me.LBLE.Location = New System.Drawing.Point(191, 330)
        Me.LBLE.Name = "LBLE"
        Me.LBLE.Size = New System.Drawing.Size(21, 24)
        Me.LBLE.TabIndex = 1249
        Me.LBLE.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(111, 334)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 1248
        Me.Label1.Text = "Total  $"
        '
        'BTNIMPRIMIR
        '
        Me.BTNIMPRIMIR.BackColor = System.Drawing.Color.White
        Me.BTNIMPRIMIR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNIMPRIMIR.Image = CType(resources.GetObject("BTNIMPRIMIR.Image"), System.Drawing.Image)
        Me.BTNIMPRIMIR.Location = New System.Drawing.Point(734, 23)
        Me.BTNIMPRIMIR.Name = "BTNIMPRIMIR"
        Me.BTNIMPRIMIR.Size = New System.Drawing.Size(92, 96)
        Me.BTNIMPRIMIR.TabIndex = 1246
        Me.BTNIMPRIMIR.UseVisualStyleBackColor = False
        '
        'BTNMOSTRAR
        '
        Me.BTNMOSTRAR.BackColor = System.Drawing.Color.White
        Me.BTNMOSTRAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNMOSTRAR.Image = CType(resources.GetObject("BTNMOSTRAR.Image"), System.Drawing.Image)
        Me.BTNMOSTRAR.Location = New System.Drawing.Point(613, 21)
        Me.BTNMOSTRAR.Name = "BTNMOSTRAR"
        Me.BTNMOSTRAR.Size = New System.Drawing.Size(92, 96)
        Me.BTNMOSTRAR.TabIndex = 1245
        Me.BTNMOSTRAR.UseVisualStyleBackColor = False
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.BackColor = System.Drawing.Color.Transparent
        Me.LBLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.ForeColor = System.Drawing.Color.Navy
        Me.LBLC.Location = New System.Drawing.Point(191, 256)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(19, 20)
        Me.LBLC.TabIndex = 1259
        Me.LBLC.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(62, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 20)
        Me.Label5.TabIndex = 1258
        Me.Label5.Text = "Tipo de Pago"
        '
        'LBLD
        '
        Me.LBLD.AutoSize = True
        Me.LBLD.BackColor = System.Drawing.Color.Transparent
        Me.LBLD.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLD.ForeColor = System.Drawing.Color.Navy
        Me.LBLD.Location = New System.Drawing.Point(191, 287)
        Me.LBLD.Name = "LBLD"
        Me.LBLD.Size = New System.Drawing.Size(19, 20)
        Me.LBLD.TabIndex = 1257
        Me.LBLD.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(107, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 20)
        Me.Label8.TabIndex = 1256
        Me.Label8.Text = "Cajer@"
        '
        'frmDetalleDeNotasCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 483)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLD)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBLA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTNOTA)
        Me.Controls.Add(Me.BTNIMPRIMIR)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBLB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBLE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTNMOSTRAR)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetalleDeNotasCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle De Notas de Cobranza"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLA As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTNOTA As System.Windows.Forms.TextBox
    Friend WithEvents BTNIMPRIMIR As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBLB As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBLE As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNMOSTRAR As System.Windows.Forms.Button
    Friend WithEvents LBLC As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LBLD As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
