let stringExp = "3.5 +4*10-5.3 /5 =";

function stringConversion(expression) {
    
    let arrExs =  expression.split(/[^\s0-9.]/);
    let arrExs2 = deleteSpaces(arrExs);

    let arrSymbols1 =  expression.split(/[\s0-9.]/);
    let arrSymbols2 = deleteSpaces(arrSymbols1);

    counting(arrExs2, arrSymbols2)
    
}
function deleteSpaces(arr){
    let arrNew = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] != '') {
            arrNew.push(arr[i]);
        } 
    }
    return arrNew;
}

function counting(arrNumbers, arrSymbols) {
    let rezult = +arrNumbers[0];

    for (let i = 0; i < arrSymbols.length; i++) {
        if(arrSymbols[i] == "+"){
            rezult += (+arrNumbers[i+1]);
        }
        else if(arrSymbols[i] == "-"){
            rezult -= arrNumbers[i+1];
        }
        else if(arrSymbols[i] == "*"){
            rezult *= arrNumbers[i+1];
        }
        else if(arrSymbols[i] == "/"){
            rezult /= arrNumbers[i+1];
        }
        else if(arrSymbols[i] == "="){
            rezult = rezult.toFixed(2);
            console.log("Итог:"+ rezult);
        }
    }
}

console.log(stringExp);
stringConversion(stringExp);