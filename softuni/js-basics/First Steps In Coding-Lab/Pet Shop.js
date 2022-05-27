function demo(input){
    let dogs=Number(input[0]);
    let cats=Number(input[1]);
    let priceDogs=dogs*2.50;
    let priceCats=cats*4;
    let sum=priceDogs+priceCats;
    
    console.log(`${sum} lv.`)
     }
     
     demo(["5 ",
     "4 "]
     )