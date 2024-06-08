const contactForm = document.getElementById('contact-form');
const valMsg = document.getElementById("val-msg");

contactForm.addEventListener("submit", getFormData);


async function getFormData(event) {
    event.preventDefault();

    valMsg.className = "";
    valMsg.innerHTML = "Verzoek aan het verwerken...";

    const captcha = document.getElementById("captcha").value

    const formData = {
        MailSender: document.getElementById("email").value,
        MailSubject: document.getElementById("subject").value,
        MailBody: document.getElementById("content").value,
        CaptchaValue: captcha,
    };

    await PostFormData(formData).then();

    contactForm.reset();
}

async function PostFormData(formData) {
    await fetch('/SendMail', {
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
            valMsg.innerHTML = "Er is iets fout gegaan tijdens het versturen.";
            console.log(error);
        });
}

