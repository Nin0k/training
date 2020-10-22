function Request(url, data) {
    fetch(url,
        {
            method: "POST",
            body: data
        })
        .then(function () { location.reload() })
}

function GetPage(url, data) {
    var xhr = new XMLHttpRequest()
    xhr.open('POST', url);
    xhr.send(data);
    xhr.onload = (function () {
        document.getElementById("forMessage").innerHTML = xhr.response;
        document.getElementById("forSections").style.display = "none";
      
    });
}

function openMessages(e) {
    let url = "/Pages/messages.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;

    let data = new FormData();
    data.append("idTopic", id);
   
    GetPage(url, data);
}
function logIn() {
    let url = "/login.cshtml";
    location.href = url;
}

function logonUser(url, data) {
    var xhr = new XMLHttpRequest()
    xhr.open('POST', url);
    xhr.send(data);
    xhr.onload = (function () {
        if (xhr.response.length < 30) {
            document.getElementById('labelError').innerHTML = xhr.response;
        }
        else {
            location.href = "/";
        }
    });
}

function registration() {
    let url = "/Pages/registration.cshtml";
    let login = document.getElementById('login').value;
    let password = document.getElementById('password').value;
    let admin = document.getElementById('admin').checked;

    if (login.length > 1 && password.length > 3) {
        let data = new FormData();
        data.append("login", login);
        data.append("password", password);
        data.append("admin", admin);
        logonUser(url, data);
    }
    else if (login.length < 2) {
        document.getElementById('labelError').innerText = "Имя должно состоять хотя бы из двух букв.";
    }
    else if (password.length < 3) {
        document.getElementById('labelError').innerText = "Пароль должн состоять хотя бы из четырех символов.";
    }
}

function logon() {
    let url = "/Pages/logOn.cshtml";
    let login = document.getElementById('login').value;
    let password = document.getElementById('password').value;

    if (login.length > 1 && password.length > 3) {
        let data = new FormData();
        data.append("login", login);
        data.append("password", password);
        data.append("admin", admin);
        logonUser(url, data);
    }
    else if (login.length < 2) {
        document.getElementById('labelError').innerText = "Неверное имя пользователя.";
    }
    else if (password.length < 3) {
        document.getElementById('labelError').innerText = "Неверный пароль.";
    }
}
function exit() {
    location.href = "/logout.cshtml";
}

let buttonTopics = document.querySelectorAll('.nameTopic');
for (let i = 0; i < buttonTopics.length; i++) {
    buttonTopics[i].addEventListener("click", openMessages);
}
//document.getElementById('button_exit').addEventListener("click", exit);

//document.getElementById('button_login').addEventListener("click", logIn);

document.getElementById('logon').addEventListener("click", logon);

document.getElementById('registration').addEventListener("click", registration);

