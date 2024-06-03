const nav = document.querySelector("nav");

function toggleNav() {
    nav.classList.toggle("open");
}

function getData(form) {
    let formData = new FormData(form);

    for (let pair of formData.entries()) {
        console.log(pair[0] + ": " + pair[1]);
    }

    console.log(Object.fromEntries(formData));
}

document.querySelector("form").addEventListener("submit", function (e) {
    e.preventDefault();
    getData(e.target);
});