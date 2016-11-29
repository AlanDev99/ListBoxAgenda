Public Class Form1
    'Cantidad de registros acumulados
    Dim totalRegistros As Integer

    'Cantidad maxima de registros + 1
    Dim cantContactos As Integer

    Structure Contacto
        Dim nombre As String
        Dim telefono As String
        Dim email As String
    End Structure

    Dim MiAgenda() As Contacto
    'Definimos el array MiAgenda

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Este procedimiento es invocado automaticamente al iniciar el formulario
        totalRegistros = 0
        reservarAgenda()

    End Sub

    Sub reservarAgenda()
        Dim Message As String = "¿Cuantos contactos va a ingresar?"
        Me.cantContactos = Val(InputBox(Message, "Ingresar", "5")) - 1
        'ReDimension de la agenda de 0 a cantContactos
        ReDim MiAgenda(cantContactos)
        'Reservado (cantContactos) + 1 espacios
        'Por ese motivo resto -1 en el InputBox
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'Verificacion del tamaño del array
        'MsgBox(MiAgenda.Count)
        If totalRegistros > cantContactos Then
            MsgBox("Lista completa", 16, "Error")
        Else
            MiAgenda(totalRegistros).nombre = txtNombre.Text
            MiAgenda(totalRegistros).telefono = txtTelefono.Text
            MiAgenda(totalRegistros).email = txtEmail.Text

            ListBoxAgenda.Items.Add(txtNombre.Text)

            txtNombre.Clear()
            txtTelefono.Clear()
            txtEmail.Clear()
            txtNombre.Focus()

            totalRegistros += 1
        End If

    End Sub

    Private Sub ListBoxAgenda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAgenda.SelectedIndexChanged

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim n As Integer = ListBoxAgenda.SelectedIndex
        ListBoxAgenda.Items.RemoveAt(n)

        For i = n To totalRegistros - 2
            MiAgenda(i).nombre = MiAgenda(i + 1).nombre
            MiAgenda(i).telefono = MiAgenda(i + 1).telefono
            MiAgenda(i).email = MiAgenda(i + 1).email
        Next i

        totalRegistros -= 1
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        Dim n As Integer = ListBoxAgenda.SelectedIndex
        txtNombre.Text = MiAgenda(n).nombre
        txtTelefono.Text = MiAgenda(n).telefono
        txtEmail.Text = MiAgenda(n).email
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub
End Class
