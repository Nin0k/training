﻿function Request(url, data) {
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
        if (xhr.response.length < 60) {
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
    else if (password.length < 4) {
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

function saveTopic(el) {
    let url = "/Pages/addTopic.cshtml";
    let headerTopic = document.getElementById('headerTopic').value;
    let textTopic = document.getElementById('textTopic').value;
    let nameUser = document.getElementById('nameUserForTopic').value;
    let idForm = findAncestorId(el.target, "form_addTopic");
    let removeSpacesHeader = headerTopic.trim();
    let removeSpacesText = textTopic.trim();

    let nameForum;
    if (idForm == "info") {
        nameForum = "Информация";
    }
    else if (idForm == "assasin") {
        nameForum = "Assasin's Creed";
    }
    else if (idForm == "redemption") {
        nameForum = "Red Dead Redemption";
    }
    else if (idForm == "witcher") {
        nameForum = "Witcher";
    }

    if (removeSpacesHeader.length > 0 && removeSpacesText.length > 0 && nameUser && nameForum) {
        let data = new FormData();
        data.append("headerTopic", headerTopic);
        data.append("textTopic", textTopic);
        data.append("nameUser", nameUser);
        data.append("nameForum", nameForum); 
        document.getElementById("exit").click();
        Request(url, data);
    }
    else {
        alert("Введите текст и название темы!");
    }
}


function сhangeRole(e) {
    let url = "/Pages/editUser.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let idSelect = el.id;
    let role = document.getElementById(idSelect).value;
    let nameUser = idSelect.substr(6);

    let roleInversion;
    let nameRole;

    if (role=="true") {
        nameRole = "администратор";
        roleInversion = "false";
    }
    else if(role=="false"){
        nameRole = "пользователь";
        roleInversion = "true";
    }

    if (confirm(`Изменить роль пользователя ${nameUser} на ${nameRole}?`)) {
        let data = new FormData();
        data.append("nameUser", nameUser);
        data.append("newRole", role);
       
        Request(url, data);
    }
    else {
        
        document.getElementById(idSelect).value = roleInversion;
    }
}
function deletUser(e) {
    let url = "/Pages/delUser.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let idButton = el.id;
    let nameUser = idButton.substr(5);
    if (confirm(`Удалить пользователя ${nameUser}?`)) {
        let data = new FormData();
        data.append("nameUser", nameUser);
       
        Request(url, data);
    }
    
}


let buttonTopics = document.querySelectorAll('.nameTopic');
for (let i = 0; i < buttonTopics.length; i++) {
    buttonTopics[i].addEventListener("click", openMessages);
}


let userSelect = document.getElementsByName('userSelect');
for (let i = 0; i < userSelect.length; i++) {
    userSelect[i].addEventListener("change", сhangeRole);
}

let buttonDeletUser = document.querySelectorAll('.deletUser');
for (let i = 0; i < buttonDeletUser.length; i++) {
    buttonDeletUser[i].addEventListener("click", deletUser);
}

//document.getElementById('button_exit').addEventListener("click", exit);

//document.getElementById('button_login').addEventListener("click", logIn);
//document.getElementById('saveTopic').addEventListener("click", saveTopic);

document.getElementById('logon').addEventListener("click", logon);

document.getElementById('registration').addEventListener("click", registration);




