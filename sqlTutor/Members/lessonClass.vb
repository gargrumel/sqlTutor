Public Class lessonClass
    Dim id As Integer
    Dim lessonStatus As Integer

    Public Sub New(id As Integer, lessonStatus As Integer)
        Me.id = id
        Me.lessonStatus = lessonStatus
    End Sub

    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property LessonStatus1 As Integer
        Get
            Return lessonStatus
        End Get
        Set(value As Integer)
            lessonStatus = value
        End Set
    End Property
End Class
