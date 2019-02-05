Imports System.IO

Public Class sScores

    Private Structure tabLine
        Dim p As sMenu.Player
        Dim gm As Integer
        Dim diff As Integer
        Function getScores() As sMenu.Score
            Return p.scores(gm, diff)
        End Function
    End Structure


    Private Function getNewtabLine(ByVal i As Integer, ByVal gm As Integer, ByVal diff As Integer)
        Dim t As New tabLine
        t.p = players(i)
        t.gm = gm
        t.diff = diff
        Return t
    End Function

    Private gmNames As String() = {"Standard", "Contre la montre", "Block"}
    Private diffNames As String() = {"Facile", "Moyen", "Difficile"}

    Private tabNbCol As Integer = 5
    Private tab(tabNbCol - 1, 0) As TextBox
    Private cur As Integer() = {0, 0}

    Private players As ArrayList

    Private tabLines As tabLine()

    Private Sub bM_close_Click(sender As Object, e As EventArgs) Handles bM_close.Click
        sMenu.Show()
        Me.Close()
    End Sub

    Private Sub tb_tab_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub sScores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fs As New FileStream(Path.Combine(My.Application.Info.DirectoryPath, sMenu.savePath), FileMode.OpenOrCreate)
        Try
            players = bf.Deserialize(fs)
        Catch ex As Exception
            players = New ArrayList
        End Try
        fs.Close()
        Dim lc As Integer = 0
        For i = 0 To players.Count - 1
            For gm = 0 To players(i).scores.getlength(0) - 1
                For diff = 0 To players(i).scores.getlength(0) - 1
                    If players(i).scores(gm, diff).score <> 0 Then
                        lc += 1
                    End If
                Next
            Next
        Next
        createtab(lc)
        fillTabLines()
        tribyGm(1)
        fillTab()
    End Sub

    Private Sub createtab(ByVal nbL As Integer)
        Dim tabHeight As Integer = 19
        Dim tabWidth As Integer = 95
        Dim tabSpaceH As Integer = 3
        Dim tabSpaceW As Integer = 3

        ReDim tab(tab.GetLength(0) - 1, nbL - 1)
        ReDim tabLines(nbL - 1)

        For i = 0 To (nbL * tabNbCol) - 1
            Dim tb As New TextBox
            Console.WriteLine(tbS_pseu.Height)
            With tb
                .Location = New Point(cur(0) * (tabWidth + tabSpaceW), cur(1) * (tabHeight + tabSpaceH))
                .Size = New Point(tabWidth, tabHeight)
                .Name = "tbS_tab_" & cur(0) & "_" & cur(1)
                .Text = ""
                .Margin = New Padding(0)
                .TextAlign = HorizontalAlignment.Center
            End With
            AddHandler tb.KeyPress, AddressOf tb_tab_KeyPress
            pS_tab.Controls.Add(tb)
            tab(cur(0), cur(1)) = tb
            cur(0) += 1
            If cur(0) = tabNbCol Then
                cur(1) += 1
                cur(0) = cur(0) Mod tabNbCol
            End If
        Next
    End Sub

    Private Sub fillTabLines()
        Dim cpt As Integer = 0
        For i = 0 To players.Count - 1
            For gm = 0 To players(i).scores.getlength(0) - 1
                For diff = 0 To players(i).scores.getlength(1) - 1
                    If players(i).scores(gm, diff).score <> 0 Then
                        tabLines(cpt) = getNewtabLine(i, gm, diff)
                        cpt += 1
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub fillTab()
        Dim cpt As Integer = 0
        For i = 0 To tabLines.Length - 1
            tab(0, cpt).Text = tabLines(i).p.name
            tab(1, cpt).Text = gmNames(tabLines(i).gm)
            tab(2, cpt).Text = diffNames(tabLines(i).diff)
            tab(3, cpt).Text = tabLines(i).getScores.score
            tab(4, cpt).Text = tabLines(i).getScores.aideLoss
            AddHandler tab(4, cpt).Click, AddressOf aidePanel
            cpt += 1
        Next
    End Sub

    Dim panStay As Timer
    Dim pan As Panel

    Private Sub aidePanel(sender As Object, e As EventArgs)
        Dim sx As Integer = Integer.Parse(sender.name(8))
        Dim sy As Integer = Integer.Parse(sender.name(10))

        Dim pWidth As Integer = 200
        Dim pHeight As Integer = 150
        Dim px As Integer = (sender.location.x + (sender.width \ 2)) - (pWidth \ 2) + pS_tab.Location.X
        Dim py As Integer = sender.location.y + pS_tab.Location.Y - pHeight \ 6
        If py + pHeight + 45 > Me.Height Then
            py = Me.Height - pHeight - 45
        End If

        pan = New Panel
        With pan
            .Location = New Point(px, py)
            .Width = pWidth
            .Height = pHeight
            .BackColor = Color.FromArgb(240, 240, 240)
            .BorderStyle = BorderStyle.FixedSingle
        End With
        AddHandler pan.MouseEnter, AddressOf hovPan
        AddHandler pan.MouseLeave, AddressOf leavePan

        panStay = New Timer
        panStay.Interval = 10
        AddHandler panStay.Tick, AddressOf delPan

        Dim l As Label
        Dim posY As Integer = 10
        Dim pas = 25

        l = getNewLabelForAidePan(posY)
        l.Text = "Indications couleurs : " & If(tabLines(sy).getScores.aideCoul, "Oui", "Non")
        pan.Controls.Add(l)
        posY += pas
        l = getNewLabelForAidePan(posY)
        l.Text = "Solution de cases aléatoires : " & If(tabLines(sy).getScores.aideAleat > 0, tabLines(sy).getScores.aideAleat, "Non")
        pan.Controls.Add(l)
        posY += pas
        l = getNewLabelForAidePan(posY)
        l.Text = "Solution de case unique : " & If(tabLines(sy).getScores.aideSol > 0, tabLines(sy).getScores.aideSol, "Non")
        pan.Controls.Add(l)
        posY += pas
        l = getNewLabelForAidePan(posY)
        l.Text = "Défilement des possiblités : " & If(tabLines(sy).getScores.aideDefil, "Oui", "Non")
        pan.Controls.Add(l)
        posY += pas
        l = getNewLabelForAidePan(posY)
        l.Text = "Suggestion des possibilités : " & If(tabLines(sy).getScores.aideSug, "Oui", "Non")
        pan.Controls.Add(l)
        posY += pas

        Me.Controls.Add(pan)
        pan.BringToFront()
    End Sub

    Private Function getNewLabelForAidePan(ByVal posY As Integer) As Label
        Dim l As New Label
        With l
            .Font = New Font("Microsoft Sans Serif", 8)
            .Location = New Point(0, posY)
            .Width = pan.Width
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        AddHandler l.MouseEnter, AddressOf hovPan
        AddHandler l.MouseLeave, AddressOf leavePan
        Return l
    End Function

    Private Sub hovPan(sender As Object, e As EventArgs)
        panStay.Stop()
    End Sub
    Private Sub leavePan(sender As Object, e As EventArgs)
        panStay.Start()
    End Sub
    Private Sub delPan()
        Me.Controls.Remove(pan)
        panStay.Dispose()
    End Sub

    '------- TRIS -------'

    Private Sub triByName(ByVal c As Integer)
        Debug.Assert(c = -1 Or c = 1)

        Dim tabLines2(tabLines.Length - 1) As tabLine
        Dim list As List(Of tabLine) = tabLines.ToList
        For i2 = 0 To tabLines2.Length - 1
            Dim i As Integer = 0
            For i1 = list.Count - 1 To 0 Step -1
                If If(c > 0, list(i1).p.name <= list(i).p.name, list(i1).p.name >= list(i).p.name) Then
                    'Nom
                    If list(i1).p.name = list(i).p.name Then
                        'meme nom
                        If list(i1).gm <= list(i).gm Then
                            'gm
                            If list(i1).gm = list(i).gm Then
                                'meme gm
                                If list(i1).p.scores(list(i1).gm, list(i1).diff).score < list(i).p.scores(list(i).gm, list(i).diff).score Then
                                    i = i1
                                End If
                            Else
                                'pas meme gm
                                i = i1
                            End If
                        End If
                    Else
                        'pas meme nom
                        i = i1
                    End If
                End If
            Next
            tabLines2(i2) = list(i)
            list.RemoveAt(i)
        Next
        tabLines = tabLines2
    End Sub

    Private Sub tribyGm(ByVal c As Integer)
        Debug.Assert(c = -1 Or c = 1)

        Dim tabLines2(tabLines.Length - 1) As tabLine
        Dim list As List(Of tabLine) = tabLines.ToList
        For i2 = 0 To tabLines2.Length - 1
            Dim i As Integer = 0
            For i1 = list.Count - 1 To 0 Step -1
                If If(c > 0, list(i1).gm <= list(i).gm, list(i1).gm >= list(i).gm) Then
                    'gm
                    If list(i1).gm = list(i).gm Then
                        'meme gm
                        If list(i1).diff <= list(i).diff Then
                            'diff
                            If list(i1).diff = list(i).diff Then
                                'meme diff
                                If list(i1).p.scores(list(i1).gm, list(i1).diff).score < list(i).p.scores(list(i).gm, list(i).diff).score Then
                                    i = i1
                                End If
                            Else
                                'pas meme diff
                                i = i1
                            End If
                        End If
                    Else
                        'pas meme gm
                        i = i1
                    End If
                End If
            Next
            tabLines2(i2) = list(i)
            list.RemoveAt(i)
        Next
        tabLines = tabLines2
    End Sub

    Private Sub tribyDiff(ByVal c As Integer)
        Debug.Assert(c = -1 Or c = 1)

        Dim tabLines2(tabLines.Length - 1) As tabLine
        Dim list As List(Of tabLine) = tabLines.ToList
        For i2 = 0 To tabLines2.Length - 1
            Dim i As Integer = 0
            For i1 = list.Count - 1 To 0 Step -1
                If If(c > 0, list(i1).diff <= list(i).diff, list(i1).diff >= list(i).diff) Then
                    'diff
                    If list(i1).diff = list(i).diff Then
                        'meme diff
                        If list(i1).gm <= list(i).gm Then
                            'gm
                            If list(i1).gm = list(i).gm Then
                                'meme gm
                                If list(i1).p.scores(list(i1).gm, list(i1).diff).score < list(i).p.scores(list(i).gm, list(i).diff).score Then
                                    i = i1
                                End If
                            Else
                                'pas meme gm
                                i = i1
                            End If
                        End If
                    Else
                        'pas meme diff
                        i = i1
                    End If
                End If
            Next
            tabLines2(i2) = list(i)
            list.RemoveAt(i)
        Next
        tabLines = tabLines2
    End Sub

    Private tri = 0
    Private ordre = -1

    Private Sub tbS_pseu_Click(sender As Object, e As EventArgs) Handles tbS_pseu.Click
        If tri <> 0 Then
            ordre = 1
            tri = 0
        Else
            ordre *= -1
        End If
        triByName(ordre)
        fillTab()
    End Sub
    Private Sub tbS_gm_Click(sender As Object, e As EventArgs) Handles tbS_gm.Click
        If tri <> 1 Then
            ordre = 1
            tri = 1
        Else
            ordre *= -1
        End If
        tribyGm(ordre)
        fillTab()
    End Sub
    Private Sub tbS_diff_Click(sender As Object, e As EventArgs) Handles tbS_diff.Click
        If tri <> 2 Then
            ordre = 1
            tri = 2
        Else
            ordre *= -1
        End If
        tribyDiff(ordre)
        fillTab()
    End Sub

End Class