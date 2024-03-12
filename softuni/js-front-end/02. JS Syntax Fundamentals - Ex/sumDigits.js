function sumDigits(number){
    const digitsString = number.toString();
    let sum = 0;

    for (let i = 0; i < digitsString.length; i++) {
        sum += Number(digitsString[i]);
    }

    console.log(sum);
}

sumDigits(12345);