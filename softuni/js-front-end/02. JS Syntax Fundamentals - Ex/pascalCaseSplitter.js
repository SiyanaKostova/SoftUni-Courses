function pascalCaseSplitter(text){
    let words = text.split(/(?=[A-Z])/);
    console.log(words.join(', '))
}

pascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan' );