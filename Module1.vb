Imports System
Imports Microsoft.VisualBasic

Module Module1
    ' +-------------------+
    ' Coded By : Teix
    ' GitHub : https://github.com/Teixz
    ' Credits for SmoLL_ice
    ' Don´t Remove this!
    ' +-------------------+
    Dim Scan As New DotNetScanMemory_SmoLL
    Dim Founds As IntPtr()
    Dim bytestr As String
    Dim str As String
    Dim path As String
    Dim proces As String
    Dim hexstr As String
    Dim fileReader As String
    Sub Main()
        Console.Title = "String Cheker based on Teix work"
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("Please, Put the process ( Don´t use extension ) :")
        proces = Console.ReadLine()
        Console.WriteLine("Please, Put the path for the txt ( ex: folder/file.txt ) :")
        path = Console.ReadLine()
        Console.WriteLine("Searching for process " & proces & "...")
        
        SearchProc()
    End Sub
    Public Sub RemoveString()
        Try
            Dim i As Long
            Dim abData() As Byte
            abData = System.Text.Encoding.Default.GetBytes(str)
            For i = 0 To UBound(abData)
                hexstr = hexstr & Hex(abData(i)) & " "
            Next
            bytestr = hexstr
            bytestr = bytestr.Substring(0, bytestr.Length - 1)
            Founds = Scan.ScanArray(Scan.GetPID(proces), bytestr)
            If (Founds.Count > 0) Then
                If Founds(0) = 0 Then
                    ' Menssage of String Not Found
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("The string " & str & " Not found on " & proces)
                Else
                    For ic As Integer = 0 To Founds.Count - 1
                        ' Menssage of String Found
                        Scan.WriteArray(Founds(i), "00")
                        Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("The string " & str & " se trouve bien dans " & proces)
                        Console.ReadLine()
                        'Information if you want.
                        Console.WriteLine("+--------+")
                        Console.WriteLine("String : " & str)
                        Console.WriteLine("Process : " & proces)
                        Console.WriteLine("Quantity : " & Founds.Count)
                        Console.WriteLine("+--------+")
                    Next
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
    Public Sub SearchProc()
        Try
            Dim Proc() As Process = Process.GetProcessesByName(proces)
            If Proc.Count > 0 Then
                If Proc.Count > 2 Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("There are two process with same name, please kill one.")
                    Console.ReadLine()
                Else
            fileReader = My.Computer.FileSystem.ReadAllText(str)
          For Each Line As String In File.ReadLines(str)
           'YourTextbox.Text = line
            Console.WriteLine("Je cherche la string " & line & " on " & proces & "...")
            str = line;
                    RemoveString()
            await Task.Delay(500)//Await a second
        Next
        'Console.WriteLine("Je cherche la string " & str & " on " & proces & "...")
                    'RemoveString()
                End If
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("The process : " & proces & " don´t exist.")
                Console.ReadLine()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
End Module
