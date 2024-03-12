function mathOperation(first, second, operator) {
    let result;
    switch(operator) {
        case 'add':
            result = first + second;
            break;
        case 'subtract':
            result = first - second;
            break;
        case 'multiply':
            result = first * second;
            break;
        case 'divide':
            result = first / second;
            break;
    }
    console.log(result);
}

mathOperation(5, 5, 'multiply' );