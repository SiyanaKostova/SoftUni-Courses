function third(input){

    let numDancers=Number(input.shift());
    let numPoints=Number(input.shift());
    let season=input.shift();
    let place=input.shift();

    let price=0;

    if(place==='Bulgaria'){
        price=numPoints*numDancers;
        if(season==='summer'){
            price*=0.95;
        } else if (season==='winter'){
            price*=0.92;
        }
    } else if(place==='Abroad'){
        price=1.5*(numPoints*numDancers);
        if(season==='summer'){
            price*=0.90;
        } else if (season==='winter'){
            price*=0.85;
        }
    }

    let moneyForCharity=0.75*price;
    let moneyForDancers=0.25*price;

    let moneyForOnePerson=moneyForDancers/numDancers;

    console.log(`Charity - ${moneyForCharity.toFixed(2)}`);
    console.log(`Money per dancer - ${moneyForOnePerson.toFixed(2)}`);

}
third(["25",
"98",
"winter",
"Bulgaria"])
