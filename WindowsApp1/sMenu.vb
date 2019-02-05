Imports System.IO

Public Class sMenu
    Public savePath As String = "saves.xml"

    <Serializable()> Public Structure Score
        Shared MAXGM As Integer = 3
        Shared MAXDIFF As Integer = 3
        Dim aideAleat As Integer
        Dim aideDefil As Boolean
        Dim aideSug As Boolean
        Dim aideSol As Integer
        Dim aideCoul As Boolean
        Dim score As Integer
        Dim aideLoss As Integer
    End Structure

    <Serializable()> Public Structure Player
        Dim name As String
        'scores(gameMode, difficulty)
        Dim scores(,) As Score
    End Structure

    Private currentPlayer As Integer

    Private comboName() As String

    Private players As New ArrayList
    Private cp As New Player

    '-------- FONCTIONS SCORES ---------'

    Private Function getNewPlayer(ByVal s As String) As Player
        Dim p As New Player
        p.name = s
        ReDim p.scores(Score.MAXGM - 1, Score.MAXDIFF - 1)
        Return p
    End Function

    Private Sub addScoreToPlayer(ByRef p As Player, ByRef opt As sOptions.Setting, ByVal nbUseSol As Integer,
                                 ByVal nbUseAleat As Integer, ByVal score As Integer, ByVal scLoss As Integer)
        p.scores(opt.gm, opt.diff) = getNewScore(score, scLoss, nbUseSol, nbUseAleat, opt)
    End Sub

    Private Function getNewScore(ByVal sc As Integer, ByVal scLoss As Integer, ByVal nbUseSol As Integer, ByVal nbUseAleat As Integer, ByRef opt As sOptions.Setting)
        Dim s As New Score()
        s.score = sc
        s.aideLoss = scLoss
        s.aideAleat = nbUseAleat
        s.aideDefil = opt.aideDefil
        s.aideSug = opt.aideSug
        s.aideSol = nbUseSol
        s.aideCoul = opt.aideCoul
        Return s
    End Function

    Public Sub saveScore(ByVal sc As Integer, ByVal scLoss As Integer, ByVal nbUseSol As Integer, ByVal nbUseAleat As Integer, ByRef opt As sOptions.Setting)
        If sc > players.Item(currentPlayer).scores(opt.gm, opt.diff).score Then
            addScoreToPlayer(players(currentPlayer), opt, nbUseSol, nbUseAleat, sc, scLoss)
        End If
        seriaScores()
    End Sub

    Private Sub seriaScores()
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New FileStream(Path.Combine(My.Application.Info.DirectoryPath, savePath), FileMode.OpenOrCreate)
        bf.Serialize(fs, players)
        fs.Close()
    End Sub

    '-------- FONCTIONS BOUTONS ---------'

    Private Sub bM_close_Click(sender As Object, e As EventArgs) Handles bM_close.Click
        seriaScores()

        timer_lblM_best.Stop()
        timer_aff.Stop()

        Me.Close()
    End Sub

    Private Sub bM_jouer_Click(sender As Object, e As EventArgs) Handles bM_jouer.Click
        sOptions.Show()
        Me.Hide()
    End Sub

    Private Sub bM_scores_Click(sender As Object, e As EventArgs) Handles bM_scores.Click
        sScores.Show()
        Me.Hide()
    End Sub

    '-------- FONCTIONS FORM ---------'

    Private Sub sMenu_Click(sender As Object, e As EventArgs) Handles Me.Click
        If bM_ajouter.Visible Then
            bM_ajouter.Select()
        Else
            bM_jouer.Select()
        End If
        If players.Count > 0 Then
            cbM_player.SelectedIndex = currentPlayer
        End If
    End Sub

    Private Sub sMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New FileStream(Path.Combine(My.Application.Info.DirectoryPath, savePath), FileMode.OpenOrCreate)
        Try
            players = bf.Deserialize(fs)
        Catch ex As Exception
            players = New ArrayList
        End Try
        updateComboname()
        fs.Close()

        If cbM_player.Text = "" Then
            bM_suppr.Hide()
        End If

        timer_lblM_best.Interval = 70
        AddHandler timer_lblM_best.Tick, AddressOf timer_lblM_best_Tick
        timer_lblM_best.Start()

        timer_aff.Interval = 5000
        AddHandler timer_aff.Tick, AddressOf timer_aff_Tick
        If players.Count > 0 Then
            timer_aff_Tick()
            timer_aff.Start()
            lblM_best.Show()
        End If

        pM_player_timer.Interval = 7
        pM_player_timerStay.Interval = 5000
        AddHandler pM_player_timer.Tick, AddressOf pM_player_Update
        AddHandler pM_player_timerStay.Tick, AddressOf cbM_Player_MouseLeave
    End Sub

    '-------- FONCTIONS COMBOBOX ---------'

    Private pM_player_timer As New Timer
    Private pM_player_timerStay As New Timer
    Private pM_player_width1 = 212
    Private pM_player_step = -1
    Private pM_player_width2 = 250

    Private Sub updateComboname()
        ReDim comboName(players.Count - 1)
        For i = 0 To players.Count - 1
            comboName(i) = players.Item(i).name
        Next
        cbM_player.DataSource = comboName
    End Sub

    Private Sub cbM_Player_MouseEnter() Handles cbM_player.MouseEnter
        pM_player_step = 1
        pM_player_timer.Start()
        pM_player_timerStay.Start()
    End Sub

    Private Sub cbM_Player_MouseLeave() Handles cbM_player.MouseLeave
        pM_player_step = -1
        pM_player_timer.Start()
    End Sub

    Private Sub pM_player_Update()
        pM_player.Width += pM_player_step
        If pM_player.Width + pM_player_step <= pM_player_width1 Then
            pM_player.Width = pM_player_width1
            pM_player_timer.Stop()
        ElseIf pM_player.Width + pM_player_step >= pM_player_width2 Then
            pM_player.Width = pM_player_width2
            pM_player_timer.Stop()
        End If
    End Sub

    Private Sub cbM_player_KeyPress(sender As Object, e As KeyEventArgs) Handles cbM_player.KeyDown
        If cbM_player.Text.Length >= 8 And Char.IsLetterOrDigit(Chr(e.KeyCode)) Then
            cbM_player.Text = cbM_player.Text.Substring(0, cbM_player.Text.Length - 1)
            MsgBox("La taille de votre pseudo ne doit pas dépasser 8 caractères", vbOKOnly + vbExclamation, "Attention")
            Return
        End If

        If e.KeyCode = Keys.Enter Then
            If bM_ajouter.Visible Then
                bM_ajouter.Select()
            Else
                bM_jouer.Select()
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            bM_suppr_Click()
        End If
    End Sub

    Private Sub cbM_player_GotFocus(sender As Object, e As EventArgs) Handles cbM_player.GotFocus
        sender.select(sender.text.length, sender.text.length)
        cbM_Player_MouseEnter()
    End Sub

    Private Sub cbM_player_LostFocus(sender As Object, e As EventArgs) Handles cbM_player.LostFocus
        sender.select(sender.text.length, sender.text.length)
        cbM_Player_MouseLeave()
        For i = 0 To comboName.GetLength(0) - 1
            If Trim(comboName(i).ToLower) = Trim(sender.text.toLower) Then
                cbM_player.SelectedIndex = i
                Return
            End If
        Next
    End Sub

    Private Sub cbM_player_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbM_player.TextChanged
        Dim i As Integer = 0
        For i = 0 To comboName.GetLength(0) - 1
            If Trim(comboName(i).ToLower) = Trim(sender.text.toLower) Then
                bM_ajouter.Hide()
                bM_suppr.Show()
                currentPlayer = i
                Return
            End If
        Next
        bM_ajouter.Show()
        bM_suppr.Hide()
    End Sub

    '-------- FONCTIONS AJOUTER ---------'

    Private Sub bM_ajouter_Click(sender As Object, e As EventArgs) Handles bM_ajouter.Click
        Dim i As Integer
        If cbM_player.Text.Trim = "" Then
            cbM_player.Select()
            Return
        End If
        Dim p As Player = getNewPlayer(cbM_player.Text)
        'players.Add(p)
        If players.Count > 0 Then
            For i = 0 To players.Count - 1
                If cbM_player.Text < players(i).name Then
                    Exit For
                End If
            Next
        Else
            i = 0
        End If
        players.Insert(i, p)
        updateComboname()
        cbM_player.SelectedIndex = -1
        cbM_player.SelectedIndex = i

        timer_aff.Start()
        lblM_best.Show()
        aff_ind = -1
        timer_aff_Tick()
        bM_jouer.Select()
    End Sub

    '-------- FONCTIONS SUPPRIMER ---------'

    Private Sub bM_suppr_Click() Handles bM_suppr.Click
        For i = 0 To players.Count - 1
            If Trim(players.Item(i).name.toLower) = Trim(cbM_player.Text.ToLower) Then
                players.RemoveAt(i)
                updateComboname()
                seriaScores()
                If comboName.Count > 0 Then
                    cbM_player.SelectedIndex = If(i >= comboName.Count, comboName.Count - 1, i)
                Else
                    timer_aff.Stop()
                    lblM_best.Hide()
                    cbM_player.Text = ""
                End If
                Return
            End If
        Next
    End Sub

    '-------- FONCTIONS LABEL ---------'

    Dim timer_lblM_best As New Timer
    Dim red_lblM_best As Double = 0
    Dim green_lblM_best As Double = 0
    Dim blue_lblM_best As Double = 0
    Dim step_lblM_best As Double = 0.15

    Dim timer_aff As New Timer
    Dim aff_gm As String() = {"Standard", "Contre la montre", "Block"}
    Dim aff_diff As String() = {"Facile ", "Moyen", "Difficile"}
    Dim aff_ind As Integer = -1

    Private Sub timer_lblM_best_Tick()
        If players.Count > 0 Then
            If comboName(currentPlayer).Trim.ToLower = "rainbow" Then
                Me.BackColor = rgbToColor(Math.Sin(red_lblM_best + 4) * 127 + 128, Math.Sin(green_lblM_best + 0) * 127 + 128, Math.Sin(blue_lblM_best + 2) * 127 + 128)
                lblM_best.ForeColor = Color.Black
            Else
                Me.BackColor = Color.Gray
                lblM_best.ForeColor = rgbToColor(Math.Sin(red_lblM_best) * 127 + 128, Math.Sin(green_lblM_best + 2) * 127 + 128, Math.Sin(blue_lblM_best + 4) * 127 + 128)

            End If
        End If
        red_lblM_best += step_lblM_best
        green_lblM_best += step_lblM_best
        blue_lblM_best += step_lblM_best
        red_lblM_best = red_lblM_best Mod Math.PI * 2
        green_lblM_best = green_lblM_best Mod Math.PI * 2
        blue_lblM_best = blue_lblM_best Mod Math.PI * 2
    End Sub

    Private Function rgbToColor(ByVal red As Double, ByVal green As Double, ByVal blue As Double) As Color
        Return Color.FromArgb(Math.Round(red), Math.Round(green), Math.Round(blue))
    End Function

    Private Sub timer_aff_Tick()
        aff_ind += 1
        aff_ind = aff_ind Mod 9
        Dim gm As Integer = aff_ind \ 3
        Dim diff As Integer = aff_ind Mod 3

        lblM_best.Text = aff_gm(gm) & " - " & aff_diff(diff) & " : " & If(players(currentPlayer).scores(gm, diff).score <> Nothing, players(currentPlayer).scores(gm, diff).score, "Aucun")
    End Sub

End Class

