function conditions(input){
   let name=input[0];
   let durationOfEp=Number(input[1]);
   let durationOfBreak=Number(input[2]);

   let timeForLunch=durationOfBreak/8;
   let timeForRest=durationOfBreak/4;

   let timeForEp=durationOfBreak-(timeForRest+timeForLunch);
   let diff=Math.abs(timeForEp-durationOfEp);

   if (timeForEp>=durationOfEp) {
       console.log(`You have enough time to watch ${name} and left with ${Math.ceil(diff)} minutes free time.`);
   } else {
       console.log(`You don't have enough time to watch ${name}, you need ${Math.ceil(diff)} more minutes.`);
   }
}
conditions(["Game of Thrones",
"60",
"96"])



