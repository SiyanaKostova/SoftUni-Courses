function csAdv(input){

    let countDays = Number(input[0]);
    let roomType = input[1];
    let rating = input[2];
    let nights = countDays - 1;
    let totalPrice = 0;

    switch (roomType)
    {
        case "room for one person":
            totalPrice = nights * 18;
            break;
        case "apartment":
            totalPrice = nights * 25;
            if (countDays>15)
            {
                totalPrice *= 0.5;
            }
            else if (countDays>=10)
            {
                totalPrice *= 0.65;
            }
            else
            {
                totalPrice *= 0.6;
            }
            break;
        case "president apartment":
            totalPrice = nights * 35;
            if (countDays>15)
            {
                totalPrice *= 0.8;
            }
            else if (countDays>=10)
            {
                totalPrice *= 0.85;
            }
            else
            {
                totalPrice *= 0.9;
            }
            break;
    }
    switch (rating)
    {
        case "positive":
            totalPrice *= 1.25;
            break;
        case "negative":
            totalPrice *= 0.9;
            break;
    }
    console.log(`${totalPrice.toFixed(2)}`);
}
csAdv(["14",
"apartment",
"positive"])
