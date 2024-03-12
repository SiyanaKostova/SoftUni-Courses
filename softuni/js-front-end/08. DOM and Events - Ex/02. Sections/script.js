function create(words) {
   const content = document.getElementById('content');

   words.forEach(function (string) {
      const div = document.createElement('div');
      const paragraph = document.createElement('p');

      paragraph.textContent = string;
      paragraph.style.display = 'none';

      div.appendChild(paragraph);
      div.addEventListener('click', function () {
         paragraph.style.display = paragraph.style.display === 'none' ? 'block' : 'none';
      });

      content.appendChild(div);
   });
}