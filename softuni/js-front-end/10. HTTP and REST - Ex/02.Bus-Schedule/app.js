function solve() {

    const departButton = document.querySelector('#depart');
    const arriveButton = document.querySelector('#arrive');
    const busInfoBox = document.querySelector('#info .info');

    let busStopInfo = {
        name: '',
        next: 'depot'
    };

    function updateStopInfo(departButtonState, arriveButtonState, textContent){
        departButton.disabled = departButtonState;
        arriveButton.disabled = arriveButtonState;
        busInfoBox.textContent = textContent;
    }


    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${busStopInfo.next}`)
        .then((res) => res.json())
        .then((busStop) => {
            busStopInfo = busStop;
            updateStopInfo(true, false, `Next stop ${busStopInfo.name}`);
        })
        .catch(() => {
            updateStopInfo(true, true, 'Error');
        })
    }

    async function arrive() {
        updateStopInfo(false, true, `Arriving at ${busStopInfo.name}`);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();