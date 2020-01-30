function solve() {
  document.querySelector("button").addEventListener("click", () => {
    for (const furniture of JSON.parse(document.querySelector("textarea").value)) {

      let tableRow = document.createElement("tr");

      let img = document.createElement("td");
      let imgTag = document.createElement("img");
      imgTag.src = furniture.img;
      img.appendChild(imgTag);

      tableRow.appendChild(img);

      let furnitureValues = Object.values(furniture);

      for (let i = 0; i < furnitureValues.length; i++) {
        if (i !== 1) {
          let paragraph = document.createElement("p");
          let tableData = document.createElement("td");

          paragraph.innerHTML = furnitureValues[i];
          tableData.appendChild(paragraph);

          tableRow.appendChild(tableData);;
        }
      }

      let checkBox = document.createElement("input");
      checkBox.type = "checkbox";
      checkBox.disabled;
      let checkBoxTd = document.createElement("td");
      checkBoxTd.appendChild(checkBox);

      tableRow.appendChild(checkBoxTd);

      document.querySelector("tbody").appendChild(tableRow);
    }
  })

  document.querySelectorAll("button")[1].addEventListener("click", () => {
    let bag = [];

    let rows = document.querySelectorAll("tr");
    let checkBoxes = document.querySelectorAll("input");

    for (let i = 1; i < checkBoxes.length; i++) {
      if (checkBoxes[i].checked) {
        let tablesDatas = rows[i + 1].querySelectorAll("td");

        let obj = {};
        obj.name = tablesDatas[1].querySelector("p").innerHTML;
        obj.price = Number(tablesDatas[2].querySelector("p").innerHTML);
        obj.decFactor = Number(tablesDatas[3].querySelector("p").innerHTML);

        bag.push(obj);
      }
    }

    buy(bag);
  })

  function buy(bag) {
    let result = document.querySelectorAll("textarea");
    result = result[result.length - 1];

    let productNames = [];
    let totalDecFactor = 0;
    let totalPrice = 0;

    for (const obj of bag) {
      productNames.push(obj.name);
      totalDecFactor += obj.decFactor;
      totalPrice += obj.price;
    }

    result.innerHTML += `Bought furniture: ${productNames.join(', ')}\n`;
    result.innerHTML += `Total price: ${totalPrice.toFixed(2)}\n`;
    result.innerHTML += `Average decoration factor: ${totalDecFactor / Object.keys(bag).length}`
  }
}