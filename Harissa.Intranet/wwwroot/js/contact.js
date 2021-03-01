$(document).ready(function () {

    //Delete
    $("body").on("click", ".removeButton", function (event) {
        event.preventDefault();
        let send = $(this).data("id");
        $.post("/Contact/RemoveJS", { id: send }, function (data) {
            if (data == true) {
                contactList();
            }
            else {
                alert("Wystąpił problem..");
            }
        });
    });

    //Start edit
    $("body").on("click", ".editButton", function (event) {
        event.preventDefault();
        let dataFormButton = $(this);
        let toHide = $(".toHide");
        toHide.addClass("disabledElement").animate({ opacity: 0.2 }, 600);

        $(".editContact").animate({ opacity: 1 }, 600, function () {
            $(".idEdit").attr("value", dataFormButton.data("id"));
            $(".emailEdit").attr("value", dataFormButton.data("email"));
            $(".nameEdit").attr("value", dataFormButton.data("name"));
            $(".phoneEdit").attr("value", dataFormButton.data("phone"));

        }).removeClass("disabledElement");
    });


    function editOut() {
        $(".editContact").animate({ opacity: 0.2 }, 600, function () {
            $(".toHide").animate({ opacity: 1 }, 600).removeClass("disabledElement");
            $(this).addClass("disabledElement");
        });
        editReset()
    }

    //Show list
    function contactList() {
        $.getJSON("/Contact/ListJS", function (data) {
            let htmlToFor = "";
            for (var i = 0; i < data.length; i++) {

                htmlToFor += "" +
                    "<div class=\"col-sm-6  mt-2\">" +
                    "<div class=\"card toHide\">" +
                    "<div class=\"card-body\">" +
                    "<div class=\"row\">" +
                    "<div class=\"col-8 text-left\">" +
                    "<h5 class=\"card-title\">" + data[i].name + "</h5>" +
                    "</div>" +
                    "<div class=\"col-4 text-right\">" +
                    "<a href=\"Contact/DeleteSocialMedias\" class=\"removeButton\" data-id=\"" + data[i].contactID + "\"><i class=\"fas fa-trash mr-1\" style=\"font-size: 1rem; color:black;\"></i></a>" +
                    "<a href=\"#\" class=\"editButton\" data-id=\"" + data[i].contactID + "\" data-email=\"" + data[i].email + "\" data-name=\"" + data[i].name + "\" data-phone=\"" + data[i].phone + "\"><i class=\"fas fa-tools\" style=\"font-size: 1rem; color:black;\"></i></a>" +
                    "</div>" +
                    "</div>" +
                    "<div class=\"row\">" +
                    "<div class=\"col-12\">" +
                    "<p class=\"card-text\">" + data[i].email + "</p>" +
                    "<p class=\"card-text\">" + data[i].phone + "</p>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>" +
                    "</div>";

            }
            $("#contactList").html(htmlToFor);
        });
    }

    function createReset() {
        $("#formCreate")[0].reset();
    }

    function editReset() {
        $(".idEdit").attr("value", "");
        $(".emailEdit").attr("value", "");
        $(".nameEdit").attr("value", "");
        $(".phoneEdit").attr("value", "");
    }

    $("#cancelEdit").click(function (event) {
        //event.preventDefault();
        editOut();
    });

    //Edit
    $("#formEdit").submit(function (e) {
        e.preventDefault();
        if ($(".field-validation-error").length != 0)
            return;

        var formValues = $(this).serialize();
        $.post("/Contact/EditJS", formValues, function (data) {
            if (data == true) {
                editOut();
                contactList();
            }
            else {
                alert("Wystąpił problem..");
            }
        });
    });

    //Create
    $("#formCreate").submit(function (e) {
        e.preventDefault();
        if ($(".field-validation-error").length != 0)
            return;

        var formValues = $(this).serialize();
        $.post("/Contact/CreateJS", formValues, function (data) {
            if (data == true) {
                createReset();
                contactList();
            }
            else {
                alert("Wystąpił problem..");
            }
        });
    });

});