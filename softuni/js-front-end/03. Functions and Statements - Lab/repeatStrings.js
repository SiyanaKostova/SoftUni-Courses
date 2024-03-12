function repeatString(word, times) {
    let text = ' ';
    for (let i = 0; i < times; i++) {
        text += word;
    }
    console.log(text);
}

repeatString('abc', 3);