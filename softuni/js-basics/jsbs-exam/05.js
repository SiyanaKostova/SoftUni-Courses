function fifth(input){

    let Break = input.shift();
    let Meters = Number(input.shift());
    let counterDays = 1;
    let metersFromStart = 5364;
    let peak = 8848;

    while (Break != "END")
    {

        if (Break == "Yes")
        {
            counterDays++;
            metersFromStart += Meters;
        }
        else if (Break == "No")
        {
            metersFromStart += Meters;
        }
        if (counterDays > 5 && metersFromStart < peak)
        {
            console.log(`Failed!`);
            console.log(`${metersFromStart - Meters}`)
            break;
        }
        else if (counterDays > 5 && metersFromStart >= peak)
        {
            console.log(`Goal reached for ${counterDays} days!`);
        }
        if (peak <= metersFromStart)
        {
            console.log(`Goal reached for ${counterDays} days!`)
            break;
        }

        Break = input.shift();

        if (Break == "END")
        {
            console.log('Failed!');
            console.log(`${metersFromStart}`);
            break;
        }

        Meters = Number(input.shift());
    }
}
fifth(["Yes",
"1254",
"Yes",
"1402",
"No",
"250",
"Yes",
"635"])
