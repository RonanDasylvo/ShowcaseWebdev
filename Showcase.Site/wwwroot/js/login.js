const loginForm = document.getElementById('login-form');

if (loginForm !== null) {
    loginForm.addEventListener("submit", getFormData);
}

async function getFormData(event) {
    event.preventDefault();

    const formData = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
    };

    await LoginAccount(formData).then();
    this.reset();
}

async function LoginAccount(formData) {
    await fetch('/ManageAccount/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData)
    })
        .then()
        .catch(error => {
            valMsg.classList.add("text-red-400");
            valMsg.innerHTML = "Er is iets fout gegaan tijdens inloggen.";
            console.log(error);
        });
}