<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarImpresora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarImpresora))
        Me.LBIMP = New System.Windows.Forms.ListBox
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LBIMP
        '
        Me.LBIMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBIMP.FormattingEnabled = True
        Me.LBIMP.ItemHeight = 31
        Me.LBIMP.Location = New System.Drawing.Point(12, 36)
        Me.LBIMP.Name = "LBIMP"
        Me.LBIMP.Size = New System.Drawing.Size(618, 500)
        Me.LBIMP.TabIndex = 0
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.BackColor = System.Drawing.Color.White
        Me.BTNACEPTAR.Image = CType(resources.GetObject("BTNACEPTAR.Image"), System.Drawing.Image)
        Me.BTNACEPTAR.Location = New System.Drawing.Point(670, 94)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 5
        Me.BTNACEPTAR.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.button_cancel
        Me.Button1.Location = New System.Drawing.Point(670, 370)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 112)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmSeleccionarImpresora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 567)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.LBIMP)
        Me.Name = "frmSeleccionarImpresora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar la Impresora"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LBIMP As System.Windows.Forms.ListBox
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
