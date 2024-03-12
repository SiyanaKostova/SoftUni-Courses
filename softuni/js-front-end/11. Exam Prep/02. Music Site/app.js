window.addEventListener('load', solve);

function solve() {

    const addButtonElement = document.querySelector('#add-btn');

    addButtonElement.addEventListener('click', (e) => {

        e.preventDefault();

        const genreInputElement = document.querySelector('#genre');
        const nameSongInputElement = document.querySelector('#name');
        const authorInputElement = document.querySelector('#author');
        const dateInputElement = document.querySelector('#date');
    
        const genre = genreInputElement.value;
        const nameSong = nameSongInputElement.value;
        const author = authorInputElement.value;
        const date = dateInputElement.value;

        const totalLikesElement = document.querySelector("#total-likes > .likes > p");
        let totalLikes = 0;

        if(!genre || !nameSong || !author || !date) {
            return;
        }

        const divAllHitsContainer = document.querySelector('.all-hits-container');
        console.log(divAllHitsContainer);

        let imageToAdd = document.createElement('img');
        imageToAdd.src = "./static/img/img.png";

        const genreElement = document.createElement('h2');
        genreElement.textContent = `Genre: ${genre}`;

        const nameElement = document.createElement('h2');
        nameElement.textContent = `Name: ${nameSong}`;

        const authorElement = document.createElement('h2');
        authorElement.textContent = `Author: ${author}`;

        const dateElement = document.createElement('h3');
        dateElement.textContent = `Date: ${date}`;
   
        const saveButtonElement = document.createElement('button');
        saveButtonElement.className = 'save-btn';
        saveButtonElement.textContent = 'Save song';

        const likeButtonElement = document.createElement('button');
        likeButtonElement.className = 'like-btn';
        likeButtonElement.textContent = 'Like song';

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.className = 'delete-btn';
        deleteButtonElement.textContent = 'Delete';

        const divHitsInfoElement = document.createElement('div');
        divHitsInfoElement.className = 'hits-info';

        divHitsInfoElement.appendChild(imageToAdd);
        divHitsInfoElement.appendChild(genreElement);
        divHitsInfoElement.appendChild(nameElement);
        divHitsInfoElement.appendChild(authorElement);
        divHitsInfoElement.appendChild(dateElement);
        divHitsInfoElement.appendChild(saveButtonElement);
        divHitsInfoElement.appendChild(likeButtonElement);
        divHitsInfoElement.appendChild(deleteButtonElement);

        divAllHitsContainer.appendChild(divHitsInfoElement);

        genreInputElement.value = '';
        nameSongInputElement.value = '';
        authorInputElement.value = '';
        dateInputElement.value = '';

        likeButtonElement.addEventListener('click', (e) => {
            totalLikes++;
            totalLikesElement.textContent = `Total Likes: ${totalLikes}`;
            likeButtonElement.disabled = true;
        })

        saveButtonElement.addEventListener('click', (e) => {
            const savedSondsElement = document.querySelector('.saved-container');
            divHitsInfoElement.removeChild(likeButtonElement);
            divHitsInfoElement.removeChild(saveButtonElement);
            savedSondsElement.appendChild(divHitsInfoElement);
        });

        deleteButtonElement.addEventListener('click', (e) => {
            
            divHitsInfoElement.remove();
        })
    });
}