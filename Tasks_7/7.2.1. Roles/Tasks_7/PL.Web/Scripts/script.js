
function addUser() {
    let url = "/Pages/addNewEssence.cshtml";
    let nameUser = document.getElementById('nameUser').value;
    let birthday = document.getElementById('birthday').value;
 
    if (nameUser.length > 0 && birthday.length > 0) {
        let data = new FormData();
        data.append("type", "user");
        data.append("name", nameUser);
        data.append("birthday", birthday);
        Request(url, data);
    }
}

function addAward() {
    let url = "/Pages/addNewEssence.cshtml";
    let award = document.getElementById('titleAward').value;
   
    if (award.length > 0 ) {
        let data = new FormData();
        data.append("type", "award");
        data.append("title", award);
        Request(url, data);
    }
}

function addReward(type) {
    let url = "/Pages/addReward.cshtml";
    let idUser;
    let idAward;

    if (type == "user") {
        idUser = document.getElementById('current_id').value;
        idAward = document.getElementById('newRewardForUser').value;
    }
    else if (type == "award") {
        idAward = document.getElementById('current_idAward').value;
        idUser = document.getElementById('newUserForAward').value;
    }

    if (idAward != "reward0" && idUser != "reward0" && idAward.length > 1 && idUser.length > 1) {
        let data = new FormData();
        data.append("idUser", idUser);
        data.append("idAward", idAward);
        Request(url, data);
    }
}

function delUser(e) {
    let url = "/Pages/dellEssence.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    console.log(id);
    if (id.length > 0) {
        if (confirm("Удалить пользователя?")) {
       
            let data = new FormData();
            data.append("type", "user");
            data.append("id", id);
            Request(url, data);
        }
    }
} 

function delAward(e) {
    let url = "/Pages/dellEssence.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    if (id.length > 0) {
        if (confirm("Награда будет удалена у всех пользователей! Удалить? ")) {
           
            let data = new FormData();
            data.append("type", "award");
            data.append("id", id);
            Request(url, data);
        }
    }
}

function delReward() {
   let url = "/Pages/dellEssence.cshtml";
   let idUser = document.getElementById('current_id').value;
   let idAward = document.getElementById('current_' + idUser).value;
   if (idUser.length > 0 && idAward.length > 0) {
        if (confirm("Удалить награду у данного пользователя?")) {
            let data = new FormData();
            data.append("type", "reward");
            data.append("idUser", idUser);
            data.append("idAward", idAward);
            Request(url, data);
        }
   }
}

function saveEditUser() {
    let url = "/Pages/editEssence.cshtml";
    let idUser = document.getElementById('current_idUserEdit').value;
    let nameUser = document.getElementById('newNameUserEdit').value;
    let birthdayUser = document.getElementById('newBirthdayUserEdit').value;

    if (idUser.length > 1 && nameUser.length > 1 && birthdayUser.length > 1) {
        let data = new FormData();
        data.append("type", "user");
        data.append("idUser", idUser);
        data.append("nameUser", nameUser);
        data.append("birthdayUser", birthdayUser);
        Request(url, data);
    }
}
function saveEditAward() {
    let url = "/Pages/editEssence.cshtml";
    let idAward = document.getElementById('current_idAwardEdit').value;
    let title = document.getElementById('newTitleAwardEdit').value;
   
    if (idAward.length > 1 && title.length > 1) {
        let data = new FormData();
        data.append("type", "award");
        data.append("idAward", idAward);
        data.append("title", title);
        Request(url, data);
    }
} 
function Request(url, data) {
     fetch(url,
        {
            method: "POST",
            body: data
        })
         .then(function () {location.reload()})
}

function GetModal(url, idModal, data) {
    var xhr = new XMLHttpRequest()
    xhr.open('POST', url);
    xhr.send(data);
    xhr.onload = (function () {
        document.getElementById("forModal").innerHTML = xhr.response;
        location.href = idModal;
    });
}

function openUserAwards(e) {
    let url = "/Pages/userModal.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    let idGuid = id.slice(6);

    let data = new FormData();
    data.append("type", "user");
    data.append("ID", idGuid);
    let idModal = "#openModal";
    GetModal(url, idModal, data);
}

function openRewardUser(e) {
    let url = "/Pages/userModalAward.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    let idGuid = id.slice(5);

    let data = new FormData();
    data.append("type", "award");
    data.append("ID", idGuid);
    let idModal = "#openModalAward";
    GetModal(url, idModal, data);
}

function openEditUser(e) {
    let url = "/Pages/modalEditUser.cshtml";

    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    let idGuid = id.slice(5);

    let idModal = "#openModalEditUser";

    if (idGuid.length > 0) {
        let data = new FormData();
        data.append("idUser", idGuid);
        GetModal(url, idModal, data);
    }
}

function openEditAward(e) {
    let url = "/Pages/modalEditAward.cshtml";

    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    let idGuid = id.slice(5);

    let idModal = "#openModalEditAward";

    if (idGuid.length > 0) {
        let data = new FormData();
        data.append("idAward", idGuid);
        GetModal(url, idModal, data);
    }
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
        Request(url, data);
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


    let buttonDelUser = document.querySelectorAll('.user_del');
    for (let i = 0; i < buttonDelUser.length; i++) {
        buttonDelUser[i].addEventListener("click", delUser);
    }

    let buttonAward = document.querySelectorAll('.user_award');
    for (let i = 0; i < buttonAward.length; i++) {
        buttonAward[i].addEventListener("click", openUserAwards);
    }

    let buttonDelAward = document.querySelectorAll('.award_del');
    for (let i = 0; i < buttonDelAward.length; i++) {
        buttonDelAward[i].addEventListener("click", delAward);
}

let buttonUsers = document.querySelectorAll('.award_allUser');
for (let i = 0; i < buttonUsers.length; i++) {
    buttonUsers[i].addEventListener("click", openRewardUser);
}

let buttonUserEdit = document.querySelectorAll('.user_edit');
for (let i = 0; i < buttonUserEdit.length; i++) {
    buttonUserEdit[i].addEventListener("click", openEditUser);
} 

let buttonAwardEdit = document.querySelectorAll('.award_edit');
for (let i = 0; i < buttonAwardEdit.length; i++) {
    buttonAwardEdit[i].addEventListener("click", openEditAward);
}
document.getElementById('logon').addEventListener("click", logon);

document.getElementById('registration').addEventListener("click", registration);
//document.getElementById('addNewUser').addEventListener("click", addUser);

//document.getElementById('addNewAward').addEventListener("click", addAward);

