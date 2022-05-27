function basketballEquipment(input){
    let annualFee=Number(input[0]);
    let sneakers=annualFee*0.60;
    let clothing=sneakers*0.80;
    let ball=clothing/4;
    let accessories=ball/5;

    let total=annualFee+sneakers+clothing+ball+accessories;
    console.log(total);
}
basketballEquipment(["365"])