
$(document).ready(function() {

    let fileinput = $(".newMediaItem");

    $("form").submit(function () {
        $('div.progress').fadeIn("slow");
        $('button').fadeOut();
    });

    fileinput.on("change", function (event) {
        let $output = $("#imgPreview");
        $output.fadeOut("slow").hide();
        let input = event.target;
        let reader = new FileReader();
        reader.onload = function () {


            $("input[type=submit]").before(""
            + "<div class=\"progress\">"
            + "<div class=\"progress-bar progress-bar-striped progress-bar-animated\" role=\"progressbar\" "
            + "aria-valuenow=\"0\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: \"0%\ id=\"progressView\"></div>"
            + "</div >");


            let dataURL = reader.result;
            //let output = document.getElementById("imgPreview");
            $output.attr("src", dataURL);
            $output.fadeIn("slow");
        };

        reader.onprogress = function (data) {
            if (data.lengthComputable) {
                var progress = parseInt(((data.loaded / data.total) * 100), 10);
                $('#progressView').css("width", progress + "%");
                $('#progressView').attr("aria-valuenow", progress + "%");
            }

            reader.onloadend = function () {
                $('#progressView').css("width", 100+"%");
                $('#progressView').attr("aria-valuenow", 100 + "%");
                $('div.progress').fadeOut("slow");
            }

        };

        reader.readAsDataURL(input.files[0]);
    });

});


