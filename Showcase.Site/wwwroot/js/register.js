const registerForm = document.getElementById('register-form');

if (registerForm !== null) {
    registerForm.addEventListener("submit", getFormData);
}

async function getFormData(event) {
    event.preventDefault();

    valMsg.className = "";
    valMsg.innerHTML = "Verzoek aan het verwerken...";

    const formData = {
        Username: document.getElementById("name").value,
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value
    };

    await CreateAccount(formData).then();
    this.reset();
}

async function CreateAccount(formData) {
    await fetch('/ManageAccount/Register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData)
    })
        .then(response => response.json())
        .then(data => {
            valMsg.innerHTML = data.message;
            if (!data.success) {
                valMsg.classList.add("text-red-400");
                return;
            }
            valMsg.classList.add("text-green-400")
        })
        .catch(error => {
            valMsg.classList.add("text-red-400");
            valMsg.innerHTML = "Er is iets fout gegaan tijdens registreren van het account.";
            console.log(error);
        });
}