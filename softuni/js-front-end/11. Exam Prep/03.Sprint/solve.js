function attachEvents() {

    const base_URL = 'http://localhost:3030/jsonstore/tasks/';
  
    const sections = {
        ToDo: "todo-section",
        "In Progress": "in-progress-section",
        "Code Review": "code-review-section",
        Done: "done-section",
    };

    const taskListElement = Array.from(document.querySelectorAll('.task-list'));
    let currentId = '';

    const loadButtonElement = document.querySelector('#load-board-btn');
    const addButtonElement = document.querySelector('#create-task-btn');

    loadButtonElement.addEventListener('click', loadInformation);

    const titleInputElement = document.querySelector('#title');
    const descInputElement = document.querySelector('#description');

    addButtonElement.addEventListener('click', async (e) => {

        const title = titleInputElement.value;
        const description = descInputElement.value;
        
        const taskElement = {
            title,
            description, 
            status: 'ToDo',
            _id: currentId
        }
        await fetch(base_URL, {
            method: 'POST',
            body: JSON.stringify(taskElement)
        });
    
        titleInputElement.value = '';
        descInputElement.value = '';
    
        taskListElement.forEach((el) => {el.innerHTML = ''});
    
        const response = await fetch(base_URL);
        const data = await response.json();
        const tasks = Object.values(data);
    
        for (const task of tasks) {
            let ul = document.querySelector(`#${sections[task.status]} > .task-list`);
            const taskElement = createTask(task);
            taskElement.setAttribute('task-id', task._id);
            ul.appendChild(taskElement);
        }
    })

    async function loadInformation() {

        taskListElement.forEach((el) => {el.innerHTML = ''});

        const response = await fetch(base_URL);
        const data = await response.json();
        const tasks = Object.values(data);
    
        for (const task of tasks) {
            let ul = document.querySelector(`#${sections[task.status]} > .task-list`);
            const taskElement = createTask(task);
            taskElement.setAttribute('task-id', task._id);
            ul.appendChild(taskElement);
        }
    }

    function createTask(task) {

        const taskLiElement = document.createElement('li');
        taskLiElement.className = 'task';

        const nameElement = document.createElement('h3');
        nameElement.textContent = task.title;

        const descElement = document.createElement('p');
        descElement.textContent = task.description;

        const buttonTaskElement = document.createElement('button');

         if (task.status === 'ToDo') {
            buttonTaskElement.textContent = 'Move to In Progress';
        } else if (task.status === 'In Progress') {
            buttonTaskElement.textContent = 'Move to Code Review';
        } else if (task.status === 'Code Review') {
            buttonTaskElement.textContent = 'Move to Done';
        } else if (task.status === 'Done') {
            buttonTaskElement.textContent = 'Close';
        }

        taskLiElement.appendChild(nameElement);
        taskLiElement.appendChild(descElement);
        taskLiElement.appendChild(buttonTaskElement);

        buttonTaskElement.addEventListener('click', async (e) => {
            
            currentId = taskLiElement.getAttribute('task-id');

            if (e.target.textContent === 'Move to In Progress') {
                e.target.textContent.replace('Move to Code Review', 'Move to In Progress');
                await fetch((`${base_URL}${currentId}`), {
                    method: 'PATCH',
                    body: JSON.stringify({status: 'In Progress'})
                });
    
            }
            if (e.target.textContent === 'Move to Code Review') {
                e.target.textContent.replace('Move to Done', 'Move to Code Review');
                await fetch((`${base_URL}${currentId}`), {
                    method: 'PATCH',
                    body: JSON.stringify({status: 'Code Review'})
                });
    
            }
            if (e.target.textContent === 'Move to Done') {
                e.target.textContent.replace('Close', 'Move to Done');
                await fetch((`${base_URL}${currentId}`), {
                    method: 'PATCH',
                    body: JSON.stringify({status: 'Done'})
                });
    
            }
            if(e.target.textContent === 'Close') {
                await fetch(`${base_URL}${currentId}`, {
                    method: 'DELETE'
                });
            }

            taskListElement.forEach((el) => {el.innerHTML = ''});

            const response = await fetch(base_URL);
            const data = await response.json();
            const tasks = Object.values(data);
        
            for (const task of tasks) {
                let ul = document.querySelector(`#${sections[task.status]} > .task-list`);
                const taskElement = createTask(task);
                taskElement.setAttribute('task-id', task._id);
                ul.appendChild(taskElement);
            }
            })

        return taskLiElement;
    }

}

attachEvents();