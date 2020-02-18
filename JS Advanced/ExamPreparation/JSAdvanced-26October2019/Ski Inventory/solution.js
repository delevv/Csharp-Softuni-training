function solve() {
   let products = document.getElementById("products").children[1];
   let myProducts = document.getElementById("myProducts").children[1];

   let filterElements = document.querySelector('div[class="filter"]').children;
   let filterInput = filterElements[1];
   let filterButton = filterElements[2];

   let formElements = document.getElementById("add-new").children;
   let name = formElements[1];
   let quantity = formElements[2];
   let price = formElements[3];
   let addButton = formElements[4];

   let total = document.getElementsByTagName('h1')[1];

   addButton.addEventListener('click', (addEvent) => {
      addEvent.preventDefault();

      let li = document.createElement('li');
      li.innerHTML = `<span>${name.value}</span>` +
         `<strong>Available: ${quantity.value}</strong>` +
         '<div>' +
         `<strong>${Number(price.value).toFixed(2)}</strong>` +
         `<button>Add to Client's List</button>` +
         '</div>';

      li.children[2].children[1].addEventListener('click', (clientEvent) => {
         addEvent.preventDefault();

         let currLi = clientEvent.target.parentElement.parentElement;
         let price = Number(currLi.children[2].children[0].textContent);
         let currQuantity = Number(currLi.children[1].textContent.split(' ')[1]);

         let newLi = document.createElement('li');
         newLi.innerHTML = `${currLi.children[0].textContent}` + `<strong>${Number(price).toFixed(2)}</strong>`;

         if (currQuantity - 1 === 0) {
            currLi.remove();
         }
         else {
            currLi.children[1].textContent = `Available: ${currQuantity - 1}`;
         }
         myProducts.appendChild(newLi);

         total.textContent = `Total Price: ${(Number(total.textContent.split(' ')[2]) + price).toFixed(2)}`;
      });

      products.appendChild(li);
   })

   myProducts.parentElement.children[2].addEventListener('click', (buyEvent) => {
      total.textContent = `Total Price: 0.00`;
      buyEvent.target.parentElement.children[1].innerHTML = '';
   });

   filterButton.addEventListener('click', (filterEvent) => {
      filterEvent.preventDefault();

      Array.from(products.children).forEach(li => {
         if (!li.children[0].textContent.toLowerCase().includes(filterInput.value.toLowerCase())) {
            li.style.display = 'none';
         }
         else {
            li.style.display = 'block';
         }
      });
   });
}