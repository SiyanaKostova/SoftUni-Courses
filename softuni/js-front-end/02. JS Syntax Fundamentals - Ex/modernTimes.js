function modernTimes(text){
    let splitted = text.split(' ');
    let letters = /^[#]+[a-zA-Z]+$/g;

    for (const word of splitted) {
        if(word[0] === '#') {
            if (word.match(letters)){
                let newWord = word.substring(1);
                console.log(newWord);
            }
        }
      }
}

modernTimes('Nowadays everyone uses # to tag a #special word in #socialMedia');