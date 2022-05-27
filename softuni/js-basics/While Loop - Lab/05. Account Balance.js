function solve(input) {
    let total = 0;
    let index = 0;
    let currentElement = input[index];

    while (currentElement !== 'NoMoreMoney') {
        let elementAsNum = Number(currentElement);
        if (elementAsNum < 0) {
            console.log(`Invalid operation!`);
            break;
        }
        total += elementAsNum;
        console.log(`Increase: ${elementAsNum.toFixed(2)}`);
        index++;
        currentElement=input[index];
    }
    console.log(`Total: ${total.toFixed(2)}`);
}
solve(["5.51",
    "69.42",
    "100",
    "NoMoreMoney"])
