function loops(input){
    let index=0;
    let count=Number(input[index]);
    index++;

    let musala=0;
    let montblanck=0;
    let kilimanjaro=0;
    let k2=0;
    let everest=0;
    let total=0;

    for (let i = 0; i < count; i++) {
        let people=Number(input[index]);
        index++;
        total+=people;
        
        if (people<6) {
            musala+=people;
        } else if (people>=6&&people<=12) {
            montblanck+=people;
        } else if (people>=13&&people<=25) {
            kilimanjaro+=people;
        } else if (people>=26&&people<=40) {
            k2+=people;
        } else {
            everest+=people;
        }
    }

    let musalaPr=musala/total*100;
    let montblanckPr=montblanck/total*100;
    let kilimanjaroPr=kilimanjaro/total*100;
    let k2Pr=k2/total*100;
    let everestPr=everest/total*100;

    console.log(`${musalaPr.toFixed(2)}%`);
    console.log(`${montblanckPr.toFixed(2)}%`);
    console.log(`${kilimanjaroPr.toFixed(2)}%`);
    console.log(`${k2Pr.toFixed(2)}%`);
    console.log(`${everestPr.toFixed(2)}%`);
}
loops(["5",
"25",
"41",
"31",
"250",
"6"])
