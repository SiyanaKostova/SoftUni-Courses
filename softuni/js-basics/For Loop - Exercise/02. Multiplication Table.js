function loops(input){
    let num=Number(input[0]);
    for (let i = 1; i < 11; i++) {
        console.log(`${i} * ${num} = ${i*num}`);
    }
}
loops(["5"])