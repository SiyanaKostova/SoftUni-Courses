const tasksUrl = `http://localhost:3030/jsonstore/tasks/`;

const courseTypes = [
    'Long',
    'Medium',
    'Short'
];

const loadbuttonElement = document.querySelector('#load-course');
const addButtonElement = document.querySelector('#add-course');
const editCourseButtonElement = document.querySelector('#edit-course');

let currentEditCourseId = '';

const courseTitleElement = document.querySelector('#course-name');
const courseTypeElement = document.querySelector('#course-type');
const courseDescElement = document.querySelector('#description');
const courseTeacherElement = document.querySelector('#teacher-name');

const courseListElement = document.querySelector('#list');

loadbuttonElement.addEventListener('click', loadCourses);
addButtonElement.addEventListener('click', addCourse);
editCourseButtonElement.addEventListener('click', editCourse);

async function editCourse(e) {
    e.preventDefault();
    const title = courseTitleElement.value;
    const type = courseTypeElement.value;
    const description = courseDescElement.value;
    const teacher = courseTeacherElement.value;

    if (!courseTypes.includes(type)) {
        return;
    }

    const course = {
        title,
        type,
        description,
        teacher
    };

    await fetch(`${tasksUrl}${currentEditCourseId}`, {
        method: 'PUT',
        body: JSON.stringify(course)
    });

    courseTitleElement.value = '';
    courseTypeElement.value = '';
    courseDescElement.value = '';
    courseTeacherElement.value = '';

    editCourseButtonElement.disabled = true;
    addButtonElement.disabled = false;

    await loadCourses();
}

async function addCourse(e) {
    e.preventDefault(); 
    const title = courseTitleElement.value;
    const type = courseTypeElement.value;
    const description = courseDescElement.value;
    const teacher = courseTeacherElement.value;

    if (!courseTypes.includes(type)) {
        return;
    }

    const course = {
        _id: currentEditCourseId,
        title,
        type,
        description,
        teacher
    };

    await fetch(tasksUrl, {
        method: 'POST',
        body: JSON.stringify(course)
    });

    courseTitleElement.value = '';
    courseTypeElement.value = '';
    courseDescElement.value = '';
    courseTeacherElement.value = '';

    await loadCourses();
}

async function loadCourses() {
    courseListElement.innerHTML = '';
    const response = await fetch(tasksUrl);
    const data = await response.json();
    const courses = Object.values(data);

    for (const course of courses) {
        const courseElement = renderCourse(course);
        courseElement.setAttribute('data-course-id', course._id);
        courseListElement.appendChild(courseElement);
    }
}

function renderCourse(course) {

    const headingElement = document.createElement('h2');
    headingElement.textContent = course.title;

    const teacherElement = document.createElement('h3');
    teacherElement.textContent = course.teacher;

    const typeElement = document.createElement('h3');
    typeElement.textContent = course.type;

    const descriptionElement = document.createElement('h4');
    descriptionElement.textContent = course.description;

    const editButtonElement = document.createElement('button');
    editButtonElement.className = 'edit-btn';
    editButtonElement.textContent = 'Edit Course';

    const finishButtonElement = document.createElement('button');
    finishButtonElement.className = 'finish-btn';
    finishButtonElement.textContent = 'Finish Course';

    const courseContainerElement = document.createElement('div');
    courseContainerElement.className = 'container';

    courseContainerElement.appendChild(headingElement);
    courseContainerElement.appendChild(teacherElement);
    courseContainerElement.appendChild(typeElement);
    courseContainerElement.appendChild(descriptionElement);
    courseContainerElement.appendChild(editButtonElement);
    courseContainerElement.appendChild(finishButtonElement);

    editButtonElement.addEventListener('click', (e) => {
        courseTitleElement.value = course.title;
        courseTypeElement.value = course.type;
        courseDescElement.value = course.description;
        courseTeacherElement.value =  course.teacher;

        currentEditCourseId = courseContainerElement.getAttribute('data-course-id');

        courseContainerElement.remove();

        editCourseButtonElement.disabled = false;
        addButtonElement.disabled = true;

    }); 

    finishButtonElement.addEventListener('click', async(e) => {
        await fetch(`${tasksUrl}${course._id}`, {
            method: 'DELETE'
        });

        await loadCourses();
    });

    return courseContainerElement;
}

