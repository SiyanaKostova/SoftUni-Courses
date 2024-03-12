function sortAdresses(input) {
    const adresses = input.reduce((acc, curr) => {
        const [name, adress] = curr.split(':');
        acc[name] = adress;
        return acc;
    }, {});
    Object.keys(adresses).sort((a, b) => a.localeCompare(b)).forEach((key) => {console.log(key + ' -> ' + adresses[key])});
}

sortAdresses(['Bob:Huxley Rd',
'John:Milwaukee Crossing',
'Peter:Fordem Ave',
'Bob:Redwing Ave',
'George:Mesta Crossing',
'Ted:Gateway Way',
'Bill:Gateway Way',
'John:Grover Rd',
'Peter:Huxley Rd',
'Jeff:Gateway Way',
'Jeff:Huxley Rd']);