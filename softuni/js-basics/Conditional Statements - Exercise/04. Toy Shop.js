function conditions(input){
    let excursionPrice=Number(input[0]);
    let puzzleCount=Number(input[1]);
    let dollCount=Number(input[2]);
    let teddyBearCount=Number(input[3]);
    let minionsCount=Number(input[4]);
    let truckCount=Number(input[5]);

    let toysCount=puzzleCount+dollCount+teddyBearCount+minionsCount+truckCount;
    let money=puzzleCount*2.60+dollCount*3+teddyBearCount*4.10+minionsCount*8.20+truckCount*2;

    if (toysCount>=50) {
        money*=0.75;
    }

    money*=0.9;
    let diff=Math.abs(money-excursionPrice);

    if (money>=excursionPrice) {
        console.log(`Yes! ${diff.toFixed(2)} lv left.`);
    } else {
        console.log(`Not enough money! ${diff.toFixed(2)} lv needed.`);
    }
}
conditions(["40.8",
"20",
"25",
"30",
"50",
"10"])
