function solve() {
   let checkboxes = document.querySelectorAll('input[type="checkbox"]');
   let modules = {};

   document.querySelector('button').addEventListener('click', () => {
      Array.from(checkboxes).forEach(box => {
         if (box.checked) {
            let currentModule = box.value;

            switch (currentModule) {
               case "js-fundamentals": modules["JS-Fundamentals"] = 170;
                  break;
               case "js-advanced": modules["JS-Advanced"] = 180;
                  break;
               case "js-applications": modules["JS-Applications"] = 190;
                  break;
               case "js-web": modules["JS-Web"] = 490;
                  break;
            }
         }
      });

      let modulesKeys = Object.keys(modules);

      if (modulesKeys.includes("JS-Advanced") && modulesKeys.includes("JS-Fundamentals")) {
         modules["JS-Advanced"] = modules["JS-Advanced"] * 0.90;
      }

      if (modulesKeys.includes("JS-Fundamentals") && modulesKeys.includes("JS-Advanced") && modulesKeys.includes("JS-Applications")) {
         modules["JS-Advanced"] = modules["JS-Advanced"] * 0.94;
         modules["JS-Fundamentals"] = modules["JS-Fundamentals"] * 0.94;
         modules["JS-Applications"] = modules["JS-Applications"] * 0.94;
      }

      if (modulesKeys.length === 4) {
         modules["HTML and CSS"] = 0;
      }

      let totalPrice = Object.values(modules).reduce((a, b) => a + b, 0);

      let isOnline = document.querySelectorAll('input[type="radio"]')[1].checked;

      if (isOnline) {
         totalPrice *= 0.94;
      }

      modulesKeys = Object.keys(modules)
      let modulesList = document.querySelectorAll('div[class="courseBody"]')[1].children[0];

      for (let moduleName of modulesKeys) {
         let li = document.createElement('li');
         li.textContent = moduleName;
         modulesList.appendChild(li);
      }

      totalPrice = Math.floor(totalPrice);
      document.querySelectorAll('div[class="courseFoot"]')[1].children[0].textContent = `Cost: ${totalPrice.toFixed(2)} BGN`;
   });
}

solve();