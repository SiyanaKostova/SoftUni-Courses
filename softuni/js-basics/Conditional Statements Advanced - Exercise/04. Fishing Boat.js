function csAdv(input){

    let budjet = Number(input[0]);
    let season = input[1];
    let numFisherman = Number(input[2]);

    let price = 0.00;

    if (season == "Spring")
    {
        price += 3000.00;
    }
    else if (season=="Summer"||season=="Autumn")
    {
        price += 4200;
    }
    else if (season=="Winter")
    {
        price += 2600;
    }

    if (numFisherman<=6)
    {
        price *= 0.90;
    }
    else if (numFisherman>6&&numFisherman<12)
    {
        price *= 0.85;
    }
    else if (numFisherman>11)
    {
        price *= 0.75;
    }

    if (numFisherman%2==0&&season!="Autumn")
    {
        price *= 0.95;
    }

    let left = Math.abs(price - budjet);

    if (price<=budjet)
    {
        console.log(`Yes! You have ${left.toFixed(2)} leva left.`)  
    }
    else if (price>budjet)
    {
        console.log(`Not enough money! You need ${left.toFixed(2)} leva.`)
    }
}
csAdv(["3600",
"Autumn",
"6"])
