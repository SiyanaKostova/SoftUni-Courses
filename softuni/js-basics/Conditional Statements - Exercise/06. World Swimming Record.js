function record(input){
    let recordInSec=Number(input[0]);
    let distanceInM=Number(input[1]);
    let timeInSecForOneM=Number(input[2]);

    let delay=Math.floor(distanceInM/15);
    let delayInSec=delay*12.5;
    
    let time=distanceInM*timeInSecForOneM+delayInSec;

    if (time<recordInSec) {
        console.log(`Yes, he succeeded! The new world record is ${time.toFixed(2)} seconds.`)
    } else {
        let diff=time-recordInSec;
        console.log(`No, he failed! He was ${diff.toFixed(2)} seconds slower.`)
    }
}
record(["55555.67",
"3017",
"5.03"])
