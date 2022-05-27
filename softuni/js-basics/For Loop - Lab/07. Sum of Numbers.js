function solve(input){
    let num=input[0];
    let textNum=""+num;
    let sum=0;

    for (let i = 0; i < textNum.length; i++) {
        sum+=Number(textNum[i]);
    }
    console.log(`The sum of the digits is:${sum}`);
}
solve(["564891"])   