Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim teachersData As New List(Of Users)()
            Dim queryTeachers As String = "SELECT * FROM Users WHERE PersonType = @PersonType"
            Using commandTeachers As New SqlCommand(queryTeachers, connection)
                commandTeachers.Parameters.AddWithValue("@PersonType", "Teacher")

                Using readerTeachers As SqlDataReader = commandTeachers.ExecuteReader()
                    While readerTeachers.Read()
                        Dim teacher As New Users()
                        teacher.FirstName = readerTeachers.GetString(readerTeachers.GetOrdinal("FirstName"))
                        teacher.LastName = readerTeachers.GetString(readerTeachers.GetOrdinal("LastName"))
                        teacher.Email = readerTeachers.GetString(readerTeachers.GetOrdinal("Email"))
                        teacher.Gender = readerTeachers.GetString(readerTeachers.GetOrdinal("Gender"))
                        teacher.Hobbies = readerTeachers.GetString(readerTeachers.GetOrdinal("Hobbies"))

                        teachersData.Add(teacher)
                    End While
                End Using
            End Using

            Dim studentsData As New List(Of Users)()
            Dim queryStudents As String = "SELECT * FROM Users WHERE PersonType = @PersonType"
            Using commandStudents As New SqlCommand(queryStudents, connection)
                commandStudents.Parameters.AddWithValue("@PersonType", "Student")

                Using readerStudents As SqlDataReader = commandStudents.ExecuteReader()
                    While readerStudents.Read()
                        Dim student As New Users()
                        student.FirstName = readerStudents.GetString(readerStudents.GetOrdinal("FirstName"))
                        student.LastName = readerStudents.GetString(readerStudents.GetOrdinal("LastName"))
                        student.Email = readerStudents.GetString(readerStudents.GetOrdinal("Email"))
                        student.Gender = readerStudents.GetString(readerStudents.GetOrdinal("Gender"))
                        student.Hobbies = readerStudents.GetString(readerStudents.GetOrdinal("Hobbies"))

                        studentsData.Add(student)
                    End While
                End Using
            End Using

            ViewData("Teachers") = teachersData
            ViewData("Students") = studentsData
        End Using

        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    <HttpPost>
    Function Login(model As Login) As ActionResult
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim isValidUser As Boolean = AuthenticateUser(model.UserName, model.Password, connection)

            If isValidUser Then
                Return RedirectToAction("Index")
            Else
                ViewBag.InvalidCredentials = True
                Return View("Index", model)
            End If
        End Using
    End Function

    Private Function AuthenticateUser(username As String, password As String, connection As SqlConnection) As Boolean

        Dim query As String = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Password = @Password"
        Using command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@UserName", username)
            command.Parameters.AddWithValue("@Password", password)

            Dim count As Integer = CInt(command.ExecuteScalar())
            Return count > 0
        End Using
    End Function


End Class
