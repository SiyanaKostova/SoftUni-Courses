function task(input){
    let numOfPages=Number(input[0]);
    let pagesPerHour=Number(input[1]);
    let numOfDays=Number(input[2]);
    let timeForReading=numOfPages/pagesPerHour;
    let timeForDay=timeForReading/numOfDays;
    console.log(timeForDay);
}
task(["212 ",
"20 ",
"2 "]
);