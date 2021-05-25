$("body").on("click", ".removeButton", function (event) {
    event.preventDefault();
    let toHide = $(this);
    let send = $(this).data("id");
    $.post("/News/RemoveJS", { id: send }, function (data) {
        if (data == true) {
            toHide.parent().fadeOut();
        }
        else {
            alert("Wystąpił problem..");
        }
    });
});