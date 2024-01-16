Public Class VideoGame
    Public gameid As String
    Public name As String
    Public summary As String
    Public video_id As String
    Public platform As String

    Public Sub New()
        Me.gameid = "unknown"
        Me.name = "N/A"
        Me.summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
        Me.platform = "N/A"
    End Sub

    Public Sub New(id As String, name As String, platform As String)
        Me.gameid = id
        Me.name = name
        Me.platform = platform
    End Sub

    Public Sub Launch_Video()
        Process.Start($"https://www.youtube.com/watch?v={video_id}")
    End Sub

    Public Overrides Function ToString() As String
        Return $"{name} ({platform})"
    End Function
End Class
