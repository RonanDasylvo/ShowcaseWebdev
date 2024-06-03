const nav = document.querySelector("nav");

function toggleNav() {
    nav.classList.toggle("open");
}

function getFormData(event) {
    event.preventDefault();

    // const form = document.getElementById("form");

    const formData = {
        "mailAdress": document.getElementById("email").value,
        "mailsubject": document.getElementById("subject").value,
        "mailBody": document.getElementById("content").value
    };

    postData(formData).then();
}

document.getElementById('form').addEventListener('submit', getFormData);

async function postData(formData) {
    const response = await fetch("http://localhost:5146/Mail/SendMail", {
        method: "POST",
        body: JSON.stringify(formData)
    });
    
    const mailData = await response.json();
    console.log(mailData);
}