
import {Service}  from './task3.js';

let user1 = {
    name: "Мария",
    surname: "Иванова",
};
let user2 = {
    name: "Анна",
    surname: "Каренина",
};
let user3 = {
    name: "Маргарита",
    surname: "Николаевна",
};

let storage = new Service();

storage.add(user1);
storage.add(user2);
storage.add(user3);
storage.add();

console.log(storage.getById(2));
console.log(storage.getById(5));
console.log(storage.getById());

console.log("");

let allElements = storage.getAll();
for (let entry of allElements) { 
    console.log(entry);
}

console.log("");

storage.updateById(2,{maidenName: "Облонская"});

storage.replaceById(1,{name: "Татьяна", surname: "Ларина"});

console.log(storage.deleteById(3));
console.log("");

let allElements2 = storage.getAll();
for (let entry of allElements2) { 
    console.log(entry);
}