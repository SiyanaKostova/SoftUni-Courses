function solve(info)
{
  const commands = info.slice(1);
  const ridersAll = [];
 
  const input = info.slice(1, 1 + Number(info[0]));
 
  input.forEach((inputField) => {
    const [rider, fuelCapacity, position] = inputField.split("|");
    if(fuelCapacity > 100) {
      fuelCapacity = 100;
    }
    ridersAll.push({ rider, fuelCapacity: Number(fuelCapacity), position: Number(position) });
  })
 
  commands.forEach((task) => {
    const [command, ...rest] = task.split(" - ");
 
    if (command === 'StopForFuel') {
      StopForFuel(...rest);
    } else if (command === 'Overtaking') {
      Overtaking(...rest);
    } else if (command === 'EngineFail') {
      EngineFail(...rest);
    } else if (command === 'Finish') {
      ridersAll.sort((a, b) => a.position - b.position);
      ridersAll.forEach((rider) => {
        console.log(`${rider.rider}\n  Final position: ${rider.position}`);
      })
    }
  })
 
  function StopForFuel(nameOfRider, minCapOfFuel, newPosition) {
    const rider = ridersAll.find((r) => r.rider === nameOfRider);
    if (minCapOfFuel > rider.fuelCapacity) {
      console.log(`${nameOfRider} stopped to refuel but lost his position, now he is ${newPosition}.`);
      rider.position = Number(newPosition);
      return;
    } 
    console.log(`${nameOfRider} does not need to stop for fuel!`);
  }
 
  function Overtaking(riderOne, riderTwo) {
 
    const first = ridersAll.find((r) => r.rider === riderOne);
    const second = ridersAll.find((r) => r.rider === riderTwo);
 
    if ((Number(second.position) > Number(first.position))) {
 
      const tempor = Number(first.position);

    first.position = Number(second.position);
     second.position = tempor;
 
      console.log(`${first.rider} overtook ${second.rider}!`);
    }
  }
 
  function EngineFail(nameOfRider, leftLaps) {
    const rider = ridersAll.find((r) => r.rider === nameOfRider);
    console.log(`${nameOfRider} is out of the race because of a technical issue, ${leftLaps} laps before the finish.`);
    let indexOfRider = ridersAll.indexOf(rider);
    ridersAll.splice(indexOfRider, 1);
  }

  console.log(Number(true))
}
 
solve(["3",
"Valentino Rossi|100|1",
"Marc Marquez|90|2",
"Jorge Lorenzo|80|3",
"StopForFuel - Valentino Rossi - 50 - 1",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"])
 
solve(["4",
"Valentino Rossi|100|1",
"Marc Marquez|90|3",
"Jorge Lorenzo|80|4",
"Johann Zarco|80|2",
"StopForFuel - Johann Zarco - 90 - 5",
"Overtaking - Marc Marquez - Jorge Lorenzo",
"EngineFail - Marc Marquez - 10",
"Finish"]
)
 