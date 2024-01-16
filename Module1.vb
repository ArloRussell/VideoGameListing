Module Module1
    Private videoGames As New List(Of VideoGame)

    Sub Main()
        Dim input As String
        BuildGameList()
        Do
            PrintVideoGameList()
            Console.Write("Enter an index for more info on a person, or ""Q"" to quit >> ")
            input = Console.ReadLine.Trim.ToUpper
            Dim num As Integer
            If Integer.TryParse(input, num) AndAlso num >= 0 AndAlso num < videoGames.Count() Then
                PrintGameSummary(videoGames(num))
            End If
        Loop While input <> "Q"
    End Sub

    Sub BuildGameList()
        Dim filename As String = "someMarioGames.txt"
        Dim delimiter As String = ControlChars.Tab
        If Not IO.File.Exists(filename) Then
            Console.WriteLine("File Not Found")
            Return
        End If
        Dim infile As New IO.StreamReader(filename)
        videoGames = New List(Of VideoGame)
        infile.ReadLine() 'Munches down on first row. Nom Nom.
        While infile.Peek <> -1
            Dim line() As String = infile.ReadLine.Split(delimiter)
            Dim game As New VideoGame
            game.gameid = line(0)
            game.name = line(1)
            game.summary = line(2)
            game.video_id = line(3)
            game.platform = line(4)
            videoGames.Add(game)
        End While
        SortByName()
        infile.Close()
    End Sub
    Sub SortByName()
        videoGames.Sort(Function(x As VideoGame, y As VideoGame)
                            Return x.name.CompareTo(y.name)
                        End Function)
    End Sub
    Sub PrintVideoGameList()
        Console.Clear()
        Console.WriteLine($"{"index".PadLeft(5)} | {"Name".PadRight(25)}")
        For i As Integer = 0 To videoGames.Count - 1
            Dim vg As VideoGame = videoGames(i)
            Console.WriteLine($"{i.ToString.PadLeft(5)} | {vg.name.PadRight(25)}")
        Next
    End Sub
    Sub PrintGameSummary(game As VideoGame)
        Dim input As String
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(game.name)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Summary:")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine(game.summary)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Platforms:")
        Console.ForegroundColor = ConsoleColor.White
        PrintPlatforms(game)

        Console.WriteLine(vbNewLine & $"Enter ""v"" to watch a video on {game.name}")
        input = Console.ReadLine.Trim.ToUpper
        If input = "V" Then
            game.Launch_Video()
        End If
    End Sub
    Sub PrintPlatforms(game As VideoGame)
        Dim separator As String = ","

        Dim line() As String = game.platform.Split(separator)

        For i As Integer = 0 To line.Length - 1

            Console.WriteLine(line(i))
        Next
    End Sub
End Module
