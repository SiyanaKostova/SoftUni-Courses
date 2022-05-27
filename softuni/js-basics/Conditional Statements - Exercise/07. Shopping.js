function conditions(input){
    let budjet=Number(input[0]);
    let VGAcount=Number(input[1]);
    let CPUcount=Number(input[2]);
    let RAMcount=Number(input[3]);

    let moneyForVga=VGAcount*250;
    let priceCPU=moneyForVga*0.35;
    let moneyForCPU=priceCPU*CPUcount;
    let priceRAM=moneyForVga*0.10;
    let moneyForRAM=RAMcount*priceRAM;

    let totalMoney=moneyForVga+moneyForCPU+moneyForRAM;

    if (VGAcount>CPUcount) {
        totalMoney*=0.85;
    }

    let diff=Math.abs(totalMoney-budjet);

    if (budjet>=totalMoney) {
        console.log(`You have ${diff.toFixed(2)} leva left!`)
    } else {
        console.log(`Not enough money! You need ${diff.toFixed(2)} leva more!`)
    }
}
conditions(["920.45",
"3",
"1",
"1"])

