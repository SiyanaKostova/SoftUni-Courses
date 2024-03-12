function findPerfect(number){

    let sum = 0;

    for (let i = 1; i < number; i++) {
        if (number % i === 0){
            sum += i;
        }
    }

    return sum === number ? `We have a perfect number!` : `It's not so perfect.`;
}

findPerfect(6);
findPerfect(28);
findPerfect(1236498);