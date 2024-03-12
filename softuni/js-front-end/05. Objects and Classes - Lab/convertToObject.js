function convertToObject(person) {
    Object.entries(JSON.parse(person)).forEach(pair => {console.log((`${pair[0]}: ${pair[1]}`))});
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');