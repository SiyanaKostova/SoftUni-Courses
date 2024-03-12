function findPalindrome(numbers) {

    for(const number of numbers){
        let array = number.toString().split('');

        array.length % 2 === 0 ? console.log(check(0, array)) : console.log(check(1, array));
    }

    function check(len, array) {
        let first = 0;
        let second = 0;

        while (array.length > len && first === second) {
            first = Number(array.pop());
            second = Number(array.shift());
        }

        if (first !== second) {
            return false;
        } else if (first === second && array.length === len) {
            return true;
        }
    }
}

findPalindrome([123,323,421,121]);