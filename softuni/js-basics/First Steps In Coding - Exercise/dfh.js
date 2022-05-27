function task(input){
    let numChickenMenus=Number(input[0]);
    let numFishMenus=Number(input[1]);
    let numVegMenus=Number(input[2]);

    let chickenMenuPrice=10.35*numChickenMenus;
    let fishMenuPrice=12.40*numFishMenus;
    let vegMenuPrice=8.15*numVegMenus;

    let totalMenusPrice=chickenMenuPrice+fishMenuPrice+vegMenuPrice;
    let dessertPrice=0.2*totalMenusPrice;
    let delivery=2.50;
    let total=totalMenusPrice+dessertPrice+delivery;

    console.log(total);
}
task(["2 ",
"4 ",
"3 "]
);