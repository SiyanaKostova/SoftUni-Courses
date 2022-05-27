function solve(input){
   let name=input[0];
   let grade=1;
   let gradesSum=0;
   let excluded=0;
   let index=0;
   while(grade<=12){
       index++;
       let yearlyGrade=Number(input[index]);
       if(yearlyGrade<4.00){
           excluded++;
           if (excluded==2) {
               console.log(`${name} has been excluded at ${grade} grade`);
               break;
           }
           continue;
       }
       gradesSum+=yearlyGrade;  
       grade++;
   }
   let average=gradesSum/12;
   if (excluded<2) {
       console.log(`${name} graduated. Average grade: ${average.toFixed(2)}`);
   }
}
solve(["Mimi", 
"5",
"6",
"5",
"6",
"5",
"6",
"6",
"2",
"3"])

