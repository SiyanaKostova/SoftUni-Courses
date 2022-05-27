function csAdv(input){
    
    let budjet=Number(input[0]);
    let season=input[1];

    let price=0.00;
    let place='';
    let type='';

    if (budjet<=100) {
        place='Bulgaria';
        if (season=='summer') {
            price=0.3*budjet;
        } else if (season=='winter') {
            price=0.7*budjet;
        }
    }

    else if (budjet<=1000) {
        place='Balkans';
        if (season=='summer') {
            price=0.4*budjet;
        } else if (season=='winter') {
            price=0.8*budjet;
        }
    }

    else if (budjet>1000) {
        place='Europe';
        type='Hotel';
        price=0.9*budjet;
        }

    if (season=='summer'&&place!='Europe')
    {
        type = "Camp";
    }
    else if (season=='winter')
    {
        type = "Hotel";
    }

    console.log(`Somewhere in ${place}`);
    console.log(`${type} - ${price.toFixed(2)}`);
}
csAdv(["1500", "summer"])