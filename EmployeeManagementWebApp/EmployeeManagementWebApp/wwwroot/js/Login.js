function validation() {
    var emailExp = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;
    var passwordExp = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;
    if (!emailExp.test(document.form1.username.value)) {
        alert("Invalid email-Id ");
        document.form1.username.focus();
        return false;
    } else if (!passwordExp.test(document.form1.password.value)) {
        alert("Invalid password ");
        document.form1.password.focus();

        return false;
    } else {
        alert("Login is successfull");
    }
}