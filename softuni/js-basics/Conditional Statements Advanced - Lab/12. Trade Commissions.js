function conditionalsAd(input){
    let town = input[0];
    let percentageOfSales = Number(input[1]);
    let comision = 0;
    if (town=='Sofia')
    {
        if (percentageOfSales>=0&&percentageOfSales<=500)
        {
            comision = 0.05;
        }
        else if (percentageOfSales > 500 && percentageOfSales <= 1000)
        {
            comision = 0.07;
        }
        else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
        {
            comision = 0.08;
        }
        else if (percentageOfSales > 10000)
        {
            comision = 0.12;
        }
        else
        {
            console.log('error');
        }
    }
    else if (town=="Varna")
    {
        if (percentageOfSales >= 0 && percentageOfSales <= 500)
        {
            comision = 0.045;
        }
        else if (percentageOfSales > 500 && percentageOfSales <= 1000)
        {
            comision = 0.075;
        }
        else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
        {
            comision = 0.10;
        }
        else if (percentageOfSales > 10000)
        {
            comision = 0.13;
        }
        else
        {
            console.log('error');
        }
    }
    else if (town == "Plovdiv")
    {
        if (percentageOfSales >= 0 && percentageOfSales <= 500)
        {
            comision = 0.055;
        }
        else if (percentageOfSales > 500 && percentageOfSales <= 1000)
        {
            comision = 0.08;
        }
        else if (percentageOfSales > 1000 && percentageOfSales <= 10000)
        {
            comision = 0.12;
        }
        else if (percentageOfSales > 10000)
        {
            comision = 0.145;
        }
        else
        {
            console.log('error');
        }
    }

    else
    {
        console.log('error');
    }

    let total = percentageOfSales * comision;

    if (comision!=0)
    {
        console.log(`${total.toFixed(2)}`);
    }
}
conditionalsAd(["Sofia",
"1500"])
