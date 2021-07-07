$("body").on("click", ".removeButton", function (event) {
    event.preventDefault();
    let toHide = $(this);
    let send = $(this).data("id");
    let type = $(this).data("type");

    if (type == "Head") {
        $.post("/PageSettings/RemoveJSHead", { id: send }, function (data) {
            if (data == true) {
                toHide.parent().fadeOut();
            }
            else {
                alert("Wystąpił problem..");
            }
        });
    }
    if (type == "Footer") {
        $.post("/PageSettings/RemoveJSFooter", { id: send }, function (data) {
            if (data == true) {
                toHide.parent().fadeOut();
            }
            else {
                alert("Wystąpił problem..");
            }
        });
    }
});