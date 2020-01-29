function solve() {
  let websites = document.querySelectorAll("a");
  let visits = document.querySelectorAll("p");

  for (let i = 0; i < websites.length; i++) {
    websites[i].addEventListener("click", () => {
      let currentVisits = +visits[i].innerHTML.split(' ')[1];
      visits[i].innerHTML = `visited ${++currentVisits} times`;
    })
  }
}