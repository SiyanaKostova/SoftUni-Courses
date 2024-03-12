const BASE_URL = "http://localhost:3030/jsonstore/tasks/";
const loadButton = document.querySelector("#load-board-btn");
const addButton = document.querySelector("#create-task-btn");
const inputTitle = document.querySelector("#title");
const textareaDescription = document.querySelector("#description");

const sections = {
  ToDo: "todo-section",
  "In Progress": "in-progress-section",
  "Code Review": "code-review-section",
  Done: "done-section",
};

let taskLists = Array.from(document.querySelectorAll(".task-list"));

const statusButtons = {
  ToDo: "Move to In Progress",
  "In Progress": "Move to Code Review",
  "Code Review": "Move to Done",
  Done: "Close",
};

function attachEvents() {
  loadButton.addEventListener("click", loadTasksHandler);
  addButton.addEventListener("click", addTask);
}

function loadTasksHandler() {
  taskLists.forEach((ul) => {ul.innerHTML = "";});
  fetch(BASE_URL)
    .then((res) => res.json())
    .then((list) => {
      Object.values(list).forEach(({ title, description, status, _id }) => {
        let ul = document.querySelector(`#${sections[status]} > .task-list`);
        let liItem = createElement("li", "", ul);
        liItem.className = "task";
        let h3Item = createElement("h3", title, liItem);

        let pItem = createElement("p", description, liItem);

        const button = createElement("button", `${statusButtons[status]}`, liItem);
        button.id = _id;

        button.addEventListener("click", moveTask);
      });
    });
}
function moveTask(e) {
  if (e.target.textContent === "Close") {
    const id = e.target.id;
    console.log(id);
    const headers = {
      method: "DELETE",
    };

    fetch(BASE_URL + `${id}`, headers).then(() => loadTasksHandler());
  } else {
    const newStatus = e.target.textContent.replace("Move to ", "");
    const headers = {
      method: "PATCH",
      body: JSON.stringify({ status: newStatus }),
    };

    fetch(BASE_URL + `${e.target.id}`, headers).then(() => loadTasksHandler(e));
  }
}

function addTask(event) {
  const headers = {
    method: "POST",
    body: JSON.stringify({
      title: inputTitle.value,
      description: textareaDescription.value,
      status: "ToDo",
    }),
  };
  fetch(BASE_URL, headers).then(() => loadTasksHandler(event));
  inputTitle.value = "";
  textareaDescription.value = "";
}
function createElement(elementTag, value, parent) {
  const newElement = document.createElement(elementTag);
  newElement.innerHTML = value;
  if (parent) {
    parent.appendChild(newElement);
  }

  return newElement;
}
attachEvents();