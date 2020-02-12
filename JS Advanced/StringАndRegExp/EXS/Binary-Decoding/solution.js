function solve() {
	let input = document.getElementById('input').value;

	let sum = Array.from(input).reduce((a, b) => a + Number(b), 0);

	while(sum > 9) {
		sum = Array.from(sum.toString()).reduce((a, b) => a + Number(b), 0);
	}

	input = input.slice(sum, input.length - sum);

	let resultArray = [];
	let curr = '';

	for (let i = 0; i < input.length; i++) {
		curr += input[i];
		if ((i + 1) % 8 === 0 || i === input.length - 1) {
			resultArray.push(parseInt(curr, 2));
			curr = '';
		}
	}

	let text = resultArray.map(x => String.fromCharCode(x)).filter(x => x.match(/[a-zA-Z ]+/)).join('');

	document.getElementById('resultOutput').textContent = text;
}