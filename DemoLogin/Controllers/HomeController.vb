Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    'Function Index() As ActionResult
    '    Return View()
    'End Function

    Function Index() As ActionResult
        ' Retrieve the connection string from Web.config
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        ' Create a SqlConnection using the connection string
        Using connection As New SqlConnection(connectionString)
            ' Your code to interact with the database goes here
            connection.Open()

            ' Fetch data for teachers
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

            ' Fetch data for students
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

            ' Pass the lists of teachers and students to the view
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
End Class
