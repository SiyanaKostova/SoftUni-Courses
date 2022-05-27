function oscarsCeremony(input){

    let naem=Number(input.shift());
    let priceStatuetki=0.7*naem;
    let priceKeturing=0.85*priceStatuetki;
    let priceSound=0.5*priceKeturing;
    let all=naem+priceStatuetki+priceKeturing+priceSound;
    console.log(`${all.toFixed(2)}`);
}
oscarsCeremony(["3500"]);