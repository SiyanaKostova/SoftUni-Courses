function solve(input) {

    let element = input[0];
    let index = 0;
    let min = Number.MAX_SAFE_INTEGER;
    while (element !== 'Stop') {
        let num = Number(element);
        if (num < min) {
            min = num;
        }
        element = input[index];
        index++;
    }
    console.log(min);
}
solve(["-10",
    "20",
    "-30",
    "Stop"])
