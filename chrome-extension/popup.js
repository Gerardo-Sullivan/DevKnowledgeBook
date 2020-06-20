const form = document.querySelector('form');
const url = document.getElementById("url");
let baseUrl = localStorage.getItem('baseUrl');
let apiKey = localStorage.getItem('apiKey');

form.addEventListener('submit', function (e) {
    e.preventDefault();
    url.value;
})

