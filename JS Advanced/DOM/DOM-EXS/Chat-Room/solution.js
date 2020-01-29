function solve() {
   let sendButton = document.getElementById("send");

   sendButton.addEventListener("click", () => {
      let input = document.getElementById("chat_input");

      let div = document.createElement("div");
      div.className = "message my-message";

      div.innerHTML = input.value;
      input.value = '';

      document.getElementById("chat_messages").appendChild(div);
   });
}