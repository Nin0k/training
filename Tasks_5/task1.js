let originalString = "У попа была собака, он её любил!";
console.log(originalString);

function charRemover(str, repeatedChar) {

    let rezult = [];

    for(let i=0; i < str.length; i++){
        if(repeatedChar.indexOf(str[i]) == -1){

            rezult.push(str[i]);
        }
    }
    let rezultString = rezult.join('');
    console.log(rezultString);
}

function changeStr(str) { 
   
    let arrWords =  str.split(" ");
    let repeatedChar = [];

    for(let i=0; i <arrWords.length; i++){
        for(let j=0; j <arrWords[i].length; j++) {

            if (arrWords[i].indexOf(arrWords[i][j]) !== arrWords[i].lastIndexOf(arrWords[i][j]) ) {

                repeatedChar.push(arrWords[i][j]);
            }
        }
    }
    charRemover(str, repeatedChar)
  }
  
  changeStr(originalString);