function conditions(input){
    let type=input[0];
    let area=0;
    if (type ===`square`) {
      let a=Number(input[1]);
      area=a*a;
    } else if (type ===`rectangle`) {
        let a=Number(input[1]);
        let b=Number(input[2]);
        area=a*b;
    } else if (type ===`circle`) {
        let r=Number(input[1]);
        area=Math.PI*r*r;
    } else if (type ===`triangle`) {
        let a=Number(input[1]);
        let ha=Number(input[2]);
        area=(a*ha)/2;
    }
    console.log(area.toFixed(3));
}
conditions(["triangle",
"4.5",
"20"])


