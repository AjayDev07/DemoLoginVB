Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports WebGrease.Css.ImageAssemblyAnalysis

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        ' GET: Account
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: /Account/Login
        Function Login() As ActionResult
            Dim model As New Login()
            Return View(model)
        End Function

        ' POST: /Account/Login
        <HttpPost>
        Function Login(model As Login) As ActionResult
            If AuthenticateUser(model.UserName, model.Password) Then
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "Invalid username or password")
                Return View(model)
            End If
        End Function

        <HttpPost>
        Function Logout() As ActionResult
            FormsAuthentication.SignOut()

            Return RedirectToAction("Index", "Account")
        End Function

        Private Function AuthenticateUser(username As String, password As String) As Boolean
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT COUNT(*) FROM Login WHERE Username = @Username AND Password = @Password"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", username)
                    command.Parameters.AddWithValue("@Password", password)

                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        End Function


        <HttpPost>
        Function AddPerson(model As Users) As ActionResult
            If ModelState.IsValid Then

                SavePersonToDatabase(model)

                Return Json(New With {.success = True})
            End If

            Return Json(New With {.success = False, .errors = ModelState.Values.SelectMany(Function(v) v.Errors.Select(Function(e) e.ErrorMessage))})
        End Function


        Private Sub SavePersonToDatabase(model As Users)
            Try
                Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "INSERT INTO Users (FirstName, LastName, Email, Gender, Hobbies, PersonType) VALUES (@FirstName, @LastName, @Email, @Gender, @Hobbies, @PersonType)"

                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@FirstName", model.FirstName)
                        command.Parameters.AddWithValue("@LastName", model.LastName)
                        command.Parameters.AddWithValue("@Email", model.Email)
                        command.Parameters.AddWithValue("@Gender", model.Gender)
                        command.Parameters.AddWithValue("@Hobbies", String.Join(",", model.Hobbies))
                        command.Parameters.AddWithValue("@PersonType", model.PersonType)

                        command.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex As Exception

                ModelState.AddModelError("", "Error saving data to the database.")
            End Try
        End Sub

        <HttpPost>
        Function DeletePerson(personId As String) As ActionResult
            Try
                Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    Dim query As String = "DELETE FROM Users WHERE Email = @Email"

                    Using command As New SqlCommand(query, connection)

                        command.Parameters.AddWithValue("@Email", personId)


                        command.ExecuteNonQuery()
                    End Using
                End Using

                Return Json(New With {.success = True})

            Catch ex As Exception
                Return Json(New With {.success = False, .error = "Error deleting data from the database."})
            End Try
        End Function


    End Class
End Namespace
