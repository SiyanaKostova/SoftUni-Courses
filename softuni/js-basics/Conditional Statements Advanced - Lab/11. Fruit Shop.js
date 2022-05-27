function conditionalsAd(input){
    let fruit = input[0];
    let dayOfWeek = input[1];
    let num=Number(input[2]);
    let price=0;
    if (dayOfWeek == "Monday"
        || dayOfWeek == "Tuesday"
        || dayOfWeek == "Wednesday"
        || dayOfWeek == "Thursday"
        || dayOfWeek == "Friday")
    {
        switch (fruit)
        {
            case "banana":
                price = 2.50;
                break;
            case "apple":
                price = 1.20;
                break;
            case "orange":
                price = 0.85;
                break;
            case "grapefruit":
                price = 1.45;
                break;
            case "kiwi":
                price = 2.70;
                break;
            case "pineapple":
                price = 5.50;
                break;
            case "grapes":
                price = 3.85;
                break;
            default:
                console.log('error');
                break;
        }
    }

    else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday")
    {
        switch (fruit)
        {
            case "banana":
                price = 2.70;
                break;
            case "apple":
                price = 1.25;
                break;
            case "orange":
                price = 0.90;
                break;
            case "grapefruit":
                price = 1.60;
                break;
            case "kiwi":
                price = 3.00;
                break;
            case "pineapple":
                price = 5.60;
                break;
            case "grapes":
                price = 4.20;
                break;
            default:
                console.log('error');
                break;
        }
    }

        else
        {
        console.log('error');
        }

    let total=num*price;

    if (price!=0)
    {
        console.log(`${total.toFixed(2)}`);
    }
}
conditionalsAd(["apple",
"Tuesday",
"2"])
