function subtract() {
    const firstNumber = Number(document.querySelector('#firstNumber').value);
    const secondNumber = Number(document.querySelector('#secondNumber').value);
    const sum = firstNumber - secondNumber;
    const result = document.querySelector('#result');
    result.textContent = sum;
}