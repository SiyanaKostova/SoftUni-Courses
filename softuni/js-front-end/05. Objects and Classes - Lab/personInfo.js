function createPerson(firstName, lastName, age){

    const person = {};
    person.firstName = firstName;
    person.lastName = lastName;
    person.age = age;

    return person;
}

console.log(createPerson("Peter", "Pan", "20"));