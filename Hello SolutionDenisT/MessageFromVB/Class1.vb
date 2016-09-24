Public Class VbMessage
    Inherits MessageFromCPP.CppMessage
    Public Overrides Sub Message()
        MyBase.Message()
        Console.WriteLine("This message comes from VB Layer")
    End Sub
End Class
