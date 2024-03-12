window.addEventListener("load", solve);

function solve() {

  const publishButton = document.querySelector('#publish-btn');

  publishButton.addEventListener('click', (event) => {
    const titleElement = document.querySelector('#task-title');
    const categoryElement = document.querySelector('#task-category');
    const contentElement = document.querySelector('#task-content');

    const title = titleElement.value;
    const category = categoryElement.value;
    const content = contentElement.value;

    if (!title || !category || !content) {
        return;
    }

    const titleHeaderElement = document.createElement('h4');
    titleHeaderElement.textContent = title;

    const categoryParElement = document.createElement('p');
    categoryParElement.textContent = `Category: ${category}`;

    const contentParElement = document.createElement('p');
    contentParElement.textContent = `Content: ${content}`;

    const articleElement = document.createElement('article');
    articleElement.appendChild(titleHeaderElement);
    articleElement.appendChild(categoryParElement);
    articleElement.appendChild(contentParElement);

    const buttonElement = document.createElement('button');
    buttonElement.classList.add('action-btn');

    const buttonEditElement = buttonElement.cloneNode();
    buttonEditElement.classList.add('edit');
    buttonEditElement.textContent = 'Edit';

    const buttonPostElement = buttonElement.cloneNode();
    buttonPostElement.classList.add('post');
    buttonPostElement.textContent = 'Post';

    const listItemElement = document.createElement('li');
    listItemElement.className = 'rpost';
    listItemElement.appendChild(articleElement);
    listItemElement.appendChild(buttonEditElement);
    listItemElement.appendChild(buttonPostElement);

    const reviewListElement = document.querySelector('#review-list');
    const uploadListElement = document.querySelector('#published-list');
    reviewListElement.appendChild(listItemElement);

    titleElement.value = '';
    categoryElement.value = '';
    contentElement.value = '';

    buttonEditElement.addEventListener('click', (e) => {
        titleElement.value = title;
        categoryElement.value = category;
        contentElement.value = content;

        listItemElement.remove();
    });

    buttonPostElement.addEventListener('click', (e) => {
        buttonEditElement.remove();
        buttonPostElement.remove();
        uploadListElement.appendChild(listItemElement);
    });
  });
}