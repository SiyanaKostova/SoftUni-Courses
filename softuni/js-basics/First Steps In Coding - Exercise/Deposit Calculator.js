function task(input){
    let depSum=Number(input[0]);
    let srok=Number(input[1]);
    let percentPerYear=Number(input[2]);
    let sum=depSum+srok*((depSum*(percentPerYear/100))/12);
    console.log(sum);
}
task(["200 ",
"3 ",
"5.7 "])
