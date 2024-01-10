@Code
    ViewData("Title") = "Home Page"
End Code

<!-- Bootstrap CSS -->
<link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">

<!-- jQuery and Bootstrap JS -->
<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>


<main>
    <section class="row align-items-center" aria-labelledby="aspnetTitle">
        <style>
            .column {
                margin-bottom: 30px; /* Adjust the margin as needed */
            }
        </style>

        <div class="container">
            <div class="row">
                <div class="col-md-6 column">
                    <h1 id="title">Dashboard</h1>
                </div>
                <div class="col-md-6 text-right column">
                    @Using Html.BeginForm("Logout", "Account", FormMethod.Post)
                        @Html.AntiForgeryToken()
                        @<button type="submit" class="btn btn-danger">Logout</button>
                    End Using
                </div>
            </div>
        </div>

        <button type="button" class="btn btn-primary" data-toggle="modal" style="width: 120px !important; max-width: 120px !important;" data-target="#addPersonModal">Add Person</button>



        <br />

        <h2>Teachers</h2>
        <table class="table">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Gender</th>
                    <th>Hobbies</th>
                </tr>
            </thead>
            <tbody>
                @If ViewData("Teachers") IsNot Nothing Then
                    @For Each teacher In CType(ViewData("Teachers"), List(Of Users))
                        @<tr>
                            <td>@teacher.FirstName</td>
                            <td>@teacher.LastName</td>
                            <td>@teacher.Email</td>
                            <td>@teacher.Gender</td>
                            <td>@teacher.Hobbies</td>
                        </tr>
                    Next
                End If
            </tbody>
        </table>

        <h2>Students</h2>
        <table class="table">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Gender</th>
                    <th>Hobbies</th>
                </tr>
            </thead>
            <tbody>
                @If ViewData("Students") IsNot Nothing Then
                    @For Each student In CType(ViewData("Students"), List(Of Users))
                        @<tr>
                            <td>@student.FirstName</td>
                            <td>@student.LastName</td>
                            <td>@student.Email</td>
                            <td>@student.Gender</td>
                            <td>@student.Hobbies</td>
                        </tr>
                    Next
                End If
            </tbody>
        </table>

    </section>
</main>

<!-- Add Person Modal -->
<div class="modal fade" id="addPersonModal" tabindex="-1" role="dialog" aria-labelledby="addPersonModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="addPersonModalLabel">Add Person</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <!-- Form fields for the person -->
                <form id="addPersonForm">
                    <div class="form-group">
                        <label for="firstName">First Name:</label>
                        <input type="text" class="form-control" id="firstName" name="firstName" required>
                    </div>
                    <div class="form-group">
                        <label for="lastName">Last Name:</label>
                        <input type="text" class="form-control" id="lastName" name="lastName" required>
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" class="form-control" id="email" name="email" required>
                    </div>
                    <div class="form-group">
                        <label>Gender:</label>
                        <div class="form-check">
                            <input type="radio" class="form-check-input" id="male" name="gender" value="Male" required>
                            <label class="form-check-label" for="male">Male</label>
                        </div>
                        <div class="form-check">
                            <input type="radio" class="form-check-input" id="female" name="gender" value="Female" required>
                            <label class="form-check-label" for="female">Female</label>
                        </div>
                        <div class="form-check">
                            <input type="radio" class="form-check-input" id="others" name="gender" value="Others" required>
                            <label class="form-check-label" for="others">Others</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label>Hobbies:</label>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="playingGames" name="hobbies" value="Playing Games" required>
                            <label class="form-check-label" for="playingGames">Playing Games</label>
                        </div>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="dancing" name="hobbies" value="Dancing" required>
                            <label class="form-check-label" for="dancing">Dancing</label>
                        </div>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="singing" name="hobbies" value="Singing" required>
                            <label class="form-check-label" for="singing">Singing</label>
                        </div>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="reading" name="hobbies" value="Reading" required>
                            <label class="form-check-label" for="reading">Reading</label>
                        </div>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="writing" name="hobbies" value="Writing" required>
                            <label class="form-check-label" for="writing">Writing</label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="personType">Person Type:</label>
                        <select class="form-control" id="personType" name="personType" required>
                            <option value="Teacher">Teacher</option>
                            <option value="Student">Student</option>
                        </select>
                    </div>
                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-warning" onclick="resetForm()">Reset</button>
                <button type="button" class="btn btn-primary" onclick="submitFormToServer()">Submit</button>
            </div>
        </div>
    </div>
</div>



<script>
    function resetForm() {
        document.getElementById("addPersonForm").reset();
    }

    function submitFormToServer() {
        var formData = {
            firstName: $('#firstName').val(),
            lastName: $('#lastName').val(),
            email: $('#email').val(),
            gender: $('input[name="gender"]:checked').val(),
            hobbies: $('input[name="hobbies"]:checked').map(function () {
                return this.value;
            }).get().join(','),
            personType: $('#personType').val()
        };

        $.ajax({
            type: 'POST',
            url: '/Account/AddPerson',
            data: formData,
            success: function (response) {

                if (response.success) {
                    resetForm();

                    $('#addPersonModal').modal('hide');

                    console.log("Success! Hiding modal.");

                } else {

                    console.log(response.errors);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
</script>

