function solve(x, y, z) {
    
    const sum = (x, y) => x + y;
    const subtract = (x, z) => x - z;

    console.log(subtract(sum(x, y), z));
}

solve(23, 6, 10);