function solve() {
  const sentences = document.querySelector("#input").value.split(".");
  sentences.pop();

  const output = document.querySelector("#output");

  while (sentences.length > 0) {
    const p = document.createElement("p");
    output.appendChild(p);
    p.textContent = `${sentences.splice(0, 3).join(".")}.`;
  }
}