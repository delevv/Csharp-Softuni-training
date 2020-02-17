function solve() {
   let buttons = document.getElementsByTagName('button');

   let rebuildButton = buttons[0];
   let joinButton = buttons[1];
   let attackButton = buttons[2];

   let map = document.getElementById("map");

   rebuildButton.addEventListener('click', (e) => {
      let kingdom = e.target.parentElement.querySelectorAll('input')[0];
      let king = e.target.parentElement.querySelectorAll('input')[1];

      let currentKingdom = map.querySelector(`div[id=${kingdom.value.toLowerCase()}]`);

      if (currentKingdom && currentKingdom.style.display === 'none' && king.value.length >= 2) {

         currentKingdom.innerHTML = `<h1>${kingdom.value.toUpperCase()}</h1>` +
            '<div class="castle"></div>' +
            `<h2>${king.value.toUpperCase()}</h2>` +
            '<fieldset>' +
            '<legend>Army</legend>' +
            '<p>TANKS - 0</p>' +
            '<p>FIGHTERS - 0</p>' +
            '<p>MAGES - 0</p>' +
            '<div class="armyOutput"></div>' +
            '</fieldset>' +
            '</div>';

         currentKingdom.style.display = 'inline-block';
      }
      else {
         king.value = '';
         kingdom.value = '';
      }
   });

   joinButton.addEventListener('click', (e) => {
      let characters = document.querySelectorAll('input[type="radio"]');
      let chType = Array.from(characters).filter(ch => ch.checked === true)[0];

      if (chType) {
         let inputs = chType.parentElement.parentElement.querySelectorAll('input[type="text"]');
         let chName = inputs[0].value;
         let chKingdom = inputs[1].value.toLowerCase();

         let currentKingdom = document.querySelector(`div[id="${chKingdom}"]`);

         if (chName.length >= 2 && currentKingdom && currentKingdom.style.display === 'inline-block') {
            let fieldsetInfo = currentKingdom.querySelector('fieldset').children;

            switch (chType.value) {
               case 'fighter': fieldsetInfo[2].textContent = `FIGHTERS - ${Number(fieldsetInfo[2].textContent.split(' ')[2]) + 1}`;
                  break;
               case 'mage': fieldsetInfo[3].textContent = `MAGES - ${Number(fieldsetInfo[3].textContent.split(' ')[2]) + 1}`;
                  break;
               case 'tank': fieldsetInfo[1].textContent = `TANKS - ${Number(fieldsetInfo[1].textContent.split(' ')[2]) + 1}`;
                  break;
            }

            fieldsetInfo[4].textContent += `${chName} `;
         }
         else {
            inputs[0].value = '';
            inputs[1].value = '';
         }
      }
   });

   attackButton.addEventListener('click', (e) => {
      let attacker = e.target.parentElement.children[1].value.toLowerCase();
      let defender = e.target.parentElement.children[2].value.toLowerCase();

      let attackKingdom = document.querySelector(`div[id="${attacker}"]`);
      let defenseKingdom = document.querySelector(`div[id="${defender}"]`);

      if (attackKingdom && attackKingdom.style.display === 'inline-block' && defenseKingdom && defenseKingdom.style.display === 'inline-block') {
         let attackKingdomPoints = getKingdomPoints(attackKingdom, 'attack');
         let defenseKingdomPoints = getKingdomPoints(defenseKingdom, 'defense');

         if (attackKingdomPoints > defenseKingdomPoints) {
            defenseKingdom.children[2].textContent = attackKingdom.children[2].textContent;
         }
      }
      else {
         e.target.parentElement.children[1].value = '';
         e.target.parentElement.children[2].value = '';
      }
   });

   function getKingdomPoints(kingdom, type) {
      let fieldSet = kingdom.children[3];

      let tanks = Number(fieldSet.children[1].textContent.split(' ')[2]);
      let fighters = Number(fieldSet.children[2].textContent.split(' ')[2]);
      let mages = Number(fieldSet.children[3].textContent.split(' ')[2]);

      if (type === 'attack') {
         return tanks * 20 + fighters * 50 + mages * 70;
      }
      else if (type === 'defense') {
         return tanks * 80 + fighters * 50 + mages * 30;
      }
   }
}

solve();