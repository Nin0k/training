import {Service}  from './service.js';

let note1 = {
    header: "Стих",
    text: "Случайных встреч по жизни не бывает, Они быть может нам судьбою решены, Но часто эти встречи мы теряем Скрываясь в серости безмолвия души. Мы забываем тех, кого ценили Мы ждем того, кого не стоит ждать Мы верим тем, кого порой любили И лжем тому, кто должен правду знать"};

let note2 = {
    header: "Позвонить!",
    text: "Мария Иванова +79874562135",
};

let storage = new Service();

storage.add(note1);
storage.add(note2);

let sizeElements = storage.size();
let allElements = storage.getAll();
let maxId;

if(sizeElements>0){
    for (let entry of allElements) { 
        maxId = entry[0];
        createNote(entry[0]);
    }
}

document.getElementById('save').onclick = function create() {
    let header = document.getElementById('header0').value;
    let text = document.getElementById('text0').value;
    if(header.length > 0 || text.length > 0) {
        let note = makeNote(header, text);

        if(storage.add(note))
        {document.getElementById("exit").click();}

        createNote(++maxId);
        }
    else {
        location.href="#close";
    }
}

function openEditNote(id) {
    location.href="#openModalEdit";
    let oldDiv = document.getElementById(`note${id}`);
    let child = oldDiv.childNodes;
    let header = child[0].textContent;
    let txt = child[1].textContent;

    document.getElementById("headerEdit").value = header;
    document.getElementById("textEdit").value = txt;

    document.getElementById('saveEdit').onclick = function saveEdit() {

        oldDiv.remove();
        let headerEdit = document.getElementById('headerEdit').value;
        let txtEdit = document.getElementById('textEdit').value;
        
        let note = makeNote(headerEdit, txtEdit);
        storage.replaceById(id,note);

        createNote(id);
        location.href="#close";
    }
}


function deleteNote(id) {
    event.stopPropagation();
    if (confirm("Удалить заметку?")) {
        storage.deleteById(id);
        var removableNode = document.getElementById("note"+id);
        removableNode.remove();
    }
}

document.getElementById("startSearch").addEventListener("click", function() {
    let filter = document.getElementById("inputSearch").value;
    let elements = document.querySelectorAll('#content > div');
    let count = 0;

    for (let i = 0; i < elements.length; i++) {
        let str = elements[i].textContent;
        
        if(str.indexOf(filter) != -1) {
            ++count;
        }
        else {
            document.getElementById(elements[i].id).style.display='none';
        }
    }
    if(count==0){
        let newElement = document.createElement("div");
        newElement.classList.add("notFound");
        newElement.innerHTML = "Ничего не найдено.";
        document.getElementById('content').prepend(newElement);
    }
});

document.getElementById("endSearch").addEventListener("click", function() {
    let notFound = document.querySelector('.notFound');
    if(notFound) {
        notFound.remove();
    }
    document.querySelector('.box-search').value = "";
    
    let elements = document.querySelectorAll('#content > div');
    for (let i = 0; i < elements.length; i++) {
        document.getElementById(elements[i].id).style.display = 'block';
    }
});

function makeNote(header = "", text = "") {
    return {
        header: header,
        text: text
    };
  }

function createNote(id) {
    let parentElement = document.getElementById('content');
   
    let newElement = document.createElement("div");
    newElement.classList.add("note");
    newElement.id = `note${id}`;
    newElement.innerHTML = `<p>${storage.getById(id).header}</p><p>${storage.getById(id).text}</p>`;
    newElement.addEventListener("click", function(){ 
        openEditNote(id); 
            }, false);

    let deleteDiv = document.createElement('div');
    deleteDiv.classList.add("deleteNote");
    deleteDiv.innerHTML = `<img src="img/delete.png"/>`;
    deleteDiv.firstChild.addEventListener("click", function(){
            deleteNote(id);
            }, true);
            
    newElement.append(deleteDiv);
    parentElement.prepend(newElement);
    
}