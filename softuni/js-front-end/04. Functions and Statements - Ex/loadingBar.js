function printLoadingBar(percentage) {

    const percentageNumber = percentage / 10;
    const bar = '%'.repeat(percentageNumber) + '.'.repeat(10 - percentageNumber);

    console.log(percentage === 100 ? `100% Complete!\n[${bar}]` : `${percentage}% [${bar}]\nStill loading...`);
}

printLoadingBar(30);
printLoadingBar(50);
printLoadingBar(100);
