function movieRating(input){

    let player=input.shift();
    let initialPoints=301;
    let successful=0;
    let unSuccessful=0;

    let field=input.shift();
    let points=Number(input.shift());

    while(initialPoints>0){
        if(field==='Retire'){
            break;
        }
    if(field=='Triple'){
        points*=3;
    } else if(field=='Double'){
        points*=2;
    } else if(field=='Single'){
        points*=1;
    }
    if(points<=initialPoints){
        initialPoints-=points;
        successful++;
    } else {
        unSuccessful++;
    }
    field=input.shift();
    points=input.shift();
}
    if(field==='Retire'){
        console.log(`${player} retired after ${unSuccessful} unsuccessful shots.`);
    } else {
        console.log(`${player} won the leg with ${successful} shots.`);
    }
}
movieRating(["Michael van Gerwen", "Triple", "20", "Triple", "19", "Double", "10", "Single",
"3", "Single", "1", "Triple", "20", "Triple", "20", "Double", "20"])