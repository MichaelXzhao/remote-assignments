//Request 1: Click to Change Text
const welcomeMessage = document.querySelector(".title h1");

welcomeMessage.addEventListener("click", function () {
  welcomeMessage.textContent = "Have a Good Time!";
});

// Request 2: Click to Show More Content Boxes
const callToActionButton = document.querySelector(".btn button");
const contentBoxes = document.querySelector(".container2");

callToActionButton.addEventListener("click", () => {
  contentBoxes.style.display = "grid";
});
