function loops(input){
    let index=0;
    let openTabs=Number(input[index]);
    index++;
    let currentSalary=Number(input[index]);
    index++;

    let isIt=true;
   
    for (let i = 1; i <= openTabs ; i++) {
        let nameOfWebsite=input[index];
        index++;
        if (nameOfWebsite=='Facebook') {
            currentSalary-=150;
        } else if (nameOfWebsite=='Instagram') {
            currentSalary-=100;
        } else if (nameOfWebsite=='Reddit') {
            currentSalary-=50;
        }
        if (currentSalary<=0) {
            console.log("You have lost your salary.");
            isIt=false;
            break;
        } 
    }
    if(isIt){
        console.log(Math.trunc(currentSalary));
    }
}
loops(["10",
"750",
"Facebook",
"Dev.bg",
"Instagram",
"Facebook",
"Reddit",
"Facebook",
"Facebook"])

