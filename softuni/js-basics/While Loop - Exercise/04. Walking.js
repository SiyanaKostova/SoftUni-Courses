function solve(input){

    let index=0;
    let target=10000;
    let command=input[index];
    index++;

    let totalSteps=0;

    while(command!=='Going home'){
        let steps=Number(command);
        totalSteps+=steps;

        if (totalSteps>=target) {
            let diff=Math.abs(totalSteps-target);
            console.log(`Goal reached! Good job!`);
            console.log(`${diff} steps over the goal!`);
            break;
        }
        command=input[index];
        index++;
    }
    
    if (command==='Going home') {
        let steps=Number(input[index]);
        index++;
        totalSteps+=steps;
        let diff=Math.abs(totalSteps-target);   

        if (totalSteps>=target) {
            console.log(`Goal reached! Good job!`);
            console.log(`${diff} steps over the goal!`);
        } else {
            console.log(`${diff} more steps to reach goal.`);
        }
    }
}
solve(["1500",
"3000",
"250",
"1548",
"2000",
"Going home",
"2000"])

