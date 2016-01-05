<Serializable()> Public Class Info_Time_Node
    Dim morning As Boolean
    Dim afternoon As Boolean
    Dim night As Boolean

    Sub New(ByVal morning As Boolean, ByVal afternoon As Boolean, ByVal night As Boolean)
        Me.morning = False
        Me.afternoon = False
        Me.night = False
    End Sub

    Public Function setMorning(ByVal bool As Boolean) As Boolean
        morning = bool
        Return True
    End Function
    Public Function setAfternoon(ByVal bool As Boolean) As Boolean
        afternoon = bool
        Return True
    End Function
    Public Function setNight(ByVal bool As Boolean) As Boolean
        night = bool
        Return True
    End Function

    Public Function getMorning()
        Return morning
    End Function
    Public Function getAfternoon()
        Return afternoon
    End Function
    Public Function getNight()
        Return night
    End Function
End Class
