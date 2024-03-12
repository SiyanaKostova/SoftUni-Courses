function factorialDivision(x, y) {

    let sumX = 1;
    let sumY = 1;

    for (let i = 1; i <= x ; i++) {
        sumX *= i;
    }

    for (let j = 1; j <= y; j++) {
        sumY *= j;
    }

    console.log((sumX / sumY).toFixed(2));
}

factorialDivision(5, 2);