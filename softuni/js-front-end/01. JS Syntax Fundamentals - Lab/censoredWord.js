function censoredWord(text, word){

    const replacement = "*".repeat(word.length);
    let censored = text;

    while(censored.includes(word)){
        censored = censored.replace(word, replacement);
    }
    
    console.log(censored);
}

censoredWord('A small sentence with some words', 'small')