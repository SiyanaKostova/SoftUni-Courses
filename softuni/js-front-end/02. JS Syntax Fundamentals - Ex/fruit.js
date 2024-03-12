function fruit(fruit, weight, price){
    const weightInKg = weight / 1000;
    const money = weightInKg * price;
    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`)
}

fruit('orange', 2500, 1.80);