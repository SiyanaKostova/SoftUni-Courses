function refineCrystal(input) {
    const [target, ...chunks] = input;
  
    const canCut = (chunk) => chunk / 4 >= target;
    const cut = (chunk) => chunk / 4;
    const lap = (chunk) => chunk - chunk * 0.2;
    const grind = (chunk) => chunk - 20;
    const etch = (chunk) => chunk - 2;
    const xRay = (chunk) => chunk + 1;
  
    const operations = [lap, grind, etch];
  
    for (let chunk of chunks) {
      console.log(`Processing chunk ${chunk} microns`);
  
      while (chunk > target) {
        if (canCut(chunk)) {
          let counter = 0;
  
          while (canCut(chunk)) {
            chunk = cut(chunk);
            counter++;
          } 
          console.log(`Cut x${counter}`);
          chunk = washChunk(chunk);
        }
  
        for (const operation of operations) {
          if (operation(chunk) >= target) {
            let counter = 0;
  
            while (operation !== etch ? operation(chunk) >= target : operation(chunk) >= target - 1) {
              chunk = operation(chunk);
              counter++;
            }
  
            let capitalized = operation.name.charAt(0).toUpperCase() + operation.name.slice(1);
  
            console.log(`${capitalized} x${counter}`);
            chunk = washChunk(chunk);
          }
        }
      }
  
      if (xRay(chunk) === target) {
        chunk = xRay(chunk);
        console.log("X-ray x1");
      }
  
      console.log(`Finished crystal ${target} microns`);
    }
  
    function washChunk(chunk) {
      console.log("Transporting and washing");
      return Math.floor(chunk);
    }
  }
  
  refineCrystal([1375, 50000]);