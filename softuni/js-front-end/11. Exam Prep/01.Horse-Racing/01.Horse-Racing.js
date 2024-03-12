function solve(input) {

    const horses = input.shift().split('|');
    
    let line = input.shift();

    while (line !== 'Finish') {
        const commandArr = line.split(' ');
        const command = commandArr[0];
        const firstHorse = commandArr[1];
        const secondHorse = commandArr[2];

        let firstHorsePosition = horses.indexOf(firstHorse);

        switch(command) {
            case 'Retake':             
                let secondHorsePosition = horses.indexOf(secondHorse);

                if (firstHorsePosition < secondHorsePosition) {
                    horses[firstHorsePosition] = secondHorse;
                    horses[secondHorsePosition] = firstHorse;

                    console.log(`${firstHorse} retakes ${secondHorse}.`);
                } 
                break;
            case 'Trouble':
                if (firstHorsePosition > 0) {
                    horses[firstHorsePosition] = horses[firstHorsePosition - 1];
                    horses[firstHorsePosition - 1] = firstHorse;

                    console.log(`Trouble for ${firstHorse} - drops one position.`)
                }
                break;
            case 'Rage':
                if (firstHorsePosition === horses.length - 2) {
                    horses[horses.length - 2] = horses[horses.length - 1];
                    horses[horses.length - 1] = firstHorse;
                    console.log(`${firstHorse} rages 2 positions ahead.`)
                } else if (firstHorsePosition < horses.length - 1) {
                    horses[firstHorsePosition] = horses[firstHorsePosition + 1];
                    horses[firstHorsePosition + 1] = horses[firstHorsePosition + 2];
                    horses[firstHorsePosition + 2] = firstHorse;
                    console.log(`${firstHorse} rages 2 positions ahead.`)
                } else {
                    console.log(`${firstHorse} rages 2 positions ahead.`)
                }

                break;
            case 'Miracle':
                const lastHorse = horses.shift();
                horses.push(lastHorse);
                console.log(`What a miracle - ${lastHorse} becomes first.`)
                break;
        }

        line = input.shift();
    }

    console.log(horses.join('->'));
    console.log(`The winner is: ${horses.pop()}`);
}

solve((['Bella|Alexia|Sugar', 'Retake Alexia Sugar', 'Rage Bella', 'Trouble Bella', 'Finish']));
solve((['Onyx|Domino|Sugar|Fiona', 'Trouble Onyx', 'Retake Onyx Sugar', 'Rage Domino', 'Miracle', 'Finish']));
solve((['Fancy|Lilly', 'Retake Lilly Fancy', 'Trouble Lilly', 'Trouble Lilly', 'Finish', 'Rage Lilly']));