function mathOperation(first, second, operator) {
    let result;
    switch(operator) {
        case '+':
            result = first + second;
            break;
        case '-':
            result = first - second;
            break;
        case '*':
            result = first * second;
            break;
        case '/':
            result = first / second;
            break;
        case '**':
            result = first ** second;
            break;
        case '%':
            result = first % second;
            break;
    }
    console.log(result);
}

mathOperation(3, 5.5, '*' );