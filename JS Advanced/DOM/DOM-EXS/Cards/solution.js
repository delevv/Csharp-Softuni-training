function solve() {
   let resultDiv = document.getElementById("result").children;
   let history = document.getElementById("history");

   let playerOneCard = '';
   let playerTwoCard = '';

   document.getElementsByClassName("cards")[0].addEventListener("click", function (e) {
      let targetPlayer = e.target.parentElement.id;

      if (targetPlayer === 'player1Div') {
         playerOneCard = e.target;
         e.target.src = "images/whiteCard.jpg";
         resultDiv[0].innerHTML = e.target.name;
      }
      else if (targetPlayer == 'player2Div') {
         playerTwoCard = e.target;
         e.target.src = "images/whiteCard.jpg";
         resultDiv[2].innerHTML = e.target.name;
      }

      if (playerOneCard !== '' && playerTwoCard !== '') {
         if (+playerOneCard.name > +playerTwoCard.name) {
            playerOneCard.style.border = "2px solid green";
            playerTwoCard.style.border = "2px solid red";
         }
         else {
            playerTwoCard.style.border = "2px solid green";
            playerOneCard.style.border = "2px solid red";
         }

         resultDiv[0].innerHTML = '';
         resultDiv[2].innerHTML = '';

         history.innerHTML += `[${playerOneCard.name} vs ${playerTwoCard.name}] `;

         playerOneCard = '';
         playerTwoCard = '';
      }
   })
}