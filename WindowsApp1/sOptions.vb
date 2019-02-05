Imports System.IO

Public Class sOptions

    Private optionPath As String = "options.xml"

    <Serializable()> Public Structure Setting
        Dim gm As Integer
        Dim diff As Integer
        Dim aideInd As Boolean
        Dim aideAleat As Boolean
        Dim aideDefil As Boolean
        Dim aideSug As Boolean
        Dim aideSol As Boolean
        Dim aideCoul As Boolean
    End Structure

    Private Function getNewSetting(ByVal i1 As Integer, ByVal i2 As Integer)
        Dim s As New Setting
        s.gm = i1
        s.diff = i2
        s.aideInd = False
        s.aideAleat = False
        s.aideDefil = False
        s.aideSug = False
        s.aideSol = False
        s.aideCoul = False
        Return s
    End Function

    Private opt As Setting
    Public Const scLosAleat As Integer = 150
    Public Const scLosDefil As Integer = 500
    Public Const scLosSug As Integer = 350
    Public Const scLosSol As Integer = 50
    Public Const scLosCoul As Integer = 100

    Private gmInfos As String() = {vbCrLf & "Expérience standard du sudoku" & vbCrLf & vbCrLf & "Résolvez le plus rapidement",
        vbCrLf & "Un sudoku en contre la montre" & vbCrLf & vbCrLf & "Remplissez un maximum de cases dans le temps impartit",
        "Une expérience enrichie de la version standard" & vbCrLf & vbCrLf & "Vous ne pouvez ecrire qu'une seule fois dans les cases bleues"}

    Private diffInfos As String = "Plus la difficultée est élevée, plus le nombre de cases a remplir sera élevé" & vbCrLf & vbCrLf & "(Une génération difficle demande parfois plus de temps)"

    Private aides(5) As Boolean
    Private aidesInfos() As String = {vbCrLf & "Permet de saisir un nombre temporairement dans une case",
        "Affiche la solution de 5 cases aléatoirement." & vbCrLf & vbCrLf & "-150 points par utilisation",
        "Permet de faire défiler les solution possibles via la molette de la souris" & vbCrLf & vbCrLf & "-500 points",
        "Permet d'afficher les solutions possibles pour une case via un double le clic puis de selectionner l'une d'entre elles" & vbCrLf & vbCrLf & "-350 points",
        "Affiche la solution pour la derniere case selectionnée." & vbCrLf & vbCrLf & "-50 points par utilisation",
        "Si une case n'est pas valide, celle-ci et les cases impliquées s'allument" & vbCrLf & vbCrLf & "-100 points"}

    Private Sub seriaOpt()
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New FileStream(Path.Combine(My.Application.Info.DirectoryPath, optionPath), FileMode.OpenOrCreate)
        bf.Serialize(fs, opt)
        fs.Close()
    End Sub

    Private Sub bO_close_Click(sender As Object, e As EventArgs) Handles bO_close.Click
        seriaOpt()
        Me.Close()
        sMenu.Show()
    End Sub

    Private Sub sOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New FileStream(Path.Combine(My.Application.Info.DirectoryPath, optionPath), FileMode.OpenOrCreate)
        Try
            opt = bf.Deserialize(fs)
        Catch ex As Exception
            opt = getNewSetting(0, 0)
        End Try
        fs.Close()
        For Each c As RadioButton In pO_gm.Controls.OfType(Of RadioButton)
            If opt.gm = Integer.Parse(c.Name(c.Name.Length - 1)) Then
                c.Checked = True
            End If
            AddHandler c.CheckedChanged, AddressOf rbO_gm_CheckedChanged
            AddHandler c.MouseHover, AddressOf infos_gm_MouseHover
        Next
        For Each c As RadioButton In pO_diff.Controls.OfType(Of RadioButton)
            If opt.diff = Integer.Parse(c.Name(c.Name.Length - 1)) Then
                c.Checked = True
            End If
            AddHandler c.CheckedChanged, AddressOf rbO_diff_CheckedChanged
            AddHandler c.MouseHover, AddressOf infos_diff_MouseHover
        Next

        ckO_ind0.Checked = opt.aideInd
        ckO_aleat1.Checked = opt.aideAleat
        ckO_defil2.Checked = opt.aideDefil
        ckO_sug3.Checked = opt.aideSug
        ckO_sol4.Checked = opt.aideSol
        ckO_coul5.Checked = opt.aideCoul
        If opt.gm = 2 Then
            ckO_aleat1.Enabled = False
            ckO_defil2.Enabled = False
            ckO_sug3.Enabled = False
            ckO_sol4.Enabled = False
        End If
        For Each c As CheckBox In pO_aide.Controls.OfType(Of CheckBox)
            AddHandler c.CheckedChanged, AddressOf ckO_aide_CheckedChanged
            AddHandler c.MouseHover, AddressOf infos_aide_MouseHover
            AddHandler c.MouseLeave, AddressOf infos_MouseLeave
        Next
    End Sub

    '-------- INFOS --------'

    Private Sub infos_gm_MouseHover(sender As Object, e As EventArgs)
        rtbO_infos.Text = vbCrLf & vbCrLf & gmInfos(Integer.Parse(sender.name(sender.name.length - 1)))
        rtbO_infos.Show()
        pO_infos.Show()
    End Sub

    Private Sub infos_diff_MouseHover(sender As Object, e As EventArgs)
        rtbO_infos.Text = vbCrLf & vbCrLf & diffInfos
        rtbO_infos.Show()
        pO_infos.Show()
    End Sub

    Private Sub infos_aide_MouseHover(sender As Object, e As EventArgs)
        rtbO_infos.Text = vbCrLf & vbCrLf & aidesInfos(Integer.Parse(sender.name(sender.name.length - 1)))
        rtbO_infos.Show()
        pO_infos.Show()
    End Sub

    Private Sub infos_MouseLeave(sender As Object, e As EventArgs)
        rtbO_infos.Hide()
        pO_infos.Hide()
    End Sub

    Private Sub bM_jouer_Click(sender As Object, e As EventArgs) Handles bM_jouer.Click
        seriaOpt()
        sJeu.WindowState = FormWindowState.Minimized
        sJeu.Show()
        If opt.gm = 2 Then
            ckO_aleat1.Checked = False
            ckO_defil2.Checked = False
            ckO_sug3.Checked = False
            ckO_sol4.Checked = False
        End If
        sJeu.generate(opt)
        sJeu.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub

    '-------- RADIO BUTTON --------'

    Private Sub rbO_gm_CheckedChanged(sender As Object, e As EventArgs)
        opt.gm = Integer.Parse(sender.name(sender.name.Length - 1))
        If opt.gm = 2 Then
            ckO_aleat1.Enabled = False
            ckO_defil2.Enabled = False
            ckO_sug3.Enabled = False
            ckO_sol4.Enabled = False
        Else
            ckO_aleat1.Enabled = True
            ckO_defil2.Enabled = True
            ckO_sug3.Enabled = True
            ckO_sol4.Enabled = True
        End If
    End Sub

    Private Sub rbO_diff_CheckedChanged(sender As Object, e As EventArgs)
        opt.diff = Integer.Parse(sender.name(sender.name.length - 1))
    End Sub

    '-------- CHECKBOX --------'

    Private Sub ckO_aide_CheckedChanged(sender As Object, e As EventArgs)
        Select Case (Integer.Parse(sender.name(sender.name.length - 1)))
            Case 0
                opt.aideInd = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
            Case 1
                opt.aideAleat = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
            Case 2
                opt.aideDefil = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
            Case 3
                opt.aideSug = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
            Case 4
                opt.aideSol = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
            Case 5
                opt.aideCoul = sender.checked
                aides(Integer.Parse(sender.name(sender.name.Length - 1))) = sender.checked
        End Select
    End Sub
End Class