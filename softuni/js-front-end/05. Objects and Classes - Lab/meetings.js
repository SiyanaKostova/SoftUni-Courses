function schedule(input) {
    const schedule = input.reduce((acc, curr) => {
        const [day, name] = curr.split(' ');

        if (acc.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        } else {
            acc[day] = name;
            console.log(`Scheduled for ${day}`);
        }
        return acc;
    }, {});

    Object.keys(schedule).forEach(key => {console.log(key + ' -> ' + schedule[key])});
}

schedule(['Friday Bob',
'Saturday Ted',
'Monday Bill',
'Monday John',
'Wednesday George'])