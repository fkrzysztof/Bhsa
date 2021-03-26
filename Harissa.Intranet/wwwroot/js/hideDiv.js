let hideEmenet = $(".hideElement");
hideEmenet.hide();
//$("#createButton").on("click", function (e) {
//    e.preventDefault();
//    $(".formCreate").slideDown();
//});
$(".hideButton").on("click", function () {
    hideEmenet.slideToggle();
});
