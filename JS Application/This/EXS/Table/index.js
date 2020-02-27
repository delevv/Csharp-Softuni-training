function solve() {
   let tbody = document.getElementsByTagName('tbody')[0];

   tbody.addEventListener('click', (e) => {
      let currRow = e.target.parentElement;

      if (currRow.style.backgroundColor === '') {
         Array.from(currRow.parentElement.children).forEach(r => r.style.backgroundColor = '');
         currRow.style.backgroundColor = "#413f5e";
      }
      else {
         currRow.style.backgroundColor = '';
      }
   });
}