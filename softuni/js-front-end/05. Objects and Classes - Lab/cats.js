function createCats(input) {

    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
        makeSound() {
            console.log(`${this.name}, age ${this.age} says Meow`)
        }
    }

    input.forEach(line => {
        const [name, age] = line.split(' ');
        const cat = new Cat(name, age);
        cat.makeSound();
    })
}

createCats(['Candy 1', 'Poppy 3', 'Nyx 2'])