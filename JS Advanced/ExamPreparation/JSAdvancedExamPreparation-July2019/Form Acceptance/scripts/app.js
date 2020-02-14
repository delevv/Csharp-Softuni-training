function acceptance() {
	let inputs = document.querySelectorAll('input[type="text"]');
	let werehouse = document.getElementById('warehouse');

	document.querySelector('button').addEventListener('click', () => {
		let shippingCompany = inputs[0].value;
		let productName = inputs[1].value;
		let productQuantity = Number(inputs[2].value);
		let productScrape = Number(inputs[3].value);

		if (shippingCompany !== '' && productName !== '' && Number.isInteger(productQuantity) && Number.isInteger(productQuantity) && productQuantity - productScrape > 0) {
			let div = document.createElement('div');

			let p = document.createElement('p');
			p.textContent = `[${shippingCompany}] ${productName} - ${(productQuantity - productScrape)} pieces`;
			div.appendChild(p);

			let button = document.createElement('button');
			button.type = "button";
			button.textContent = 'Out of stock';
			div.appendChild(button);

			button.addEventListener('click', (e) => {
				e.target.parentElement.remove();
			});

			werehouse.appendChild(div);

			inputs[0].value = '';
			inputs[1].value = '';
			inputs[2].value = '';
			inputs[3].value = '';
		}
	});
}