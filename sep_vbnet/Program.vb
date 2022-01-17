Public Class RadioClass
    Shared power As Boolean

    Public Sub Main(ByVal args() As String)
        Dim tc = New RadioClass(True)
        power = tc.Test(3)
        Dim a() As String = {"R24", "DRS1", "DRS2", "SWF3", "B3", "Wannsee"}
        For i As Integer = LBound(a) To UBound(a)
            For k As Integer = 0 To a.GetLength(0)
                Console.WriteLine("Hello " + a(i, k))
            Next
        Next
        Dim j As Integer
        Dim d As Double
        Console.WriteLine("Hello World!" & a[0, 0])
    End Sub
    Shared Function Test(x As Integer) As Double
        x += 1
        Test = x
    End Function
    Public Sub New()
        power = 0
    End Sub
    Enum Radio : Start : Tune : End Enum
    Public Sub New(ByRef powerLevel As Boolean)
        MyBase.New()
        Me.power = powerLevel
    End Sub
End Class