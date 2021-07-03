$(document).ready(function () {
    
    $(".filesInput").on("change", function (e) {
        let $input = $(this);
        let name;
        for (let i = 0; i < $input[0].files.length; i++) {
            name = $input[0].files[i].name;
            ////tooltips
            //<button type="button" class="btn btn-secondary" data-toggle="tooltip" data-placement="top" title="Tooltip on top">
            //    Tooltip on top
            //</button>

            //tooltips
            //<button type="button" class="btn btn-secondary" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Tooltip on top\">
            //    Tooltip on top
            //</button>


            //preView
            let reader = new FileReader();
            inputFile = e.target;
            reader.onload = function (event) {

                //$input.closest(".row").append("<div class=\"col-md-3 m-2 \"><img src=\"" + event.target.result + "\" class=\"img-fluid\" /></div>").hide().fadeIn("slow");
                $input.closest(".row").append("<div class=\"col-md-3 m-2 \"><img src=\"" + event.target.result + "\" class=\"img-fluid\" data-toggle=\"tooltip\" data-placement=\"top\" title=\""+ name  +"\" /></div>").hide().fadeIn("slow");
            }

            reader.readAsDataURL(inputFile.files[i]);
        }
    });



    //*******************************************************
    //$(document).ready(function () {
    //    let $input = $(".filesInput");
    //    $input.on("change", function (e) {
    //        $("#galleryCollection").hide();
    //        let name;
    //        for (let i = 0; i < $input[0].files.length; i++) {


    //            name = $input[0].files[i].name;
    //            $(this).parent().parent().append("<div class=\"alert alert-success text-truncate\" role=\"alert\">+ file added: " + name + "</div>");

    //            //preView
    //            var reader = new FileReader();
    //            inputFile = e.target;
    //            reader.onload = function (event) {

    //                $("#galleryCollection").append("<div class=\"col-md-3 m-2\"><img src=\"" + event.target.result + "\" class=\"img-fluid\" /></div>");

    //            }

    //            reader.readAsDataURL(inputFile.files[i]);

    //        }
    //        $("#galleryCollection").fadeIn("slow");
    //    });
    //*******************************************************

    //preView

    //".newMediaItem"
    // .imgPreview

    //$($.parseHTML('<img>')).attr('src', event.target.result).appendTo(placeToInsertImagePreview);

        //$(".imgPreview").addClass("bg-light");
        //let fileinput = $(".newMediaItem");


        //fileinput.on("change", function (event) {
        //    let $output = $(this).closest("form").find(".imgPreview");
        //    $output.fadeOut("slow").hide();
        //    let input = event.target;
        //    let reader = new FileReader();
        //    reader.onload = function () {

        //        $output.before(""
        //            + "<div class=\"progress\">"
        //            + "<div class=\"progress-bar progress-bar-striped progress-bar-animated\" role=\"progressbar\" "
        //            + "aria-valuenow=\"0\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: \"0%\ id=\"progressView\"></div>"
        //            + "</div >");

        //        let dataURL = reader.result;
        //        $output.attr("src", dataURL);
        //        $output.fadeIn("slow");
        //    };

        //    reader.onprogress = function (data) {
        //        if (data.lengthComputable) {
        //            var progress = parseInt(((data.loaded / data.total) * 100), 10);
        //            $('#progressView').css("width", progress + "%");
        //            $('#progressView').attr("aria-valuenow", progress + "%");
        //        }

        //        reader.onloadend = function () {
        //            $('#progressView').css("width", 100 + "%");
        //            $('#progressView').attr("aria-valuenow", 100 + "%");
        //            $('div.progress').fadeOut("slow");
        //        }

        //    };

        //    reader.readAsDataURL(input.files[0]);
        //});



});



