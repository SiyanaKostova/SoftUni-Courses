function oddOccurances(input) {
    const words = input.split(' ');
    const wordsOcc = words.reduce((acc, curr) => {
        const lowerCaseWord = curr.toLowerCase();
        acc[lowerCaseWord] = (acc[lowerCaseWord] || 0) + 1;
        return acc;
    }, {})
    const oddElements = [];
    Object.entries(wordsOcc).forEach(([key, value]) => {
        if (value % 2 !== 0) {
            oddElements.push(key);
        }
    })
    return console.log(oddElements.join(' ').trimEnd());
}

oddOccurances('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')