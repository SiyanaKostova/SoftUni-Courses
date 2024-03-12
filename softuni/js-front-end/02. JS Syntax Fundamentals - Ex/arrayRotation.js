function arrayRotation(arr, rotationCount){
    for (let i = 0; i < rotationCount; i++) {
        const firstElement = arr.shift();
        arr.push(firstElement);
    }
    console.log(arr.join(' '));
}

arrayRotation([51, 47, 32, 61, 21], 2);