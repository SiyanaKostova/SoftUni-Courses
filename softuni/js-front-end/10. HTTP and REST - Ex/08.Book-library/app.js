function attachEvents() {
  const BASE_URL = "http://localhost:3030/jsonstore/collections/books/";
  const booksContainer = document.querySelector("tbody");
  const titleInput = document.querySelector('[name="title"]');
  const authorInput = document.querySelector('[name="author"]');
  const formTitle = document.querySelector("#form h3");

  let editBookId = null;

  document.getElementById("loadBooks").addEventListener("click", loadAllBooks);
  const submitBtn = document.querySelector("#form button");
  submitBtn.addEventListener("click", function () {
    if (submitBtn.textContent === "Submit") {
      submit();
    } else {
      save();
    }
  });

  function loadAllBooks() {
    fetch(`${BASE_URL}`)
      .then((res) => res.json())
      .then((books) => {
        booksContainer.innerHTML = "";
        for (const key in books) {
          let { author, title } = books[key];

          const tr = document.createElement("tr");
          const td1 = document.createElement("td");
          td1.textContent = title;
          const td2 = document.createElement("td");
          td2.textContent = author;
          const td3 = document.createElement("td");

          //Edit
          const editBtn = document.createElement("button");
          editBtn.addEventListener("click", () => {
            editBookId = key;
            formTitle.textContent = "Edit FORM";
            submitBtn.textContent = "Save";
            titleInput.value = title;
            authorInput.value = author;
          });
          editBtn.textContent = "Edit";
          editBtn.id = key;

          const deleteBtn = document.createElement("button");
          deleteBtn.addEventListener("click", deleteBook);
          deleteBtn.textContent = "Delete";
          deleteBtn.id = key;

          td3.appendChild(editBtn);
          td3.appendChild(deleteBtn);
          tr.appendChild(td1);
          tr.appendChild(td2);
          tr.appendChild(td3);
          booksContainer.appendChild(tr);
        }
      });
  }

  function submit() {
    let title = titleInput.value;
    let author = authorInput.value;

    if (title !== "" && author !== "") {
      fetch(BASE_URL, {
        method: "POST",
        body: JSON.stringify({ title, author }),
      })
        .then((res) => res.json())
        .then(() => {
          loadAllBooks();
          titleInput.value = "";
          authorInput.value = "";
        })
        .catch((err) => {
          console.log(err);
        });
    } else {
      titleInput.value = "";
      authorInput.value = "";
    }
  }

  function deleteBook() {
    const id = this.id;
    fetch(`${BASE_URL}${id}`, {
      method: "DELETE",
    })
      .then((res) => res.json())
      .then(loadAllBooks)
      .catch((err) => {
        console.log(err);
      });
  }

  function save() {
    let title = titleInput.value;
    let author = authorInput.value;

    fetch(`${BASE_URL}${editBookId}`, {
      method: "PUT",
      body: JSON.stringify({ title, author }),
    })
      .then((res) => res.json())
      .then(() => {
        loadAllBooks();
        formTitle.textContent = "FORM";
        submitBtn.textContent = "Submit";
        titleInput.value = "";
        authorInput.value = "";
      })
      .catch((err) => {
        console.log(err);
      });
  }
}
attachEvents();