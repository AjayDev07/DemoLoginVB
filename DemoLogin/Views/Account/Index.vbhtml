@ModelType Login

<h2>Login</h2>

@*@if (ViewBag.InvalidCredentials IsNot Nothing AndAlso ViewBag.InvalidCredentials) {
    <div class="alert alert-danger">
    Invalid username or password. Please try again.
    </div>
    }*@

@Using Html.BeginForm("Login", "Account", FormMethod.Post, New With {.onsubmit = "return validateForm()"})
    @<div>
        <label for="Username">Username :</label>
        @Html.TextBoxFor(Function(m) m.UserName, New With {.class = "form-control", .placeholder = "Enter your username"})
    </div>

    @<div>
        <label for="Password">Password :</label>
        @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control", .placeholder = "Enter your password"})
    </div>

    @<br>
    @<button type="submit">Login</button>
End Using


<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

<script>
    function validateForm() {
        var username = document.getElementById("UserName").value;
        var password = document.getElementById("Password").value;

        if (username === "" || password === "") {
            alert("Please enter both username and password.");
            return false;
        }

        return true;
    }
</script>

