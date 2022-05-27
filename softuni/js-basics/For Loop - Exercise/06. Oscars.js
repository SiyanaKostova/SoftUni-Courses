function loops(input){
    let index=0;
    let nameOfActor=input[index];
    index++;
    let points=Number(input[index]);
    index++;
    let juryCount=Number(input[index]);
    index++;

    let isNominated=false;

    for (let i = 0; i < juryCount; i++) {
        let name=input[index];
        index++;
        let tempPoints=Number(input[index]);
        index++;

        points += name.length*tempPoints/2;
        

        if (points>=1250.5) {
            isNominated=true;
            console.log(`Congratulations, ${nameOfActor} got a nominee for leading role with ${points.toFixed(1)}!`);
            break; 
        }
    }
    let diff=1250.5-points;
    if (isNominated==false) {
        console.log(`Sorry, ${nameOfActor} you need ${diff.toFixed(1)} more!`);
    }
}
loops(["Zahari Baharov",
"205",
"4",
"Johnny Depp",
"45",
"Will Smith",
"29",
"Jet Lee",
"10",
"Matthew Mcconaughey",
"39"])
