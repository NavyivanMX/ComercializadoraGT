<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompras))
        Me.LBLDES = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LBLTF = New System.Windows.Forms.Label()
        Me.TXTCANT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTCOS = New System.Windows.Forms.TextBox()
        Me.LBLCOS = New System.Windows.Forms.Label()
        Me.LBLPRO = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTFECHA = New System.Windows.Forms.DateTimePicker()
        Me.CBPROD = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBGRU = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTNOCOMPRA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LBLNOTFAC = New System.Windows.Forms.Label()
        Me.LBLFACNOT = New System.Windows.Forms.Label()
        Me.LBLCOSTO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LBLPRE = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNQUITAR = New System.Windows.Forms.Button()
        Me.BTNAGREGAR = New System.Windows.Forms.Button()
        Me.BTNGUARDAR = New System.Windows.Forms.Button()
        Me.BTNBUS = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBUNI = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLTI = New System.Windows.Forms.Label()
        Me.LBLTS = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTCLA = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTDESC = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTPED = New System.Windows.Forms.TextBox()
        Me.CHK1 = New System.Windows.Forms.CheckBox()
        Me.CBALM = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LBLNPRO = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLDES
        '
        Me.LBLDES.AutoSize = True
        Me.LBLDES.BackColor = System.Drawing.Color.Transparent
        Me.LBLDES.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDES.ForeColor = System.Drawing.Color.Navy
        Me.LBLDES.Location = New System.Drawing.Point(8, 15)
        Me.LBLDES.Name = "LBLDES"
        Me.LBLDES.Size = New System.Drawing.Size(96, 17)
        Me.LBLDES.TabIndex = 1095
        Me.LBLDES.Text = "Descripción"
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSkyBlue
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column3, Me.Column8, Me.Column7, Me.Column5, Me.Column4})
        Me.DGV.Location = New System.Drawing.Point(23, 322)
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.DGV.Size = New System.Drawing.Size(964, 292)
        Me.DGV.TabIndex = 1094
        '
        'Column6
        '
        Me.Column6.HeaderText = "LOTE"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "GRUPO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "PRODUCTO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column3.HeaderText = "CANTIDAD"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "UNIDAD"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle15.Format = "C2"
        DataGridViewCellStyle15.NullValue = "0"
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle15
        Me.Column7.HeaderText = "DESCUENTO"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "C2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column5.HeaderText = "COSTO UNITARIO"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "C2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column4.HeaderText = "COSTO TOTAL"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'LBLTF
        '
        Me.LBLTF.AutoSize = True
        Me.LBLTF.BackColor = System.Drawing.Color.Transparent
        Me.LBLTF.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTF.ForeColor = System.Drawing.Color.Navy
        Me.LBLTF.Location = New System.Drawing.Point(875, 617)
        Me.LBLTF.Name = "LBLTF"
        Me.LBLTF.Size = New System.Drawing.Size(25, 25)
        Me.LBLTF.TabIndex = 1087
        Me.LBLTF.Text = "0"
        '
        'TXTCANT
        '
        Me.TXTCANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCANT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCANT.Location = New System.Drawing.Point(180, 289)
        Me.TXTCANT.MaxLength = 8
        Me.TXTCANT.Name = "TXTCANT"
        Me.TXTCANT.Size = New System.Drawing.Size(100, 22)
        Me.TXTCANT.TabIndex = 2
        Me.TXTCANT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(184, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 1082
        Me.Label7.Text = "Cantidad"
        '
        'TXTCOS
        '
        Me.TXTCOS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOS.Location = New System.Drawing.Point(713, 289)
        Me.TXTCOS.MaxLength = 20
        Me.TXTCOS.Name = "TXTCOS"
        Me.TXTCOS.Size = New System.Drawing.Size(133, 22)
        Me.TXTCOS.TabIndex = 5
        Me.TXTCOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLCOS
        '
        Me.LBLCOS.AutoSize = True
        Me.LBLCOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOS.Location = New System.Drawing.Point(747, 270)
        Me.LBLCOS.Name = "LBLCOS"
        Me.LBLCOS.Size = New System.Drawing.Size(48, 16)
        Me.LBLCOS.TabIndex = 1080
        Me.LBLCOS.Text = "Total "
        '
        'LBLPRO
        '
        Me.LBLPRO.AutoSize = True
        Me.LBLPRO.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRO.ForeColor = System.Drawing.Color.Navy
        Me.LBLPRO.Location = New System.Drawing.Point(138, 42)
        Me.LBLPRO.Name = "LBLPRO"
        Me.LBLPRO.Size = New System.Drawing.Size(84, 17)
        Me.LBLPRO.TabIndex = 1079
        Me.LBLPRO.Text = "proveedor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(31, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 18)
        Me.Label9.TabIndex = 1078
        Me.Label9.Text = "Proveedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(250, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 16)
        Me.Label5.TabIndex = 1077
        Me.Label5.Text = "Fecha"
        Me.Label5.Visible = False
        '
        'DTFECHA
        '
        Me.DTFECHA.Enabled = False
        Me.DTFECHA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTFECHA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTFECHA.Location = New System.Drawing.Point(307, 14)
        Me.DTFECHA.Name = "DTFECHA"
        Me.DTFECHA.Size = New System.Drawing.Size(125, 25)
        Me.DTFECHA.TabIndex = 1072
        Me.DTFECHA.Visible = False
        '
        'CBPROD
        '
        Me.CBPROD.BackColor = System.Drawing.Color.White
        Me.CBPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPROD.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPROD.FormattingEnabled = True
        Me.CBPROD.Location = New System.Drawing.Point(260, 151)
        Me.CBPROD.Name = "CBPROD"
        Me.CBPROD.Size = New System.Drawing.Size(304, 25)
        Me.CBPROD.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(172, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 18)
        Me.Label2.TabIndex = 1075
        Me.Label2.Text = "Producto"
        '
        'CBGRU
        '
        Me.CBGRU.BackColor = System.Drawing.Color.White
        Me.CBGRU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBGRU.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBGRU.FormattingEnabled = True
        Me.CBGRU.Location = New System.Drawing.Point(260, 113)
        Me.CBGRU.Name = "CBGRU"
        Me.CBGRU.Size = New System.Drawing.Size(304, 25)
        Me.CBGRU.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(195, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 18)
        Me.Label4.TabIndex = 1073
        Me.Label4.Text = "Grupo"
        '
        'TXTNOCOMPRA
        '
        Me.TXTNOCOMPRA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNOCOMPRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNOCOMPRA.Location = New System.Drawing.Point(842, 15)
        Me.TXTNOCOMPRA.Name = "TXTNOCOMPRA"
        Me.TXTNOCOMPRA.ReadOnly = True
        Me.TXTNOCOMPRA.Size = New System.Drawing.Size(125, 22)
        Me.TXTNOCOMPRA.TabIndex = 1101
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(746, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 17)
        Me.Label8.TabIndex = 1102
        Me.Label8.Text = "Compra No."
        '
        'LBLNOTFAC
        '
        Me.LBLNOTFAC.AutoSize = True
        Me.LBLNOTFAC.BackColor = System.Drawing.Color.Transparent
        Me.LBLNOTFAC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNOTFAC.ForeColor = System.Drawing.Color.Navy
        Me.LBLNOTFAC.Location = New System.Drawing.Point(138, 12)
        Me.LBLNOTFAC.Name = "LBLNOTFAC"
        Me.LBLNOTFAC.Size = New System.Drawing.Size(61, 17)
        Me.LBLNOTFAC.TabIndex = 1107
        Me.LBLNOTFAC.Text = "factura"
        '
        'LBLFACNOT
        '
        Me.LBLFACNOT.AutoSize = True
        Me.LBLFACNOT.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLFACNOT.Location = New System.Drawing.Point(32, 14)
        Me.LBLFACNOT.Name = "LBLFACNOT"
        Me.LBLFACNOT.Size = New System.Drawing.Size(71, 18)
        Me.LBLFACNOT.TabIndex = 1106
        Me.LBLFACNOT.Text = "Factura"
        '
        'LBLCOSTO
        '
        Me.LBLCOSTO.AutoSize = True
        Me.LBLCOSTO.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOSTO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOSTO.ForeColor = System.Drawing.Color.Navy
        Me.LBLCOSTO.Location = New System.Drawing.Point(127, 49)
        Me.LBLCOSTO.Name = "LBLCOSTO"
        Me.LBLCOSTO.Size = New System.Drawing.Size(17, 17)
        Me.LBLCOSTO.TabIndex = 1108
        Me.LBLCOSTO.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 17)
        Me.Label1.TabIndex = 1109
        Me.Label1.Text = "Ultimo costo  $"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 17)
        Me.Label10.TabIndex = 1111
        Me.Label10.Text = "Precio de venta  $"
        '
        'LBLPRE
        '
        Me.LBLPRE.AutoSize = True
        Me.LBLPRE.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRE.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRE.ForeColor = System.Drawing.Color.Navy
        Me.LBLPRE.Location = New System.Drawing.Point(153, 80)
        Me.LBLPRE.Name = "LBLPRE"
        Me.LBLPRE.Size = New System.Drawing.Size(17, 17)
        Me.LBLPRE.TabIndex = 1110
        Me.LBLPRE.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBLDES)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LBLCOSTO)
        Me.GroupBox1.Controls.Add(Me.LBLPRE)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(576, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 116)
        Me.GroupBox1.TabIndex = 1112
        Me.GroupBox1.TabStop = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.BackColor = System.Drawing.Color.White
        Me.BTNCANCELAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCANCELAR.ForeColor = System.Drawing.Color.Black
        Me.BTNCANCELAR.Image = CType(resources.GetObject("BTNCANCELAR.Image"), System.Drawing.Image)
        Me.BTNCANCELAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNCANCELAR.Location = New System.Drawing.Point(23, 196)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNCANCELAR.TabIndex = 9
        Me.BTNCANCELAR.Text = "       F7 Cancelar"
        Me.BTNCANCELAR.UseVisualStyleBackColor = False
        '
        'BTNQUITAR
        '
        Me.BTNQUITAR.BackColor = System.Drawing.Color.White
        Me.BTNQUITAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNQUITAR.ForeColor = System.Drawing.Color.Black
        Me.BTNQUITAR.Image = CType(resources.GetObject("BTNQUITAR.Image"), System.Drawing.Image)
        Me.BTNQUITAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNQUITAR.Location = New System.Drawing.Point(23, 153)
        Me.BTNQUITAR.Name = "BTNQUITAR"
        Me.BTNQUITAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNQUITAR.TabIndex = 8
        Me.BTNQUITAR.Text = "       F5 Quitar"
        Me.BTNQUITAR.UseVisualStyleBackColor = False
        '
        'BTNAGREGAR
        '
        Me.BTNAGREGAR.BackColor = System.Drawing.Color.White
        Me.BTNAGREGAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNAGREGAR.ForeColor = System.Drawing.Color.Black
        Me.BTNAGREGAR.Image = CType(resources.GetObject("BTNAGREGAR.Image"), System.Drawing.Image)
        Me.BTNAGREGAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNAGREGAR.Location = New System.Drawing.Point(23, 111)
        Me.BTNAGREGAR.Name = "BTNAGREGAR"
        Me.BTNAGREGAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNAGREGAR.TabIndex = 7
        Me.BTNAGREGAR.Text = "    F4 Agregar"
        Me.BTNAGREGAR.UseVisualStyleBackColor = False
        '
        'BTNGUARDAR
        '
        Me.BTNGUARDAR.BackColor = System.Drawing.Color.White
        Me.BTNGUARDAR.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGUARDAR.ForeColor = System.Drawing.Color.Black
        Me.BTNGUARDAR.Image = CType(resources.GetObject("BTNGUARDAR.Image"), System.Drawing.Image)
        Me.BTNGUARDAR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNGUARDAR.Location = New System.Drawing.Point(23, 277)
        Me.BTNGUARDAR.Name = "BTNGUARDAR"
        Me.BTNGUARDAR.Size = New System.Drawing.Size(127, 35)
        Me.BTNGUARDAR.TabIndex = 10
        Me.BTNGUARDAR.Text = "      F12 Guardar"
        Me.BTNGUARDAR.UseVisualStyleBackColor = False
        '
        'BTNBUS
        '
        Me.BTNBUS.BackColor = System.Drawing.Color.White
        Me.BTNBUS.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNBUS.ForeColor = System.Drawing.Color.Black
        Me.BTNBUS.Image = CType(resources.GetObject("BTNBUS.Image"), System.Drawing.Image)
        Me.BTNBUS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNBUS.Location = New System.Drawing.Point(23, 236)
        Me.BTNBUS.Name = "BTNBUS"
        Me.BTNBUS.Size = New System.Drawing.Size(127, 35)
        Me.BTNBUS.TabIndex = 6
        Me.BTNBUS.Text = "        F10 Buscar"
        Me.BTNBUS.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(685, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 16)
        Me.Label3.TabIndex = 1118
        Me.Label3.Text = "$"
        '
        'CBUNI
        '
        Me.CBUNI.BackColor = System.Drawing.Color.White
        Me.CBUNI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUNI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUNI.FormattingEnabled = True
        Me.CBUNI.Location = New System.Drawing.Point(329, 287)
        Me.CBUNI.Name = "CBUNI"
        Me.CBUNI.Size = New System.Drawing.Size(105, 24)
        Me.CBUNI.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(350, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 1120
        Me.Label6.Text = "Unidad"
        '
        'LBLTI
        '
        Me.LBLTI.AutoSize = True
        Me.LBLTI.BackColor = System.Drawing.Color.Transparent
        Me.LBLTI.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTI.ForeColor = System.Drawing.Color.Navy
        Me.LBLTI.Location = New System.Drawing.Point(526, 617)
        Me.LBLTI.Name = "LBLTI"
        Me.LBLTI.Size = New System.Drawing.Size(25, 25)
        Me.LBLTI.TabIndex = 1122
        Me.LBLTI.Text = "0"
        '
        'LBLTS
        '
        Me.LBLTS.AutoSize = True
        Me.LBLTS.BackColor = System.Drawing.Color.Transparent
        Me.LBLTS.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTS.ForeColor = System.Drawing.Color.Navy
        Me.LBLTS.Location = New System.Drawing.Point(146, 617)
        Me.LBLTS.Name = "LBLTS"
        Me.LBLTS.Size = New System.Drawing.Size(25, 25)
        Me.LBLTS.TabIndex = 1121
        Me.LBLTS.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(773, 617)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 25)
        Me.Label11.TabIndex = 1123
        Me.Label11.Text = "Total :  $"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(445, 617)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 25)
        Me.Label12.TabIndex = 1124
        Me.Label12.Text = "IVA:  $"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 617)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 25)
        Me.Label13.TabIndex = 1125
        Me.Label13.Text = "Sub-total: $"
        '
        'TXTCLA
        '
        Me.TXTCLA.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLA.Location = New System.Drawing.Point(321, 190)
        Me.TXTCLA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXTCLA.MaxLength = 50
        Me.TXTCLA.Name = "TXTCLA"
        Me.TXTCLA.Size = New System.Drawing.Size(243, 29)
        Me.TXTCLA.TabIndex = 1126
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(170, 201)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 18)
        Me.Label14.TabIndex = 1127
        Me.Label14.Text = "Codigo de barras"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(814, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 24)
        Me.Label15.TabIndex = 1130
        Me.Label15.Text = "$"
        Me.Label15.Visible = False
        '
        'TXTDESC
        '
        Me.TXTDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDESC.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESC.Location = New System.Drawing.Point(842, 69)
        Me.TXTDESC.MaxLength = 20
        Me.TXTDESC.Name = "TXTDESC"
        Me.TXTDESC.Size = New System.Drawing.Size(133, 32)
        Me.TXTDESC.TabIndex = 4
        Me.TXTDESC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTDESC.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(846, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 24)
        Me.Label16.TabIndex = 1129
        Me.Label16.Text = "Descuento"
        Me.Label16.Visible = False
        '
        'TXTPED
        '
        Me.TXTPED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTPED.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPED.Location = New System.Drawing.Point(477, 36)
        Me.TXTPED.MaxLength = 20
        Me.TXTPED.Name = "TXTPED"
        Me.TXTPED.Size = New System.Drawing.Size(232, 32)
        Me.TXTPED.TabIndex = 1131
        Me.TXTPED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CHK1
        '
        Me.CHK1.AutoSize = True
        Me.CHK1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK1.Location = New System.Drawing.Point(477, 6)
        Me.CHK1.Name = "CHK1"
        Me.CHK1.Size = New System.Drawing.Size(113, 24)
        Me.CHK1.TabIndex = 1132
        Me.CHK1.Text = "Pedimento"
        Me.CHK1.UseVisualStyleBackColor = True
        '
        'CBALM
        '
        Me.CBALM.BackColor = System.Drawing.Color.White
        Me.CBALM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBALM.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBALM.FormattingEnabled = True
        Me.CBALM.Location = New System.Drawing.Point(151, 75)
        Me.CBALM.Name = "CBALM"
        Me.CBALM.Size = New System.Drawing.Size(413, 25)
        Me.CBALM.TabIndex = 1133
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(78, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 18)
        Me.Label17.TabIndex = 1134
        Me.Label17.Text = "Tienda"
        '
        'LBLNPRO
        '
        Me.LBLNPRO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBLNPRO.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNPRO.Location = New System.Drawing.Point(172, 236)
        Me.LBLNPRO.Name = "LBLNPRO"
        Me.LBLNPRO.Size = New System.Drawing.Size(795, 18)
        Me.LBLNPRO.TabIndex = 1135
        Me.LBLNPRO.Text = "Producto"
        '
        'frmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(999, 641)
        Me.Controls.Add(Me.LBLNPRO)
        Me.Controls.Add(Me.CBALM)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.CHK1)
        Me.Controls.Add(Me.TXTPED)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TXTDESC)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXTCLA)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LBLTI)
        Me.Controls.Add(Me.LBLTS)
        Me.Controls.Add(Me.CBUNI)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTNCANCELAR)
        Me.Controls.Add(Me.BTNQUITAR)
        Me.Controls.Add(Me.BTNAGREGAR)
        Me.Controls.Add(Me.BTNGUARDAR)
        Me.Controls.Add(Me.BTNBUS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LBLNOTFAC)
        Me.Controls.Add(Me.LBLFACNOT)
        Me.Controls.Add(Me.TXTNOCOMPRA)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LBLTF)
        Me.Controls.Add(Me.TXTCANT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTCOS)
        Me.Controls.Add(Me.LBLCOS)
        Me.Controls.Add(Me.LBLPRO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTFECHA)
        Me.Controls.Add(Me.CBPROD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBGRU)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCompras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBLDES As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents LBLTF As System.Windows.Forms.Label
    Friend WithEvents TXTCANT As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTCOS As System.Windows.Forms.TextBox
    Friend WithEvents LBLCOS As System.Windows.Forms.Label
    Friend WithEvents LBLPRO As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTFECHA As System.Windows.Forms.DateTimePicker
    Friend WithEvents CBPROD As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBGRU As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTNOCOMPRA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBLNOTFAC As System.Windows.Forms.Label
    Friend WithEvents LBLFACNOT As System.Windows.Forms.Label
    Friend WithEvents LBLCOSTO As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LBLPRE As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNCANCELAR As System.Windows.Forms.Button
    Friend WithEvents BTNQUITAR As System.Windows.Forms.Button
    Friend WithEvents BTNAGREGAR As System.Windows.Forms.Button
    Friend WithEvents BTNGUARDAR As System.Windows.Forms.Button
    Friend WithEvents BTNBUS As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CBUNI As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBLTI As System.Windows.Forms.Label
    Friend WithEvents LBLTS As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTCLA As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TXTDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTPED As System.Windows.Forms.TextBox
    Friend WithEvents CHK1 As System.Windows.Forms.CheckBox
    Friend WithEvents CBALM As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LBLNPRO As Label
End Class
