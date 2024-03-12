function validatePassword(password) {

    let isValid = true;

    if(password.length < 6 || password.length > 10) {
        isValid = false;
        console.log("Password must be between 6 and 10 characters");
    }

    if(password.match(/[^a-zA-Z0-9]+/g)) {
        isValid = false;
        console.log("Password must consist only of letters and digits"); 
    }

    if(!password.match(/(?=.*\d+.*\d+)/)){
        isValid = false;
        console.log("Password must have at least 2 digits");
    }
   
    if(isValid){
        console.log("Password is valid")
    }
}

validatePassword('logIn');
validatePassword('MyPass123');
validatePassword('Pa$s$s');