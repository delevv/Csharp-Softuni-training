function solve() {
  let text = document.getElementById('text').value;
  let convertType = document.getElementById('naming-convention').value;

  text = text.toLowerCase().split(' ').filter(w => w !== '');
  let result = '';

  for (let word of text) {
    if (convertType === 'Camel Case' || convertType === 'Pascal Case') {
      word = word.replace(word[0], word[0].toUpperCase());
      result += word;
    }
    else {
      result = 'Error!';
      break;
    }
  }
  if (convertType === 'Camel Case') {
    result = result.replace(result[0], result[0].toLowerCase());
  }

  document.getElementById('result').textContent = result;
}