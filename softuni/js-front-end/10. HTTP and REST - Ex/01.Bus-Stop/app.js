async function getInfo() {
    const busStopId = document.querySelector('#stopId').value;
    const list = document.querySelector('ul');
    const stopName = document.querySelector('#stopName');
    list.innerHTML = "";

    const service = {
        busInfoURL: (ID) => `http://localhost:3030/jsonstore/bus/businfo/${ID}`
    };

    let busStopInfo;

    try {
        const response = await fetch(service.busInfoURL(busStopId));
        busStopInfo = await response.json();
    } catch (_) {
        stopName.textContent = 'Error';
        return;
    }

    stopName.textContent = busStopInfo.name;

    Object.entries(busStopInfo.buses).map(([busNumber, timeInMinutes]) => {
        const item = document.createElement('li');
        item.textContent = `Bus ${busNumber} arrives in ${timeInMinutes} minutes`;

        list.appendChild(item);
    });
}