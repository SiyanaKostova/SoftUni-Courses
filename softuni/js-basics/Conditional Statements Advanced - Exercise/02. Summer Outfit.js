function csAdv(input){

    let temperature=Number(input[0]);
    let time=input[1];

    let outfit='';
    let shoes='';

    if (temperature>=10&&temperature<=18) {
        if (time=='Morning') {
            outfit='Sweatshirt';
            shoes='Sneakers'
        } else if (time=='Afternoon') {
            outfit='Shirt';
            shoes='Moccasins';
        } else if (time=='Evening') {
            outfit='Shirt';
            shoes='Moccasins';
        }
    } 

    else if (temperature>18&&temperature<=24) {
        if (time=='Morning') {
            outfit='Shirt';
            shoes='Moccasins';
        } else if (time=='Afternoon') {
            outfit='T-Shirt';
            shoes='Sandals';
        } else if (time=='Evening') {
            outfit='Shirt';
            shoes='Moccasins';
        }
    } 

    else if (temperature>=25) {
        if (time=='Morning') {
            outfit='T-Shirt';
            shoes='Sandals';
        } else if (time=='Afternoon') {
            outfit='Swim Suit';
            shoes='Barefoot';
        } else if (time=='Evening') {
            outfit='Shirt';
            shoes='Moccasins';
        }
    }

    console.log(`It's ${temperature} degrees, get your ${outfit} and ${shoes}.`)
}
csAdv(["16",
"Morning"])
