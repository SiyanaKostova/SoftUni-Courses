function easterEggs(input) {

    let eggs = Number(input.shift());

    let orangeEggs = 0;
    let redEggs = 0;
    let blueEggs = 0;
    let greenEggs = 0;

    let colour = "";

    let max = Number.MIN_SAFE_INTEGER;

    for (let i = 1; i <= eggs; i++) {
        let colourEgg = input.shift();
        switch (colourEgg) {
            case 'red':
                redEggs++;
                if(redEggs>max){
                    max=redEggs;
                    colour='red';
                }
                break;
            case 'green':
                greenEggs++;
                if(greenEggs>max){
                    max=greenEggs;
                    colour='green';
                }
                break;
            case 'orange':
                orangeEggs++;
                if(orangeEggs>max){
                    max=orangeEggs;
                    colour='orange';
                }
                break;
            case 'blue':
                blueEggs++;
                if(blueEggs>max){
                    max=blueEggs;
                    colour='blue';
                }
                break;
        }
    }


    console.log(`Red eggs: ${redEggs}`);
    console.log(`Orange eggs: ${orangeEggs}`);
    console.log(`Blue eggs: ${blueEggs}`);
    console.log(`Green eggs: ${greenEggs}`);
    console.log(`Max eggs: ${max} -> ${colour}`);

}
easterEggs(["7", "orange", "blue", "green", "green", "blue", "red", "green"])