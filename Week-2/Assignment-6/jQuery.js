// Request 1: Click to Change Text
$(".title h1").click(function () {
  $(this).text("Have a Good Time!");
});

// Request 2: Click to Show More Content Boxes
$(".btn button").click(function () {
  $(".container2").css("display", "grid");
});
