function solve(input){
    
    let index=0;
    let w=Number(input[index]);
    index++;
    let l=Number(input[index]);
    index++;
    let cakeSize=w*l;

    let command=input[index];
    index++;
    let isCake=true;

    while (command!=='STOP'){
        let pieces=Number(command);
        cakeSize-=pieces;

        if (cakeSize<0) {
            isCake=false;   
            break;
        }
        command=input[index];
        index++;
    }

    if(isCake){
        console.log(`${cakeSize} pieces are left.`);
    } else {
        console.log(`No more cake left! You need ${Math.abs(cakeSize)} pieces more.`);
    }

}
solve(["10",
"2",
"2",
"4",
"6",
"STOP"])

