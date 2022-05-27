function solve(input){
    let n = Number(input.shift());
    let a, b, c, d;
    let isFound = false;

            for (let i = 1; i <= 9; i++)
            {
                a = i;
                for (let j = 9; j >= a; j--)
                {
                    b = j;
                    for (let k = 0; k <= 9; k++)
                    {
                        c = k;
                        for (let l = 9; l >= c; l--)
                        {
                            d = l;

                            let sum = a + b + c + d;
                            let multiply = a * b * c * d;
                            let lastDigitn = n % 10;

                            if (sum === multiply && lastDigitn === 5)
                            {
                                console.log(`${a}${b}${c}${d}`);
                                isFound = true;
                                return;
                            }
                            else if ((multiply / sum === 3)){
                                if(n%3==0){
                                    console.log(`${d}${c}${b}${a}`);
                                    isFound = true;
                                    return;
                            }
                        }
                        }
                    }
                }
            }
            if (!isFound)
            {
                console.log(`Nothing found`);
            }
}
solve(["123"])