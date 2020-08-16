export class Service {
    storageMap;
    id = 0;

    constructor() {
      this.storageMap = new Map();
    }

    add(name = "new") {

      if(name == "new"){
        return false;
      }

      this.id++;
      this.storageMap.set(this.id.toString(), name);
      return true;
    }

    getById(ID = -1){

      if(ID == -1){
        return null;
      }
      
      let value = this.storageMap.get(ID.toString());
      if(value){
        return value;
      }
      else {
        return null;
      }
    }

    getAll(){
      return this.storageMap.entries();
    }

    deleteById(ID = -1){
      if(ID == -1){
        return false;
      }
      
      let value = this.storageMap.get(ID.toString());
      this.storageMap.delete(ID.toString());
      return value;
    }

    updateById(ID = -1, addName = "add"){

      if(ID == -1 && addName == "add"){
        return false;
      }
  
      if(this.storageMap.has(ID.toString())){

        let objectNew = this.storageMap.get(ID.toString());
        let arrKey = Object.keys(addName);

        for (let i = 0; i < arrKey.length; i++) {
          objectNew[arrKey[i]] = addName[arrKey[i]];
        } 
        this.storageMap.set(ID.toString(), objectNew);

        return true;
        }
      else {
        return false;
      } 
    }

    replaceById(ID = -1, name = "new"){

      if(ID == -1 && name == "new"){
        return false;
      }
      
      if(this.storageMap.has(ID.toString())){
        this.storageMap.set(ID.toString(), name);
        return true;
      }
      else {
        return false;
      }
    }
}
  