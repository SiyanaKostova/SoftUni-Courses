function demo(input){
    let firstName=input[0];
    let SecondName=input[1];
    let age=Number(input[2]);
    let town=input[3];
    console.log(`You are ${firstName} ${SecondName}, a ${age}-years old person from ${town}.`)
     }
     
     demo(['Maria', 'Ivanova', 20, 'Sofia'])