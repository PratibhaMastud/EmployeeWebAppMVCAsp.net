var firstName = document.getElementById('firstname')
var lastName = document.getElementById('lastname')
/*var mobileNum = document.getElementById('mobileNo')
var emailId = document.getElementById('email')
var address = document.getElementById('address')
var pin = document.getElementById('pin')
var compName = document.getElementById('compname')
var jobPro = document.getElementById("job")
var pass = document.getElementById("pass")
var comnpass = document.getElementById('comnpass')
var form = document.getElementById('formRegist')
var errorElement = document.getElementById('error')*/

form.addEventListener('submit', (e) => {
    let messages = []
    if (firstName.value === '' || firstName.value == null) {
        messages.push('Name is required')
    }
    if (messages.length > 0) {
        e.preventDefault()
        errorElement.innerText = messages.join(', ')
    }
})


