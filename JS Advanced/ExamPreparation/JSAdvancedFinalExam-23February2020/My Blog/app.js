function solve() {
   let creator = document.getElementById('creator');
   let title = document.getElementById('title');
   let category = document.getElementById('category');
   let content = document.getElementById('content');
   let createButton = document.querySelector('button[class="btn create"]');
   
   let articles = document.querySelector('div[class="site-content"]').children[0].children[0];
   let archive = document.querySelector('section[class="archive-section"]').children[1];

   createButton.addEventListener('click', (c) => {
      c.preventDefault();

      let currArticle = document.createElement('article');
      currArticle.innerHTML = `<h1>${title.value}</h1>` +
         `<p> Category: <strong>${category.value}</strong> </p>` +
         `<p> Creator: <strong>${creator.value}</strong> </p>` +
         `<p>${content.value}</p>` +
         '<div class="buttons">' +
         '<button class="btn delete">Delete</button>' +
         '<button class="btn archive">Archive</button>' +
         '</div>';

      articles.appendChild(currArticle);

      currArticle.children[4].children[0].addEventListener('click', (d) => {
         d.target.parentElement.parentElement.remove();
      });

      currArticle.children[4].children[1].addEventListener('click', (a) => {
         let title = a.target.parentElement.parentElement.children[0].textContent;

         let li = document.createElement('li');
         li.textContent = title;

         archive.appendChild(li);
         orderList(archive);

         a.target.parentElement.parentElement.remove();
      });
   });

   function orderList(list) {
      let listItems = Array.from(list.children);
      list.innerHTML = '';

      listItems
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => list.appendChild(li));
   }
}