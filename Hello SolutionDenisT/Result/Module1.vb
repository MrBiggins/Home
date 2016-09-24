Imports System.Security.Cryptography.X509Certificates

Module Module1

    Sub Main()



        Dim fisrt As Integer
        Dim second As Integer
        Dim third As Integer
        Dim result As Integer

        Dim firstEntrance = New FisrtDigit.DigitiListener()
        Dim secondEntrance = New SecondDigit.DigitListener()
        Dim thirdEntrance = New ThirdDigit.DigitiListener()
        fisrt = firstEntrance.EnterDigit()
        second = secondEntrance.EnterDigit()
        third = thirdEntrance.EnterDigit()
        result = fisrt + second + third


        Console.WriteLine("Result is: " + result.ToString())

        Console.ReadLine()
    End Sub
End Module
