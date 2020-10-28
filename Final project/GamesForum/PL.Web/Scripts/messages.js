function ChangeContents(data) {
    if (data[0] == "reputation") {
        let beginId = "reputation";
        let idUser = data[1];
        let reputationUser = data[2];
        let idMessage = data[3];
        let reputationMessange = data[4];

        let users = document.querySelectorAll("." + beginId + idUser);

        for (let i = 0; i < users.length; i++) {
           users[i].innerHTML = "Репутация: " + reputationUser;
        }
        document.getElementById(beginId + idMessage).innerHTML = reputationMessange;
    }
    else if (data[0] == "newMessange") {
        let iDUser = data[1];
        let nickname = data[2];
        let userReputation = data[3];
        let idMessage = data[4];
        let text = data[5];
        let date = data[6];
        let messageReputation = data[7];

        let parentElement = document.getElementById('categoryForMessages');

        let elementMessage = document.createElement("div");
        elementMessage.classList.add("message");

        let userBlock = document.createElement("div");
        userBlock.id = iDUser + idMessage;
        userBlock.classList.add("userBlock");
        userBlock.innerHTML = `<img src="Content/image/no_avatar.png" alt="avatar"/>
                            <h3>${nickname}</h3>
                            <span class="reputation${iDUser}"> Репутация: ${userReputation}</span>`;

        let textMessage = document.createElement("div");
        textMessage.classList.add("text_message");
        textMessage.id = idMessage;
        textMessage.innerHTML = `<p>${text}</p>`;

        let infoMessange = document.createElement("div");
        infoMessange.classList.add("info_messange");

        infoMessange.innerHTML = `<p>${date}</p>`;
        infoMessange.innerHTML += `<button class="reputation">
                                        <img class="reputation_messges reputation_plus" src="Content/image/plus.png" alt="plus" />
                                    </button>`;
        infoMessange.innerHTML += `<p id="reputation${idMessage}">${messageReputation}</p>`;
        infoMessange.innerHTML += `<button class="reputation">
                                        <img class="reputation_messges reputation_minus" src="Content/image/minus.png" alt="minus" />
                                    </button>`;
        textMessage.append(infoMessange);

        elementMessage.append(userBlock);
        elementMessage.append(textMessage); 

        parentElement.append(elementMessage); 
    }
    
}
function RequestNoUpdates (url, data) {
    fetch(url,
        {
            method: "POST",
            body: data
        })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ChangeContents(data);
        });
}

function findAncestorId(el, cls) {
    while ((el = el.parentElement) && !el.classList.contains(cls));
    return el.id;
}

function editMessage(e) {
    let url = "/Pages/editMessage.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let allClass = el.classList;
    console.log(allClass);
    let data = new FormData();
    
    for (var i = 0; i < allClass.length; i++) {
        if (allClass[i] == "reputation_plus") {
            let idMessage = findAncestorId(el, "text_message")
            data.append("id_message", idMessage);
            data.append("action", "+");
            RequestNoUpdates(url, data);
        }
        else if (allClass[i] == "reputation_minus") {
            let idMessage = findAncestorId(el, "text_message")
            data.append("id_message", idMessage);
            data.append("action", "-");
            RequestNoUpdates(url, data);
        }
        else if (allClass[i] == "buttonForSaveMessage") {
            saveMessage(el);
        }
        else if (allClass[i] == "img_deleteMessage") {
            deleteMessage(el);
        }
        else if (allClass[i] == "img_deleteTopic") {
            deleteTopic(el);
        }
      
    } 
    
} 
function saveMessage(el) {
    let url = "/Pages/addMessage.cshtml";
    let textMessage = document.getElementById('textMessage').value;
    let nameUser = document.getElementById('nameUser').value;
    let idTopic = findAncestorId(el, "forModalWindow");
    console.log("nameUser " + nameUser);
    console.log("idTopic " + idTopic);
    let removeSpaces = textMessage.trim();

    if (removeSpaces.length > 0 && nameUser && idTopic) {
        let data = new FormData();
        data.append("textMessage", textMessage);
        data.append("nameUser", nameUser);
        data.append("idTopic", idTopic);
        document.getElementById("exit").click();
        RequestNoUpdates(url, data);
    }
    else {
        document.getElementById('textMessage').value="Введите текст!";
    }
}
function deleteMessage(el) {
    let url = "/Pages/delMessage.cshtml";
    if (confirm("Удалить сообщение?")) {
        let id = findAncestorId(el, "deleteMessage");
        let idMessage = id.substr(6);
        let data = new FormData();
        data.append("idMessage", idMessage);
        Request(url, data);
    }
    
}
function deleteTopic(el) {
    let url = "/Pages/delTopic.cshtml";
    if (confirm("Удалить тему?")) {
        let id = findAncestorId(el, "deleteTopic");
        let idTopic = id.substr(6);
        let data = new FormData();
        data.append("idTopic", idTopic);
        Request(url, data);
    }

}

document.getElementById('forMessage').addEventListener("click", editMessage);

document.getElementById('saveTopic').addEventListener("click", saveTopic);

