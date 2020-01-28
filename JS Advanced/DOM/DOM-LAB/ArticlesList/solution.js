function createArticle() {

	let title = document.getElementById("createTitle");
	let content = document.getElementById("createContent");

	if (title.value !== '' && content.value !== '') {
		let h3 = document.createElement("h3");
		h3.innerHTML = title.value;
		let p = document.createElement("p");
		p.innerHTML = content.value;

		title.value = '';
		content.value = '';

		let article = document.createElement("article");
		article.appendChild(h3);
		article.appendChild(p);

		let section = document.getElementById("articles");
		section.appendChild(article);
	}
}