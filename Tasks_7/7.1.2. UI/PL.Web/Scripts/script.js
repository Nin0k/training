

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
function delUser(e) {
    let url = "/Pages/dellEssence.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let id = el.id;
    
    if (id.length > 0) {
        if (confirm("Удалить пользователя?")) {
            console.log(id);
            let data = new FormData();
            data.append("type", "user");
            data.append("id", id);
            console.log(url);
            console.log(data);
            Request(url, data);
        }
    }
}
function Request(url, data) {
    fetch(url,
        {
            method: "POST",
            body: data
        })
       .then(function () { document.getElementById('text').innerHTML = "Ошибка!"; })//TODO
       .then(function () { document.getElementById('text').innerHTML = "Сохранено!"})//TODO*/

}

document.getElementById('addNewUser').addEventListener("click", addUser);

let buttonDel = document.querySelectorAll('.user_del');
for (let i = 0; i < buttonDel.length; i++) {
    buttonDel[i].addEventListener("click", delUser);
}
    