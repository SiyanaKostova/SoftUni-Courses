function conditions(input){
    let budjet=Number(input[0]);
    let extrasCount=Number(input[1]);
    let clothingPrice=Number(input[2]);

    let decor=budjet*0.1;
    let moneyForClothing=extrasCount*clothingPrice;

    if (extrasCount>150) {
        moneyForClothing*=0.9;
    }

    let totalMoney=decor+moneyForClothing;
    let diff=Math.abs(totalMoney-budjet);

    if (budjet>=totalMoney) {
        console.log("Action!");
        console.log(`Wingard starts filming with ${diff.toFixed(2)} leva left.`)
    } else{
        console.log("Not enough money!");
        console.log(`Wingard needs ${diff.toFixed(2)} leva more.`)
    }
}

conditions(["9587.88",  
"222",
"55.68"])
