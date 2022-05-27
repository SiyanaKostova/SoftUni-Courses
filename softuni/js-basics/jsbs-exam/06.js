function sixth(input){

    let upperFirst = Number(input.shift());
    let upperSecond = Number(input.shift());
    let upperThird = Number(input.shift());
            for (let i = 1; i <= upperFirst; i++)
            {
                if (i%2 == 0)
                {
                    for (let j = 1; j <= upperSecond; j++)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            for (let k = 1; k <= upperThird; k++)
                            {
                                if (k%2 == 0)
                                {
                                    console.log(`${i} ${j} ${k}`);
                                }
                            }
                        }
                    }
                }
            }
}
sixth(["3",
"5",
"5"])
