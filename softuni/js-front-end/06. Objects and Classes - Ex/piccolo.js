function piccolo(parkingLot) {

    class Parking {
      constructor() {
        this.cars = new Set();
      }
      enter(carNumber) {
        this.cars.add(carNumber);
      }
      exit(carNumber) {
        this.cars.delete(carNumber);
      }
      printCars() {
        this.cars.size === 0
          ? console.log("Parking Lot is Empty")
          : Array.from(this.cars)
              .sort()
              .forEach((carNumber) => {
                console.log(carNumber);
              });
      }
    }
    const parking = new Parking();
  
    parkingLot.forEach((entry) => {
      const [direction, carNumber] = entry.split(", ");
      direction === "IN" ? parking.enter(carNumber) : parking.exit(carNumber);
    });
  
    parking.printCars();
    
}
piccolo(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU'])