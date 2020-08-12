var originalString = "У попа была собака, он её любил!";
console.log(originalString);

function charRemover(str, repeatedChar) {

    var rezult = [];

    for(i=0; i < str.length; i++){
        if(repeatedChar.indexOf(str[i]) == -1){

            rezult.push(str[i]);
        }
    }
    var rezultString = rezult.join('');
    console.log(rezultString);
}

function changeStr(str) { 
   
    var arrWords =  str.split(" ");
    var repeatedChar = [];

    for(i=0; i <arrWords.length; i++){
        for(j=0; j <arrWords[i].length; j++) {

            if (arrWords[i].indexOf(arrWords[i][j]) !== arrWords[i].lastIndexOf(arrWords[i][j]) ) {

                repeatedChar.push(arrWords[i][j]);
            }
        }
    }
    charRemover(str, repeatedChar)
  }
  
  changeStr(originalString);