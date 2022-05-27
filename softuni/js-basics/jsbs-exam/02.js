function second(input){

    let priceMaidenParty = Number(input.shift());
    let numLoveLetter=Number(input.shift());
    let numWaxRose=Number(input.shift());
    let numKeychain=Number(input.shift());
    let numCartoon=Number(input.shift());
    let numSurpriceGift=Number(input.shift());

    let loveLetterPrice=0.60*numLoveLetter;
    let waxRosePrice=7.20*numWaxRose;
    let keychainPrice=3.60*numKeychain;
    let cartoonPrice=18.20*numCartoon;
    let surpriceGiftPrice=22.00*numSurpriceGift;

    let allProducts=numLoveLetter+numWaxRose+numKeychain+numCartoon+numSurpriceGift;
    let allPrice=loveLetterPrice+waxRosePrice+keychainPrice+cartoonPrice+surpriceGiftPrice;

    if(allProducts>=25){
        allPrice*=0.65;
    }

    allPrice*=0.90;
    let diff=Math.abs(priceMaidenParty-allPrice);
    if(allPrice>=priceMaidenParty){
        console.log(`Yes! ${diff.toFixed(2)} lv left.`);
    } else {
        console.log(`Not enough money! ${diff.toFixed(2)} lv needed.`);
    }
}
second(["320","8",
"2",
"5",
"5",
"1"])

