function solve() {
   let tableRows = document.querySelectorAll("tbody > tr");

   document.getElementById("searchBtn").addEventListener("click", () => {
      let searchInput = document.getElementById("searchField");
      let searchStr = searchInput.value;
      searchInput.value = "";

      for (let row = 0; row < tableRows.length; row++) {
         let currRow = tableRows[row].querySelectorAll("td");
         tableRows[row].className = "";

         for (let col = 0; col < currRow.length; col++) {
            let currCell = currRow[col];

            if (currCell.innerHTML.includes(searchStr)) {
               tableRows[row].className = "select";
               break;
            }
         }
      }
   });
}