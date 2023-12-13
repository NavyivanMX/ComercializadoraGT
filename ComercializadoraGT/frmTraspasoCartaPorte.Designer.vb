<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTraspasoCartaPorte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasoCartaPorte))
        Me.CBVE = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBCHO = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTNAC = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTHORA = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTPOLMA = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTASEMA = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTMONTO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CBVE
        '
        Me.CBVE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBVE.FormattingEnabled = True
        Me.CBVE.Location = New System.Drawing.Point(133, 39)
        Me.CBVE.Margin = New System.Windows.Forms.Padding(4)
        Me.CBVE.Name = "CBVE"
        Me.CBVE.Size = New System.Drawing.Size(588, 28)
        Me.CBVE.TabIndex = 297
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(31, 43)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 24)
        Me.Label10.TabIndex = 298
        Me.Label10.Text = "Vehículo"
        '
        'CBCHO
        '
        Me.CBCHO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCHO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCHO.FormattingEnabled = True
        Me.CBCHO.Location = New System.Drawing.Point(133, 95)
        Me.CBCHO.Margin = New System.Windows.Forms.Padding(4)
        Me.CBCHO.Name = "CBCHO"
        Me.CBCHO.Size = New System.Drawing.Size(588, 28)
        Me.CBCHO.TabIndex = 299
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 101)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 300
        Me.Label1.Text = "Chofer"
        '
        'DTNAC
        '
        Me.DTNAC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTNAC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTNAC.Location = New System.Drawing.Point(113, 187)
        Me.DTNAC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTNAC.Name = "DTNAC"
        Me.DTNAC.Size = New System.Drawing.Size(171, 29)
        Me.DTNAC.TabIndex = 301
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(109, 160)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 22)
        Me.Label2.TabIndex = 302
        Me.Label2.Text = "Fecha de Salida"
        '
        'DTHORA
        '
        Me.DTHORA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTHORA.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTHORA.Location = New System.Drawing.Point(480, 187)
        Me.DTHORA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTHORA.Name = "DTHORA"
        Me.DTHORA.ShowUpDown = True
        Me.DTHORA.Size = New System.Drawing.Size(171, 29)
        Me.DTHORA.TabIndex = 303
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(476, 160)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 22)
        Me.Label3.TabIndex = 304
        Me.Label3.Text = "Hora de Salida"
        '
        'TXTPOLMA
        '
        Me.TXTPOLMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOLMA.Location = New System.Drawing.Point(479, 277)
        Me.TXTPOLMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPOLMA.MaxLength = 200
        Me.TXTPOLMA.Name = "TXTPOLMA"
        Me.TXTPOLMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTPOLMA.TabIndex = 306
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(479, 250)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 22)
        Me.Label12.TabIndex = 308
        Me.Label12.Text = "Poliza Carga"
        '
        'TXTASEMA
        '
        Me.TXTASEMA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTASEMA.Location = New System.Drawing.Point(13, 277)
        Me.TXTASEMA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTASEMA.MaxLength = 200
        Me.TXTASEMA.Name = "TXTASEMA"
        Me.TXTASEMA.Size = New System.Drawing.Size(341, 29)
        Me.TXTASEMA.TabIndex = 305
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 250)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(190, 22)
        Me.Label13.TabIndex = 307
        Me.Label13.Text = "Aseguradora Carga"
        '
        'TXTMONTO
        '
        Me.TXTMONTO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMONTO.Location = New System.Drawing.Point(17, 363)
        Me.TXTMONTO.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTMONTO.MaxLength = 10
        Me.TXTMONTO.Name = "TXTMONTO"
        Me.TXTMONTO.Size = New System.Drawing.Size(341, 29)
        Me.TXTMONTO.TabIndex = 309
        Me.TXTMONTO.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 336)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 22)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "Monto Asegurado"
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(371, 438)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 311
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'frmTraspasoCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 563)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.TXTMONTO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTPOLMA)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTASEMA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DTHORA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTNAC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBCHO)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBVE)
        Me.Controls.Add(Me.Label10)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraspasoCartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información para Traslado Carta Porte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBVE As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CBCHO As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTNAC As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DTHORA As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTPOLMA As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXTASEMA As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXTMONTO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BTNGUARDAR As Button
    Friend WithEvents BTNINFO As Button
End Class
