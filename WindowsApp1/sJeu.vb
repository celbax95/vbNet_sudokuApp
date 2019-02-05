Public Class sJeu

    Private Const T As Integer = 9
    Private Const Z As Integer = 3
    Private FULL As Integer = T * T
    Private diffs() As Integer = {43, 37, 31}

    Private opt As sOptions.Setting

    Private colorNormal As Color = Color.White
    Private colorSelect As Color = Color.FromArgb(&HFFE0FFE0)
    Private colorWrong As Color = Color.FromArgb(&HFFFF5050)
    Private colorWrongSelect As Color = Color.FromArgb(&HFFFFA050)
    Private colorPlayGrid As Color = Color.FromArgb(&HFFF0F0F0)
    Private colorBlock As Color = Color.FromArgb(&HFF89A7C3)
    Private colorBlockSelect As Color = Color.FromArgb(&HFF89B5C3)
    Private colorBlockUsed As Color = Color.FromArgb(&HFFAEAEAE)

    Private Const bestStdScore As Integer = 5000
    Private nbAT As Integer
    Private unique As Boolean = True

    Private random As New Random()
    Private solution(T - 1, T - 1) As Integer 'Grille complete
    Private gridTB(T - 1, T - 1) As TextBox 'Grille de textbox
    Private grid(T - 1, T - 1) As Integer 'Grille de jeu
    Private playGrid(T - 1, T - 1) As Integer 'Grille avec les trous

    'nombre de points perdus avec l'aide
    Private lostAide As Integer = 50
    'nombre de case a completer avec l'aide aleat
    Private nbAideAleat As Integer = 5
    Private aideInd As Boolean
    Private aide As Boolean
    Private nbUseSol As Integer = 0
    Private nbUseAleat As Integer = 0

    Private lastfocus(1) As Integer

    Private indWheel As Integer = 0

    Private tmpButtonsHovered As Boolean
    Private tmpButtons As Panel

    Private scoreCaseClm As Integer = 100

    Private startCLM As Integer = 60
    Private chrono As Integer
    Private tim As New Timer

    Private nbBlock As Integer
    Private nbBlockFill As Integer
    Private block(,) As Boolean
    Private blockCaseScore As Integer = 200
    Private blockGridScore As Integer = 500
    Private bestBlockScore As Integer = 2000

    '-------- FONCTIONS FORM ----------'

    Private Sub grid_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim sx As Integer = Integer.Parse(sender.Name(7))
        Dim sy As Integer = Integer.Parse(sender.Name(9))
        If Not IsNumeric(e.KeyChar) Then
            If playGrid(sx, sy) <> 0 Then
                e.Handled = True
                Return
            End If
            If Not IsNothing(block) Then
                If block(sx, sy) And grid(sx, sy) <> 0 Then
                    e.Handled = True
                    Return
                End If
            End If
            If Asc(e.KeyChar) = 8 Then
                sender.text = ""
            End If
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub grid_TextChanged(sender As Object, e As EventArgs)
        Dim sx As Integer = Integer.Parse(sender.Name(7))
        Dim sy As Integer = Integer.Parse(sender.Name(9))

        If IsNumeric(sender.Text) Or sender.Text = "" Then
            If IsNumeric(sender.Text) Then
                grid(sx, sy) = Integer.Parse(sender.Text)
                If isBlock(sx, sy) Then
                    If If(sender.Controls.Count > 0,
                    (Not IsNothing(sender.Controls.Item(0))), False
                    ) Then
                        sender.Controls.RemoveAt(0)
                        Return
                    End If
                    nbBlockFill += 1
                End If
            Else
                grid(sx, sy) = 0
            End If
            If Not isBlock(sx, sy) Then
                For x = 0 To T - 1
                    For y = 0 To T - 1
                        If (Not isValid(grid(x, y), x, y, grid)) And (grid(x, y) <> 0) Then
                            If opt.aideCoul Then
                                If x = sx And y = sy Then
                                    gridTB(x, y).BackColor = colorWrongSelect
                                Else
                                    gridTB(x, y).BackColor = colorWrong
                                End If
                            End If
                        Else
                            If (playGrid(x, y) = 0) Then
                                If x = sx And y = sy Then
                                    gridTB(x, y).BackColor = colorSelect
                                Else
                                    gridTB(x, y).BackColor = colorNormal
                                End If
                            Else
                                gridTB(x, y).BackColor = colorPlayGrid
                            End If
                        End If
                        updateBlock(x, y)
                    Next
                Next
                tbJ_indOf_updateColor(gridTB(sx, sy))
            Else
                updateBlock(sx, sy)
            End If
        End If
    End Sub

    Private Sub grid_GetFocus(sender As Object, e As EventArgs)
        ' acienne case focus
        If playGrid(lastfocus(0), lastfocus(1)) = 0 Then
            'la case peut-elle etre jouée
            If (Not isValid(grid(lastfocus(0), lastfocus(1)), lastfocus(0), lastfocus(1), grid)) And (grid(lastfocus(0), lastfocus(1)) <> 0) Then
                ' Case Fausse
                gridTB(lastfocus(0), lastfocus(1)).BackColor = colorWrong
            Else
                'Case bonne
                gridTB(lastfocus(0), lastfocus(1)).BackColor = colorNormal
            End If
        End If

        'update couleur case si block
        updateBlock(lastfocus(0), lastfocus(1))
        ' update couleur des indices
        tbJ_indOf_updateColor(gridTB(lastfocus(0), lastfocus(1)))

        ' nouvelle case focus
        lastfocus(0) = Integer.Parse(sender.Name(7))
        lastfocus(1) = Integer.Parse(sender.Name(9))

        If playGrid(lastfocus(0), lastfocus(1)) = 0 Then
            'Case jouable
            If (Not isValid(grid(lastfocus(0), lastfocus(1)), lastfocus(0), lastfocus(1), grid)) And (grid(lastfocus(0), lastfocus(1)) <> 0) Then
                'Case fausse
                gridTB(lastfocus(0), lastfocus(1)).BackColor = colorWrongSelect
            Else
                'case bonne
                gridTB(lastfocus(0), lastfocus(1)).BackColor = colorSelect
            End If
        End If

        If isBlock(lastfocus(0), lastfocus(1)) Then
            gridTB(lastfocus(0), lastfocus(1)).BackColor = colorBlockSelect
        End If

        tbJ_indOf_updateColor(gridTB(lastfocus(0), lastfocus(1)))
    End Sub

    Private Sub grid_MouseDown(sender As Object, e As MouseEventArgs)
        If playGrid(Integer.Parse(sender.Name(7)), Integer.Parse(sender.Name(9))) Then
            Me.Select()
        End If

        If e.Button = MouseButtons.Right Then
            If opt.aideInd Then
                addSupprIndice(sender)
            Else
                sender.select()
            End If
        End If
    End Sub

    '-------- FONCTIONS BOUTONS ----------'

    Private Sub bJ_quitter_Click(sender As Object, e As EventArgs) Handles bJ_quitter.Click
        sMenu.Show()
        tim.Enabled = False
        Me.Close()
    End Sub

    Private Sub bJ_gen_Click() Handles bJ_gen.Click
        solution = create()
        Dim tGrid As Integer(,) = getPlayableBoard(solution, diffs(1), True)
        apply(tGrid)
    End Sub

    Private Sub bj_sol_Click() Handles bJ_sol.Click
        tim.Stop()
        apply(solution)
    End Sub

    Private Sub bJ_vider_Click() Handles bJ_vider.Click
        ReDim playGrid(playGrid.GetLength(0) - 1, playGrid.GetLength(1) - 1)
        For y = 0 To T - 1
            For x = 0 To T - 1
                gridTB(x, y).Text = ""
            Next
        Next
    End Sub

    '-------- FONCTIONS MAINFRAME ----------'

    Private Sub sJeu_Click(sender As Object, e As EventArgs) Handles Me.Click
        gridTB(lastfocus(0), lastfocus(1)).Select()
    End Sub

    Private Sub sJeu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tb As New System.Windows.Forms.TextBox
        Dim startPosX As Integer = 30
        Dim startPosY As Integer = 20
        Dim tbPosX As Integer = startPosX
        Dim tbPosY As Integer = startPosY
        Dim tbSize As Integer = 38
        Dim space As Integer = 5
        For y = 0 To T - 1
            If y Mod 3 = 0 And y <> 0 Then
                tbPosY += space
            End If

            For x = 0 To T - 1
                If x Mod 3 = 0 And x <> 0 Then
                    tbPosX += space
                End If
                tb.Name = "txtBox_" & x & "-" & y
                tb.Size = New Size(tbSize, tbSize)
                tb.Location = New Point((tbSize * (x + 1)) + tbPosX,
                                        (tbSize * (y + 1)) + tbPosY)
                tb.Font = New Font("Courier", 21)
                tb.MaxLength = 1
                tb.TextAlign = HorizontalAlignment.Center
                tb.ShortcutsEnabled = False
                AddHandler tb.KeyPress, AddressOf grid_KeyPress
                AddHandler tb.TextChanged, AddressOf grid_TextChanged
                AddHandler tb.Enter, AddressOf grid_GetFocus
                AddHandler tb.MouseDown, AddressOf grid_MouseDown
                gridTB(x, y) = tb
                Me.Controls.Add(tb)

                tb = New System.Windows.Forms.TextBox
            Next
            tbPosX = startPosX
        Next
    End Sub

    '-------- FONCTIONS AIDE ----------'

    Private Sub bJ_aide_Click(sender As Object, e As EventArgs) Handles bJ_aide.Click
        Console.WriteLine()
        If playGrid(lastfocus(0), lastfocus(1)) <> 0 Then
            Return
        End If

        gridTB(lastfocus(0), lastfocus(1)).Text = solution(lastfocus(0), lastfocus(1))

        nbUseSol += 1
    End Sub

    Private Sub bJ_aleat_Click(sender As Object, e As EventArgs) Handles bJ_aleat.Click
        Dim x, y As Integer
        For i = 1 To nbAideAleat
            Do
                x = random.Next(0, T)
                y = random.Next(0, T)
            Loop Until (playGrid(x, y) = 0 And grid(x, y) = 0) Or isFull(grid)
            nbUseAleat += 1
            gridTB(x, y).Text = solution(x, y)
        Next
    End Sub

    '-------- FONCTIONS BOUTON INDICES  ----------'

    Private Sub grid_HideIndicesButtons(sender As Object, e As EventArgs)
        Me.Controls.Remove(sender)
    End Sub

    Public Sub grid_ShowIndicesButtons(sender As Object, e As EventArgs)
        Dim sx As Integer = Integer.Parse(sender.Name(7))
        Dim sy As Integer = Integer.Parse(sender.Name(9))

        If playGrid(sx, sy) <> 0 Or isBlock(sx, sy) Then
            Return
        End If

        Dim poss As Integer() = getPossibleNumbers(sx, sy, grid)
        Console.WriteLine()
        Dim bWidth As Integer = 22
        Dim bFontSize As Integer = 8
        Dim bBordSize As Integer = 1
        Dim tmpBBordSize As Integer = 1
        Dim tx As Integer = 0
        Dim ty As Integer = 0
        Dim b As New Button
        Dim nbInLine As Integer

        tmpButtons = New Panel
        tmpButtons.Name = "gbJ_tmpB"
        tmpButtons.BackColor = Color.FromArgb(&HFFF8F8F8)
        tmpButtons.BorderStyle = BorderStyle.FixedSingle
        If poss.Length <= 4 Then
            tmpButtons.Location = New Point((sender.location.x - (bWidth * 2 - sender.width) \ 2) - tmpBBordSize,
                                            (sender.location.y - (bWidth * 2 - sender.width) \ 2) - tmpBBordSize)
            tmpButtons.Width = bWidth * 2
            tmpButtons.Height = bWidth * 2
            nbInLine = 2
        Else
            tmpButtons.Location = New Point((sender.location.x - (bWidth * 3 - sender.width) \ 2) - tmpBBordSize,
                                            (sender.location.y - (bWidth * 3 - sender.width) \ 2) - tmpBBordSize)
            tmpButtons.Width = bWidth * Z
            tmpButtons.Height = bWidth * Z
            nbInLine = 3
        End If
        tmpButtons.Width += tmpBBordSize * 2
        tmpButtons.Height += tmpBBordSize * 2
        AddHandler tmpButtons.Leave, AddressOf grid_HideIndicesButtons
        Me.Controls.Add(tmpButtons)
        tmpButtons.Select()
        tmpButtons.BringToFront()

        For i = 0 To poss.Length - 1
            b.Size = New Size(bWidth, bWidth)
            b.Location = New Point((bWidth * (i Mod nbInLine)), (bWidth * (i \ nbInLine)))
            b.Text = poss(i)
            b.TextAlign = HorizontalAlignment.Center
            b.Font = New Font("Courrier", bFontSize)
            b.Name = "bJ_tmp_" & sx & "_" & sy
            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = bBordSize
            b.BackColor = Color.FromArgb(&HFFF8F8F8)
            b.FlatAppearance.MouseOverBackColor = Color.White
            AddHandler b.Click, AddressOf buttonsAide
            tmpButtons.Controls.Add(b)
            b.BringToFront()
            b = New Button
        Next
    End Sub

    Private Sub buttonsAide(sender As Object, e As EventArgs)
        gridTB(Integer.Parse(sender.Name(7)), Integer.Parse(sender.Name(9))).Text = sender.text
        Me.Controls.Remove(tmpButtons)
    End Sub

    '-------- FONCTIONS ROULETTE SOURIS ----------'

    Private Sub aideMouseWheel(sender As Object, e As MouseEventArgs)
        Dim sx As Integer = Integer.Parse(sender.Name(7))
        Dim sy As Integer = Integer.Parse(sender.Name(9))

        If playGrid(sx, sy) <> 0 Or isBlock(sx, sy) Then
            Return
        End If

        Dim poss As Integer() = getPossibleNumbers(sx, sy, grid)

        gridTB(sx, sy).Select()

        indWheel = 0
        If poss.GetLength(0) > 0 Then
            For i = 0 To poss.GetLength(0) - 1
                If poss(i) = grid(sx, sy) Then
                    indWheel = i
                End If
            Next

            If e.Delta > 0 Then
                indWheel = (indWheel + 1) Mod poss.GetLength(0)
                gridTB(sx, sy).Text = poss(indWheel)
            Else
                indWheel = If(indWheel - 1 < 0, poss.GetLength(0) - 1, indWheel - 1)
                gridTB(sx, sy).Text = poss(indWheel)
            End If
        End If
    End Sub

    '-------- FONCTIONS INDICES ----------'

    Private Sub addSupprIndice(ByRef tb As TextBox)
        Dim sx As Integer = Integer.Parse(tb.Name(7))
        Dim sy As Integer = Integer.Parse(tb.Name(9))

        If (isBlock(sx, sy) And grid(sx, sy) <> 0) Or (playGrid(sx, sy) <> 0) Then
            Return
        End If

        If tb.Controls.OfType(Of TextBox).Count > 0 Then
            tb.Controls.OfType(Of TextBox).ElementAt(0).Select()
        Else
            Dim tbi As New TextBox
            tbi.Location = New Point(24, -1)
            tbi.Width = 10
            tbi.Height = 10
            tbi.Font = New Font("Courier", 9)
            tbi.MaxLength = 1
            tbi.ShortcutsEnabled = False
            tbi.BackColor = tb.BackColor
            tbi.BorderStyle = BorderStyle.None
            tbi.TextAlign = HorizontalAlignment.Center
            tbi.Name = "tbJ_indOf_" & sx & "_" & sy
            AddHandler tbi.Click, AddressOf tbJ_indOf_Click
            AddHandler tbi.Leave, AddressOf tbJ_indOf_Leave
            AddHandler tbi.KeyPress, AddressOf tbJ_indOf_KeyPress

            tb.Controls.Add(tbi)
            tbi.BringToFront()
            tbi.Select()
        End If

    End Sub

    Private Sub tbJ_indOf_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then
            sender.text = ""
        End If
    End Sub

    Private Sub tbJ_indOf_Click(sender As Object, e As MouseEventArgs)
        Dim parent As TextBox = gridTB(Integer.Parse(sender.Name(10)), Integer.Parse(sender.Name(12)))
        parent.Select()
        grid_MouseDown(parent, e)
    End Sub

    Private Sub tbJ_indOf_Leave(sender As Object, e As EventArgs)
        If sender.text = "" Then
            gridTB(Integer.Parse(sender.name(10)), Integer.Parse(sender.name(12))).Controls.Remove(sender)
        End If
    End Sub

    Private Sub tbJ_indOf_updateColor(ByRef tb As TextBox)
        If If(tb.Controls.Count > 0,
        (Not IsNothing(tb.Controls.Item(0))), False
        ) Then
            tb.Controls.Item(0).BackColor = tb.Controls.Item(0).Parent.BackColor
        End If
    End Sub

    '-------- FONCTIONS STANDARD ----------'

    Private Sub playStd()
        chrono = 0
        lblJ_cpt.Text = chrono
        AddHandler tim.Tick, AddressOf playStdLoop
        tim.Interval = 1000
        tim.Enabled = True
    End Sub

    Private Sub playStdLoop(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isFull(grid) Or chrono >= bestStdScore Then
            If isValid(grid) Or chrono >= bestStdScore Then
                tim.Enabled = False
                Dim sc As Integer = (bestStdScore - chrono)
                Dim scLoss As Integer = (nbUseSol * sOptions.scLosSol) + (nbUseAleat * sOptions.scLosAleat)
                If opt.aideDefil Then
                    scLoss += sOptions.scLosDefil
                End If
                If opt.aideCoul Then
                    scLoss += sOptions.scLosCoul
                End If
                If opt.aideSug Then
                    scLoss += sOptions.scLosSug
                End If
                sc -= scLoss
                If sc < 0 Then
                    sc = 0
                End If

                MsgBox("Votre score : " & sc, vbOKOnly, "Partie terminée")
                sMenu.saveScore(sc, scLoss, nbUseSol, nbUseAleat, opt)
                Return
            End If
        End If
        chrono += 1
        lblJ_cpt.Text = chrono



    End Sub

    '-------- FONCTIONS CONTRE LA MONTRE ----------'

    Private Sub playClm()
        chrono = startCLM
        lblJ_cpt.Text = chrono
        AddHandler tim.Tick, AddressOf playClmLoop
        tim.Interval = 1000
        tim.Enabled = True
    End Sub

    Private Sub playClmLoop(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isFull(grid) Or chrono <= 0 Then
            If isValid(grid) Or chrono <= 0 Then
                tim.Enabled = False

                Dim sc As Integer = ((nbAT - nbEmpty()) * scoreCaseClm) - (startCLM - chrono)
                Dim scLoss As Integer = (nbUseSol * sOptions.scLosSol) + (nbUseAleat * sOptions.scLosAleat)
                If opt.aideDefil Then
                    scLoss += sOptions.scLosDefil
                End If
                If opt.aideCoul Then
                    scLoss += sOptions.scLosCoul
                End If
                If opt.aideSug Then
                    scLoss += sOptions.scLosSug
                End If
                sc -= scLoss

                If sc < 0 Then
                    sc = 0
                End If

                MsgBox("Votre score : " & sc, vbOKOnly, "Partie terminée")
                sMenu.saveScore(sc, scLoss, nbUseSol, nbUseAleat, opt)
                Return
            End If
        End If
        chrono -= 1
        If chrono >= 0 Then
            lblJ_cpt.Text = chrono
        End If
    End Sub

    '-------- FONCTIONS BLOCK ----------'

    Private Function isBlock(ByVal x As Integer, ByVal y As Integer) As Boolean
        If Not IsNothing(block) Then
            Return block(x, y)
        End If
        Return False
    End Function

    Private Sub playBlock()
        chrono = 0
        lblJ_cpt.Text = chrono
        nbBlock = diffs(opt.diff) \ 2
        nbBlockFill = 0
        ReDim block(T - 1, T - 1)
        For i = 1 To nbBlock
            Dim x As Integer
            Dim y As Integer
            Do
                x = random.Next(T)
                y = random.Next(T)
            Loop While playGrid(x, y) <> 0 Or block(x, y)
            block(x, y) = True
            gridTB(x, y).BackColor = colorBlock
        Next

        AddHandler tim.Tick, AddressOf playBlockLoop
        tim.Interval = 1000
        tim.Enabled = True
    End Sub

    Private Function cloneWB(ByRef g As Integer(,)) As Integer(,)
        Dim g2 As Integer(,) = clone(g)
        For x = 0 To T - 1
            For y = 0 To T - 1
                If block(x, y) Then
                    g2(x, y) = 0
                End If
            Next
        Next
        Return g2
    End Function

    Private Function getValidBlock(ByRef useSol As Integer(,))
        Dim cpt As Integer = 0
        For y = 0 To T - 1
            For x = 0 To T - 1
                If block(x, y) Then
                    If isValid(grid(x, y), x, y, useSol) Then
                        cpt += 1
                    End If
                End If
            Next
        Next
        Return cpt
    End Function

    Private Sub playBlockLoop()
        If chrono >= bestBlockScore Then
            tim.Enabled = False
        End If
        If nbBlockFill = nbBlock Then
            tim.Enabled = False
        End If


        If Not tim.Enabled Then
            Dim useSol As Integer(,) = solution
            Dim cptV As Integer = 0

            If isFull(grid) Then
                If Not areEquals(solution, grid) Then
                    Dim gridWB As Integer(,) = cloneWB(grid)
                    If isValid(gridWB) Then
                        useSol = gridWB
                    End If
                End If
            End If

            cptV = getValidBlock(useSol)

            Dim sc As Integer = ((bestBlockScore - chrono) \ (1 / (cptV / nbBlock))) \ 2 +
                (cptV * blockCaseScore) -
                ((nbBlock - cptV) * (blockCaseScore \ 2)) +
                If(isValid(grid), blockGridScore, 0)
            Dim scLoss As Integer = 0
            If opt.aideCoul Then
                scLoss += sOptions.scLosCoul
            End If
            sc -= scLoss
            If sc < 0 Then
                sc = 0
            End If

            MsgBox("Votre score : " & sc, vbOKOnly, "Partie terminée")
            sMenu.saveScore(sc, scLoss, nbUseSol, nbUseAleat, opt)
            Return
        End If
        chrono += 1
        lblJ_cpt.Text = chrono
    End Sub

    Private Sub updateBlock(ByVal x As Integer, ByVal y As Integer)
        If Not IsNothing(block) Then
            If block(x, y) Then
                If gridTB(x, y).Text <> "" Then
                    gridTB(x, y).BackColor = colorBlockUsed
                    gridTB(x, y).Cursor = Cursors.Arrow
                Else
                    gridTB(x, y).BackColor = colorBlock
                End If
            End If
        End If
    End Sub

    '-------- FONCTIONS SUDO ----------'

    Public Sub generate(ByRef opt As sOptions.Setting)
        Me.opt = opt

        solution = create()
        Dim tGrid As Integer(,) = getPlayableBoard(solution, diffs(opt.diff), True)

        If Not opt.aideAleat Then
            bJ_aleat.Hide()
        End If
        If Not opt.aideSol Then
            bJ_aide.Hide()
        End If

        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            If tb.Name.Substring(0, 6) = "txtBox" Then
                If opt.aideSug Then
                    AddHandler tb.DoubleClick, AddressOf grid_ShowIndicesButtons
                End If
                If opt.aideDefil Then
                    AddHandler tb.MouseWheel, AddressOf aideMouseWheel
                End If
            End If
        Next

        apply(tGrid)

        Select Case (opt.gm)
            Case 0
                playStd()
            Case 1
                playClm()
            Case 2
                playBlock()
        End Select

    End Sub

    Private Function create() As Integer(,)
        Dim fullGrid(T - 1, T - 1) As Integer
        Dim builder(,)() = getBuilder()
        Dim cpt = 0, x, y, n As Integer
        While Not isFull(fullGrid)

            x = cpt Mod T
            y = cpt \ T
            n = len(builder(x, y))

            If n = 0 Then
                refull(builder(x, y))
                fullGrid(x, y) = 0
                cpt = If(cpt - 1 < 0, FULL - 1, cpt - 1)
                Continue While
            End If

            n = rFB(builder(x, y))

            If Not isValid(n + 1, x, y, fullGrid) Then
                builder(x, y)(n) = False
                Continue While
            End If

            fullGrid(x, y) = n + 1
            builder(x, y)(n) = False
            cpt = (cpt + 1) Mod FULL
        End While
        Return clone(fullGrid)
    End Function

    Private Function getPlayableBoard(ByRef fullG As Integer(,), ByRef diff As Integer, ByVal unique As Boolean)

        nbAT = FULL - diff
        Dim x, y As Integer
        Dim tab As Integer(,)

        Do
            tab = clone(fullG)
            For i = 0 To nbAT - 1
                Do
                    x = random.Next(T)
                    y = random.Next(T)
                Loop Until (tab(x, y) <> 0)
                tab(x, y) = 0
            Next
        Loop While If(unique, Not isUnique(tab, fullG), False)
        Return tab
    End Function

    Private Function getSol(ByRef tGrid As Integer(,), ByVal nbSol As Integer) As Integer()(,)
        Dim builder(,)() = getBuilder()
        Dim sol(-1)(,) As Integer
        Dim pos(-1)() As Integer

        Dim indPos As Integer = 1
        For ty = 0 To T - 1
            For tx = 0 To T - 1
                If tGrid(tx, ty) = 0 Then
                    Dim p(1) As Integer
                    ReDim Preserve pos(pos.GetLength(0))
                    p(0) = tx
                    p(1) = ty
                    pos(pos.GetLength(0) - 1) = p
                End If
            Next
        Next

        Dim nb As Integer = 0
        Dim cpt As Integer = nb
        Dim x, y, n As Integer

        Dim g As Integer(,) = clone(tGrid)
        While nb < pos.GetLength(0)
            While Not isFull(g)
                x = pos(cpt)(0)
                y = pos(cpt)(1)

                n = len(builder(x, y))
                If n = 0 Then
                    refull(builder(x, y))
                    g(x, y) = 0
                    cpt = If(cpt - 1 < 0, pos.GetLength(0) - 1, cpt - 1)
                    Continue While
                End If

                n = rFB(builder(x, y))

                If Not isValid(n + 1, x, y, g) Then
                    builder(x, y)(n) = False
                    Continue While
                End If

                g(x, y) = n + 1
                builder(x, y)(n) = False
                cpt = (cpt + 1) Mod pos.GetLength(0)
            End While
            If Not alreadyFound(sol, g) Then
                ReDim Preserve sol(sol.GetLength(0))
                sol(sol.GetLength(0) - 1) = g
            End If
            g = clone(tGrid)
            nb += 1
            cpt = nb
            builder = getBuilder()
            If sol.GetLength(0) > nbSol And nbSol > 0 Then
                Return sol
            End If
        End While
        Return sol
    End Function

    'utilities

    Private Sub apply(ByRef gridF As Integer(,))
        playGrid = gridF
        For y = 0 To T - 1
            For x = 0 To T - 1
                If playGrid(x, y) <> 0 Then
                    gridTB(x, y).Text = playGrid(x, y).ToString()
                    gridTB(x, y).BackColor = colorPlayGrid
                    gridTB(x, y).ForeColor = Color.FromArgb(&HFF303030)
                    gridTB(x, y).Cursor = Cursors.Arrow
                Else
                    gridTB(x, y).Text = ""
                    gridTB(x, y).Cursor = Cursors.IBeam
                End If
            Next
        Next
    End Sub

    Private Function isValid(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer, ByRef tGrid As Integer(,)) As Boolean
        'Line / Column
        For i = 0 To T - 1
            If i <> x Then
                If tGrid(i, y) = n Then
                    Return False
                End If
            End If
            If i <> y Then
                If tGrid(x, i) = n Then
                    Return False
                End If
            End If
        Next
        'Square
        Dim x2 As Integer = (x \ 3) * 3
        Dim y2 As Integer = (y \ 3) * 3
        For ty = y2 To y2 + 2
            For tx = x2 To x2 + 2
                If tx <> x And ty <> y Then
                    If tGrid(tx, ty) = n Then
                        Return False
                    End If
                End If
            Next
        Next
        Return True
    End Function

    Private Function isValid(ByRef tab(,) As Integer) As Boolean
        For y = 0 To T - 1
            For x = 0 To T - 1
                If Not isValid(grid(x, y), x, y, grid) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Function isUnique(ByRef tab As Integer(,), ByRef fullg As Integer(,))
        Dim tSol As Integer()(,) = getSol(tab, 2)
        If tSol.GetLength(0) = 1 Then
            Return True
        End If
        Return False
    End Function

    Private Function getPossibleNumbers(ByVal x As Integer, ByVal y As Integer, ByRef g As Integer(,)) As Integer()
        Dim tab(-1) As Integer
        For i = 0 To T - 1
            If isValid(i + 1, x, y, g) Then
                ReDim Preserve tab(tab.GetLength(0))
                tab(tab.GetLength(0) - 1) = i + 1
            End If
        Next
        Return tab
    End Function

    '-------- FONCTIONS ANNEXES ----------'

    Private Function nbEmpty() As Integer
        Dim cpt As Integer = 0
        For y = 0 To T - 1
            For x = 0 To T - 1
                If grid(x, y) = 0 Then
                    cpt += 1
                End If
            Next
        Next
        Return cpt
    End Function

    Private Function alreadyFound(ByRef solL As Integer()(,), ByRef sol As Integer(,)) As Boolean
        For i = 0 To solL.GetLength(0) - 1
            If areEquals(solL(i), sol) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function getBuilder() As Boolean(,)()
        Dim builder(T - 1, T - 1)() As Boolean
        For i = 0 To T - 1
            For j = 0 To T - 1
                Dim tab(T - 1) As Boolean
                For k = 0 To T - 1
                    tab(k) = True
                Next
                builder(i, j) = tab
            Next
        Next
        Return builder
    End Function

    Private Function clone(ByRef grid As Integer(,)) As Integer(,)
        Dim t(grid.GetLength(0) - 1, grid.GetLength(1) - 1) As Integer

        For y = 0 To grid.GetLength(1) - 1
            For x = 0 To grid.GetLength(0) - 1
                t(x, y) = grid(x, y)
            Next
        Next
        Return t
    End Function

    Private Sub refull(ByRef tb As Boolean())
        For i = 0 To tb.GetLength(0) - 1
            tb(i) = True
        Next
    End Sub

    Private Function isFull(ByRef tb As Integer(,)) As Boolean
        For y = 0 To tb.GetLength(1) - 1
            For x = 0 To tb.GetLength(0) - 1
                If tb(x, y) = 0 Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Function len(ByRef tb As Boolean()) As Integer
        Dim cpt As Integer = 0
        For i = 0 To T - 1
            If tb(i) Then
                cpt += 1
            End If
        Next
        Return cpt
    End Function

    'Random num from du builder (!= 0)
    Private Function rFB(ByRef tb As Boolean()) As Integer
        Dim n As Integer
        Do
            n = random.Next(0, 9)
        Loop Until tb(n)
        Return n
    End Function

    Private Function areEquals(ByRef t1 As Integer(,), ByRef t2 As Integer(,))
        If t1.GetLength(0) <> t2.GetLength(0) Then
            Return False
        End If
        If t1.GetLength(1) <> t2.GetLength(1) Then
            Return False
        End If

        For i = 0 To t1.GetLength(0) - 1
            For j = 0 To t1.GetLength(1) - 1
                If t1(i, j) <> t2(i, j) Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Private Function charToIntArray(ByRef tc As Char(,)) As Integer(,)
        Dim ti(tc.GetLength(0), tc.GetLength(1)) As Integer
        For i = 0 To tc.GetLength(0) - 1
            For j = 0 To tc.GetLength(1) - 1
                ti(i, j) = Char.GetNumericValue(tc(i, j))
            Next
        Next
        Return ti
    End Function

    Private Sub display(ByVal tb As Integer(,))
        For y = 0 To T - 1
            If y Mod 3 = 0 Then
                For i = 0 To 30
                    Console.Write("-")
                Next
                Console.WriteLine()
            End If
            For x = 0 To T - 1
                If x Mod 3 = 0 Then
                    Console.Write("|")
                End If
                Console.Write(" " & tb(x, y) & " ")
            Next
            Console.WriteLine("|")
        Next
        For i = 0 To 30
            Console.Write("-")
        Next
        Console.WriteLine()
    End Sub

End Class