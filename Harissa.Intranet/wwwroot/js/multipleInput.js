$(document).ready(function () {
    let $input = $("#filesInput");
    $input.on("change", function () {
        let name;
        for (let i = 0; i < $input[0].files.length; i++) {
            name = $input[0].files[i].name;
            $(this).parent().parent().append("<div class=\"alert alert-success text-truncate\" role=\"alert\">+ file added: " + name + "</div>");
        }
    });
});