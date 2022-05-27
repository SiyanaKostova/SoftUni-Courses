function fourth(input){

    let N = Number(input.shift());
    let M = Number(input.shift());
    let Km = M;
    let allKm = M;
    for (let i = 1; i <= N; i++)
    {
        let percentage = Number(input.shift());
        Km = Km + Km * (percentage / 100);
        allKm = allKm + Km;
    }
    
    if (allKm >= 1000)
    {
        let more = allKm - 1000;
        console.log(`You've done a great job running ${Math.ceil(more)} more kilometers!`);
    }
    else
    {
        let needed = 1000 - allKm;
        console.log(`Sorry Mrs. Ivanova, you need to run ${Math.ceil(needed)} more kilometers`);
    }
}
fourth(["4",
"100",
"30",
"50",
"60",
"80"])

