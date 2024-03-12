function vacation(count, type, day){

    let sum = 0;

    if (type == 'Students'){
        if (day === 'Friday') {
            sum = count * 8.45;
        } else if (day == 'Saturday'){
            sum = count * 9.80;
        } else if (day == 'Sunday'){
            sum = count * 10.46;
        }

        if (count >= 30){
            sum *= 0.85;
        }
    } else if (type == 'Business') {
        
        if (count >= 100){
            count -= 10;
        }

        if (day === 'Friday') {
            sum = count * 10.90;
        } else if (day == 'Saturday'){
            sum = count * 15.60;
        } else if (day == 'Sunday'){
            sum = count * 16;
        }
    } else if (type == 'Regular') {
        if (day === 'Friday') {
            sum = count * 15;
        } else if (day == 'Saturday'){
            sum = count * 20;
        } else if (day == 'Sunday'){
            sum = count * 22.50;
        }

        if (count >= 10 && count <= 20){
            sum *= 0.95;
        }
    }

    console.log(`Total price: ${sum.toFixed(2)}`);
}

vacation(30, "Students", "Sunday");
vacation(40, "Regular", "Saturday");