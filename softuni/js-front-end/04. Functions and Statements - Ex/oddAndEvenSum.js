function oddAndEvenSum (number) {

    const numberAsString = number.toString();

    let oddSum = 0;
    let evenSum = 0;

    for(const digit of numberAsString) {
        if(digit % 2 === 0){
            evenSum += Number(digit);
        } else {
            oddSum += Number(digit);
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

oddAndEvenSum(3495892137259234);