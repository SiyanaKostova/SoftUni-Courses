function inventory(input) {
    class Hero {
        constructor(name, level, items) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
            printHero() {
                console.log(`Hero: ${this.name}`);
                console.log(`level => ${this.level}`);
                console.log(`items => ${this.items.join(', ')}`);
            }
        }
        
        const heroes = input.reduce((acc, curr) => {
            const [name, level, items] = curr.split(' / ');
            const hero = new Hero(name, Number(level), items.split(', '));
            acc.push(hero);
            return acc;
        }, []).sort((a, b) => a.level - b.level)
        .forEach((h) => h.printHero());
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ])