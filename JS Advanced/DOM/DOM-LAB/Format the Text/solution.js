function solve() {
  let input = document.getElementById("input")
    .textContent
    .split('.')
    .filter(x => x !== '');

  let outputP = document.getElementById("output");
  let sentences = '';

  for (let i = 0; i < input.length; i++) {
    sentences += input[i] + '.';

    if ((i + 1) % 3 === 0 || i === input.length - 1) {
      let paragraph = document.createElement("p");

      paragraph.textContent = sentences;
      sentences = '';

      outputP.appendChild(paragraph);
    }
  }
}