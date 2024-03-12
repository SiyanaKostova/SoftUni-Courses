function substring(word, first, second){
    let result = word.substring(first, second + first);
    console.log(result);
}

substring('ASentence', 1, 8 );
substring('SkipWord', 4, 7);