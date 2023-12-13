<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionaCliente))
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        Me.BTNBUSCAR = New System.Windows.Forms.Button
        Me.TXTC = New System.Windows.Forms.TextBox
        Me.LBLC = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 24)
        Me.Label1.TabIndex = 1075
        Me.Label1.Text = "Cliente"
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Image = CType(resources.GetObject("BTNACEPTAR.Image"), System.Drawing.Image)
        Me.BTNACEPTAR.Location = New System.Drawing.Point(158, 158)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 2
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(381, 12)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSCAR.TabIndex = 0
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'TXTC
        '
        Me.TXTC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTC.Location = New System.Drawing.Point(147, 51)
        Me.TXTC.MaxLength = 30
        Me.TXTC.Name = "TXTC"
        Me.TXTC.Size = New System.Drawing.Size(151, 38)
        Me.TXTC.TabIndex = 1
        Me.TXTC.Text = "0"
        Me.TXTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLC
        '
        Me.LBLC.AutoSize = True
        Me.LBLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLC.Location = New System.Drawing.Point(24, 108)
        Me.LBLC.Name = "LBLC"
        Me.LBLC.Size = New System.Drawing.Size(16, 24)
        Me.LBLC.TabIndex = 1079
        Me.LBLC.Text = "."
        '
        'frmSeleccionaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 282)
        Me.Controls.Add(Me.LBLC)
        Me.Controls.Add(Me.TXTC)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionaCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar al Cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNBUSCAR As System.Windows.Forms.Button
    Friend WithEvents TXTC As System.Windows.Forms.TextBox
    Friend WithEvents LBLC As System.Windows.Forms.Label
End Class
