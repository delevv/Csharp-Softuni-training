function solve() {
   let buttons = document.getElementsByTagName('button');

   let rebuildButton = buttons[0];
   let joinButton = buttons[1];
   let attackButton = buttons[2];

   let map = document.getElementById("map");

   rebuildButton.addEventListener('click', (e) => {
      let kingdom = e.target.parentElement.querySelectorAll('input')[0].value.toLowerCase();
      let king = e.target.parentElement.querySelectorAll('input')[1].value.toLowerCase();

      let currentKingdom = map.querySelector(`div[id=${kingdom}]`);

      if (currentKingdom) {
         let h1 = document.createElement('h1');
         h1.textContent = kingdom.toUpperCase();
         currentKingdom.appendChild(h1);

         let div = document.createElement('div');
         div.classList.add('castle');
         currentKingdom.appendChild(div);

         let h2 = document.createElement('h2');
         h2.textContent = king.toUpperCase();
         currentKingdom.appendChild(h2);

         let fieldset = document.createElement('fieldset');

         let legend = document.createElement('legend');
         legend.textContent = 'Army';
         fieldset.appendChild(legend);

         let p1 = document.createElement('p');
         p1.textContent = 'TANKS - 0';
         fieldset.appendChild(p1);

         let p2 = document.createElement('p');
         p2.textContent = 'FIGHTERS - 0';
         fieldset.appendChild(p2);

         let p3 = document.createElement('p');
         p3.textContent = 'MAGES - 0';
         fieldset.appendChild(p3);

         let armyOutPutDiv = document.createElement('div');
         armyOutPutDiv.classList.add('armyOutput');
         fieldset.appendChild(armyOutPutDiv);

         currentKingdom.appendChild(fieldset);

         currentKingdom.style.display = 'inline-block';
         return false;
      }
   });

   let characters = document.querySelectorAll('input[type="radio"]');

   joinButton.addEventListener('click', (e) => {
      let chType = Array.from(characters).filter(ch => ch.checked === true)[0];

      if (chType) {
         let inputs = chType.parentElement.parentElement.querySelectorAll('input[type="text"]');
         let chName = inputs[0].value;
         let chKingdom = inputs[1].value.toLowerCase();

         let currentKingdom = document.querySelector(`div[id=${chKingdom}]`);

         if (chName.length >= 2 && currentKingdom && currentKingdom.style.display === 'inline-block') {
            let fieldset = currentKingdom.querySelector('fieldset');
            joinCharacter(chName, fieldset);
         }
      }
   });

   function joinCharacter(chName, fieldset) {

      switch (chName.value) {
         case 'fighter': fieldset[1].textContent = `FIGHTERS - ${Number(fieldset[1].split(' ')[2]) + 1}`;
      }
   }
}

solve();