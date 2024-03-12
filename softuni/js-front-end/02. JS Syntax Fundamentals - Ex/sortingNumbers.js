function sortingNumbers(arr){

    const sortedArray = arr.sort((a, b) => a - b);
    const resultArray = [];
    const length = arr.length;

    for (let i = 0; i < length; i++) {
        if (i % 2 === 0) {
            resultArray.push(sortedArray.shift());
        } else {
            resultArray.push(sortedArray.pop());
        }
    }

    return resultArray;
}

sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);