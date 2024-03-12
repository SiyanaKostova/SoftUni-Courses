function cafeteria(input) {
    let coffees = {};
 
    function makeCoffee(nameOfBarista, shift, coffeeType) {
      if (coffees[nameOfBarista]) {
        if (coffees[nameOfBarista].shift === shift){
        const drinks = coffees[nameOfBarista].drinks;
        if (drinks.includes(coffeeType)) {
          console.log(`${nameOfBarista} has prepared a ${coffeeType} for you!`);
        } else {
          console.log(`${nameOfBarista} is not available to prepare a ${coffeeType}.`);
        }
      } else {
        console.log(`${nameOfBarista} is not available to prepare a ${coffeeType}.`);
      }
    }
    }
 
    function replaceShift(nameOfBarista, newShift) {
      coffees[nameOfBarista].shift = newShift;
      console.log(`${nameOfBarista} has updated his shift to: ${newShift}`);
    }
 
    function learnType(nameOfBarista, newCoffeeType) {
      const drinks = coffees[nameOfBarista].drinks;
      if (drinks.includes(newCoffeeType)) {
        console.log(`${nameOfBarista} knows how to make ${newCoffeeType}.`);
      } else {
        drinks.push(newCoffeeType);
        console.log(`${nameOfBarista} has learned a new coffee type: ${newCoffeeType}.`);
      }
    }
 
    const n = Number(input[0]);
    for (let i = 1; i <= n; i++) {
      const [name, shift, drinks] = input[i].split(' ');
      coffees[name] = { shift, drinks: drinks.split(',') };
    }
 
    for (let i = n + 1; i < input.length; i++) {
      const [action, nameOfBarista, param1, param2] = input[i].split(' / ');
 
      switch (action) {
        case 'Prepare':
          makeCoffee(nameOfBarista, param1, param2);
          break;
        case 'Change Shift':
          replaceShift(nameOfBarista, param1);
          break;
        case 'Learn':
          learnType(nameOfBarista, param1);
          break;
      }
    }
 
    for (const nameOfBarista in coffees) {
      const { shift, drinks } = coffees[nameOfBarista];
      console.log(`Barista: ${nameOfBarista}, Shift: ${shift}, Drinks: ${drinks.join(', ')}`);
    }
  }

  cafeteria([
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed'
  ]);
  cafeteria([
    '4',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'David night Espresso',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / day',
    'Learn / Carol / Latte',
    'Prepare / Bob / night / Latte',
    'Learn / David / Cappuccino',
    'Prepare / Carol / day / Cappuccino',
    'Change Shift / Alice / night',
    'Learn / Bob / Mocha',
    'Prepare / David / night / Espresso',
    'Closed'
  ]);