function myFunction() {
  var dots = document.getElementById("dots");
  var moreText = document.getElementById("more");
  var btnText = document.getElementById("myBtn");

  if (dots.style.display === "none") {
    dots.style.display = "inline";
    btnText.innerHTML = "Read more";
    moreText.style.display = "none";
  } else {
    dots.style.display = "none";
    btnText.innerHTML = "Read less";
    moreText.style.display = "inline";
  }
}
$("#decreaseBtn-1").click(function () {
  let val = $("#quantityInOrder").val();
  if (val > 1) {
    $("#quantityInOrder").val(val - 1); 
  }
});
$("#increaseBtn-1").click(function () {
  let val = $("#quantityInOrder").val();
  $("#quantityInOrder").val(parseInt(val) + 1);
});
var pricetxt = $("#priceInOrder").text();
var price = parseFloat(pricetxt.replace("$", ""));
$("#sumPriceInOrder").text(pricetxt);
$(".adjustAmountBtn").click(function () {
  let sumPrice = price * $("#quantityInOrder").val();
  $("#sumPriceInOrder").text("$" + sumPrice);
});

$(".productInBasket").each(function(){
  $(this).find(".decreaseBtn-2").click(function(){
      let quantity = $(this).parent().find(".quantityInBasket").val();
      if (quantity > 1) {
          $(this).parent().find(".quantityInBasket").val(quantity - 1);
      }
  });
  $(this).find(".increaseBtn-2").click(function(){
      let quantity = $(this).parent().find(".quantityInBasket").val();
      $(this).parent().find(".quantityInBasket").val(parseInt(quantity) + 1);
      console.log(parseInt(quantity) + 1);
  });
});