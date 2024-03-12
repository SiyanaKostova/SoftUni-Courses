window.addEventListener("load", solve);

function solve() {
  const publishButton = document.querySelector('#form-btn');
  const previewSection = document.querySelector('#preview-list');
  const mainDivElement = document.querySelector('#main');
  let bodyElement = document.querySelector(".body");

  const firstNameElement = document.querySelector('#first-name');
  const lastNameElement = document.querySelector('#last-name');
  const ageElement = document.querySelector('#age');
  const titleElement = document.querySelector('#story-title');
  const genreElement = document.querySelector('#genre');
  const storyElement = document.querySelector('#story');


  publishButton.addEventListener('click', (e) => {

    const firstName = firstNameElement.value;
    const lastName = lastNameElement.value;
    const age = ageElement.value;
    const title = titleElement.value;
    const genre = genreElement.value;
    const story = storyElement.value;

    if(!firstName || !lastName || !age || !title || !story) {
      return;
    }

    const infoContainer = document.createElement('li');
    infoContainer.className = 'story-info';

    const articleContainer = document.createElement('article');

    const nameFormElement = document.createElement('h4');
    nameFormElement.textContent = `Name: ${firstName} ${lastName}`;

    const ageFormElement = document.createElement('p');
    ageFormElement.textContent = `Age: ${age}`;

    const titleFormElement = document.createElement('p');
    titleFormElement.textContent = `Title: ${title}`;

    const genreFormElement = document.createElement('p');
    genreFormElement.textContent = `Genre: ${genre}`;

    const storyFormElement = document.createElement('p');
    storyFormElement.textContent = story;

    articleContainer.appendChild(nameFormElement);
    articleContainer.appendChild(ageFormElement);
    articleContainer.appendChild(titleFormElement);
    articleContainer.appendChild(genreFormElement);
    articleContainer.appendChild(storyFormElement);

    const saveBtnFormElement = document.createElement('button');
    saveBtnFormElement.className = 'save-btn';
    saveBtnFormElement.textContent = 'Save Story';

    const editBtnFormElement = document.createElement('button');
    editBtnFormElement.className = 'edit-btn';
    editBtnFormElement.textContent = 'Edit Story';

    const deleteBtnFormElement = document.createElement('button');
    deleteBtnFormElement.className = 'delete-btn';
    deleteBtnFormElement.textContent = 'Delete Story';

    infoContainer.appendChild(articleContainer);
    infoContainer.appendChild(saveBtnFormElement);
    infoContainer.appendChild(editBtnFormElement);
    infoContainer.appendChild(deleteBtnFormElement);

    previewSection.appendChild(infoContainer);

    firstNameElement.value = '';
    lastNameElement.value = '';
    ageElement.value = '';
    titleElement.value = '';
    storyElement.value = '';

    publishButton.disabled = true;

    saveBtnFormElement.disabled = false;
    deleteBtnFormElement.disabled = false;
    editBtnFormElement.disabled = false;

    editBtnFormElement.addEventListener('click', (e) => {
      firstNameElement.value = firstName;
      lastNameElement.value = lastName;
      ageElement.value = age;
      titleElement.value = title;
      storyElement.value = story;
  
      publishButton.disabled = false;

      saveBtnFormElement.disabled = true;
      deleteBtnFormElement.disabled = true;
      editBtnFormElement.disabled = true;

      previewSection.removeChild(infoContainer);
    });

    saveBtnFormElement.addEventListener('click', (e) => {
      mainDivElement.remove();
      const messageStory = document.createElement('h1');
      messageStory.textContent = '"Your scary story is saved!';

      let mainDiv = document.createElement("div");
      mainDiv.setAttribute("id", "main");
      mainDiv.appendChild(messageStory);

      bodyElement.appendChild(mainDiv);
    });

    deleteBtnFormElement.addEventListener('click', (e) => {
      previewSection.removeChild(infoContainer);
      publishButton.disabled = false;
    })
  });
}
