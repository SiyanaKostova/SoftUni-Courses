function extractText() {
    let nodeItem = Array.from(document.querySelectorAll(`li`));
    let text = nodeItem.map((li) => li.textContent).join(`\n`);
    document.querySelector(`textarea`).value = text;
}