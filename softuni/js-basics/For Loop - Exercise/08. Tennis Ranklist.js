function loops(input){
    let index=0;
    let countTournaments=Number(input[index]);
    index++;
    let startPoints=Number(input[index]);
    index++;

    let points=0;
    let countWin=0;

    for (let i = 0; i < countTournaments; i++) {
        let res=input[index];
        index++;

        if (res=='W') {
            points+=2000;
            countWin++;
        } else if (res=='F') {
            points+=1200;
        } else if (res=='SF'){
            points+=720;
        }
    }
    let finalPoints=points+startPoints;
    let averagePoints=points/countTournaments;
    let win=countWin/countTournaments*100;
    console.log(`Final points: ${finalPoints}`);
    console.log(`Average points: ${Math.floor(averagePoints)}`);
    console.log(`${win.toFixed(2)}%`);
}
loops(["4",
"750",
"SF",
"W",
"SF",
"W"])

