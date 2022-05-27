function csAdv(input){
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);
    let symbol = input[2];
    let result = 0.00;

    if (symbol == '+')
    {
        result = firstNum + secondNum;
        if (result % 2 == 0)
        {
            console.log(`${firstNum} + ${secondNum} = ${result} - even`)
        }
        else
        {
            console.log(`${firstNum} + ${secondNum} = ${result} - odd`)
        }
    }
    else if (symbol == '-')
    {
        result = firstNum - secondNum;
        if (result % 2 == 0)
        {
            console.log(`${firstNum} - ${secondNum} = ${result} - even`)
        }
        else
        {
            console.log(`${firstNum} - ${secondNum} = ${result} - odd`)
        }
    }
    else if (symbol == '*')
    {
        result = firstNum * secondNum;
        if (result % 2 == 0)
        {
            console.log(`${firstNum} * ${secondNum} = ${result} - even`)
        }
        else
        {
            console.log(`${firstNum} * ${secondNum} = ${result} - odd`)
        }
    }
    else if (symbol == '/')
    {
        if (secondNum==0)
        {
            console.log(`Cannot divide ${firstNum} by zero`)
        }
        else
        {
        result = firstNum / secondNum;
        console.log(`${firstNum} / ${secondNum} = ${result.toFixed(2)}`)
        }
    }
    else if (symbol == '%')
    {
        if (secondNum == 0)
        {
            console.log(`Cannot divide ${firstNum} by zero`)
        }
        else
        {
            result = firstNum % secondNum;
            console.log(`${firstNum} % ${secondNum} = ${result}`)
        }
    }
}
csAdv(["7",
"3",
"*"])
