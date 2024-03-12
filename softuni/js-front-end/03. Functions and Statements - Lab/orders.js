function order(product, quantity) {

    let price = 0;
    switch(product){
        case 'water':
        price = quantity * 1.00;
        break;
        case 'coffee':
            price = quantity * 1.50;
            break;
        case 'coke':
        price = quantity * 1.40;
        break;
        case 'snacks':
        price = quantity * 2.00;
        break;
    }
    console.log(price.toFixed(2));
}

order("water", 5 );
order("coffee", 2 );