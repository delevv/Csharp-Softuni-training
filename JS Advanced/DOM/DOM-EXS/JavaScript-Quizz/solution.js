function solve() {
  let options = document.getElementsByClassName("answer-wrap");
  let trueAnswers = 0;
  let quizLevel = 0;
  const correctAnswers = ["onclick", "JSON.stringify()", "A programming API for HTML and XML documents"];

  for (let i = 0; i < options.length; i++) {
    options[i].addEventListener("click", function (e) {

      if (correctAnswers.includes(e.target.innerHTML)) {
        trueAnswers++;
      }

      let currentSection = document.querySelectorAll("section")[quizLevel];
      currentSection.style.display = "none";

      if (document.querySelectorAll("section")[++quizLevel] !== undefined) {
        let nextSection = document.querySelectorAll("section")[quizLevel];
        nextSection.style.display = "block";
      }
      else {
        document.getElementById("results").style.display = "block";

        let result = document.getElementsByClassName("results-inner")[0].children[0];

        if (trueAnswers != 3) {
          result.innerHTML =
            `You have ${trueAnswers} right answers`;
        }
        else {
          result.innerHTML =
            "You are recognized as top JavaScript fan!";
        }
      }
    });
  }
}
