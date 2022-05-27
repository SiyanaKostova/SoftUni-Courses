function easterDecoration(input){

    let basketPrice=1.50;
    let wreathPrice=3.80;
    let chocolateBunny=7.00;
    let average=0;

    let clients=Number(input.shift());
    for (let i = 0; i < clients; i++) {
        let command=input.shift();
        let price=0;
        let count=0;


        while(command!='Finish'){
            switch (command) {
                case 'basket':
                price+=basketPrice;
                count++;
                break;
                case 'wreath':
                price+=wreathPrice;
                count++;
                break;
                case 'chocolate bunny': 
                price+=chocolateBunny;
                count++;
                break;                 
            }
            command=input.shift();
        }
        if(count%2==0){
            price*=0.80;
        }
        average+=price;
        console.log(`You purchased ${count} items for ${price.toFixed(2)} leva.`);
    }
    average=average/clients;
    console.log(`Average bill per client is: ${average.toFixed(2)} leva.`);
}
easterDecoration(["2", "basket", "wreath", "chocolate bunny", "Finish", "wreath", "chocolate bunny", "Finish"])