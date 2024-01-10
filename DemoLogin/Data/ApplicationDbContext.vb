Imports System.Data.Entity

Public Class ApplicationDbContext
    Inherits DbContext

    'Public Sub New(ByVal options As DbContextOptions(Of ApplicationDbContext))
    '    MyBase.New(options)
    'End Sub

    Public Property Logins As DbSet(Of Login)
End Class
