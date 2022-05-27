function demo(input){
    let sqMeters=Number(input[0]);
    let price=sqMeters*7.61;
    let discount=price*0.18;
    let sale=price-discount;
    
    console.log(`The final price is: ${sale} lv.`);
    console.log(`The discount is: ${discount} lv.`)
     }
     
     demo(["550"])