function specialNumbers(input){
    let num=Number(input.shift());
    let a=1;
    let b=0;
    let spec=true;
    for (let first = 1111; first <= 9999; first++) {
        a=first;
        while (a!=0) {
            b=a%10;
            if (b==0) {
                spec=false;
                break;
            }
            else if (num%b==0) {
                a/=10;
 
            }
 
            else{
                spec=false;
                break;
            }
            a.toFixed(0);
            spec=true;
        }
    }
}
specialNumbers(["3"])
