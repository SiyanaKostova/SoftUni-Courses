function signCheck(first, second, third) {
    if (first >= 0 && second>=0 && third >= 0 || first <= 0 && second <= 0 && third >= 0 || first >= 0 && second <= 0 && third <= 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}

signCheck(5, 12, -15);
signCheck(-6, -12, 14);
signCheck(-1, -2, -3);