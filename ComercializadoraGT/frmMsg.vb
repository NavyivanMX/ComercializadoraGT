Public Class frmMsg

    Private Sub frmMsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = frmPrincipal.Icon
      OPVisualizacionForm(Me)
    End Sub
    Public Sub MOSTRAR(ByVal NV As String, ByVal PREGUNTA As String, ByVal PREGUNTA2 As String)
        Dim LUGAR As New System.Drawing.Point
        LBLPREG.Text = PREGUNTA
        LBLPREG2.Text = PREGUNTA2
        Me.Text = NV
        Dim LARGO As Integer
        LARGO = LBLPREG.Size.Width
        If LBLPREG2.Size.Width > LARGO Then
            LARGO = LBLPREG2.Size.Width
        End If
        If LARGO > 665 Then
            Dim TAMA As New System.Drawing.Size
            TAMA.Height = Me.Size.Height
            TAMA.Width = LARGO + 24
            Me.Size = TAMA

            LUGAR.X = (TAMA.Width - 425) / 2
            LUGAR.Y = 283
            BTNYES.Location = LUGAR
            LUGAR.X = LUGAR.X + 119 + 153
            BTNNO.Location = LUGAR
        End If
        LUGAR.Y = 118
        LUGAR.X = (Me.Size.Width - 24 - LBLPREG.Size.Width) / 2
        LBLPREG.Location = LUGAR
        LUGAR.Y = 166
        LUGAR.X = (Me.Size.Width - 24 - LBLPREG2.Size.Width) / 2
        LBLPREG2.Location = LUGAR
        Me.ShowDialog()
    End Sub

    Private Sub BTNYES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNYES.Click

    End Sub
End Class