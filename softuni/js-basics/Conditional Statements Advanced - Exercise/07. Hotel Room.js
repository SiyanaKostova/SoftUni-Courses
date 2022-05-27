function csAdv(input){

    let season = input[0];
    let nights = Number(input[1]);
    let totalMoneyForStudio = 0;
    let totalMoneyForApartment = 0;

    switch (season)
    {
        case "May":
        case "October":
            totalMoneyForStudio = nights * 50;
            totalMoneyForApartment = nights * 65;
            if (nights>7&&nights<14)
            {
                totalMoneyForStudio -= totalMoneyForStudio * 0.05;
            }
            else if (nights>14)
            {
                totalMoneyForStudio -= totalMoneyForStudio * 0.3;
            }
            break;
        case "June":
        case "September":
            totalMoneyForStudio = nights * 75.20;
            totalMoneyForApartment = nights * 68.70;
            if (nights>14)
            {
                totalMoneyForStudio -= totalMoneyForStudio * 0.20;
            }
            break;
        case "July":
        case "August":
            totalMoneyForStudio = 76 * nights;
            totalMoneyForApartment = 77 * nights;
            break;
    }

    if (nights>14)
    {
        totalMoneyForApartment -= totalMoneyForApartment * 0.10;
    }

    console.log(`Apartment: ${totalMoneyForApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${totalMoneyForStudio.toFixed(2)} lv.`);
}
csAdv(["May",
"15"])
