function solve(commands) {

    const carWash = {
        soap: (cleanPercentage) => cleanPercentage + 10,
        water: (cleanPercentage) => cleanPercentage + cleanPercentage * 0.2,
        "vacuum cleaner": (cleanPercentage) =>
          cleanPercentage + cleanPercentage * 0.25,
        mud: (cleanPercentage) => cleanPercentage - cle,
      };

    let cleanPercentage = 0;
  
    for (let i = 0; i < commands.length; i++) {
      const command = commands[i];
  
      if (command === "soap") {
        cleanPercentage += 10;
      } else if (command === "water") {
        cleanPercentage += cleanPercentage * 0.2;
      } else if (command === "vacuum cleaner") {
        cleanPercentage += cleanPercentage * 0.25;
      } else if (command === "mud") {
        cleanPercentage -= cleanPercentage * 0.1;
      }
    }

    console.log( `The car is ${cleanPercentage.toFixed(2)}% clean.`);
}
  
solve(["soap", "soap", "vacuum cleaner", "mud", "soap", "water"]);