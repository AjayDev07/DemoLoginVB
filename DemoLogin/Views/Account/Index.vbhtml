@ModelType Login

<h2>Login</h2>

@Using Html.BeginForm("Login", "Account", FormMethod.Post)
    @<div>
        <label for="Username">Username :</label>
        @Html.TextBoxFor(Function(m) m.Username, New With {.class = "form-control", .placeholder = "Enter your username"})
    </div>

          @<div>
                <label for = "Password" > Password :    </label>
    @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Enter your password"})
            </div>
           @<br>
    @<button type = "submit" > Login</button>
End Using
