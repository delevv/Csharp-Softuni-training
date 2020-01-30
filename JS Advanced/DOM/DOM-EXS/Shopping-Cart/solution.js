function solve() {
   let resultArea = document.querySelector("textarea");
   let bag = {};

   Array.from(document.querySelectorAll("button")).forEach(b => {
      if (b.className === "add-product") {
         b.addEventListener("click", function (e) {
            let currElement = e.target.parentElement;

            let price = Number(currElement.nextElementSibling.innerHTML);
            let name = currElement.previousElementSibling
               .getElementsByClassName("product-title")[0].innerHTML;

            if (!bag[name]) {
               bag[name] = 0;
            }
            bag[name] += price;

            resultArea.innerHTML += `Added ${name} for ${price.toFixed(2)} to the cart.\n`
         });
      }
      else if (b.className === "checkout") {
         b.addEventListener("click", () => {
            let products = Object.keys(bag).join(', ');
            let totalPrice = Object.values(bag).reduce((acc, curr) => acc + curr, 0);

            resultArea.innerHTML += `You bought ${products} for ${totalPrice.toFixed(2)}.`;

            Array.from(document.querySelectorAll("button")).forEach(b => b.disabled = true);
         });
      }
   });
}