function csAdv(input){

    let typeFlower=input[0];
    let numFlowers=Number(input[1]);
    let budjet=Number(input[2]);

    let totalPrice=0.00;

            if (typeFlower=="Roses")
            {
                if (numFlowers > 80)
                {
                    totalPrice -= 5.00 * numFlowers * 0.10;
                }
                    totalPrice += 5.00 * numFlowers;
            }

            else if (typeFlower == "Dahlias")
            {
                
                if (numFlowers > 90)
                {
                    totalPrice -= 3.80 * numFlowers * 0.15;
                }
                    totalPrice += 3.80 * numFlowers;
            }

            else if (typeFlower == "Tulips")
            {
                if (numFlowers > 80)
                {
                    totalPrice -= 2.80 * numFlowers * 0.15;
                }
                    totalPrice += 2.80 * numFlowers;
            }

            else if (typeFlower == "Narcissus")
            {
                if (numFlowers < 120)
                {
                    totalPrice += 3.00 * numFlowers * 0.15;
                }
                    totalPrice += 3.00 * numFlowers;
            }

            else if (typeFlower == "Gladiolus")
            {
                if (numFlowers < 80)
                {
                    totalPrice += 2.50 * numFlowers * 0.20;
                }
                    totalPrice += 2.50 * numFlowers;
            }

            let left = Math.abs(budjet - totalPrice);
            
            if (totalPrice<=budjet)
            {
                console.log(`Hey, you have a great garden with ${numFlowers} ${typeFlower} and ${left.toFixed(2)} leva left.`)
            }
            else if (totalPrice>budjet)
            {
                console.log(`Not enough money, you need ${left.toFixed(2)} leva more.`)
            }
}
csAdv(["Narcissus",
"119",
"360"])

