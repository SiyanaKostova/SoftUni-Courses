function task(input){
    let nylon=Number(input[0]);
    let paint=Number(input[1]);
    let thinner=Number(input[2]);
    let hours=Number(input[3]);

    let qNylon=nylon+2;
    let qPaint=paint*1.10;
    let price=qNylon*1.50+qPaint*14.50+thinner*5+0.40;

    let workForOneHour=price*0.30;
    let totalPriceWork=workForOneHour*hours;

    let total=price+totalPriceWork;
    console.log(total);
}
task(["10 ",
"11 ",
"4 ",
"8 "]
);