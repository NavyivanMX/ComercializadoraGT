<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesNotaCredito
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
        Me.TXTCOM = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CBMP = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CBFP = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBCP = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTAR = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BTNACEPTAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TXTCOM
        '
        Me.TXTCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOM.Location = New System.Drawing.Point(31, 215)
        Me.TXTCOM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCOM.MaxLength = 5000
        Me.TXTCOM.Multiline = True
        Me.TXTCOM.Name = "TXTCOM"
        Me.TXTCOM.Size = New System.Drawing.Size(877, 77)
        Me.TXTCOM.TabIndex = 109
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 191)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 20)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Comentario"
        '
        'CBMP
        '
        Me.CBMP.BackColor = System.Drawing.Color.Cyan
        Me.CBMP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBMP.FormattingEnabled = True
        Me.CBMP.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBMP.Location = New System.Drawing.Point(31, 49)
        Me.CBMP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBMP.Name = "CBMP"
        Me.CBMP.Size = New System.Drawing.Size(405, 28)
        Me.CBMP.TabIndex = 114
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(85, 23)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 20)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Método de Pago"
        '
        'CBFP
        '
        Me.CBFP.BackColor = System.Drawing.Color.Cyan
        Me.CBFP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBFP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBFP.FormattingEnabled = True
        Me.CBFP.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBFP.Location = New System.Drawing.Point(505, 49)
        Me.CBFP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBFP.Name = "CBFP"
        Me.CBFP.Size = New System.Drawing.Size(403, 28)
        Me.CBFP.TabIndex = 112
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(623, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Forma de Pago"
        '
        'CBCP
        '
        Me.CBCP.BackColor = System.Drawing.Color.Cyan
        Me.CBCP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCP.FormattingEnabled = True
        Me.CBCP.Items.AddRange(New Object() {"Aguascalientes ", "Baja California ", "Baja California Sur ", "Campeche ", "Chiapas ", "Chihuahua ", "Coahuila ", "Colima ", "Distrito Federal ", "Durango ", "Estado de México ", "Guanajuato ", "Guerrero ", "Hidalgo ", "Jalisco ", "Michoacán ", "Morelos ", "Nayarit ", "Nuevo León ", "Oaxaca ", "Puebla ", "Querétaro ", "Quintana Roo ", "San Luis Potosí ", "Sinaloa ", "Sonora ", "Tabasco ", "Tamaulipas ", "Tlaxcala ", "Veracruz ", "Yucatán ", "Zacatecas "})
        Me.CBCP.Location = New System.Drawing.Point(33, 124)
        Me.CBCP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBCP.Name = "CBCP"
        Me.CBCP.Size = New System.Drawing.Size(403, 28)
        Me.CBCP.TabIndex = 116
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 101)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 20)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Condiciones de Pago"
        '
        'TXTTAR
        '
        Me.TXTTAR.BackColor = System.Drawing.Color.Cyan
        Me.TXTTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTAR.Location = New System.Drawing.Point(692, 144)
        Me.TXTTAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTTAR.MaxLength = 4
        Me.TXTTAR.Name = "TXTTAR"
        Me.TXTTAR.Size = New System.Drawing.Size(128, 26)
        Me.TXTTAR.TabIndex = 1118
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(665, 95)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(164, 44)
        Me.Label16.TabIndex = 1119
        Me.Label16.Text = "4 dígitos Tarjeta o Cheque"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.button_ok
        Me.BTNACEPTAR.Location = New System.Drawing.Point(384, 311)
        Me.BTNACEPTAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(164, 138)
        Me.BTNACEPTAR.TabIndex = 1120
        '
        'frmOpcionesNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTNACEPTAR)
        Me.Controls.Add(Me.TXTTAR)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CBCP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTCOM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBMP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBFP)
        Me.Controls.Add(Me.Label4)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpcionesNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de Nota de Crédito"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTCOM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CBMP As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CBFP As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBCP As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTTAR As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BTNACEPTAR As System.Windows.Forms.Button
End Class
