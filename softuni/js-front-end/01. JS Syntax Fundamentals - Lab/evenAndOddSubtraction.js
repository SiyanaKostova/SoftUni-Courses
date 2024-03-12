function subtract(input) {

    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < input.length; i++) {
        if (input[i] % 2 === 0) {
            evenSum += input[i];
        } else {
            oddSum += input[i];
        }
    }
    console.log(evenSum - oddSum);
}

subtract([1,2,3,4,5,6]);