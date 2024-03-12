function countStringOccurances(text, word) {

    const words = text.split(" ");
    let occurances = 0;

    for (let i = 0; i < words.length; i++) {
        if(words[i] === word) {
            occurances++;
        }
    }

    console.log(occurances);
}

countStringOccurances('This is a word and it also is a sentence','is')