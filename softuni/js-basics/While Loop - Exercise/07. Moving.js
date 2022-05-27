function solve(input) {

    let index = 0;
    let w = Number(input[index]);
    index++;
    let l = Number(input[index]);
    index++;
    let h = Number(input[index]);
    index++;

    let size = w * l * h;
    let command = input[index];
    index++;
    let isFreeSpace = true;

    while (command !== 'Done') {
        let box = Number(command);

        size -= box;

        if (size < 0) {
            isFreeSpace = false;
            break;
        }
        command = input[index];
        index++;
    }

    if (isFreeSpace) {
        console.log(`${size} Cubic meters left.`);
    } else {
        console.log(`No more free space! You need ${Math.abs(size)} Cubic meters more.`);
    }
}
solve(["10",
    "10",
    "2",
    "20",
    "20",
    "20",
    "20",
    "122"])

