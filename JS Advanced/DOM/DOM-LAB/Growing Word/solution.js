function growingWord() {
  let paragraph = document.querySelectorAll("p")[2];

  if (paragraph.style.color === "" && paragraph.style.fontSize === "") {
    paragraph.style.fontSize = "2px";
    paragraph.style.color = "blue";
    return;
  } else if (paragraph.style.color === "red") {
    paragraph.style.color = "blue";
  } else if (paragraph.style.color === "blue") {
    paragraph.style.color = "green";
  } else if (paragraph.style.color === "green") {
    paragraph.style.color = "red";
  }
  paragraph.style.fontSize = parseInt(paragraph.style.fontSize) * 2 + 'px';
}