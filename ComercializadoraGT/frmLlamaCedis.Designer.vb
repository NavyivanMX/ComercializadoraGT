<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLlamaCedis
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBALM = New System.Windows.Forms.ComboBox
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(232, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 37)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Seleccionar Almacen"
        '
        'CBALM
        '
        Me.CBALM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBALM.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Location = New System.Drawing.Point(28, 156)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(774, 39)
        Me.CBALM.TabIndex = 68
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Image = Global.ComercializadoraGT.My.Resources.Resources.button_ok
        Me.BTNACEPTAR.Location = New System.Drawing.Point(333, 289)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 398
        '
        'frmLlamaCedis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 462)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLlamaCedis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cedis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBALM As System.Windows.Forms.ComboBox
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
End Class
