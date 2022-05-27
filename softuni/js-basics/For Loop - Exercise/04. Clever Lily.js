function loops(input){
    let age=Number(input[0]);
    let perPrice=Number(input[1]);
    let toysPrice=Number(input[2]);

    let toys=0;
    let money=0;
    let currentMoney=10;

    for (let i = 1; i <= age; i++) {
        if (i%2===0) {
            money+=currentMoney;
            currentMoney+=10;
            money-=1;
        } else {
            toys++;
        }
    }
    let totalMoney=toys*toysPrice+money;
    let diff=Math.abs(perPrice-totalMoney);
    
    if (totalMoney>=perPrice) {
        console.log(`Yes! ${diff.toFixed(2)}`);
    } else {
        console.log(`No! ${diff.toFixed(2)}`);
    }
}
loops(["21",
"1570.98",
"3"])


