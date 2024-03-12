const BASE_URL = `http://localhost:3030/jsonstore/grocery/`;

const loadButtonElement = document.querySelector('#load-product');
const addButtonelement = document.querySelector('#add-product');
const updateElement = document.querySelector('#update-product');
let currentId = '';

const loadFuncContainer = document.querySelector('#tbody');

const nameInputElement = document.querySelector('#product');
const countInputElement = document.querySelector('#count');
const priceInputElement = document.querySelector('#price');

loadButtonElement.addEventListener('click', loadInformation);
addButtonelement.addEventListener('click', addInformation);

async function addInformation(e) {
    e.preventDefault();

    const product = nameInputElement.value;
    const count = countInputElement.value;
    const price = priceInputElement.value;

    const productItem = {
        _id: currentId,
        product,
        count, 
        price
    }

    await fetch(BASE_URL, {
        method: 'POST',
        body: JSON.stringify(productItem)
    });

    nameInputElement.value = '';
    countInputElement.value = '';
    priceInputElement.value = '';

    loadFuncContainer.innerHTML = '';

    const response = await fetch(BASE_URL);
    const data = await response.json();
    const lists = Object.values(data);

    for (const list of lists) {
        const listElement = createList(list);
        loadFuncContainer.appendChild(listElement);
    }
}


async function loadInformation(e) {
    e.preventDefault();
    loadFuncContainer.innerHTML = '';

    const response = await fetch(BASE_URL);
    const data = await response.json();
    const lists = Object.values(data);

    for (const list of lists) {
        const listElement = createList(list);
        listElement.setAttribute('course-id', list._id);
        loadFuncContainer.appendChild(listElement);
    }
}

function createList(list) {
    const tableContainerElements = document.createElement('tr');

    const nameLoadElement = document.createElement('td');
    nameLoadElement.className = 'name';
    nameLoadElement.textContent = list.product;
    
    const countLoadElement = document.createElement('td');
    countLoadElement.className = 'count-product';
    countLoadElement.textContent = Number(list.count);

    const priceLoadElement = document.createElement('td');
    priceLoadElement.className = 'product-price';
    priceLoadElement.textContent = Number(list.price);

    const buttonsLoadElement = document.createElement('td');
    buttonsLoadElement.className = 'btn';

    const updateBtnElement = document.createElement('button');
    updateBtnElement.className = 'update';
    updateBtnElement.textContent = 'Update';

    const deleteBtnLoadElement = document.createElement('button');
    deleteBtnLoadElement.className = 'delete';
    deleteBtnLoadElement.textContent = 'Delete';

    buttonsLoadElement.appendChild(updateBtnElement);
    buttonsLoadElement.appendChild(deleteBtnLoadElement);

    tableContainerElements.appendChild(nameLoadElement);
    tableContainerElements.appendChild(countLoadElement);
    tableContainerElements.appendChild(priceLoadElement);
    tableContainerElements.appendChild(buttonsLoadElement);

    deleteBtnLoadElement.addEventListener('click', async(e) => {
        await fetch(`${BASE_URL}${list._id}`, {
            method: 'DELETE'
        });

        loadFuncContainer.innerHTML = '';

        const response = await fetch(BASE_URL);
        const data = await response.json();
        const lists = Object.values(data);
    
        for (const list of lists) {
            const listElement = createList(list);
            listElement.setAttribute('course-id', list._id);
            loadFuncContainer.appendChild(listElement);
        }
    });

    updateBtnElement.addEventListener('click', async(e) => {
        updateElement.disabled = false;

        nameInputElement.value = list.product;
        countInputElement.value = list.count;
        priceInputElement.value = list.price;



        updateElement.addEventListener('click', async (e) => {
            e.preventDefault();
    
            currentId = tableContainerElements.getAttribute('course-id');
            const product = nameInputElement.value;
            const count = countInputElement.value;
            const price = priceInputElement.value;
    
            const productItem = {
                _id: currentId,
                product,
                count, 
                price
            };
            
            console.log(currentId);
            
            await fetch(`${BASE_URL}${currentId}`, {
                method: 'PATCH',
                body: JSON.stringify(productItem)
            });

            nameInputElement.value = '';
            countInputElement.value = '';
            priceInputElement.value = '';
    
            loadFuncContainer.innerHTML = '';
    
            const response = await fetch(BASE_URL);
            const data = await response.json();
            const lists = Object.values(data);
        
            for (const list of lists) {
                const listElement = createList(list);
                listElement.setAttribute('course-id', list._id);
                loadFuncContainer.appendChild(listElement);
            }
        })
    });

    return tableContainerElements;
}