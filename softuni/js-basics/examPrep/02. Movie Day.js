function movieDay(input){

    let timeForPhotos=Number(input.shift());
    let numScenes=Number(input.shift());
    let time=Number(input.shift());

    let prep=0.15*timeForPhotos;
    let scenes=numScenes*time;
    let all=prep+scenes;
    let diff=Math.abs(all-timeForPhotos);
    if(timeForPhotos>=all){
        console.log(`You managed to finish the movie on time! You have ${Math.round(diff)} minutes left!`);
    } else {
        console.log(`Time is up! To complete the movie you need ${Math.round(diff)} minutes.`);
    }
}
movieDay(["60","15","3"])