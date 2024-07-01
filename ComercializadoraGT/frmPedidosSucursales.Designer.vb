<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidosSucursales
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosSucursales))
        Me.LBLNOMUNI = New System.Windows.Forms.Label
        Me.LBLEXIS = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LBLCOSTO = New System.Windows.Forms.Label
        Me.CBPROD = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.CBGRU = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.LBLTP = New System.Windows.Forms.Label
        Me.CBTP = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTCANT = New System.Windows.Forms.TextBox
        Me.LBLTIME = New System.Windows.Forms.Label
        Me.LBLPED = New System.Windows.Forms.TextBox
        Me.LBLPRECIO = New System.Windows.Forms.Label
        Me.CBUNI = New System.Windows.Forms.ComboBox
        Me.CBSUC = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.DTFECHA = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV = New System.Windows.Forms.DataGridView
        Me.LBLCUANTOS = New System.Windows.Forms.Label
        Me.LBLTOT = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.BTNGUARDAR = New System.Windows.Forms.Button
        Me.BTNELIMINAR = New System.Windows.Forms.Button
        Me.BTNCANCELAR = New System.Windows.Forms.Button
        Me.BTNBUSBD = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.BTNAGREGAR = New System.Windows.Forms.Button
        Me.BTNBP = New System.Windows.Forms.Button
        Me.BTNSF = New System.Windows.Forms.Button
        Me.BTNQUITAR = New System.Windows.Forms.Button
        Me.BTNACT = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TXTCLA = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLNOMUNI
        '
        Me.LBLNOMUNI.AutoSize = True
        Me.LBLNOMUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNOMUNI.ForeColor = System.Drawing.Color.Green
        Me.LBLNOMUNI.Location = New System.Drawing.Point(607, 118)
        Me.LBLNOMUNI.Name = "LBLNOMUNI"
        Me.LBLNOMUNI.Size = New System.Drawing.Size(21, 24)
        Me.LBLNOMUNI.TabIndex = 1089
        Me.LBLNOMUNI.Text = "0"
        '
        'LBLEXIS
        '
        Me.LBLEXIS.AutoSize = True
        Me.LBLEXIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXIS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLEXIS.Location = New System.Drawing.Point(607, 94)
        Me.LBLEXIS.Name = "LBLEXIS"
        Me.LBLEXIS.Size = New System.Drawing.Size(21, 24)
        Me.LBLEXIS.TabIndex = 1088
        Me.LBLEXIS.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(603, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 18)
        Me.Label3.TabIndex = 1087
        Me.Label3.Text = "Existencia Tienda Piso"
        '
        'LBLCOSTO
        '
        Me.LBLCOSTO.AutoSize = True
        Me.LBLCOSTO.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOSTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOSTO.ForeColor = System.Drawing.Color.Navy
        Me.LBLCOSTO.Location = New System.Drawing.Point(282, 189)
        Me.LBLCOSTO.Name = "LBLCOSTO"
        Me.LBLCOSTO.Size = New System.Drawing.Size(48, 16)
        Me.LBLCOSTO.TabIndex = 1080
        Me.LBLCOSTO.Text = "Costo"
        Me.LBLCOSTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBPROD
        '
        Me.CBPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPROD.FormattingEnabled = True
        Me.CBPROD.Location = New System.Drawing.Point(123, 123)
        Me.CBPROD.Name = "CBPROD"
        Me.CBPROD.Size = New System.Drawing.Size(380, 24)
        Me.CBPROD.TabIndex = 1074
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 1077
        Me.Label7.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(122, 94)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(381, 24)
        Me.CBGRU.TabIndex = 1073
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(61, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 16)
        Me.Label8.TabIndex = 1075
        Me.Label8.Text = "Grupo"
        '
        'LBLTP
        '
        Me.LBLTP.AutoSize = True
        Me.LBLTP.BackColor = System.Drawing.Color.Transparent
        Me.LBLTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTP.Location = New System.Drawing.Point(591, 36)
        Me.LBLTP.Name = "LBLTP"
        Me.LBLTP.Size = New System.Drawing.Size(0, 16)
        Me.LBLTP.TabIndex = 1072
        '
        'CBTP
        '
        Me.CBTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTP.FormattingEnabled = True
        Me.CBTP.Location = New System.Drawing.Point(177, 25)
        Me.CBTP.Name = "CBTP"
        Me.CBTP.Size = New System.Drawing.Size(326, 24)
        Me.CBTP.TabIndex = 1056
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(630, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 1071
        Me.Label6.Text = "Unidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(500, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 1068
        Me.Label1.Text = "Cantidad"
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(486, 181)
        Me.TXTCANT.MaxLength = 8
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(91, 26)
        Me.TXTCANT.TabIndex = 1057
        Me.TXTCANT.Text = "0"
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLTIME
        '
        Me.LBLTIME.AutoSize = True
        Me.LBLTIME.BackColor = System.Drawing.Color.Transparent
        Me.LBLTIME.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTIME.Location = New System.Drawing.Point(781, 128)
        Me.LBLTIME.Name = "LBLTIME"
        Me.LBLTIME.Size = New System.Drawing.Size(0, 16)
        Me.LBLTIME.TabIndex = 1066
        Me.LBLTIME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLPED
        '
        Me.LBLPED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LBLPED.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPED.Location = New System.Drawing.Point(27, 25)
        Me.LBLPED.MaxLength = 10
        Me.LBLPED.Name = "LBLPED"
        Me.LBLPED.ReadOnly = True
        Me.LBLPED.Size = New System.Drawing.Size(144, 26)
        Me.LBLPED.TabIndex = 1065
        '
        'LBLPRECIO
        '
        Me.LBLPRECIO.AutoSize = True
        Me.LBLPRECIO.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRECIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRECIO.ForeColor = System.Drawing.Color.Navy
        Me.LBLPRECIO.Location = New System.Drawing.Point(423, 189)
        Me.LBLPRECIO.Name = "LBLPRECIO"
        Me.LBLPRECIO.Size = New System.Drawing.Size(53, 16)
        Me.LBLPRECIO.TabIndex = 1064
        Me.LBLPRECIO.Text = "Precio"
        Me.LBLPRECIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CBUNI
        '
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Items.AddRange(New Object() {"YDS", "MTS", "PZA"})
        Me.CBUNI.Location = New System.Drawing.Point(596, 183)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(142, 24)
        Me.CBUNI.TabIndex = 1058
        '
        'CBSUC
        '
        Me.CBSUC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBSUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBSUC.FormattingEnabled = True
        Me.CBSUC.Location = New System.Drawing.Point(122, 64)
        Me.CBSUC.Name = "CBSUC"
        Me.CBSUC.Size = New System.Drawing.Size(381, 24)
        Me.CBSUC.TabIndex = 1055
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(58, 70)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 16)
        Me.Label12.TabIndex = 1059
        Me.Label12.Text = "Tienda"
        '
        'DTFECHA
        '
        Me.DTFECHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHA.Location = New System.Drawing.Point(619, 23)
        Me.DTFECHA.Name = "DTFECHA"
        Me.DTFECHA.Size = New System.Drawing.Size(119, 26)
        Me.DTFECHA.TabIndex = 1062
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(554, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 1061
        Me.Label11.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1060
        Me.Label2.Text = "No de Pedido"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.Location = New System.Drawing.Point(15, 237)
        Me.DGV.Name = "DGV"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV.Size = New System.Drawing.Size(771, 395)
        Me.DGV.TabIndex = 1099
        '
        'LBLCUANTOS
        '
        Me.LBLCUANTOS.AutoSize = True
        Me.LBLCUANTOS.BackColor = System.Drawing.Color.Transparent
        Me.LBLCUANTOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCUANTOS.Location = New System.Drawing.Point(262, 591)
        Me.LBLCUANTOS.Name = "LBLCUANTOS"
        Me.LBLCUANTOS.Size = New System.Drawing.Size(68, 16)
        Me.LBLCUANTOS.TabIndex = 1095
        Me.LBLCUANTOS.Text = "Sucursal"
        '
        'LBLTOT
        '
        Me.LBLTOT.AutoSize = True
        Me.LBLTOT.BackColor = System.Drawing.Color.Transparent
        Me.LBLTOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTOT.ForeColor = System.Drawing.Color.Blue
        Me.LBLTOT.Location = New System.Drawing.Point(572, 643)
        Me.LBLTOT.Name = "LBLTOT"
        Me.LBLTOT.Size = New System.Drawing.Size(21, 24)
        Me.LBLTOT.TabIndex = 1094
        Me.LBLTOT.Text = "0"
        Me.LBLTOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(518, 649)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 1093
        Me.Label5.Text = "Total:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(282, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 1106
        Me.Label4.Text = "Costo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(423, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 16)
        Me.Label9.TabIndex = 1107
        Me.Label9.Text = "Precio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.Location = New System.Drawing.Point(801, 552)
        Me.BTNGUARDAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNGUARDAR.TabIndex = 1105
        Me.BTNGUARDAR.Text = "&G"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNELIMINAR
        '
        Me.BTNELIMINAR.BackColor = System.Drawing.Color.White
        Me.BTNELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNELIMINAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNELIMINAR.Image = CType(resources.GetObject("BTNELIMINAR.Image"), System.Drawing.Image)
        Me.BTNELIMINAR.Location = New System.Drawing.Point(799, 445)
        Me.BTNELIMINAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNELIMINAR.Name = "BTNELIMINAR"
        Me.BTNELIMINAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNELIMINAR.TabIndex = 1104
        Me.BTNELIMINAR.Text = "&E"
        Me.BTNELIMINAR.UseVisualStyleBackColor = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Transparent
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.Location = New System.Drawing.Point(910, 62)
        Me.BTNCANCELAR.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNCANCELAR.TabIndex = 1103
        Me.BTNCANCELAR.Text = "&E"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNBUSBD
        '
        Me.BTNBUSBD.BackColor = System.Drawing.Color.White
        Me.BTNBUSBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUSBD.ForeColor = System.Drawing.Color.Red
        Me.BTNBUSBD.Image = CType(resources.GetObject("BTNBUSBD.Image"), System.Drawing.Image)
        Me.BTNBUSBD.Location = New System.Drawing.Point(794, 62)
        Me.BTNBUSBD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BTNBUSBD.Name = "BTNBUSBD"
        Me.BTNBUSBD.Size = New System.Drawing.Size(85, 77)
        Me.BTNBUSBD.TabIndex = 1102
        Me.BTNBUSBD.Text = "BD"
        Me.BTNBUSBD.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(900, 340)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 80)
        Me.Button3.TabIndex = 1101
        Me.Button3.Text = "10 PEDI2"
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.SystemColors.Control
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.Location = New System.Drawing.Point(799, 239)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(80, 78)
        Me.BTNAGREGAR.TabIndex = 1100
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'BTNBP
        '
        Me.BTNBP.Image = CType(resources.GetObject("BTNBP.Image"), System.Drawing.Image)
        Me.BTNBP.Location = New System.Drawing.Point(902, 443)
        Me.BTNBP.Name = "BTNBP"
        Me.BTNBP.Size = New System.Drawing.Size(78, 80)
        Me.BTNBP.TabIndex = 1097
        Me.BTNBP.UseVisualStyleBackColor = True
        '
        'BTNSF
        '
        Me.BTNSF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSF.ForeColor = System.Drawing.Color.Blue
        Me.BTNSF.Image = CType(resources.GetObject("BTNSF.Image"), System.Drawing.Image)
        Me.BTNSF.Location = New System.Drawing.Point(900, 550)
        Me.BTNSF.Name = "BTNSF"
        Me.BTNSF.Size = New System.Drawing.Size(80, 80)
        Me.BTNSF.TabIndex = 1096
        Me.BTNSF.UseVisualStyleBackColor = True
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.Location = New System.Drawing.Point(801, 340)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(80, 80)
        Me.BTNQUITAR.TabIndex = 1090
        '
        'BTNACT
        '
        Me.BTNACT.Image = Global.ComercializadoraGTFernandoSr.My.Resources.Resources.ACTUALIZAR
        Me.BTNACT.Location = New System.Drawing.Point(902, 237)
        Me.BTNACT.Name = "BTNACT"
        Me.BTNACT.Size = New System.Drawing.Size(75, 74)
        Me.BTNACT.TabIndex = 1085
        Me.BTNACT.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(58, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 16)
        Me.Label10.TabIndex = 1108
        Me.Label10.Text = "F10 Buscar Producto"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 16)
        Me.Label13.TabIndex = 1110
        Me.Label13.Text = "Código de Barra"
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(15, 181)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCLA.MaxLength = 50
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(243, 29)
        Me.TXTCLA.TabIndex = 1127
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(185, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(116, 16)
        Me.Label14.TabIndex = 1128
        Me.Label14.Text = "Tipo de Pedido"
        '
        'frmPedidosSucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 679)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNELIMINAR)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNBUSBD)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.BTNBP)
        Me.Controls.Add(Me.BTNSF)
        Me.Controls.Add(Me.LBLCUANTOS)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.LBLTOT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLNOMUNI)
        Me.Controls.Add(Me.LBLEXIS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTNACT)
        Me.Controls.Add(Me.LBLCOSTO)
        Me.Controls.Add(Me.CBPROD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBLTP)
        Me.Controls.Add(Me.CBTP)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.LBLTIME)
        Me.Controls.Add(Me.LBLPED)
        Me.Controls.Add(Me.LBLPRECIO)
        Me.Controls.Add(Me.CBUNI)
        Me.Controls.Add(Me.CBSUC)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DTFECHA)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidosSucursales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Sucursales"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLNOMUNI As System.Windows.Forms.Label
    Friend WithEvents LBLEXIS As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BTNACT As System.Windows.Forms.Button
    Friend WithEvents LBLCOSTO As System.Windows.Forms.Label
    Friend WithEvents CBPROD As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLTP As System.Windows.Forms.Label
    Friend WithEvents CBTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents LBLTIME As System.Windows.Forms.Label
    Friend WithEvents LBLPED As System.Windows.Forms.TextBox
    Friend WithEvents LBLPRECIO As System.Windows.Forms.Label
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents CBSUC As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DTFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents BTNBP As System.Windows.Forms.Button
    Friend WithEvents BTNSF As System.Windows.Forms.Button
    Friend WithEvents LBLCUANTOS As System.Windows.Forms.Label
    Private WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents LBLTOT As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUSBD As System.Windows.Forms.Button
    Private WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNELIMINAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTCLA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
