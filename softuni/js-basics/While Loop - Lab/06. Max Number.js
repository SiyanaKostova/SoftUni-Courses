function solve(input){
   let element=input[0];
   let index=0;
   let max=Number.MIN_SAFE_INTEGER;
   while(element!=='Stop'){
       let num=Number(element);
       if(num>max) {
           max=num;
       }
       element=input[index];
       index++;
   }
   console.log(max);
}
solve(["45",
"-20",
"7",
"99",
"Stop"])
