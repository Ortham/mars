Imports AgilentAutomation.UserControl1

Module Module1

    ' B2900Control is the function through which transfer and output measurements can be made. 
    ' It outputs the results in CSV format in the string variable s.

    ' A single set of measurements consists of the following:
    ' - A transfer measurement.
    ' - An output measurement.

    ' A single set of measurements creates the following output files:
    ' - A CSV file containing transfer measurement data.
    ' - A CSV file containing output measurement data.
    ' - A PNG file containing a transfer plot.
    ' - A PNG file containing an output plot.

    ' Files will be written automatically using a standard pattern based around a label provided by the user.
    ' - "transfer-label.csv"
    ' - "output-label.csv"
    ' - "transfer-label.png"
    ' - "output-label.png"

    ' When more than one set of measurements is to be taken, the user will be asked to select a folder in which to
    ' place the generated files. Each set's files will be placed into a different subfolder within this folder, with
    ' the subfolders being named "Set N" where N is the number of the set of which it contains the data.

    Sub Main()
        Dim rm As Ivi.Visa.Interop.ResourceManager
        Dim ioObj As Ivi.Visa.Interop.FormattedIO488

        ' Settings. Hardcoded for now, but should be settable.
        Dim ifAddress As String = devAddressTxt.Text
        Dim label As String = "tester"
        Dim Var1Start As Double = -60
        Dim Var1Stop As Double = 60
        Dim Var1Count As Integer = 241
        Dim Var2Start As Double = 20
        Dim Var2Stop As Double = 80
        Dim Var2Count As Integer = 2
        Dim Compliance As Double = 0.01
        Dim Delay As Double = 0.0005
        Dim MeasurementSetNum As Integer = 1        ' How many sets of measurements to take.
        Dim RepeatInterval As Integer = 0   'Interval between successive repeats, in seconds.
        Dim rootPath As String = My.Computer.FileSystem.CurrentDirectory

        Try
            rm = New Ivi.Visa.Interop.ResourceManager
            ioObj = New Ivi.Visa.Interop.FormattedIO488
            Try
                ioObj.IO = rm.Open(ifAddress)
                ioObj.IO.Timeout = 60000
                ioObj.IO.TerminationCharacter = 10
                ioObj.IO.TerminationCharacterEnabled = True
            Catch ex As Exception
                Console.WriteLine("An error occurred: " + ex.Message)
            End Try

            For i As Integer = 0 To MeasurementSetNum
                Dim path As String = rootPath
                If MeasurementSetNum > 1 Then
                    ' Create new folder for these measurements.
                    path = rootPath & "\\Set " & (i + 1) & "\\"
                    System.IO.Directory.CreateDirectory(path)
                End If
                Dim transfer As String = ""
                Dim output As String = ""
                Console.Write("Starting measurement set " & (i + 1))
                Console.Write("Performing transfer measurement...")
                B2900control(ioObj, transfer, Var1Start, Var1Stop, Var1Count, Var2Start, Var2Stop, Var2Count, Compliance, Delay, 0, i) 'Transfer
                Console.Write("Performing output measurement...")
                B2900control(ioObj, output, Var1Start, Var1Stop, Var1Count, Var2Start, Var2Stop, Var2Count, Compliance, Delay, 1, i) 'Output

                ' Write data out.
                FileOpen(1, path & "transfer-" + label + ".csv", OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
                Print(1, transfer)
                FileClose(1)
                FileOpen(1, path & "output-" + label + ".csv", OpenMode.Output, OpenAccess.Write, OpenShare.LockReadWrite)
                Print(1, output)
                FileClose(1)
            Next


            MsgBox("Click OK to close the console window.", vbOKOnly, "")

            ioObj.IO.Close()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ioObj)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rm)
        Catch ex As Exception
            Console.WriteLine("An error occurred: " + ex.Message)
        End Try
    End Sub

    Sub B2900control(ByVal ioObj As Ivi.Visa.Interop.FormattedIO488, ByRef s As String, ByVal Var1Start As Double, ByVal Var1Stop As Double, ByVal Var1Count As Integer, ByVal Var2Start As Double, ByVal Var2Stop As Double, ByVal Var2Count As Integer, ByVal Compliance As Double, ByVal Delay As Double, ByVal TestType As Integer, ByVal Repeat As Integer)

        ' Set the source and sensor strings.
        Dim PrimarySource As String = "sour1"
        Dim SecondarySource As String = "sour2"
        Dim PrimarySens As String = "sens1"
        Dim SecondarySens As String = "sens2"
        Dim PrimaryChannel As String = "@1"
        Dim SecondaryChannel As String = "@2"
        If TestType = 1 Then
            PrimarySource = "sour2"
            SecondarySource = "sour1"
            PrimarySens = "sens2"
            SecondarySens = "sens1"
            PrimaryChannel = "@2"
            SecondaryChannel = "@1"
        End If

        ' Set the total number of counts to take place.
        Dim FullCount As Integer = Var2Count * Var1Count

        ' Set direction of primary sweep.
        Dim Direction As String
        If Var1Start < Var1Stop Then
            Direction = "UP"
        Else
            Direction = "DOWN"
        End If

        ' Need to create a list for the secondary sweep.
        Dim List As String = ""
        Dim Var2Step As Double = (Var2Stop - Var2Start) / (Var2Count - 1)
        For i As Integer = 0 To Var2Count
            For j As Integer = 0 To Var1Count
                If Var2Start < Var2Stop Then
                    List = List & (Var2Start + Var2Step * i) & ","
                Else
                    List = List & (Var2Start - Var2Step * i) & ","
                End If
            Next
        Next
        ' Get rid of trailing comma.
        List = List.Remove(List.Length - 1)

        ioObj.WriteString("*RST") ' Reset

        Try 'Set primary sweep to a linear double voltage sweep.
            ioObj.WriteString(":" + PrimarySource + ":func:mode volt")
            ioObj.WriteString(":" + PrimarySource + ":volt:mode swe")
            ioObj.WriteString(":" + PrimarySource + ":swe:dir " + Direction)
            ioObj.WriteString(":" + PrimarySource + ":swe:sta doub")
            ioObj.WriteString(":" + PrimarySource + ":swe:spac lin")
            ioObj.WriteString(":" + PrimarySource + ":volt:star " & Var1Start)
            ioObj.WriteString(":" + PrimarySource + ":volt:stop " & Var1Stop)
            ioObj.WriteString(":" + PrimarySource + ":volt:poin " & Var1Count)

            ' Set secondary sweep to a linear single voltage sweep, implemented 
            ' as a list so the primary sweep occurs at every step.
            ioObj.WriteString(":" + SecondarySource + ":func:mode volt")
            ioObj.WriteString(":" + SecondarySource + ":volt:mode list")
            ioObj.WriteString(":" + SecondarySource + ":list:volt " + List)

            ' Set auto-range current measurement
            ioObj.WriteString(":" + PrimarySens + ":func ""curr"", ""volt""")
            ioObj.WriteString(":" + PrimarySens + ":curr:nplc 0.1")
            ioObj.WriteString(":" + PrimarySens + ":curr:prot " & Compliance)
            ioObj.WriteString(":" + SecondarySens + ":func ""curr"", ""volt""")
            ioObj.WriteString(":" + SecondarySens + ":curr:nplc 0.1")
            ioObj.WriteString(":" + SecondarySens + ":curr:prot " & Compliance)

            ' Generate triggers by automatic internal algorithm
            ioObj.WriteString(":trig1:sour aint")
            ioObj.WriteString(":trig1:coun " & FullCount)
            ioObj.WriteString(":trig2:sour aint")
            ioObj.WriteString(":trig2:coun " & FullCount)

            ' Set up measurement delay.
            ioObj.WriteString(":" + PrimarySens + ":wait on")
            ioObj.WriteString(":" + PrimarySens + ":wait:auto off")
            ioObj.WriteString(":" + PrimarySens + ":wait offs " & Delay)
            ioObj.WriteString(":" + SecondarySens + ":wait on")
            ioObj.WriteString(":" + SecondarySens + ":wait:auto off")
            ioObj.WriteString(":" + SecondarySens + ":wait offs " & Delay)

            ' Set array contents
            ioObj.WriteString(":form:elem:sens volt,curr,time")

        Catch ex As Exception
            Console.WriteLine("An error occurred: " + ex.Message)
        End Try

        ' Turn on output switch
        ioObj.WriteString(":outp1 on")
        ioObj.WriteString(":outp2 on")

        ' Initiate transition and acquire?
        ioObj.WriteString(":init (@1,2)")

        Try ' Retrieve measurement result.
            ioObj.WriteString(":fetc:arr? (@1,2)")
            s = ioObj.ReadString()

            ' Now need to break up long CSV string. Each resulting line should contain 8 values.
            Dim count As Integer = 0
            Dim line As Integer = 1
            Dim pos As Integer = s.IndexOf(",")
            Dim absGateC As Double
            Dim absDrainC As Double
            While pos > -1
                If count = 5 Then
                    ' Set count back to zero and replace this comma with a newline.
                    count = 0
                    line += 1
                    s = s.Remove(pos, 1)
                    s = s.Insert(pos, "," & absGateC & "," & absDrainC & vbCrLf & Repeat & "," & line & ",")
                    pos = s.IndexOf(",", pos + (vbCrLf & "1," & line & ",").Length)
                Else
                    If count = 0 Then
                        ' Need to record the value between the next comma and this one, it is the gate current.
                        Dim pos2 As Integer = s.IndexOf(",", pos + 1)
                        absGateC = Math.Abs(CDbl(s.Substring(pos, pos2 - pos)))
                    ElseIf count = 3 Then
                        ' Need to record the value between the next comma and this one, it is the drain current.
                        Dim pos2 As Integer = s.IndexOf(",", pos + 1)
                        absDrainC = Math.Abs(CDbl(s.Substring(pos, pos2 - pos)))
                    End If
                    count += 1
                    pos = s.IndexOf(",", pos + 1)
                End If
            End While

            s = "Repeat,Point,Gate Voltage,Gate Current,Gate Time,Drain Voltage,Drain Current,Drain Time,Abs Gate Current,Abs Drain Current" & vbCrLf & Repeat & ",1," & s

        Catch ex As Exception
            Console.WriteLine("An error occurred: " + ex.Message)
        End Try
    End Sub

    Sub Delay(ByVal Seconds As Double)
        '     Const OneSecond As Double = 1.0# / (1440.0# * 60.0#)
        '    Dim WaitUntil As Date = Now.AddSeconds(OneSecond * Seconds)

        '    Do Until Now > WaitUntil

        '   Loop

    End Sub

    Sub DrawGraph(ByVal filename As String)

    End Sub

    Sub PlotValue(ByVal current As Double, ByVal voltage As Double)
        Dim width As Integer
        Dim height As Integer
        Dim bmap As New System.Drawing.Bitmap(width, height)
        Dim gr As System.Drawing.Graphics.
    End Sub
End Module
