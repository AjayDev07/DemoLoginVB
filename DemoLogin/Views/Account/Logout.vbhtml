@Code
    ViewData("Title") = "Logout"
End Code




@Using Html.BeginForm("Logout", "Account", FormMethod.Post)

    @<button type="submit">Logout</button>
End Using


