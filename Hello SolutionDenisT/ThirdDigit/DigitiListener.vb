Public Class DigitiListener
    Inherits FisrtDigit.DigitiListener

    Public Overrides Function EnterDigit() As Integer
        Console.WriteLine("Enter 3rd number>3")
        Dim number As String
        number = Console.ReadLine()
        Return number.ToString()
    End Function
End Class
