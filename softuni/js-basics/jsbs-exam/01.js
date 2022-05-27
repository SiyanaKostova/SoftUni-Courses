function first(input){

    let CPU = Number(input.shift());
    let GPU = Number(input.shift());
    let RAM = Number(input.shift());
    let RAMnum = Number(input.shift());
    let Percentage = Number(input.shift());

    let a1 = CPU * 1.57;
    let a2 = GPU * 1.57;
    let a3 = RAM * 1.57*RAMnum;

    let priceOFF1 = a1 * (1 - Percentage); 
    let priceOFF2 = a2 * (1 - Percentage);
    let sum = priceOFF1 + priceOFF2 + a3;
    console.log(`Money needed - ${sum.toFixed(2)} leva.`);
}
first(["500",
"200",
"80",
"2",
"0.05"])
