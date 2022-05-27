function easterTrip(input) {

    let destination = input.shift();
    let dates = input.shift();
    let numNights = Number(input.shift());
    let priceNight = 0;

    switch (destination) {

        case 'France':
            switch (dates) {
                case '21-23':
                    priceNight = 30;
                    break;
                case '24-27':
                    priceNight = 35;
                    break;
                case '28-31':
                    priceNight=40;
                    break;
            }
        break;

        case 'Italy':
            switch (dates) {
                case '21-23':
                    priceNight = 28;
                    break;
                case '24-27':
                    priceNight = 32;
                    break;
                case '28-31':
                    priceNight=39;
                    break;
            }
        break;

        case 'Germany':
            switch (dates) {
                case '21-23':
                    priceNight = 32;
                    break;
                case '24-27':
                    priceNight = 37;
                    break;
                case '28-31':
                    priceNight=43;
                    break;
            }
        break;
    }
    let all=numNights*priceNight;
    console.log(`Easter trip to ${destination} : ${all.toFixed(2)} leva.`);

}
easterTrip(["Germany","24-27","5"])