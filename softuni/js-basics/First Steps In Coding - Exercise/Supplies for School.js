function task(input){
    let panPack=Number(input[0]);
    let markersPack=Number(input[1]);
    let deteragent=Number(input[2]);
    let discount=Number(input[3]);
    
    let panPrice=panPack*5.80;
    let markersPrice=markersPack*7.20;
    let deteragentPrice=deteragent*1.20;
    let totalPrice=(panPrice+markersPrice+deteragentPrice)*((100-discount)/100);
    console.log(totalPrice)
}
task(["2 ",
"3 ",
"4 ",
"25 "]
);