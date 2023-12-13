<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensajeFactura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensajeFactura))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PB1 = New System.Windows.Forms.PictureBox
        Me.BTNACEPTAR = New System.Windows.Forms.Button
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 225)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(132, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mensaje IMPORTANTE"
        '
        'PB1
        '
        Me.PB1.Image = CType(resources.GetObject("PB1.Image"), System.Drawing.Image)
        Me.PB1.Location = New System.Drawing.Point(424, 21)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(80, 81)
        Me.PB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB1.TabIndex = 43
        Me.PB1.TabStop = False
        Me.PB1.Visible = False
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Image = CType(resources.GetObject("BTNACEPTAR.Image"), System.Drawing.Image)
        Me.BTNACEPTAR.Location = New System.Drawing.Point(264, 355)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(123, 112)
        Me.BTNACEPTAR.TabIndex = 44
        '
        'frmMensajeFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(656, 477)
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.PB1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMensajeFactura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje Importante"
        CType(Me.PB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PB1 As System.Windows.Forms.PictureBox
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
End Class
