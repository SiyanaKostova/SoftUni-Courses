function attachEvents() {
  const baseURL = 'http://localhost:3030/jsonstore/tasks/';

  const titleInputElement = document.querySelector('#title');
  const addInputButtonElement = document.querySelector('#add-button');
  const loadALLButtonInputElement = document.querySelector('#load-button');

  loadALLButtonInputElement.addEventListener('click', loadElements);
  const tasksListElement = document.querySelector('#todo-list');

  let currentId = '';

async function loadElements(e) {
    
    e.preventDefault();

    tasksListElement.innerHTML = '';
    const response = await fetch(baseURL);
    const data = await response.json();
    const tasks = Object.values(data);

    for (const task of tasks) {
        const taskElement = createTask(task);
        taskElement.setAttribute('task-id', task._id);
        tasksListElement.appendChild(taskElement);
    }
}

function createTask(task) {

    const tasksLiContainer = document.createElement('li');

    const taskName = document.createElement('span');
    taskName.textContent = task.name;

    const taskRemoveButton = document.createElement('button');
    taskRemoveButton.textContent = 'Remove';

    const taskEditButton = document.createElement('button');
    taskEditButton.textContent = 'Edit';

    tasksLiContainer.appendChild(taskName);
    tasksLiContainer.appendChild(taskRemoveButton);
    tasksLiContainer.appendChild(taskEditButton);

    taskEditButton.addEventListener('click', async(e) => {
        const taskNameAsInput = document.createElement('input');
        taskNameAsInput.value = task.name;
        taskNameAsInput.textContent = task.name;

        const taskSubmitButton = document.createElement('button');
        taskSubmitButton.textContent = 'Submit';

        tasksLiContainer.replaceChild(taskNameAsInput, taskName);
        tasksLiContainer.replaceChild(taskSubmitButton, taskEditButton);

        taskSubmitButton.addEventListener('click', async (e) => {

            currentId = tasksLiContainer.getAttribute('task-id');
            const name = taskNameAsInput.value;

               
            const taskItem = {
                name,
                _id: currentId
            }
            
            await fetch(`${baseURL}${currentId}`, {
                 method: 'PATCH',
                 body: JSON.stringify(taskItem)
             });

             tasksListElement.innerHTML = '';
             const response = await fetch(baseURL);
             const data = await response.json();
             const tasks = Object.values(data);
         
             for (const task of tasks) {
                 const taskElement = createTask(task);
                 taskElement.setAttribute('task-id', task._id);
                 tasksListElement.appendChild(taskElement);
             }
        })
    })

    taskRemoveButton.addEventListener('click', async (e) => {
        await fetch(`${baseURL}${task._id}`, {
            method: 'DELETE'
        });

        tasksListElement.innerHTML = '';
        const response = await fetch(baseURL);
        const data = await response.json();
        const tasks = Object.values(data);
    
        for (const task of tasks) {
            const taskElement = createTask(task);
            taskElement.setAttribute('task-id', task._id);
            tasksListElement.appendChild(taskElement);
        }
    });

    return tasksLiContainer;
}

addInputButtonElement.addEventListener('click', async (e) => {
    e.preventDefault();

    const name = titleInputElement.value;
    
    const taskItem = {
        name,
        _id: currentId
    }
    
    await fetch(baseURL, {
        method: 'POST',
        body: JSON.stringify(taskItem)
    });

    titleInputElement.value = '';

    tasksListElement.innerHTML = '';
    const response = await fetch(baseURL);
    const data = await response.json();
    const tasks = Object.values(data);

    for (const task of tasks) {
        const taskElement = createTask(task);
        taskElement.setAttribute('task-id', task._id);
        tasksListElement.appendChild(taskElement);
    }
})
}

attachEvents();
