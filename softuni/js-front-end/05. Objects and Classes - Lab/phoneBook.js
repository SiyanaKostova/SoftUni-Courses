function phoneBook(input) {
    let phoneBook = {};

    for(let line of input){
        let tokens = line.split(' ');
        let name = tokens[0];
        let number = tokens[1];
        phoneBook[name] = number;
    }

    Object.keys(phoneBook).forEach(key => {console.log(`${key} -> ${phoneBook[key]}`)});
}

phoneBook(['George 0552554',
'Peter 087587',
'George 0453112',
'Bill 0845344'])