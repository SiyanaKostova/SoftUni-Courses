function sameNumbers(number){
    let sum = 0;
    const digitsString = number.toString();
    let isDifferent = true;

    for (let i = 1; i < digitsString.length; i++) {
        if(digitsString[i] !== digitsString[i - 1]){
            isDifferent = false;
        }
    }
    for (let j = 0; j < digitsString.length; j++) {
        sum += Number(digitsString[j]);
    }
    console.log(isDifferent);
    console.log(sum);
}

sameNumbers(2222222);
sameNumbers(1234);