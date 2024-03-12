function track(input) {
    const [searchWords, ...words] = input;
    const wordOcc = searchWords.split(' ').reduce((acc, curr) => {
        acc[curr] = 0;
        return acc;
    }, {});

    words.forEach((w) => {
        if(wordOcc.hasOwnProperty(w)){
            wordOcc[w] += 1;
        }
    })

    Object.entries(wordOcc).sort(([, a], [, b]) => b - a)
    .forEach(([key, value]) => {console.log(`${key} - ${value}`)});
}

track([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
    ]
    )