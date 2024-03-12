const baseURL = 'http://localhost:3030/jsonstore/tasks/';

const divContainerToLoadTasks = document.querySelector('#list');

const addVacationButton = document.querySelector('#add-vacation');
const editVacationButton = document.querySelector('#edit-vacation');

const loadVacationButton = document.querySelector('#load-vacations');

let currentId = '';

loadVacationButton.addEventListener('click', loadVacation);

const nameInputElement = document.querySelector('#name');
const daysInputElement = document.querySelector('#num-days');
const dateInputElement = document.querySelector('#from-date');

addVacationButton.addEventListener('click', async () => {

    const name = nameInputElement.value;
    const days = daysInputElement.value;
    const date = dateInputElement.value;

    const vacationItem = {
        _id: currentId,
        name,
        days, 
        date
    }

    await fetch(baseURL, {
        method: 'POST',
        body: JSON.stringify(vacationItem)
    });

    nameInputElement.value = '';
    daysInputElement.value = '';
    dateInputElement.value = '';

    divContainerToLoadTasks.innerHTML = '';

    const response = await fetch(baseURL);
    const data = await response.json();
    const vacations = Object.values(data);

    for (const vacation of vacations) {
        const vacationElement = createVacation(vacation);
        vacationElement.setAttribute('vacation-id', vacation._id);
        divContainerToLoadTasks.appendChild(vacationElement);
    }
})

async function loadVacation() {
    divContainerToLoadTasks.innerHTML = '';

    const response = await fetch(baseURL);
    const data = await response.json();
    const vacations = Object.values(data);

    for (const vacation of vacations) {
        const vacationElement = createVacation(vacation);
        vacationElement.setAttribute('vacation-id', vacation._id);
        divContainerToLoadTasks.appendChild(vacationElement);
    }
}

function createVacation(vacation) {

    const containerVacations = document.createElement('div');
    containerVacations.className = 'container';

    const nameElement = document.createElement('h2');
    nameElement.textContent = vacation.name;

    const dateElement = document.createElement('h3');
    dateElement.textContent = vacation.date;

    const daysElement = document.createElement('h3');
    daysElement.textContent = vacation.days;

    const changeButton = document.createElement('button');
    changeButton.className = 'change-btn';
    changeButton.textContent = 'Change';

    const doneButton = document.createElement('button');
    doneButton.className = 'done-btn';
    doneButton.textContent = 'Done';

    containerVacations.appendChild(nameElement);
    containerVacations.appendChild(dateElement);
    containerVacations.appendChild(daysElement);
    containerVacations.appendChild(changeButton);
    containerVacations.appendChild(doneButton);

    changeButton.addEventListener('click', async () => {

        nameInputElement.value = vacation.name;
        daysInputElement.value = vacation.days;
        dateInputElement.value = vacation.date;

        divContainerToLoadTasks.removeChild(containerVacations);

        editVacationButton.disabled = false;
        addVacationButton.disabled = true;

        editVacationButton.addEventListener('click', async () => {
            currentId = containerVacations.getAttribute('vacation-id');

            const name = nameInputElement.value;
            const days = daysInputElement.value;
            const date = dateInputElement.value;

            const vacationItem = {
                _id: currentId,
                name,
                days, 
                date
            }
            
            await fetch(`${baseURL}${currentId}`, {
                 method: 'PUT',
                 body: JSON.stringify(vacationItem)
             });

             
            nameInputElement.value = '';
            daysInputElement.value = '';
            dateInputElement.value = '';

            divContainerToLoadTasks.innerHTML = '';

            const response = await fetch(baseURL);
            const data = await response.json();
            const vacations = Object.values(data);

            for (const vacation of vacations) {
                const vacationElement = createVacation(vacation);
                vacationElement.setAttribute('vacation-id', vacation._id);
                divContainerToLoadTasks.appendChild(vacationElement);
            }

            editVacationButton.disabled = true;
            addVacationButton.disabled = false;
        });

    })

    doneButton.addEventListener('click', async () => {

        currentId = containerVacations.getAttribute('vacation-id');
        console.log(currentId);

        await fetch(`${baseURL}${currentId}`, {
            method: 'DELETE'
        });

        divContainerToLoadTasks.removeChild(containerVacations);

        divContainerToLoadTasks.innerHTML = '';

        const response = await fetch(baseURL);
        const data = await response.json();
        const vacations = Object.values(data);

        for (const vacation of vacations) {
            const vacationElement = createVacation(vacation);
            vacationElement.setAttribute('vacation-id', vacation._id);
            divContainerToLoadTasks.appendChild(vacationElement);
        }
    })

    return containerVacations;
}