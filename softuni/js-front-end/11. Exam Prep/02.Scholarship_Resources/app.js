window.addEventListener("load", solve);

function solve() {
  
  let studentNameElement = document.querySelector('#student');
  let studentUniversityElement = document.querySelector('#university');
  let scoreElement = document.querySelector('#score');

  let buttonNextElement = document.querySelector('#next-btn');
  
  const ulElement = document.querySelector('#preview-list');
  const ulAppliedElement = document.querySelector('#candidates-list');

  buttonNextElement.addEventListener('click', () => {

    let studentName = studentNameElement.value;
    let studentUniversity = studentUniversityElement.value;
    let studentScore = Number(scoreElement.value);

    if(!studentName || !studentUniversity || !studentScore) {
      return;
    }

    let liApplication = document.createElement('li');
    liApplication.className = 'application';

    let articleApplication = document.createElement('article');

    let name = document.createElement('h4');
    name.textContent = studentName;

    let uni = document.createElement('p');
    uni.textContent = `University: ${studentUniversity}`;

    let score = document.createElement('p');
    score.textContent = `Score: ${studentScore}`;

    articleApplication.appendChild(name);
    articleApplication.appendChild(uni);
    articleApplication.appendChild(score);

    let editButton = document.createElement('button');
    editButton.className = 'action-btn edit';
    editButton.textContent = 'edit';

    let applyButton = document.createElement('button');
    applyButton.className = 'action-btn apply';
    applyButton.textContent = 'apply';

    liApplication.appendChild(articleApplication);
    liApplication.appendChild(editButton);
    liApplication.appendChild(applyButton);

    ulElement.appendChild(liApplication);

    buttonNextElement.disabled = true;

    studentNameElement.value = '';
    studentUniversityElement.value = '';
    scoreElement.value = '';

    editButton.addEventListener('click', () => {
      studentNameElement.value = studentName;
      studentUniversityElement.value = studentUniversity;
      scoreElement.value = studentScore;

      ulElement.removeChild(liApplication);
      buttonNextElement.disabled = false;
    })

    applyButton.addEventListener('click', () => {
      liApplication.removeChild(editButton);
      liApplication.removeChild(applyButton);
      ulAppliedElement.appendChild(liApplication);

      buttonNextElement.disabled = false;
    })
  })
}
  