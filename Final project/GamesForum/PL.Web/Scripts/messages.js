function ChangeContents(data) {
    if (data[0] == "reputation") {
        let beginId = "reputation";
        let users = document.querySelectorAll("."+beginId+data[1]);

        for (let i = 0; i < users.length; i++) {
            console.log(users[i]);
            users[i].innerHTML = "Репутация: "+data[2];
        }
        document.getElementById(beginId+data[3]).innerHTML = data[4];
    }
    
}
function Request(url, data) {
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

function findAncestor(el, cls) {
    while ((el = el.parentElement) && !el.classList.contains(cls));
    return el.id;
}

function editReputation(e) {
    let url = "/Pages/editMessage.cshtml";
    e = e || window.event;
    let el = e.target || e.srcElement;
    let allClass = el.classList;

    let data = new FormData();
    
    for (var i = 0; i < allClass.length; i++) {
        if (allClass[i] == "reputation_plus") {
            let id_message = findAncestor(e.target, "text_message")
            data.append("id_message", id_message);
            data.append("action", "+");
        }
        else if (allClass[i] == "reputation_minus") {
            let id_message = findAncestor(e.target, "text_message")
            data.append("id_message", id_message);
            data.append("action", "-");
        }
      
    } 
    Request(url, data);
} 

document.getElementById('forMessage').addEventListener("click", editReputation);