function sort(arr) {
    arr.sort((a, b) => a.localeCompare(b));
    
    for (let index = 0; index < arr.length; index++) {
      console.log(`${index + 1}.${arr[index]}`)
    }
}

sort(["John", 
"Bob", "Genoveva", "Zak",
"Christina", 
"Ema"])