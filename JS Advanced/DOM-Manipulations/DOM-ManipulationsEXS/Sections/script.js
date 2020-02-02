function create(words) {
   words.forEach(word => {
      let div = document.createElement("div");

      let paragraph = document.createElement("p");
      paragraph.textContent = word;
      paragraph.style.display = "none";

      div.appendChild(paragraph);

      div.addEventListener("click", function (e) {
         e.target.children[0].style.display = "block";
      });

      document.getElementById("content").appendChild(div);
   });
}