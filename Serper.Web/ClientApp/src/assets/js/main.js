function passwordToggle() {
    let form = document.getElementById("aunteficationForm");

    let password = form.elements.password;

    password.type == "password" ? password.type = "text" : password.type = "password";
}