function charactersInRange(char1, char2) {

    const chars = [];

    let first = char1.charCodeAt(0);
    let second = char2.charCodeAt(0);
  
    if(first < second){
      getChars(first, second);
    } else {
      getChars(second, first);
    }
    
    console.log(chars.join(" "));
    
    function getChars(start, end) {
      for (let i = start + 1; i < end; i++) {
        chars.push(String.fromCharCode(i));
      }  
    }
  }
  
  charactersInRange("C", "#");