function loadRepos() {
   fetch('https://api.github.com/users/testnakov/repos')
   .then((res) => res.json())
   .then((body) => {
      body.forEach((repo) => {
         const name = document.createElement('h2');
         name.textContent = repo.name;

         document.querySelector('body').appendChild(name);
      })
   })
   .catch((err) => console.log(err));
}