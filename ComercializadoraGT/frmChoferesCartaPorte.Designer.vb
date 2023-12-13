<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChoferesCartaPorte
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChoferesCartaPorte))
        Me.CBTF = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CBACT = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTPAIS = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTNRI = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTLIC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTRFC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTNOM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTNBUSCAR = New System.Windows.Forms.Button()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNELIMINAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TXTCLA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TTT = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBTF
        '
        Me.CBTF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTF.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTF.FormattingEnabled = True
        Me.CBTF.Items.AddRange(New Object() {"O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+", "ORH-", "ORH+", "RH-", "RH+", "UNIVERSAL", ""})
        Me.CBTF.Location = New System.Drawing.Point(156, 126)
        Me.CBTF.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBTF.Name = "CBTF"
        Me.CBTF.Size = New System.Drawing.Size(648, 30)
        Me.CBTF.TabIndex = 61
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 134)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 22)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Tipo Figura *"
        '
        'CBACT
        '
        Me.CBACT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBACT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBACT.FormattingEnabled = True
        Me.CBACT.Items.AddRange(New Object() {"No", "Si"})
        Me.CBACT.Location = New System.Drawing.Point(156, 341)
        Me.CBACT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CBACT.Name = "CBACT"
        Me.CBACT.Size = New System.Drawing.Size(95, 30)
        Me.CBACT.TabIndex = 68
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(74, 347)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 22)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Activo"
        '
        'TXTPAIS
        '
        Me.TXTPAIS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPAIS.Location = New System.Drawing.Point(156, 302)
        Me.TXTPAIS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTPAIS.MaxLength = 50
        Me.TXTPAIS.Name = "TXTPAIS"
        Me.TXTPAIS.ReadOnly = True
        Me.TXTPAIS.Size = New System.Drawing.Size(648, 29)
        Me.TXTPAIS.TabIndex = 67
        Me.TXTPAIS.Text = "MEX - México"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(96, 312)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 22)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Pais"
        '
        'TXTNRI
        '
        Me.TXTNRI.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNRI.Location = New System.Drawing.Point(156, 267)
        Me.TXTNRI.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNRI.MaxLength = 200
        Me.TXTNRI.Name = "TXTNRI"
        Me.TXTNRI.ReadOnly = True
        Me.TXTNRI.Size = New System.Drawing.Size(648, 29)
        Me.TXTNRI.TabIndex = 66
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 275)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 22)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Num Reg Id"
        '
        'TXTLIC
        '
        Me.TXTLIC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLIC.Location = New System.Drawing.Point(156, 233)
        Me.TXTLIC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTLIC.MaxLength = 10
        Me.TXTLIC.Name = "TXTLIC"
        Me.TXTLIC.Size = New System.Drawing.Size(648, 29)
        Me.TXTLIC.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 244)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 22)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Licencia *"
        '
        'TXTRFC
        '
        Me.TXTRFC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRFC.Location = New System.Drawing.Point(156, 198)
        Me.TXTRFC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTRFC.MaxLength = 200
        Me.TXTRFC.Name = "TXTRFC"
        Me.TXTRFC.Size = New System.Drawing.Size(648, 29)
        Me.TXTRFC.TabIndex = 64
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(83, 209)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 22)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "RFC *"
        '
        'TXTNOM
        '
        Me.TXTNOM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOM.Location = New System.Drawing.Point(156, 164)
        Me.TXTNOM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTNOM.MaxLength = 100
        Me.TXTNOM.Name = "TXTNOM"
        Me.TXTNOM.Size = New System.Drawing.Size(648, 29)
        Me.TXTNOM.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(62, 175)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Nombre"
        '
        'BTNBUSCAR
        '
        Me.BTNBUSCAR.BackColor = System.Drawing.Color.White
        Me.BTNBUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSCAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNBUSCAR.Image = CType(resources.GetObject("BTNBUSCAR.Image"), System.Drawing.Image)
        Me.BTNBUSCAR.Location = New System.Drawing.Point(304, 14)
        Me.BTNBUSCAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNBUSCAR.Name = "BTNBUSCAR"
        Me.BTNBUSCAR.Size = New System.Drawing.Size(113, 95)
        Me.BTNBUSCAR.TabIndex = 71
        Me.BTNBUSCAR.Text = "&b"
        Me.BTNBUSCAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(438, 423)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNCANCELAR.TabIndex = 70
        Me.BTNCANCELAR.Text = "&c"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(115, 421)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNELIMINAR.TabIndex = 62
        Me.BTNELIMINAR.Text = "&e"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        Me.BTNELIMINAR.Visible = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(293, 423)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(107, 98)
        Me.BTNGUARDAR.TabIndex = 69
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(653, 19)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(151, 97)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(156, 78)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXTCLA.MaxLength = 3
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(75, 29)
        Me.TXTCLA.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 87)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 22)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Clave"
        '
        'frmChoferesCartaPorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 537)
        Me.Controls.Add(Me.CBTF)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CBACT)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTPAIS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTNRI)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTLIC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTRFC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTNOM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTNBUSCAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChoferesCartaPorte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choferes Carta Porte"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBTF As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CBACT As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTPAIS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTNRI As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTLIC As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTRFC As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTNOM As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTNBUSCAR As Button
    Private WithEvents BTNCANCELAR As Button
    Friend WithEvents BTNELIMINAR As Button
    Friend WithEvents BTNGUARDAR As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TXTCLA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TTT As ToolTip
End Class
