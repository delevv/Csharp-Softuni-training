function solve() {
  let text = document.getElementById('text').value;
  let result = document.getElementById('result');

  let output = '';

  for (let element of text.split(' ').filter(e => e !== '')) {
    if (Number(element)) {
      output += (String.fromCharCode(element));
    }
    else {
      let charToNum = [];

      for (let i = 0; i < element.length; i++) {
        charToNum.push(element[i].charCodeAt(0));
      }
      let p = document.createElement('p');
      p.innerHTML = charToNum.join(' ');
      result.appendChild(p);
    }
  }
  let p = document.createElement('p');
  p.innerHTML = output
  result.appendChild(p);
}